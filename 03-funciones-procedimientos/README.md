# Guía de estudio — Tema 4
## Funciones, Procedimientos y Modularización

**Programación I · Ingeniería de Sistemas**
*De PSeInt a C#*

---

## 📖 ¿De qué trata este tema?

Hasta ahora has escrito programas donde todo el código vive en un solo bloque (`Proceso Principal` en PSeInt o `Main` en C#). Ese enfoque funciona para programas pequeños, pero **se vuelve difícil de leer, corregir y reutilizar** a medida que el programa crece.

En este tema aprenderás a dividir tus programas en **piezas pequeñas y reutilizables** llamadas *funciones* y *procedimientos*, y a **revisar tu propio código** para detectar problemas comunes de organización, validación y seguridad.

---

## 🗂️ Contenidos

1. [Funciones y procedimientos](#1-funciones-y-procedimientos)
2. [Parámetros y argumentos](#2-parámetros-y-argumentos)
3. [Valores de retorno](#3-valores-de-retorno)
4. [Ventajas de modularizar](#4-ventajas-de-usar-funciones-y-procedimientos)
5. [Cómo identificar qué convertir en función](#5-cómo-identificar-partes-del-programa-que-pueden-convertirse-en-funciones)
6. [Ejemplo completo: de código no modular a modularizado](#6-ejemplo-completo-refactorización)
7. [Revisión de código: qué es y qué revisar](#7-revisión-de-código)
8. [Problemas comunes de modularidad y seguridad](#8-problemas-comunes-que-debes-detectar)
9. [Ejercicio guiado de revisión](#9-ejercicio-guiado-de-revisión-de-código)
10. [Resumen](#-resumen-final)

---

## 1. Funciones y procedimientos

### ¿Qué es una función?

Una función es un **bloque de código con nombre propio** que:

- puede recibir datos de entrada (parámetros),
- realiza una tarea específica, y
- **devuelve un resultado**.

> 💡 Piénsala como una mini calculadora: le das datos, te devuelve un resultado.

### ¿Qué es un procedimiento?

Un procedimiento es igual a una función, pero **no devuelve ningún resultado**. Solo ejecuta una acción (mostrar un mensaje, guardar datos, imprimir algo).

> 💡 Piénsalo como una "acción" que el programa realiza, sin entregar un valor de vuelta.

### Diferencias entre función y procedimiento

| Característica | Función | Procedimiento |
|---|---|---|
| ¿Devuelve valor? | ✅ Sí | ❌ No |
| Palabra clave en PSeInt | `Funcion` | `SubProceso` |
| Palabra clave en C# | tipo de dato (`int`, `double`, `string`, `bool`...) | `void` |
| Ejemplo típico | Calcular un promedio | Mostrar un mensaje en pantalla |
| ¿Se puede usar dentro de una expresión? | Sí: `x = Sumar(2,3)` | No, se usa como instrucción independiente |

### Ejemplo 1: una función

**Concepto:** función que calcula el área de un círculo.

**PSeInt**
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

**C#**
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

**Análisis:**
- `static double CalcularAreaCirculo(double radio)` → el tipo `double` indica que la función **devuelve** un valor.
- `radio` es el **parámetro**: el dato que la función necesita.
- `return` entrega el resultado (equivale a `area <-` + `FinFuncion` en PSeInt).
- En C#, toda función vive **dentro de una clase** (`class Programa`), algo que PSeInt no exige explícitamente.

### Ejemplo 2: un procedimiento

**Concepto:** procedimiento que muestra un mensaje de bienvenida.

**PSeInt**
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

**C#**
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

**Análisis:** el `void` en C# significa *"no devuelve nada"*, tal como el `SubProceso` en PSeInt.

---

## 2. Parámetros y argumentos

- **Parámetro**: el nombre de la variable que la función espera recibir. Se define en la firma del método.
- **Argumento**: el valor real que se envía cuando se llama a la función.

```csharp
static double CalcularAreaCirculo(double radio) // radio = parámetro
...
double resultado = CalcularAreaCirculo(5.0);    // 5.0 = argumento
```

**Comparación:**

| PSeInt | C# |
|---|---|
| `Funcion r <- Sumar(a, b)` <br> `r <- a + b` <br> `FinFuncion` | `static int Sumar(int a, int b)` <br> `{` <br> `    return a + b;` <br> `}` |

Ambas versiones reciben **dos parámetros** (`a`, `b`). La diferencia es que C# exige indicar el **tipo de dato** de cada parámetro y del valor de retorno.

---

## 3. Valores de retorno

- El `return` (o `<-` en PSeInt) **entrega un resultado** y **termina** la ejecución de la función.
- Una función puede tener **varios `return`**, normalmente dentro de condicionales.
- Un procedimiento (`void`) puede usar `return;` sin ningún valor, solo para salir antes de tiempo.

**Ejemplo con condicional:**

| PSeInt | C# |
|---|---|
| `Funcion r <- EsPar(n)` <br> `    Si n % 2 == 0 Entonces` <br> `        r <- Verdadero` <br> `    SiNo` <br> `        r <- Falso` <br> `    FinSi` <br> `FinFuncion` | `static bool EsPar(int n)` <br> `{` <br> `    if (n % 2 == 0)` <br> `        return true;` <br> `    else` <br> `        return false;` <br> `}` |

**Pregunta para repasar:** ¿cuál de estas firmas de método en C# es una función y cuál un procedimiento?

```csharp
static void Validar(int edad)
static int Duplicar(int numero)
```

<details>
<summary>Ver respuesta</summary>

`Validar` → procedimiento (no retorna nada). `Duplicar` → función (retorna un `int`).

</details>

---

## 4. Ventajas de usar funciones y procedimientos

- ♻️ **Reutilización**: escribes el código una vez y lo usas muchas veces.
- 🧹 **Orden**: el programa principal queda más corto y legible.
- 🐞 **Depuración más fácil**: los errores se aíslan en bloques pequeños.
- 🤝 **Trabajo en equipo**: cada persona puede programar una función distinta.
- 🧪 **Pruebas independientes**: puedes probar cada función por separado.

---

## 5. Cómo identificar partes del programa que pueden convertirse en funciones

Pregúntate, para cada bloque de código:

- ¿Este bloque **se repite** en varias partes del programa?
- ¿Realiza **una tarea clara y específica**?
- ¿Podrías **darle un nombre descriptivo** que explique qué hace?
- ¿El programa principal sería **más fácil de leer** si esto fuera solo una línea con nombre?

Si respondiste "sí" a alguna pregunta, ese bloque es candidato a convertirse en función o procedimiento.

---

## 6. Ejemplo completo: refactorización

### 🚫 Antes: programa poco modular

Calcula el promedio de 3 notas y determina si el estudiante aprueba.

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

**Problemas de este código:**
- Todo está **mezclado**: lectura de datos, cálculo y presentación de resultados.
- La línea `Escribir "Promedio: ", promedio` está **duplicada**.
- Si quisiera calcular el promedio en otro programa, tendría que copiar y pegar todo.
- Es difícil probar solo una parte sin ejecutar el programa completo.

### ✅ Después: versión modularizada (PSeInt)

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
    FinSi
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

### ✅ Después: versión modularizada (C#)

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

### Comparación antes / después

| Aspecto | Sin modularizar | Modularizado |
|---|---|---|
| Líneas en el flujo principal | ~15 | ~6 |
| Código duplicado | Sí | No |
| Reutilizable en otro programa | No | Sí |
| Fácil de probar por partes | No | Sí |
| Fácil de leer | Regular | Alta |

> 💡 `Main` ahora se lee casi como una lista de pasos en lenguaje natural: leer datos → calcular → mostrar.

### 📝 Para practicar

Piensa en un programa que:
1. Pide el precio de un producto.
2. Pide el porcentaje de descuento.
3. Calcula el precio final.
4. Muestra el resultado con formato.

**Tarea:** identifica qué partes deberían ser funciones/procedimientos y escribe sus firmas (en PSeInt y en C#).

---

## 7. Revisión de código

### ¿Qué es una revisión de código?

Es el proceso de **leer y analizar código** (propio o de otra persona) para encontrar errores, mejorar su calidad y asegurar buenas prácticas **antes** de darlo por terminado.

> No se trata de buscar culpables, sino de mejorar el software en equipo.

### ¿Qué debemos revisar?

- 🔁 Código duplicado
- 📏 Métodos demasiado grandes
- 🎭 Responsabilidades mezcladas
- 🏷️ Nombres poco claros
- 🛡️ Validación de datos
- ⚠️ Manejo básico de errores
- 🔒 Problemas básicos de seguridad

---

## 8. Problemas comunes que debes detectar

### Código duplicado

```csharp
Console.WriteLine("== Reporte de ventas ==");
Console.WriteLine("-----------------------");
// ... cálculo de ventas

Console.WriteLine("== Reporte de compras ==");
Console.WriteLine("-----------------------");
// ... cálculo de compras
```

✅ Solución: extraer un procedimiento `MostrarEncabezado(string titulo)`.

### Métodos demasiado grandes

- Un método que hace 10 cosas distintas es difícil de leer y corregir.
- Regla práctica: si no puedes describir lo que hace un método en **una frase corta**, probablemente hace demasiado.
- Solución: dividirlo en métodos más pequeños, cada uno con una única tarea.

### Responsabilidades mezcladas

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

🚫 Este único método mezcla lectura, cálculo, validación e impresión. Cada responsabilidad debería vivir en su propia función/procedimiento.

### Nombres poco claros

| ❌ Poco claro | ✅ Claro |
|---|---|
| `static double Calc(double a, double b) { return a * b * 0.1; }` | `static double CalcularDescuento(double precio, double cantidad) { return precio * cantidad * 0.1; }` |

Un buen nombre **explica qué hace** la función sin necesidad de leer su código.

### Validación de datos

Nunca confíes en que el usuario ingresará siempre datos correctos. Validar significa comprobar que el dato cumple lo esperado antes de usarlo.

```csharp
static bool EsEdadValida(int edad)
{
    return edad >= 0 && edad <= 120;
}
```

### Manejo básico de errores

En PSeInt casi no se maneja, pero en C# es fundamental para evitar que el programa se caiga:

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

💡 `try/catch` "atrapa" el error para que el programa siga funcionando en vez de cerrarse.

### Problemas básicos de seguridad

- 🔓 Aceptar cualquier dato sin validar (edades negativas, textos donde se espera un número, etc.).
- 🗝️ Escribir contraseñas o datos sensibles directamente en el código.
- 📤 Mostrar mensajes de error demasiado detallados al usuario final.
- 🔁 No verificar límites (por ejemplo, dividir sin comprobar que el divisor no sea cero).

> En Programación I basta con **reconocer** estos problemas; en materias posteriores se profundizará en seguridad.

---

## 9. Ejercicio guiado de revisión de código

### Código con errores

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

**Preguntas guía (respóndelas antes de seguir):**
1. ¿Qué pasa si el usuario escribe una letra en vez de un número para la edad?
2. ¿Hay líneas de código que se repiten en ambos bloques (`if`/`else`)?
3. ¿Todo el código está en `Main`... debería estar dividido en funciones?
4. ¿Se valida que la edad sea un número razonable (por ejemplo, no negativo)?

<details>
<summary>Ver versión mejorada</summary>

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

**¿Qué cambió?**
- ✅ `int.TryParse` valida el dato sin que el programa se rompa.
- ✅ `EsEdadValida` comprueba un rango razonable.
- ✅ El saludo y la lógica de estado ahora son funciones separadas.
- ✅ Se eliminó la duplicación entre el `if` y el `else`.
- ✅ `return;` corta la ejecución temprano si el dato no es válido.

</details>

### 📝 Para practicar

Se te entregará (en clase) un programa en C# con: un único método `Main` muy largo, código duplicado y sin validación de datos.

**Tarea:**
1. Identifica los problemas usando la lista de revisión de la sección 7.
2. Propón qué funciones/procedimientos crearías.
3. Reescribe el programa modularizado.

---

## Ventajas de un código modular, mantenible y seguro

- 🧩 Más fácil de **entender** para cualquiera del equipo.
- 🔧 Más fácil de **corregir** cuando aparece un error.
- ♻️ Más fácil de **reutilizar** en otros proyectos.
- 🧪 Más fácil de **probar** función por función.
- 🛡️ Más **robusto** frente a datos inesperados del usuario.
- 🚀 Facilita el trabajo en **equipo** y el crecimiento del proyecto.

---

## 📌 Resumen final

- **Función** → devuelve un valor · **Procedimiento** → no devuelve valor.
- Los **parámetros** son la entrada; el **retorno** es la salida.
- **Modularizar** = dividir un programa en bloques pequeños con una responsabilidad clara.
- Una buena **revisión de código** busca: duplicación, métodos grandes, mezcla de responsabilidades, nombres poco claros, falta de validación y errores no controlados.
- Código modular = más fácil de leer, mantener, probar y asegurar.

---

*Guía de estudio — Programación I · Tema 4: Funciones, Procedimientos y Modularización*