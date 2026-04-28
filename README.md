# TaskFlow

## Descripción

TaskFlow es una aplicación de consola desarrollada en C# que permite gestionar tareas de manera eficiente. Los usuarios pueden crear, listar, actualizar el estado, cambiar el responsable y eliminar tareas. La aplicación utiliza un modelo de datos simple con estados como Pendiente, En Progreso y Completada.

## Características


👥Integrantes:
   Julian Quispe
   Facundo Oliva
   Santiago Martinez
   Facundo Zambrano
   Valentin Marchetti
   Mateo Barceló

- **Crear tareas**: Agregar nuevas tareas con título, descripción y responsable.
- **Listar tareas**: Ver todas las tareas o filtrar por estado.
- **Actualizar estado**: Cambiar el estado de una tarea existente.
- **Cambiar responsable**: Asignar un nuevo responsable a una tarea.
- **Eliminar tareas**: Remover tareas del sistema.
- **Persistencia**: Las tareas se guardan en archivos para mantener los datos entre sesiones.


## Requisitos previos

- **.NET SDK**: Versión 6.0 o superior. Puedes descargarlo desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download).
- **Visual Studio**: Recomendado para desarrollo, versión 2019 o superior con soporte para C#.
- **Git**: Para clonar el repositorio.

## Instalación

1. **Clona el repositorio**:
   ```bash
   git clone https://github.com/tu-usuario/taskflow.git
   cd taskflow
   ```

2. **Abre el proyecto**:
   - Abre Visual Studio.
   - Selecciona "Abrir proyecto o solución" y navega a la carpeta `src/TaskFlow`.
   - Si no hay un archivo `.csproj`, crea uno manualmente o usa `dotnet new console` en la carpeta `src/TaskFlow` para inicializar el proyecto.

## Construcción y ejecución

### Usando Visual Studio
1. Abre el proyecto en Visual Studio.
2. Presiona `F5` para ejecutar en modo depuración o `Ctrl+F5` para ejecutar sin depuración.

### Usando la línea de comandos
1. Navega a la carpeta del proyecto:
   ```bash
   cd src/TaskFlow
   ```
2. Restaura dependencias (si hay un `.csproj`):
   ```bash
   dotnet restore
   ```
3. Construye el proyecto:
   ```bash
   dotnet build
   ```
4. Ejecuta la aplicación:
   ```bash
   dotnet run
   ```

La aplicación mostrará un menú interactivo en la consola para gestionar las tareas.

## Pruebas

El proyecto incluye pruebas unitarias para el servicio de tareas.

1. Navega a la carpeta de pruebas:
   ```bash
   cd tests/TaskFlow.Tests
   ```
2. Ejecuta las pruebas:
   ```bash
   dotnet test
   ```

Asegúrate de que todas las pruebas pasen antes de realizar cambios.

## Estructura del proyecto

```
taskflow/
├── src/
│   └── TaskFlow/
│       ├── Program.cs              # Punto de entrada de la aplicación
│       ├── Models/
│       │   └── TaskItem.cs         # Modelo de datos para tareas
│       ├── Services/
│       │   └── TaskService.cs      # Lógica de negocio para tareas
│       └── Utils/
│           ├── ConsoleHelper.cs    # Utilidades para entrada/salida en consola
│           └── FileManager.cs      # Utilidades para manejo de archivos
├── tests/
│   └── TaskFlow.Tests/
│       └── TaskServiceTests.cs     # Pruebas unitarias
├── docs/
│   └── Arquitectura.md             # Documentación de arquitectura
├── CHANGELOG.md                    # Registro de cambios
└── README.md                       # Este archivo
```

## Tecnologías utilizadas

- **C#**: Lenguaje de programación principal.
- **.NET**: Framework para desarrollo.
- **Visual Studio**: Entorno de desarrollo integrado.
- **Git y GitHub**: Control de versiones y repositorio.

## Contribuyentes

- Julian Quispe
- Facundo Oliva
- Santiago Martinez
- Facundo Zambrano
- Valentin Marchetti
- Mateo Barceló