# Changelog

Todos los cambios notables a este proyecto serán documentados en este archivo.

El formato está basado en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/),
y este proyecto adhiere a [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Planeado
- Historial de tests con gráficos
- Exportación de resultados a CSV/JSON
- Modo de monitoreo continuo
- Test de estabilidad prolongado

## [1.0.0] - 2026-02-03

### 🎉 Lanzamiento Inicial

Primera versión estable de HFASpeedTest Pro.

### ✨ Características Agregadas

#### Información de Conexión
- Detección automática del tipo de conexión (WiFi/Ethernet)
- Obtención de IP local y pública
- Identificación de tipo de IP (Estática/Dinámica vía DHCP)
- Visualización de dirección MAC del adaptador activo

#### Test de Velocidad
- Medición de velocidad de descarga con 4 streams paralelos
- Medición de velocidad de subida con reporte de progreso
- Actualización en tiempo real cada 250ms
- Algoritmo Trimmed Mean para eliminar outliers
- Warm-up automático antes de la medición
- Duración mínima de 8-10 segundos para precisión
- Soporte para múltiples servidores con fallback automático

#### Análisis de Latencia
- Ping a servidor DNS de Google (8.8.8.8)
- 10 muestras para mayor precisión
- Métricas completas: Min, Max, Avg, Jitter
- Detección y reporte de pérdida de paquetes
- Indicadores visuales de calidad (verde/amarillo/rojo)

#### Análisis de Simetría
- Cálculo automático de ratio upload/download
- Detección de conexión simétrica/asimétrica
- Visualización con barras proporcionales
- Interpretación automática del tipo de conexión

#### Interfaz de Usuario
- Diseño moderno con tema oscuro profesional
- Colores dinámicos durante test (verde descarga, azul subida)
- Emojis y mensajes descriptivos en barra de estado
- Barras de progreso visuales
- Fuentes grandes para fácil lectura (36pt para velocidades)
- Layout responsive de 1210x600px
- 4 paneles principales organizados en grid

### 🔧 Mejoras Técnicas

#### Arquitectura
- Separación clara de responsabilidades (Services, UI)
- Patrón de eventos para actualización en tiempo real
- Manejo robusto de errores y timeouts
- Soporte para cancelación de tests
- Threading seguro con InvokeRequired

#### Rendimiento
- HttpClient configurado con MaxConnectionsPerServer optimizado
- Buffer de 64KB para lectura/escritura eficiente
- Streams paralelos para saturar conexiones rápidas
- Warm-up para eliminar latencia de handshake inicial

#### Servidores de Test
- Tele2 Speedtest (principal)
- OVH Proof Files (backup)
- OTE Speedtest (backup)
- httpbin.org para upload
- httpbingo.org para upload (backup)

### 📝 Documentación
- README.md completo con guías de uso
- CONTRIBUTING.md para colaboradores
- LICENSE (MIT)
- Documentación inline con XML comments
- Debug logging extensivo

### 🐛 Correcciones

#### Visualización
- Corregidos controles superpuestos en MainForm.Designer.cs
- Espaciado correcto entre elementos (30px vertical)
- Labels de latencia en posiciones correctas
- Tamaños consistentes de fuentes y controles

#### Funcionalidad
- Eventos de progreso correctamente suscritos
- Actualización de UI en tiempo real funcionando
- Colores dinámicos aplicándose correctamente
- Barras de simetría actualizándose proporcionalmente

#### Estabilidad
- Manejo de excepciones en eventos de progreso
- Try-catch en Invoke para prevenir crashes
- Limpieza correcta de recursos (CancellationTokenSource)
- Cancelación segura al cerrar formulario

### 🔒 Seguridad
- No se almacenan credenciales
- Solo se conecta a servidores públicos conocidos
- Timeout de 120 segundos para prevenir hangs
- AllowAutoRedirect limitado a HTTPS

### ⚡ Rendimiento

#### Benchmarks Iniciales
- Conexiones 25-100 Mbps: ±2% precisión
- Conexiones 100-500 Mbps: ±5% precisión
- Conexiones >500 Mbps: ±10% precisión
- Latencia: ±1ms precisión
- Tiempo de test completo: 15-25 segundos

### 📦 Dependencias
- .NET 8.0
- System.Net.Http (incluido en .NET)
- System.Net.NetworkInformation (incluido en .NET)
- Windows Forms (incluido en .NET)

### 🌐 Compatibilidad
- Windows 10 (1809+)
- Windows 11
- Requiere conexión a Internet
- Funciona detrás de firewalls (puertos estándar HTTP/HTTPS)

### 📊 Estadísticas del Proyecto
- Líneas de código: ~1,200
- Archivos fuente: 6
- Clases principales: 3 (SpeedTestService, LatencyService, ConnectionInfoService)
- Controles de UI: 45+
- Idioma: C# 12.0

---

## [0.9.0] - 2026-01-15 (Beta)

### ✨ Agregado
- Implementación inicial de speed test
- UI básica con WinForms
- Test de latencia simple

### 🐛 Corregido
- Crashes al cancelar test
- Valores de descarga mostrando 0.00

### ⚠️ Conocido
- UI necesita mejoras visuales
- Falta análisis de simetría

---

## [0.5.0] - 2026-01-01 (Alpha)

### ✨ Agregado
- Prueba de concepto inicial
- Obtención de información de red básica
- Ventana de formulario simple

---

## Formato de Versionado

### [MAJOR.MINOR.PATCH]

- **MAJOR**: Cambios incompatibles de API
- **MINOR**: Funcionalidad agregada de manera compatible
- **PATCH**: Correcciones de bugs compatibles

### Tipos de Cambios

- **✨ Agregado (Added)**: Nuevas características
- **🔧 Cambiado (Changed)**: Cambios en funcionalidad existente
- **❌ Deprecado (Deprecated)**: Características que serán removidas
- **🗑️ Removido (Removed)**: Características removidas
- **🐛 Corregido (Fixed)**: Corrección de bugs
- **🔒 Seguridad (Security)**: Correcciones de seguridad

[Unreleased]: https://github.com/tu-usuario/HFASpeedTest/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/tu-usuario/HFASpeedTest/releases/tag/v1.0.0
[0.9.0]: https://github.com/tu-usuario/HFASpeedTest/releases/tag/v0.9.0
[0.5.0]: https://github.com/tu-usuario/HFASpeedTest/releases/tag/v0.5.0
