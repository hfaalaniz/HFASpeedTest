# ⚡ HFASpeedTest Pro

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp)
![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows)
![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)

**Herramienta profesional para análisis completo de conexiones a Internet**

[Características](#-características) • [Instalación](#-instalación) • [Uso](#-uso) • [Capturas](#-capturas-de-pantalla) • [Documentación](#-documentación)

</div>

---

## 📋 Descripción

HFASpeedTest Pro es una aplicación de escritorio para Windows que permite realizar análisis completos y precisos de tu conexión a Internet. A diferencia de otras herramientas, ofrece mediciones en tiempo real con visualización detallada de métricas de red, incluyendo velocidad de descarga/subida, latencia, jitter, pérdida de paquetes y análisis de simetría de conexión.

### 🎯 ¿Por qué HFASpeedTest Pro?

- **🚀 Medición Precisa**: Utiliza múltiples streams paralelos para saturar completamente conexiones de alta velocidad (>100 Mbps)
- **📊 Visualización en Tiempo Real**: Observa cómo varían tus velocidades durante el test
- **🔍 Análisis Completo**: No solo mide velocidad, también detecta tipo de conexión, IPs, latencia y más
- **🎨 Interfaz Moderna**: UI oscura profesional con colores dinámicos según el estado
- **📈 Algoritmos Avanzados**: Usa trimmed mean para eliminar outliers y obtener resultados más precisos

---

## ✨ Características

### 🌐 Información de Conexión
- ✅ Detección automática del tipo de conexión (WiFi/Ethernet)
- ✅ Dirección IP local y pública
- ✅ Identificación de IP estática vs dinámica (DHCP)
- ✅ Dirección MAC del adaptador activo

### ⚡ Test de Velocidad
- ✅ **Descarga**: Múltiples streams paralelos (4 simultáneos)
- ✅ **Subida**: Medición con reporte de progreso en tiempo real
- ✅ Actualización cada 250ms durante el test
- ✅ Algoritmo Trimmed Mean para eliminar outliers
- ✅ Duración mínima de 8-10 segundos para precisión
- ✅ Warm-up automático para evitar latencia de conexión inicial

### 📊 Análisis de Simetría
- ✅ Cálculo de ratio upload/download
- ✅ Detección automática de conexión simétrica/asimétrica
- ✅ Visualización con barras proporcionales

### 🏓 Medición de Latencia
- ✅ Ping a servidor DNS de Google (8.8.8.8)
- ✅ 10 muestras para mayor precisión
- ✅ Métricas: Mínima, Máxima, Promedio, Jitter
- ✅ Detección de pérdida de paquetes
- ✅ Indicadores visuales de calidad (verde/amarillo/rojo)

### 🎨 Interfaz de Usuario
- ✅ Diseño moderno con tema oscuro
- ✅ Colores dinámicos durante test (verde descarga, azul subida)
- ✅ Emojis y mensajes descriptivos en status
- ✅ Barras de progreso visuales
- ✅ Fuentes grandes para fácil lectura
- ✅ Responsive a diferentes tamaños de pantalla

---

## 🖥️ Requisitos del Sistema

### Mínimos
- **OS**: Windows 10 (1809 o superior) / Windows 11
- **Framework**: .NET 8.0 Runtime
- **RAM**: 256 MB
- **Espacio**: 50 MB
- **Conexión**: Acceso a Internet

### Recomendados
- **OS**: Windows 11
- **Framework**: .NET 8.0 SDK (para desarrollo)
- **RAM**: 512 MB o más
- **Conexión**: Cualquier velocidad (optimizado para >100 Mbps)

---

## 📥 Instalación

### Opción 1: Desde Releases (Usuarios)

1. Ve a la sección [Releases](../../releases)
2. Descarga la última versión (`HFASpeedTest-v1.0.0.zip`)
3. Extrae el archivo ZIP
4. Ejecuta `HFASpeedTest.exe`

> **Nota**: Si Windows SmartScreen bloquea la app, click en "Más información" → "Ejecutar de todas formas"

### Opción 2: Compilar desde Código (Desarrolladores)

```bash
# Clonar el repositorio
git clone https://github.com/tu-usuario/HFASpeedTest.git
cd HFASpeedTest

# Restaurar dependencias
dotnet restore

# Compilar
dotnet build --configuration Release

# Ejecutar
dotnet run --configuration Release
```

### Opción 3: Visual Studio

1. Clona el repositorio
2. Abre `HFASpeedTest.sln` en Visual Studio 2022
3. Presiona `F5` para compilar y ejecutar

---

## 🚀 Uso

### Inicio Rápido

1. **Ejecuta** la aplicación
2. **Click** en el botón "Iniciar Test"
3. **Espera** 15-20 segundos mientras se realiza el test completo
4. **Revisa** los resultados en pantalla

### Interpretación de Resultados

#### 🌐 Información de Conexión
```
Tipo de Conexión: WiFi o Ethernet
IP Local: Tu IP en la red local (ej: 192.168.1.5)
IP Pública: Tu IP visible en Internet
Tipo de IP: Estática (fija) o Dinámica (asignada por DHCP)
Dirección MAC: Identificador único de tu adaptador
```

#### ⚡ Velocidad
```
DESCARGA: Velocidad de bajada en Mbps (megabits por segundo)
SUBIDA: Velocidad de subida en Mbps

Ejemplos de uso:
- 10-25 Mbps: Navegación básica, video SD
- 25-100 Mbps: Streaming HD, videollamadas
- 100-500 Mbps: Streaming 4K, gaming, hogar múltiple
- 500+ Mbps: Gaming competitivo, trabajo profesional
```

#### 📊 Simetría
```
Verde (85-115%): Conexión simétrica (fibra óptica típica)
Naranja (<85%): Asimétrica - upload menor (ADSL, cable)
Naranja (>115%): Asimétrica - upload mayor (poco común)
```

#### 🏓 Latencia
```
Latencia Mínima: Mejor tiempo de respuesta
Latencia Máxima: Peor tiempo de respuesta
Latencia Promedio: Media de todas las muestras
  • <50ms: Excelente (verde)
  • 50-100ms: Buena (amarillo)
  • >100ms: Regular (rojo)

Jitter: Variación de latencia (menor es mejor)
Pérdida de Paquetes: % de paquetes perdidos
  • 0%: Perfecto (verde)
  • 1-5%: Aceptable (amarillo)
  • >5%: Problemático (rojo)
```

---

## 📸 Capturas de Pantalla

### Interfaz Principal
```
┌─────────────────────────────────────────────────────────────────┐
│  ⚡ HFASpeedTest Pro                                            │
│  Analiza tu conexión a internet en segundos                     │
├─────────────────────────────────────────────────────────────────┤
│                    [ Iniciar Test ]                             │
│  ✓ Test completado exitosamente.                                │
├──────────────────────────────┬──────────────────────────────────┤
│ Información de Conexión      │  Simetría de Conexión            │
│ • Tipo de Conexión: WiFi     │  95.3%                           │
│ • IP Local: 192.168.1.5      │  ✓ Conexión simétrica            │
│ • IP Pública: 45.67.89.123   │  ████████████████████            │
│ • Tipo de IP: Dinámica (DHCP)│  ████████████████████            │
│ • Dirección MAC: AA:BB:CC... │                                  │
├──────────────────────────────┼──────────────────────────────────┤
│ Velocidad                    │  Latencia (Ping a 8.8.8.8)       │
│ ┌───────────┬───────────┐    │  • Latencia Mínima: 12 ms        │
│ │ ▼ DESCARGA│ ▲ SUBIDA  │    │  • Latencia Máxima: 18 ms        │
│ │   125.67  │   119.84  │    │  • Latencia Promedio: 14.5 ms    │
│ │   Mbps    │   Mbps    │    │  • Jitter: 2.3 ms                │
│ └───────────┴───────────┘    │  • Pérdida de Paquetes: 0%       │
└──────────────────────────────┴──────────────────────────────────┘
```

---

## 🏗️ Arquitectura

### Estructura del Proyecto

```
HFASpeedTest/
├── Services/
│   ├── SpeedTestService.cs      # Medición de velocidad
│   ├── LatencyService.cs        # Medición de latencia/ping
│   └── ConnectionInfoService.cs # Info de conexión
├── MainForm.cs                  # Lógica principal de UI
├── MainForm.Designer.cs         # Diseño de UI (generado)
├── Program.cs                   # Punto de entrada
└── HFASpeedTest.csproj         # Configuración del proyecto
```

### Clases Principales

#### `SpeedTestService`
- **Descarga**: 4 streams paralelos con warmup previo
- **Subida**: Stream único con progreso en tiempo real
- **Algoritmo**: Trimmed Mean (elimina 10% superior e inferior)
- **Servidores**: Tele2, OVH, OTE (fallback automático)

#### `LatencyService`
- **Protocolo**: ICMP Ping
- **Muestras**: 10 pings con timeout de 2000ms
- **Métricas**: Min, Max, Avg, Jitter, Packet Loss

#### `ConnectionInfoService`
- **Adaptadores**: Detección automática (prioridad: WiFi > Ethernet)
- **IPs**: Local (NetworkInterface) y Pública (API externa)
- **Tipo IP**: Detección vía comando `ipconfig /all`

---

## 🔧 Configuración Avanzada

### Modificar Servidores de Test

Edita `SpeedTestService.cs`:

```csharp
private static readonly (string Url, long ApproxBytes)[] DownloadSources = new[]
{
    ("https://tu-servidor.com/archivo.bin", 10L * 1024 * 1024),
    // Agrega más servidores aquí
};
```

### Ajustar Número de Streams Paralelos

```csharp
private const int ParallelStreams = 4; // Cambia según tu conexión
```

Recomendaciones:
- 1-2 streams: Conexiones <25 Mbps
- 4 streams: Conexiones 25-500 Mbps (predeterminado)
- 6-8 streams: Conexiones >500 Mbps

### Cambiar Duración Mínima del Test

```csharp
private const int MinTestDurationSeconds = 10; // Segundos
```

---

## 🐛 Solución de Problemas

### Los valores de descarga muestran 0,00

1. Verifica que tienes conexión a Internet
2. Revisa la ventana Output en Visual Studio (Debug)
3. Consulta `SOLUCION_VALORES_EN_CERO.md` en el repositorio
4. Prueba con diferentes servidores

### El test se queda colgado

1. Verifica tu firewall/antivirus
2. Asegúrate de tener permisos de red
3. Prueba con URLs HTTP en lugar de HTTPS
4. Revisa los logs de debug

### Los valores son inconsistentes

1. Cierra otras aplicaciones que usen Internet
2. Ejecuta el test varias veces
3. Prueba en diferentes horarios
4. Verifica con otras herramientas (speedtest.net)

### Error de compilación

1. Verifica que tienes .NET 8.0 SDK instalado
2. Ejecuta `dotnet restore`
3. Limpia y recompila: `dotnet clean && dotnet build`

---

## 📚 Documentación Adicional

- [MEJORAS_IMPLEMENTADAS.md](MEJORAS_IMPLEMENTADAS.md) - Changelog detallado
- [SOLUCION_VALORES_EN_CERO.md](SOLUCION_VALORES_EN_CERO.md) - Troubleshooting específico
- [API Reference](#) - Documentación de código (próximamente)

---

## 🤝 Contribuir

¡Las contribuciones son bienvenidas! Por favor:

1. **Fork** el proyecto
2. **Crea** una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. **Commit** tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. **Push** a la rama (`git push origin feature/AmazingFeature`)
5. **Abre** un Pull Request

### Guías de Contribución

- Usa nombres descriptivos para commits
- Sigue el estilo de código existente
- Agrega tests cuando sea posible
- Actualiza la documentación según corresponda

---

## 🗺️ Roadmap

### v1.1 (Próximo)
- [ ] Historial de tests con gráficos
- [ ] Exportación de resultados a CSV/JSON
- [ ] Modo de monitoreo continuo
- [ ] Notificaciones de cambios de velocidad

### v1.2 (Futuro)
- [ ] Soporte para múltiples servidores simultáneos
- [ ] Test de estabilidad (24 horas)
- [ ] Detección de throttling por ISP
- [ ] Reporte PDF automático

### v2.0 (Ideas)
- [ ] Versión web/multiplataforma
- [ ] API REST para integración
- [ ] Dashboard en tiempo real
- [ ] Machine Learning para predicción

---

## 📜 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

```
MIT License

Copyright (c) 2026 HFASpeedTest Contributors

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

---

## 👥 Autores

- **HFA** - *Desarrollo inicial* - [@tu-usuario](https://github.com/tu-usuario)

Ver también la lista de [contribuidores](../../contributors) que participaron en este proyecto.

---

## 🙏 Agradecimientos

- Speedtest.net por la inspiración
- Tele2, OVH y OTE por sus servidores de prueba públicos
- Comunidad .NET por las librerías y soporte
- Todos los contribuidores y testers

---

## 📞 Contacto y Soporte

- **Issues**: [GitHub Issues](../../issues)
- **Discusiones**: [GitHub Discussions](../../discussions)
- **Email**: tu-email@example.com
- **Twitter**: [@tu_handle](https://twitter.com/tu_handle)

---

## 🌟 Star History

Si este proyecto te resulta útil, ¡dale una estrella! ⭐

[![Star History Chart](https://api.star-history.com/svg?repos=tu-usuario/HFASpeedTest&type=Date)](https://star-history.com/#tu-usuario/HFASpeedTest&Date)

---

<div align="center">

**[⬆ Volver arriba](#-hfaspeedtest-pro)**

Hecho con ❤️ por la comunidad

</div>
