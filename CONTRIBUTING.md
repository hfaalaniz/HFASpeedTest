# 🤝 Guía de Contribución

¡Gracias por tu interés en contribuir a HFASpeedTest Pro! Este documento proporciona guías y mejores prácticas para contribuir al proyecto.

## 📋 Tabla de Contenidos

- [Código de Conducta](#código-de-conducta)
- [¿Cómo puedo contribuir?](#cómo-puedo-contribuir)
- [Configuración del Entorno](#configuración-del-entorno)
- [Proceso de Desarrollo](#proceso-de-desarrollo)
- [Guías de Estilo](#guías-de-estilo)
- [Proceso de Pull Request](#proceso-de-pull-request)

## 📜 Código de Conducta

Este proyecto se adhiere al [Contributor Covenant Code of Conduct](CODE_OF_CONDUCT.md). Al participar, se espera que mantengas este código. Por favor reporta comportamientos inaceptables a [tu-email@example.com].

## 🎯 ¿Cómo puedo contribuir?

### 🐛 Reportar Bugs

Antes de crear un reporte de bug, verifica si el problema ya ha sido reportado. Si encuentras un issue cerrado similar, abre uno nuevo y referencia el anterior.

**¿Cómo escribir un buen reporte de bug?**

- **Usa un título claro y descriptivo**
- **Describe los pasos exactos para reproducir el problema**
- **Proporciona ejemplos específicos**
- **Describe el comportamiento observado y el esperado**
- **Incluye capturas de pantalla si es posible**
- **Menciona tu entorno**:
  - Versión de HFASpeedTest
  - Sistema Operativo y versión
  - Versión de .NET
  - Velocidad de conexión aproximada

**Plantilla:**

```markdown
**Descripción del Bug**
Descripción clara y concisa del bug.

**Para Reproducir**
Pasos para reproducir el comportamiento:
1. Ir a '...'
2. Click en '...'
3. Ver error

**Comportamiento Esperado**
Descripción de lo que esperabas que sucediera.

**Capturas de Pantalla**
Si aplica, agrega capturas de pantalla.

**Entorno**
 - OS: [ej. Windows 11]
 - Versión: [ej. 1.0.0]
 - .NET: [ej. 8.0.1]
```

### 💡 Sugerir Mejoras

Las sugerencias de mejoras se rastrean como [GitHub issues](../../issues). Crea un issue y proporciona la siguiente información:

- **Usa un título claro y descriptivo**
- **Proporciona una descripción detallada de la mejora sugerida**
- **Proporciona ejemplos específicos** para demostrar los pasos
- **Describe el comportamiento actual** y **explica cuál te gustaría ver**
- **Explica por qué esta mejora sería útil**

### 📝 Pull Requests

Las contribuciones de código se realizan a través de Pull Requests (PRs). Los PRs son la forma más efectiva de proponer cambios.

## 🛠️ Configuración del Entorno

### Prerrequisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

### Configuración Inicial

1. **Fork el repositorio**
   
   Click en el botón "Fork" en la parte superior derecha del repositorio.

2. **Clona tu fork**

   ```bash
   git clone https://github.com/TU-USUARIO/HFASpeedTest.git
   cd HFASpeedTest
   ```

3. **Agrega el repositorio original como upstream**

   ```bash
   git remote add upstream https://github.com/USUARIO-ORIGINAL/HFASpeedTest.git
   ```

4. **Instala las dependencias**

   ```bash
   dotnet restore
   ```

5. **Compila el proyecto**

   ```bash
   dotnet build
   ```

6. **Ejecuta la aplicación**

   ```bash
   dotnet run
   ```

## 🔄 Proceso de Desarrollo

### Crear una Rama

Siempre crea una nueva rama para tu trabajo:

```bash
# Para una nueva característica
git checkout -b feature/nombre-descriptivo

# Para un bug fix
git checkout -b fix/nombre-del-bug

# Para documentación
git checkout -b docs/nombre-del-cambio
```

### Hacer Cambios

1. **Escribe código limpio y legible**
2. **Sigue las guías de estilo** (ver abajo)
3. **Comenta código complejo**
4. **Actualiza documentación** si es necesario

### Commit de Cambios

Usa mensajes de commit descriptivos:

```bash
git add .
git commit -m "feat: Agrega servidor de backup para speed test"
```

**Convención de Commits:**

- `feat:` Nueva característica
- `fix:` Corrección de bug
- `docs:` Cambios en documentación
- `style:` Cambios de formato (sin cambio de código)
- `refactor:` Refactorización de código
- `test:` Agregar o modificar tests
- `chore:` Cambios en build o herramientas

**Ejemplos:**

```
feat: Agrega soporte para IPv6
fix: Corrige cálculo de jitter en latencia
docs: Actualiza README con nuevas instrucciones
refactor: Simplifica lógica de selección de servidor
test: Agrega tests para SpeedTestService
```

### Mantén tu Fork Actualizado

```bash
git fetch upstream
git checkout main
git merge upstream/main
```

## 🎨 Guías de Estilo

### Código C#

Sigue las [convenciones de código de C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions):

#### Nomenclatura

```csharp
// PascalCase para clases, métodos, propiedades
public class SpeedTestService { }
public void MeasureDownload() { }
public double DownloadMbps { get; set; }

// camelCase para variables locales y parámetros
var downloadSpeed = 0.0;
public void Calculate(int sampleCount) { }

// _camelCase para campos privados
private int _connectionTimeout;

// UPPER_CASE para constantes
private const int MAX_RETRY_COUNT = 3;
```

#### Formato

```csharp
// Llaves en nueva línea
public void Method()
{
    if (condition)
    {
        // código
    }
}

// Espacios alrededor de operadores
var result = value1 + value2;

// Una declaración por línea
var x = 1;
var y = 2;

// Usa var cuando el tipo es obvio
var name = "John";
var count = GetCount();
```

#### Comentarios

```csharp
/// <summary>
/// Mide la velocidad de descarga usando múltiples streams paralelos.
/// </summary>
/// <param name="ct">Token de cancelación</param>
/// <returns>Velocidad en Mbps</returns>
public async Task<double> MeasureDownloadAsync(CancellationToken ct)
{
    // Warm-up para establecer conexión
    await DoWarmupAsync();
    
    // TODO: Implementar retry logic
    // HACK: Solución temporal para servidores lentos
    // NOTE: Este método podría ser optimizado
}
```

### Documentación

- **README.md**: Información general del proyecto
- **Comentarios XML**: Para métodos públicos y clases
- **Comentarios inline**: Para lógica compleja
- **CHANGELOG.md**: Registro de cambios (cuando aplique)

### Commits

- **Mensajes en imperativo**: "Agrega" no "Agregado" o "Agregando"
- **Primera línea max 72 caracteres**
- **Líneas adicionales max 100 caracteres**
- **Referencia issues** cuando aplique: `fix: Corrige bug #123`

## 🔍 Proceso de Pull Request

### Antes de Crear el PR

1. **Asegúrate de que tu código compila**

   ```bash
   dotnet build
   ```

2. **Prueba tu código localmente**

   ```bash
   dotnet run
   ```

3. **Actualiza tu rama con main**

   ```bash
   git fetch upstream
   git rebase upstream/main
   ```

4. **Push a tu fork**

   ```bash
   git push origin nombre-de-tu-rama
   ```

### Crear el Pull Request

1. Ve a tu fork en GitHub
2. Click en "Compare & pull request"
3. Usa la plantilla de PR (se carga automáticamente)
4. Completa toda la información requerida

**Plantilla de PR:**

```markdown
## Descripción
Breve descripción de los cambios.

## Tipo de Cambio
- [ ] Bug fix (cambio que corrige un issue)
- [ ] Nueva característica (cambio que agrega funcionalidad)
- [ ] Breaking change (fix o feature que causa que funcionalidad existente no funcione como esperado)
- [ ] Cambio en documentación

## ¿Cómo se ha probado?
Describe las pruebas que realizaste.

## Checklist
- [ ] Mi código sigue las guías de estilo del proyecto
- [ ] He realizado una auto-revisión de mi código
- [ ] He comentado mi código, particularmente en áreas difíciles de entender
- [ ] He realizado los cambios correspondientes a la documentación
- [ ] Mis cambios no generan nuevas advertencias
- [ ] He probado que mi fix es efectivo o que mi feature funciona
```

### Después de Crear el PR

1. **Responde a comentarios** de manera oportuna
2. **Realiza cambios solicitados** en revisiones
3. **Mantén la conversación profesional** y constructiva
4. **Sé paciente** - las revisiones pueden tomar tiempo

### Criterios de Aprobación

Un PR será aprobado si:

- ✅ Pasa todas las verificaciones automáticas
- ✅ Sigue las guías de estilo
- ✅ Tiene una descripción clara
- ✅ Los cambios son relevantes y necesarios
- ✅ No introduce bugs nuevos
- ✅ La documentación está actualizada

## 🎓 Recursos Adicionales

- [Convenciones de Código C#](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Git Flow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)
- [Semantic Versioning](https://semver.org/)
- [Conventional Commits](https://www.conventionalcommits.org/)

## ❓ Preguntas

Si tienes preguntas, puedes:

- Crear un [GitHub Issue](../../issues)
- Iniciar una [GitHub Discussion](../../discussions)
- Contactar a los maintainers

---

¡Gracias por contribuir a HFASpeedTest Pro! 🎉
