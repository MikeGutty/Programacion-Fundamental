---
theme: default
title: "Tema 4: Funciones, Procedimientos y Modularización"
info: |
  Programación I - Ingeniería de Sistemas
  De PSeInt a C#
class: text-center
transition: fade
mdc: true
---

# Tema 4
## Funciones, Procedimientos y Modularización

De PSeInt a C# — Programación I

<div class="pt-8 opacity-70">
Ingeniería de Sistemas · Primer Semestre
</div>

---

# Agenda

<v-clicks>

- 🧩 4.1 Funciones y procedimientos
- 🔧 Parámetros, argumentos y retorno
- 🏗️ Modularización de un proyecto
- 🔍 4.2 Revisión de código: seguridad y modularidad
- ✅ Actividades prácticas
- 📌 Resumen

</v-clicks>

---
layout: center
class: text-center
---

# ¿Recuerdas este problema?

Hasta ahora hemos escrito programas donde **todo el código va en un solo bloque**.

<v-click>

¿Qué pasa cuando el programa crece?

</v-click>

<v-click>

Se vuelve difícil de leer, de corregir y de reutilizar 😩

</v-click>

---

# 4.1 Funciones y procedimientos

## ¿Qué es una función?

<v-click>

Un **bloque de código con nombre propio** que:

- Recibe datos (opcional)
- Realiza una tarea específica
- **Devuelve un resultado**

</v-click>

<v-click>

> Piénsalo como una "mini calculadora": le das números, te devuelve un resultado.

</v-click>

---

# ¿Qué es un procedimiento?

<v-click>

Un **bloque de código con nombre propio** que:

- Recibe datos (opcional)
- Realiza una tarea específica
- **NO devuelve ningún resultado**

</v-click>

<v-click>

> Piénsalo como una "acción": mostrar un mensaje, guardar un archivo, imprimir un ticket.

</v-click>

---

# Función vs Procedimiento

| Característica | Función | Procedimiento |
|---|---|---|
| ¿Devuelve valor? | ✅ Sí | ❌ No |
| Palabra clave PSeInt | `Funcion` | `SubProceso` / `Procedimiento` |
| Palabra clave C# | tipo de dato (`int`, `double`, `string`...) | `void` |
| Ejemplo de uso | Calcular un promedio | Mostrar un mensaje |
| Se puede usar en... | Una expresión: `x = Sumar(2,3)` | Una instrucción independiente |

---

# Creando una función: PSeInt

**Concepto:** función que calcula el área de un círculo

```text
Funcion area <- CalcularAreaCirculo(radio)
    area <- 3.1416 * radio ^ 2
FinFuncion

Proceso Principal
    Definir r, resultado Como Real
    Escribir "Ingrese el radio:"
    Leer r
    resultado <- CalcularAreaCirculo(r)
    Escribir "El área es: ", resultado
FinProceso
```

---

# El equivalente en C#

```csharp
using System;

class Programa
{
    static double CalcularAreaCirculo(double radio)
    {
        return 3.1416 * Math.Pow(radio, 2);
    }

    static void Main()
    {
        Console.Write("Ingrese el radio: ");
        double r = double.Parse(Console.ReadLine());

        double resultado = CalcularAreaCirculo(r);
        Console.WriteLine("El área es: " + resultado);
    }
}
```

---

# Análisis del código

<v-clicks>

- `static double CalcularAreaCirculo(double radio)` → el **tipo de dato** (`double`) indica que **devuelve** un valor
- `radio` es el **parámetro**: el dato que la función necesita para trabajar
- `return` es la instrucción que **entrega el resultado** (equivale a `area <-` + `FinFuncion` en PSeInt)
- La función se **llama** dentro de `Main`, igual que en el `Proceso Principal`

</v-clicks>

<v-click>

💡 En C#, toda función/procedimiento vive **dentro de una clase**, algo que en PSeInt no existe explícitamente.

</v-click>

---

# Creando un procedimiento: PSeInt

**Concepto:** procedimiento que muestra un mensaje de bienvenida

```text
SubProceso MostrarBienvenida(nombre)
    Escribir "¡Hola, ", nombre, "! Bienvenido al sistema."
FinSubProceso

Proceso Principal
    Definir usuario Como Cadena
    Escribir "Ingrese su nombre:"
    Leer usuario
    MostrarBienvenida(usuario)
FinProceso
```

---

# El equivalente en C#

```csharp
using System;

class Programa
{
    static void MostrarBienvenida(string nombre)
    {
        Console.WriteLine("¡Hola, " + nombre + "! Bienvenido al sistema.");
    }

    static void Main()
    {
        Console.Write("Ingrese su nombre: ");
        string usuario = Console.ReadLine();

        MostrarBienvenida(usuario);
    }
}
```

<v-click>

🔎 Nota el `void`: significa **"no devuelve nada"**, tal como el `SubProceso` de PSeInt.

</v-click>

---

# Parámetros y argumentos

<v-clicks>

- **Parámetro**: el nombre de la variable que la función espera recibir (se define en la firma)
- **Argumento**: el valor real que se envía cuando se llama a la función

</v-clicks>

<v-click>

```csharp
static double CalcularAreaCirculo(double radio) // radio = parámetro
...
double resultado = CalcularAreaCirculo(5.0);    // 5.0 = argumento
```

</v-click>

---

# Parámetros: PSeInt vs C#

<div class="grid grid-cols-2 gap-4">
<div>

**PSeInt**

```text
Funcion r <- Sumar(a, b)
    r <- a + b
FinFuncion
```

</div>
<div>

**C#**

```csharp
static int Sumar(int a, int b)
{
    return a + b;
}
```

</div>
</div>

<v-click>

Ambas reciben **dos parámetros** (`a`, `b`) y funcionan igual conceptualmente. C# solo exige indicar el **tipo de dato** de cada uno.

</v-click>

---

# Valores de retorno

<v-clicks>

- El `return` (o `<-` en PSeInt) **entrega un resultado** y **termina** la ejecución de la función
- Una función puede tener **varios `return`** dentro de condicionales
- Un procedimiento (`void`) **puede usar `return;` sin valor**, solo para salir antes

</v-clicks>

---

# Retorno con condicionales

<div class="grid grid-cols-2 gap-4">
<div>

**PSeInt**

```text
Funcion r <- EsPar(n)
    Si n % 2 == 0 Entonces
        r <- Verdadero
    SiNo
        r <- Falso
    FinSi
FinFuncion
```

</div>
<div>

**C#**

```csharp
static bool EsPar(int n)
{
    if (n % 2 == 0)
        return true;
    else
        return false;
}
```

</div>
</div>

---
layout: center
---

# 🤔 Pregunta rápida

¿Cuál de estas dos firmas de método en C# corresponde a un **procedimiento** y cuál a una **función**?

```csharp
static void Validar(int edad)
static int Duplicar(int numero)
```

<v-click>

✅ `Validar` → procedimiento (no retorna nada)
✅ `Duplicar` → función (retorna un `int`)

</v-click>

---

# Ventajas de usar funciones y procedimientos

<v-clicks>

- ♻️ **Reutilización**: escribes el código una vez, lo usas muchas veces
- 🧹 **Orden**: el programa principal queda más corto y legible
- 🐞 **Depuración más fácil**: los errores se aíslan en bloques pequeños
- 🤝 **Trabajo en equipo**: cada persona puede programar una función distinta
- 🧪 **Pruebas independientes**: puedes probar cada función por separado

</v-clicks>

---

# ¿Cuándo convertir código en una función?

Pregúntate:

<v-clicks>

- ¿Este bloque de código **se repite** en varias partes del programa?
- ¿Este bloque realiza **una tarea clara y específica**?
- ¿Podría **darle un nombre descriptivo** que explique qué hace?
- ¿El programa principal sería **más fácil de leer** si esto fuera una línea con nombre?

</v-clicks>

<v-click>

Si respondiste "sí" a alguna → **¡es candidato a función o procedimiento!**

</v-click>

---
layout: section
---

# Ejemplo completo
## De un programa poco modular a uno refactorizado

---

# 🚫 Programa poco modular (PSeInt)

Calcula el promedio de 3 notas y determina si el estudiante aprueba

```text
Proceso Principal
    Definir n1, n2, n3, promedio Como Real

    Escribir "Ingrese nota 1:"
    Leer n1
    Escribir "Ingrese nota 2:"
    Leer n2
    Escribir "Ingrese nota 3:"
    Leer n3

    promedio <- (n1 + n2 + n3) / 3

    Si promedio >= 51 Entonces
        Escribir "Promedio: ", promedio
        Escribir "Resultado: APROBADO"
    SiNo
        Escribir "Promedio: ", promedio
        Escribir "Resultado: REPROBADO"
    FinSi
FinProceso
```

---

# 🔎 Problemas de este código

<v-clicks>

- Todo está **mezclado**: lectura de datos, cálculo y presentación de resultados
- El bloque `Escribir "Promedio: ", promedio` está **duplicado**
- Si mañana quiero calcular el promedio en **otro programa**, debo copiar y pegar todo
- Es difícil de **probar** una parte sin ejecutar el programa completo

</v-clicks>

---

# ✅ Refactorización (PSeInt)

<div class="code-compact">

```text
Funcion promedio <- CalcularPromedio(n1, n2, n3)
    promedio <- (n1 + n2 + n3) / 3
FinFuncion

Funcion aprobado <- EstaAprobado(promedio)
    aprobado <- promedio >= 51
FinFuncion

SubProceso MostrarResultado(promedio, aprobado)
    Escribir "Promedio: ", promedio
    Si aprobado Entonces
        Escribir "Resultado: APROBADO"
    SiNo
        Escribir "Resultado: REPROBADO"
    FinSubProceso
FinSubProceso

Proceso Principal
    Definir n1, n2, n3, prom Como Real
    Definir paso Como Logico

    Escribir "Ingrese nota 1:"
    Leer n1
    Escribir "Ingrese nota 2:"
    Leer n2
    Escribir "Ingrese nota 3:"
    Leer n3

    prom <- CalcularPromedio(n1, n2, n3)
    paso <- EstaAprobado(prom)
    MostrarResultado(prom, paso)
FinProceso
```

</div>
---

# ✅ Refactorización (C#)

<div class="code-compact">

```csharp
using System;

class Programa
{
    static double CalcularPromedio(double n1, double n2, double n3)
    {
        return (n1 + n2 + n3) / 3;
    }

    static bool EstaAprobado(double promedio)
    {
        return promedio >= 51;
    }

    static void MostrarResultado(double promedio, bool aprobado)
    {
        Console.WriteLine("Promedio: " + promedio);
        Console.WriteLine("Resultado: " + (aprobado ? "APROBADO" : "REPROBADO"));
    }

    static void Main()
    {
        Console.Write("Ingrese nota 1: ");
        double n1 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese nota 2: ");
        double n2 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese nota 3: ");
        double n3 = double.Parse(Console.ReadLine());

        double prom = CalcularPromedio(n1, n2, n3);
        bool paso = EstaAprobado(prom);
        MostrarResultado(prom, paso);
    }
}
```

</div>
---

# Antes vs Después

| Aspecto | Sin modularizar | Modularizado |
|---|---|---|
| Líneas en el flujo principal | ~15 | ~6 |
| Código duplicado | Sí | No |
| Reutilizable en otro programa | No | Sí (copiar la función) |
| Fácil de probar por partes | No | Sí |
| Fácil de leer | Regular | Alta |

<v-click>

💡 `Main` ahora se lee casi como **una lista de pasos en lenguaje natural**: leer datos → calcular → mostrar.

</v-click>

---
layout: center
---

# 📝 Actividad práctica 1

Tienes un programa que:
1. Pide el precio de un producto
2. Pide el porcentaje de descuento
3. Calcula el precio final
4. Muestra el resultado con formato

**Tarea:** identifica qué partes deberían ser funciones/procedimientos y escribe las firmas (`Funcion`/`SubProceso` o su versión en C#) que usarías.

<div class="opacity-70 pt-4">⏱️ 10 minutos · trabajo individual o en pareja</div>

---
layout: section
---

# 4.2 Revisión de código
## Seguridad y modularidad

---

# ¿Qué es una revisión de código?

<v-click>

El proceso de **leer y analizar código** (propio o de otra persona) para encontrar errores, mejorar su calidad y asegurar buenas prácticas **antes** de darlo por terminado.

</v-click>

<v-click>

> No se trata de buscar culpables, sino de **mejorar el software en equipo**.

</v-click>

---

# ¿Qué debemos revisar?

<v-clicks>

- 🔁 Código duplicado
- 📏 Métodos demasiado grandes
- 🎭 Responsabilidades mezcladas
- 🏷️ Nombres poco claros
- 🛡️ Validación de datos
- ⚠️ Manejo básico de errores
- 🔒 Problemas básicos de seguridad

</v-clicks>

---

# Código duplicado

```csharp {all|3-4|8-9}
static void Main()
{
    Console.WriteLine("== Reporte de ventas ==");
    Console.WriteLine("-----------------------");
    // ... cálculo de ventas

    Console.WriteLine("== Reporte de compras ==");
    Console.WriteLine("== Reporte de ventas ==");
    Console.WriteLine("-----------------------");
    // ... cálculo de compras
}
```

<v-click>

✅ Solución: extraer un procedimiento `MostrarEncabezado(string titulo)`

</v-click>

---

# Métodos demasiado grandes

<v-clicks>

- Un método que hace **10 cosas distintas** es difícil de leer y de corregir
- Regla práctica: si no puedes describir lo que hace en **una frase corta**, probablemente hace demasiado
- Solución: **dividir** en métodos más pequeños, cada uno con una tarea

</v-clicks>

---

# Responsabilidades mezcladas

<v-click>

```csharp
static void ProcesarPedido()
{
    // Lee datos del usuario
    // Calcula el total
    // Valida el stock
    // Imprime el ticket
    // Guarda en archivo
}
```

</v-click>

<v-click>

🚫 Este único método mezcla **lectura, cálculo, validación e impresión**.

Cada responsabilidad debería vivir en **su propia función/procedimiento**.

</v-click>

---

# Nombres poco claros

<div class="grid grid-cols-2 gap-4">
<div>

**❌ Poco claro**

```csharp
static double Calc(double a, double b)
{
    return a * b * 0.1;
}
```

</div>
<div>

**✅ Claro**

```csharp
static double CalcularDescuento(
    double precio, double cantidad)
{
    return precio * cantidad * 0.1;
}
```

</div>
</div>

<v-click>

Un buen nombre **explica qué hace** la función sin necesidad de leer su código.

</v-click>

---

# Validación de datos

<v-clicks>

- Nunca confíes en que el usuario **siempre** ingresará datos correctos
- Validar significa **comprobar** que el dato cumple lo esperado antes de usarlo

```csharp
static bool EsEdadValida(int edad)
{
    return edad >= 0 && edad <= 120;
}
```

</v-clicks>

---

# Manejo básico de errores

<v-click>

En PSeInt casi no se maneja, pero en C# es fundamental para evitar que el programa **se caiga**:

```csharp
try
{
    int numero = int.Parse(Console.ReadLine());
    Console.WriteLine("Número ingresado: " + numero);
}
catch (FormatException)
{
    Console.WriteLine("Error: debe ingresar un número válido.");
}
```

</v-click>

<v-click>

💡 `try/catch` "atrapa" el error para que el programa siga funcionando en vez de cerrarse.

</v-click>

---

# Problemas básicos de seguridad

<v-clicks>

- 🔓 Aceptar cualquier dato sin validar (ej. edades negativas, textos donde se espera un número)
- 🗝️ Escribir contraseñas o datos sensibles **directamente en el código**
- 📤 Mostrar mensajes de error demasiado detallados al usuario final
- 🔁 No verificar límites (ej. dividir sin comprobar que el divisor no sea cero)

</v-clicks>

<v-click>

> En Programación I basta con **reconocer** estos problemas; en materias posteriores se profundizará en seguridad.

</v-click>

---
layout: center
---

# 🔍 Ejercicio: encuentra los problemas

Analiza el siguiente código en parejas antes de continuar

---

# Código con errores

<div class="code-compact">

```csharp
using System;

class Programa
{
    static void Main()
    {
        Console.Write("Ingrese su edad: ");
        int edad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        if (edad >= 18)
        {
            Console.WriteLine("Hola " + nombre);
            Console.WriteLine(nombre + " es mayor de edad");
            Console.WriteLine("Puede registrarse");
        }
        else
        {
            Console.WriteLine("Hola " + nombre);
            Console.WriteLine(nombre + " es menor de edad");
            Console.WriteLine("No puede registrarse");
        }
    }
}
```

</div>
---

# 🤔 Preguntas guía

<v-clicks>

- ¿Qué pasa si el usuario escribe una letra en vez de un número para la edad?
- ¿Hay líneas de código que **se repiten** en ambos bloques (`if`/`else`)?
- ¿Todo el código está en `Main`... debería estar dividido en funciones?
- ¿Se valida que la edad sea un número **razonable** (por ejemplo, no negativo)?

</v-clicks>

---

# ✅ Versión mejorada

<div class="code-compact">

```csharp
using System;

class Programa
{
    static bool EsEdadValida(int edad)
    {
        return edad >= 0 && edad <= 120;
    }

    static void MostrarSaludo(string nombre)
    {
        Console.WriteLine("Hola " + nombre);
    }

    static void MostrarEstadoRegistro(string nombre, int edad)
    {
        bool esMayor = edad >= 18;
        string estado = esMayor ? "es mayor de edad" : "es menor de edad";
        string accion = esMayor ? "Puede registrarse" : "No puede registrarse";

        Console.WriteLine(nombre + " " + estado);
        Console.WriteLine(accion);
    }

    static void Main()
    {
        Console.Write("Ingrese su edad: ");
        int edad;
        bool datoValido = int.TryParse(Console.ReadLine(), out edad);

        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        if (!datoValido || !EsEdadValida(edad))
        {
            Console.WriteLine("Error: ingrese una edad válida (0-120).");
            return;
        }

        MostrarSaludo(nombre);
        MostrarEstadoRegistro(nombre, edad);
    }
}
```

</div>

---

# ¿Qué cambió?

<v-clicks>

- ✅ `int.TryParse` valida el dato **sin que el programa se rompa**
- ✅ `EsEdadValida` comprueba un rango razonable
- ✅ El saludo y la lógica de estado ahora son **funciones separadas**
- ✅ Se eliminó la **duplicación** entre el `if` y el `else`
- ✅ `return;` corta la ejecución temprano si el dato no es válido

</v-clicks>

---

# Ventajas de un código modular, mantenible y seguro

<v-clicks>

- 🧩 Más fácil de **entender** para cualquiera del equipo
- 🔧 Más fácil de **corregir** cuando aparece un error
- ♻️ Más fácil de **reutilizar** en otros proyectos
- 🧪 Más fácil de **probar** función por función
- 🛡️ Más **robusto** frente a datos inesperados del usuario
- 🚀 Facilita el trabajo en **equipo** y el crecimiento del proyecto

</v-clicks>

---
layout: center
---

# 📝 Actividad práctica 2

Se te entregará un programa en C# con:
- Un único método `Main` muy largo
- Código duplicado
- Sin validación de datos

**Tarea:**
1. Identifica los problemas usando la lista de revisión vista en clase
2. Propón qué funciones/procedimientos crearías
3. Reescribe el programa modularizado

<div class="opacity-70 pt-4">⏱️ 20 minutos · trabajo en grupos de 3</div>

---

# 📌 Resumen del tema

<v-clicks>

- **Función** → devuelve un valor · **Procedimiento** → no devuelve valor
- Los **parámetros** son la entrada; el **retorno** es la salida
- Modularizar = dividir un programa en bloques pequeños con una responsabilidad clara
- Una buena **revisión de código** busca: duplicación, métodos grandes, mezcla de responsabilidades, nombres poco claros, falta de validación y errores no controlados
- Código modular = más fácil de leer, mantener, probar y asegurar

</v-clicks>

---
layout: center
class: text-center
---

# ¡Gracias!

## ¿Preguntas?

<div class="pt-8 opacity-70">
Próxima clase: continuaremos con más ejercicios de refactorización
</div>