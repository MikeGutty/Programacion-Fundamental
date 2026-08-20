# Guía práctica: Configuración del entorno de desarrollo en C# con .NET

**Asignatura:** Programación  
**Carrera:** Ingeniería de Sistemas

---

## 1. Objetivo

Al finalizar esta guía, el estudiante será capaz de:

- Instalar el **.NET SDK** en su equipo.
- Instalar **Visual Studio Code** como entorno de desarrollo.
- Instalar y configurar la extensión **C# Dev Kit**.
- Crear un proyecto de C# utilizando la **Command Palette** de Visual Studio Code.
- Comprender la estructura básica de un proyecto .NET.
- Ejecutar un programa de C# desde Visual Studio Code y desde la terminal.

> **Importante:** Esta guía está orientada al desarrollo de aplicaciones de consola en C# y puede realizarse en Windows, macOS o Linux.

---

## 2. Herramientas necesarias

Para desarrollar nuestro primer programa en C# utilizaremos:

1. **.NET SDK**
2. **Visual Studio Code**
3. **C# Dev Kit**
4. Una terminal de comandos

El **.NET SDK** incluye las herramientas necesarias para crear, compilar y ejecutar aplicaciones .NET, incluyendo la herramienta de línea de comandos `dotnet`. [Documentación oficial de .NET](https://learn.microsoft.com/dotnet/core/sdk)

---

# 3. Instalación de .NET SDK

## Paso 1. Descargar .NET SDK

Ingresa al sitio oficial de .NET:

**<https://dotnet.microsoft.com/download>**

Selecciona la versión del **SDK** recomendada para tu sistema operativo.

> **No confundas SDK con Runtime.** Para desarrollar programas necesitamos el **SDK**, ya que contiene las herramientas necesarias para crear y compilar proyectos.

### Windows

Descarga el instalador correspondiente a Windows y sigue las instrucciones del instalador.

### macOS

Descarga el instalador correspondiente a tu arquitectura:

- **Arm64:** para equipos Mac con Apple Silicon.
- **x64:** para equipos Mac con procesadores Intel.

### Linux

Selecciona la distribución que utilizas y sigue las instrucciones oficiales de instalación.

Puedes consultar las instrucciones oficiales para los diferentes sistemas operativos:

<https://learn.microsoft.com/dotnet/core/install/>

---

# 4. Verificar la instalación de .NET

Una vez finalizada la instalación, abre una terminal.

Ejecuta:

```bash
dotnet --version
```

Si la instalación fue correcta, aparecerá el número de versión del SDK instalado.

También puedes ejecutar:

```bash
dotnet --info
```

Este comando muestra información adicional sobre el entorno .NET instalado.

### Resultado esperado

```text
10.0.xxx
```

> La versión exacta puede ser diferente dependiendo de la versión del SDK instalada.

### Si aparece un error

Si el sistema indica que el comando `dotnet` no existe o no se encuentra, verifica que hayas instalado el **SDK** y reinicia la terminal. También puedes consultar la documentación oficial de instalación de .NET.

---

# 5. Instalación de Visual Studio Code

Visual Studio Code será el editor que utilizaremos para escribir nuestro código C#.

## Paso 1. Descargar Visual Studio Code

Ingresa al sitio oficial:

**<https://code.visualstudio.com/>**

Descarga la versión correspondiente a tu sistema operativo.

## Paso 2. Instalar Visual Studio Code

Ejecuta el instalador y completa los pasos indicados.

Una vez instalado, abre **Visual Studio Code**.

---

# 6. Instalar la extensión C# Dev Kit

La extensión **C# Dev Kit**, publicada por Microsoft, proporciona herramientas para trabajar con proyectos C# y .NET dentro de Visual Studio Code. Entre otras funciones, permite trabajar con proyectos, IntelliSense, compilación y depuración.

## Paso 1. Abrir Extensions

En Visual Studio Code:

- Windows/Linux: `Ctrl + Shift + X`
- macOS: `Cmd + Shift + X`

También puedes seleccionar el icono de **Extensions** en la barra lateral.

## Paso 2. Buscar C# Dev Kit

En el buscador escribe:

```text
C# Dev Kit
```

Selecciona la extensión publicada por **Microsoft**.

## Paso 3. Instalar

Haz clic en:

**Install**

Después de la instalación, Visual Studio Code puede mostrar un recorrido de introducción de C# Dev Kit.

> **Nota:** C# Dev Kit puede utilizar un SDK de .NET que ya esté instalado en el equipo. En algunos casos también puede ayudarte a instalar el SDK si todavía no está disponible.

---

# 7. Comprobar que C# Dev Kit está funcionando

Después de instalar la extensión:

1. Abre Visual Studio Code.
2. Abre la **Command Palette**.
3. Escribe:

```text
.NET
```

Deberían aparecer diferentes comandos relacionados con .NET, entre ellos:

```text
.NET: New Project
```

Esto indica que Visual Studio Code reconoce las herramientas de desarrollo de .NET.

---

# 8. Crear nuestro primer proyecto de C #

Ahora crearemos una aplicación de consola utilizando la **Command Palette**.

## Paso 1. Abrir la Command Palette

Utiliza:

- Windows/Linux: `Ctrl + Shift + P`
- macOS: `Cmd + Shift + P`

También puedes abrirla desde:

**View → Command Palette**

## Paso 2. Buscar el comando para crear un proyecto

Escribe:

```text
.NET: New Project
```

Selecciona:

**.NET: New Project...**

Visual Studio Code mostrará los tipos de proyectos disponibles.

## Paso 3. Seleccionar el tipo de proyecto

Selecciona:

**Console App**

Una aplicación de consola es una aplicación que permite trabajar principalmente mediante la terminal y resulta adecuada para comenzar a aprender los fundamentos de C#.

## Paso 4. Seleccionar la ubicación

Selecciona la carpeta donde deseas guardar tus proyectos.

Por ejemplo:

```text
Documentos/Programacion
```

## Paso 5. Asignar un nombre

Cuando se solicite el nombre del proyecto, utiliza:

```text
PrimerPrograma
```

El nombre debe ser descriptivo y evitar espacios.

## Paso 6. Abrir el proyecto

Una vez creado el proyecto, Visual Studio Code abrirá la carpeta y C# Dev Kit detectará automáticamente el proyecto.

---

# 9. Estructura básica del proyecto

Al crear el proyecto encontraremos archivos similares a los siguientes:

```text
PrimerPrograma/
│
├── PrimerPrograma.csproj
└── Program.cs
```

## Program.cs

Este archivo contiene el código principal de nuestra aplicación.

En versiones actuales de .NET, podemos encontrar inicialmente un código sencillo como:

```csharp
Console.WriteLine("Hello, World!");
```

Esta instrucción muestra un mensaje en la consola.

## PrimerPrograma.csproj

El archivo `.csproj` contiene información de configuración del proyecto, como el SDK utilizado y el framework objetivo.

Por ejemplo:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

> El valor de `TargetFramework` puede variar según la versión del SDK instalada.

---

# 10. Ejecutar nuestro primer programa

Existen varias formas de ejecutar el proyecto.

## Opción A. Desde Visual Studio Code

En la parte superior de Visual Studio Code puedes utilizar las opciones de ejecución disponibles para el proyecto.

También puedes utilizar:

**Run → Run Without Debugging**

En Windows/Linux:

```text
Ctrl + F5
```

En macOS:

```text
Cmd + F5
```

## Opción B. Desde la terminal

Abre una terminal integrada:

**Terminal → New Terminal**

Verifica que estás ubicado dentro de la carpeta del proyecto:

```bash
cd PrimerPrograma
```

Después ejecuta:

```bash
dotnet run
```

El resultado esperado será similar a:

```text
Hello, World!
```

---

# 11. Crear nuestro primer programa personalizado

Ahora modificaremos `Program.cs`.

Reemplaza el contenido por:

```csharp
Console.WriteLine("¡Hola, mundo!");
Console.WriteLine("Bienvenidos a Programación con C#");
Console.WriteLine("Mi primer programa en .NET");
```

Guarda el archivo y ejecuta:

```bash
dotnet run
```

El resultado será:

```text
¡Hola, mundo!
Bienvenidos a Programación con C#
Mi primer programa en .NET
```

---

# 12. Primera actividad práctica

## Actividad: Presentación por consola

Crea un programa de consola llamado:

```text
DatosEstudiante
```

El programa debe mostrar en la consola información básica de un estudiante.

Por ejemplo:

```text
==============================
      DATOS DEL ESTUDIANTE
==============================

Nombre: Juan Pérez
Carrera: Ingeniería de Sistemas
Materia: Programación
Semestre: 1

==============================
```

### Requisitos

El programa debe utilizar:

- `Console.WriteLine()`
- Al menos **5 instrucciones** para mostrar información.
- Una presentación ordenada utilizando separadores.

### Desafío adicional

Investiga cómo utilizar:

```csharp
Console.Write()
```

y explica brevemente cuál es la diferencia entre `Console.Write()` y `Console.WriteLine()`.

---

# 13. Comandos básicos de .NET

Durante las siguientes clases utilizaremos frecuentemente los comandos de .NET.

### Verificar versión

```bash
dotnet --version
```

### Mostrar información del entorno

```bash
dotnet --info
```

### Crear una aplicación de consola

```bash
dotnet new console
```

### Crear una aplicación con nombre específico

```bash
dotnet new console -n MiProyecto
```

### Ejecutar el proyecto

```bash
dotnet run
```

### Compilar el proyecto

```bash
dotnet build
```

### Limpiar archivos generados

```bash
dotnet clean
```

---

# 14. Comprobación final

Antes de finalizar la actividad, verifica que puedes realizar lo siguiente:

- [ ] Tengo instalado el .NET SDK.
- [ ] El comando `dotnet --version` funciona correctamente.
- [ ] Tengo instalado Visual Studio Code.
- [ ] Tengo instalada la extensión C# Dev Kit.
- [ ] Puedo abrir la Command Palette.
- [ ] Puedo utilizar `.NET: New Project`.
- [ ] Puedo crear un proyecto de tipo Console App.
- [ ] Puedo identificar `Program.cs`.
- [ ] Puedo ejecutar `dotnet run`.
- [ ] Mi programa muestra información correctamente en la consola.

---

# 15. Resultado esperado

Al finalizar esta guía, el estudiante deberá contar con un **entorno de desarrollo funcional para C# y .NET**, además de haber creado y ejecutado su primer programa de consola.

Este entorno será utilizado en las siguientes actividades de la asignatura de **Programación** para trabajar conceptos como:

- Tipos de datos.
- Variables.
- Operadores.
- Expresiones.
- Estructuras de control.
- Métodos.
- Programación orientada a objetos.

---

## Recursos oficiales

- [.NET — Sitio oficial](https://dotnet.microsoft.com/)
- [Descarga de .NET](https://dotnet.microsoft.com/download)
- [Documentación de .NET](https://learn.microsoft.com/dotnet/)
- [Visual Studio Code](https://code.visualstudio.com/)
- [C# en Visual Studio Code](https://code.visualstudio.com/docs/csharp/get-started)
- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

---

**Docente:** __________________________  
**Asignatura:** Programación  
**Carrera:** Ingeniería de Sistemas
