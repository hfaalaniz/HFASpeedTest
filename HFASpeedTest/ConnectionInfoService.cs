using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Linq;

namespace HFASpeedTest.Services
{
    public class ConnectionInfo
    {
        public string PublicIP { get; set; }
        public string LocalIP { get; set; }
        public string ConnectionType { get; set; }   // WiFi / Ethernet / Unknown
        public string IPType { get; set; }            // Estática / Dinámica
        public string AdapterName { get; set; }
        public string MacAddress { get; set; }
    }

    public static class ConnectionInfoService
    {
        private static readonly string[] PublicIPApis = new[]
        {
            "https://api.ipify.org",
            "https://ipecho.net/plain",
            "https://myexternalip.com/raw"
        };

        public static async Task<ConnectionInfo> GetConnectionInfoAsync()
        {
            var info = new ConnectionInfo();

            // --- IP Pública ---
            info.PublicIP = await GetPublicIPAsync();

            // --- Adaptadores de red activos ---
            var adapters = NetworkInterface.GetAllNetworkInterfaces()
                .Where(a => a.OperationalStatus == OperationalStatus.Up
                         && a.NetworkInterfaceType != NetworkInterfaceType.Loopback
                         && a.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                .ToArray();

            // Prioridad: WiFi > Ethernet > otro
            var wifi     = adapters.FirstOrDefault(a => a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211);
            var ethernet = adapters.FirstOrDefault(a => a.NetworkInterfaceType == NetworkInterfaceType.Ethernet);
            var active   = wifi ?? ethernet ?? adapters.FirstOrDefault();

            if (active != null)
            {
                info.AdapterName    = active.Description;
                info.MacAddress     = active.GetPhysicalAddress().ToString();
                info.ConnectionType = active.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
                                        ? "WiFi"
                                        : active.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                                            ? "Ethernet"
                                            : active.NetworkInterfaceType.ToString();

                // --- IP Local (primera IPv4 no loopback del adaptador activo) ---
                var unicast = active.GetIPProperties().UnicastAddresses
                    .FirstOrDefault(u => u.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

                info.LocalIP = unicast?.Address.ToString() ?? "N/A";

                // --- Estática / Dinámica ---
                // Si la IP local es DHCP (no es rango privado estático configurado manualmente)
                // Heurística: verificamos si existe lease DHCP activo en el adaptador.
                // .NET no expone directamente esto, así que usamos la heurística de rango:
                //   - Si la IP empieza en 169.254.x.x  -> Link-Local (sin red)
                //   - Otro rango privado -> verificamos si DHCP está habilitado chequeando
                //     la configuración de adaptador via "netsh" (o usamos DhcpEnabled heurística)
                info.IPType = DetermineIPType(info.LocalIP, active);
            }
            else
            {
                info.ConnectionType = "Sin conexión";
                info.LocalIP        = "N/A";
                info.IPType         = "N/A";
            }

            return info;
        }

        private static string DetermineIPType(string localIP, NetworkInterface adapter)
        {
            if (localIP == "N/A") return "N/A";

            // Link-local = sin asignación correcta
            if (localIP.StartsWith("169.254.")) return "Link-Local (sin red)";

            // Usamos el método más fiable disponible en Windows:
            // Checar si el adaptador tiene configuración DHCP via netsh
            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName        = "netsh",
                    Arguments       = $"interface show interface name=\"{adapter.Name}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute        = false,
                    CreateNoWindow         = true
                };

                // Intentamos también con la línea de comandos alternativa
                // pero el método más confiable es revisar ipconfig
                var psi2 = new System.Diagnostics.ProcessStartInfo
                {
                    FileName        = "ipconfig",
                    Arguments       = "/all",
                    RedirectStandardOutput = true,
                    UseShellExecute        = false,
                    CreateNoWindow         = true
                };

                using var proc = System.Diagnostics.Process.Start(psi2);
                string output = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

                // Buscamos el bloque del adaptador y verificamos "DHCP habilitado"
                // El formato varía por idioma del SO, buscamos patrones comunes
                if (output.Contains("DHCP habilitado") || output.Contains("DHCP enabled"))
                {
                    // Verificar si DHCP está habilitado ("Sí"/"Yes") cerca del adaptador
                    var lines = output.Split('\n');
                    bool foundAdapter = false;
                    foreach (var line in lines)
                    {
                        if (line.Contains(adapter.Description) || line.Contains(adapter.Name))
                            foundAdapter = true;

                        if (foundAdapter && (line.Contains("DHCP habilitado") || line.Contains("DHCP enabled")))
                        {
                            if (line.Contains("Sí") || line.Contains("Yes") || line.Contains("sí") || line.Contains("yes"))
                                return "Dinámica (DHCP)";
                            else
                                return "Estática";
                        }
                    }
                }
            }
            catch { /* fallback heurística */ }

            // Fallback: IPs en rangos privados sin confirmación DHCP -> asumimos dinámica
            return "Dinámica (estimado)";
        }

        private static async Task<string> GetPublicIPAsync()
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };

            foreach (var url in PublicIPApis)
            {
                try
                {
                    var ip = await http.GetStringAsync(url);
                    if (IPAddress.TryParse(ip.Trim(), out _))
                        return ip.Trim();
                }
                catch { continue; }
            }
            return "No disponible";
        }
    }
}
