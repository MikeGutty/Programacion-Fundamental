---
theme: default
title: Tipos de Datos, Variables y Operadores
info: |
  ## Tema 2: Tipos de Datos, Variables y Operadores
  Ejemplos comparativos en PSeInt y C#
class: text-center
highlighter: shiki
lineNumbers: true
drawings:
  persist: false
transition: slide-left
mdc: true
---

# Tema 2
## Tipos de Datos, Variables y Operadores

Ejemplos comparativos: **PSeInt** vs **C#**

<div class="pt-8">
  <span class="opacity-70">Clasificar tipos de datos, variables y operadores aritméticos, lógicos y relacionales, utilizándolos en la resolución de problemas básicos.</span>
</div>

---
layout: default
---

# Agenda

<v-clicks>

- 2.1 Declarar variables y describir tipos de datos
- 2.2 ¿Qué es un operador? Tipos de operadores
  - Operadores aritméticos
  - Operadores relacionales
  - Operadores lógicos
- Ejercicio integrador
- Resumen: PSeInt → C#

</v-clicks>

---
layout: section
---

# 2.1 Variables y Tipos de Datos

---

# ¿Qué es una variable?

Un espacio en la memoria de la computadora que tiene un **nombre** (identificador) y guarda un **valor** que puede cambiar durante la ejecución de un programa.

<br>

# ¿Qué es un tipo de dato?

Define **qué clase de información** puede guardar una variable y **qué operaciones** se pueden hacer con ella.

---

# Tabla comparativa de tipos de datos

| Tipo de dato | PSeInt | C# | Ejemplo |
|---|---|---|---|
| Entero | `Entero` | `int` | `5`, `-12`, `1000` |
| Real / Decimal | `Real` | `double` | `3.14`, `-0.5` |
| Carácter / Texto | `Caracter` | `char` / `string` | `'A'`, `"Hola mundo"` |
| Lógico | `Logico` | `bool` | `Verdadero` / `Falso` |

<br>

## Reglas para nombrar variables

- Empiezan con una letra (no con números)
- Sin espacios ni símbolos especiales (`$`, `%`, `-`)
- Nombres descriptivos: `edad`, `nombreUsuario`, `precioTotal`
- En C# se recomienda **camelCase**

---
layout: two-cols
---

# Declarar variables · PSeInt

```text
Algoritmo DeclararVariables
    Definir nombre Como Caracter
    Definir edad Como Entero
    Definir estatura Como Real
    Definir esEstudiante Como Logico

    nombre <- "Ana"
    edad <- 20
    estatura <- 1.65
    esEstudiante <- Verdadero

    Escribir "Nombre: ", nombre
    Escribir "Edad: ", edad
    Escribir "Estatura: ", estatura
    Escribir "¿Es estudiante?: ", esEstudiante
FinAlgoritmo
```

::right::

# Declarar variables · C#

```csharp
string nombre = "Ana";
int edad = 20;
double estatura = 1.65;
bool esEstudiante = true;

Console.WriteLine("Nombre: " + nombre);
Console.WriteLine("Edad: " + edad);
Console.WriteLine("Estatura: " + estatura);
Console.WriteLine(
  "¿Es estudiante?: " + esEstudiante);
```

<v-click>

> 💡 Con .NET 10 / C# 14 puedes ejecutar
> este archivo con `dotnet run Program.cs`

</v-click>

---
layout: two-cols
---

# Pedir datos al usuario · PSeInt

```text
Algoritmo DatosDelUsuario
    Definir nombre Como Caracter
    Definir edad Como Entero

    Escribir "Ingrese su nombre: "
    Leer nombre

    Escribir "Ingrese su edad: "
    Leer edad

    Escribir "Hola ", nombre,
             ", tienes ", edad, " años."
FinAlgoritmo
```

::right::

# Pedir datos al usuario · C#

```csharp
Console.Write("Ingrese su nombre: ");
string nombre = Console.ReadLine();

Console.Write("Ingrese su edad: ");
int edad = int.Parse(Console.ReadLine());

Console.WriteLine(
  $"Hola {nombre}, tienes {edad} años.");
```

<v-click>

> ⚠️ `Console.ReadLine()` siempre devuelve
> `string`. Si necesitas un número, usa
> `int.Parse()`, `double.Parse()`, etc.

</v-click>

---
layout: section
---

# 2.2 Operadores

---

# ¿Qué es un operador?

Un **símbolo** que indica una operación entre uno o más valores (*operandos*), produciendo un resultado.

<v-clicks>

- **Aritméticos** → cálculos matemáticos
- **Relacionales** → comparaciones (devuelven verdadero/falso)
- **Lógicos** → combinan valores verdadero/falso

</v-clicks>

---

# a) Operadores aritméticos

| Operación | PSeInt | C# |
|---|---|---|
| Suma | `+` | `+` |
| Resta | `-` | `-` |
| Multiplicación | `*` | `*` |
| División | `/` | `/` |
| División entera | `DIV` | `/` (entre enteros) |
| Módulo (residuo) | `MOD` | `%` |
| Potencia | `^` | `Math.Pow(base, exp)` |

---
layout: two-cols
---

# Aritméticos · PSeInt

```text
Algoritmo OperadoresAritmeticos
    Definir a, b, suma, resta Como Entero
    Definir multiplicacion Como Entero
    Definir division Como Entero
    Definir residuo Como Entero

    a <- 10
    b <- 3

    suma <- a + b
    resta <- a - b
    multiplicacion <- a * b
    division <- a / b
    residuo <- a MOD b

    Escribir "Suma: ", suma
    Escribir "Residuo: ", residuo
FinAlgoritmo
```

::right::

# Aritméticos · C#

```csharp
int a = 10;
int b = 3;

int suma = a + b;
int resta = a - b;
int multiplicacion = a * b;
double division = (double)a / b;
int residuo = a % b;

Console.WriteLine($"Suma: {suma}");
Console.WriteLine($"Residuo: {residuo}");
```

<v-click>

> 💡 `10 / 3` entre `int` trunca a `3`.
> Usa `double` para obtener decimales.

</v-click>

---

# b) Operadores relacionales

Comparan dos valores y devuelven un resultado **lógico**.

| Comparación | PSeInt | C# |
|---|---|---|
| Igual que | `=` | `==` |
| Diferente que | `<>` | `!=` |
| Mayor que | `>` | `>` |
| Menor que | `<` | `<` |
| Mayor o igual que | `>=` | `>=` |
| Menor o igual que | `<=` | `<=` |

---
layout: two-cols
---

# Relacionales · PSeInt

```text
Algoritmo OperadoresRelacionales
    Definir x, y Como Entero

    x <- 8
    y <- 5

    Escribir "¿x = y? ", x = y
    Escribir "¿x <> y? ", x <> y
    Escribir "¿x > y? ", x > y
    Escribir "¿x <= y? ", x <= y
FinAlgoritmo
```

::right::

# Relacionales · C#

```csharp
int x = 8;
int y = 5;

Console.WriteLine($"¿x == y? {x == y}");
Console.WriteLine($"¿x != y? {x != y}");
Console.WriteLine($"¿x > y? {x > y}");
Console.WriteLine($"¿x <= y? {x <= y}");
```

<v-click>

> ⚠️ En C#, `=` **asigna** y `==` **compara**.
> ¡Uno de los errores más comunes!

</v-click>

---

# c) Operadores lógicos

Combinan valores lógicos (verdadero/falso) para tomar decisiones más complejas.

| Operación | PSeInt | C# |
|---|---|---|
| Y (AND) | `Y` | `&&` |
| O (OR) | `O` | `\|\|` |
| Negación (NOT) | `NO` | `!` |

---
layout: two-cols
---

# Lógicos · PSeInt

```text
Algoritmo OperadoresLogicos
    Definir edad Como Entero
    Definir tieneCarnet Como Logico

    edad <- 20
    tieneCarnet <- Verdadero

    Si (edad >= 18) Y
       (tieneCarnet = Verdadero) Entonces
        Escribir "Puede conducir."
    SiNo
        Escribir "No puede conducir."
    FinSi
FinAlgoritmo
```

::right::

# Lógicos · C#

```csharp
int edad = 20;
bool tieneCarnet = true;

if (edad >= 18 && tieneCarnet)
{
    Console.WriteLine("Puede conducir.");
}
else
{
    Console.WriteLine("No puede conducir.");
}
```

---
layout: section
---

# Ejercicio integrador

---

# Planteamiento del problema

Crear un algoritmo que pida al usuario **dos números** y su **edad**. El programa debe indicar:

<v-clicks>

1. Cuál número es mayor
2. Si la suma de los dos números es par o impar (`MOD` / `%`)
3. Si la persona es mayor de edad (18 años o más)

</v-clicks>

---

# Solución · PSeInt (1/2)

Declaración de variables, entrada de datos y comparación de números

```text {1-10|12|14-22|all}
Algoritmo EjercicioIntegrador
    Definir num1, num2, suma, edad Como Entero
    Definir esMayorDeEdad, esPar Como Logico

    Escribir "Ingrese el primer número: "
    Leer num1
    Escribir "Ingrese el segundo número: "
    Leer num2
    Escribir "Ingrese su edad: "
    Leer edad

    suma <- num1 + num2

    Si num1 > num2 Entonces
        Escribir num1, " es mayor que ", num2
    SiNo
        Si num2 > num1 Entonces
            Escribir num2, " es mayor que ", num1
        SiNo
            Escribir "Los números son iguales"
        FinSi
    FinSi
```

---

# Solución · PSeInt (2/2)

Validación de par/impar y mayoría de edad

```text {1-5|7-11|all}
    Si (suma MOD 2) = 0 Entonces
        Escribir "La suma (", suma, ") es par"
    SiNo
        Escribir "La suma (", suma, ") es impar"
    FinSi

    Si edad >= 18 Entonces
        Escribir "Es mayor de edad"
    SiNo
        Escribir "Es menor de edad"
    FinSi
FinAlgoritmo
```

---

# Solución · C# (1/2)

Entrada de datos y comparación de números

```csharp {1-9|11|13-21|all}
Console.Write("Ingrese el primer número: ");
int num1 = int.Parse(Console.ReadLine());

Console.Write("Ingrese el segundo número: ");
int num2 = int.Parse(Console.ReadLine());

Console.Write("Ingrese su edad: ");
int edad = int.Parse(Console.ReadLine());

int suma = num1 + num2;

if (num1 > num2)
{
    Console.WriteLine($"{num1} es mayor que {num2}");
}
else if (num2 > num1)
{
    Console.WriteLine($"{num2} es mayor que {num1}");
}
else
{
    Console.WriteLine("Los números son iguales");
}
```

---

# Solución · C# (2/2)

Validación de par/impar y mayoría de edad

```csharp {1-7|9-15|all}
if (suma % 2 == 0)
{
    Console.WriteLine($"La suma ({suma}) es par");
}
else
{
    Console.WriteLine($"La suma ({suma}) es impar");
}

if (edad >= 18)
{
    Console.WriteLine("Es mayor de edad");
}
else
{
    Console.WriteLine("Es menor de edad");
}
```

---
layout: section
---

# Resumen

---

# Tabla de equivalencias PSeInt → C#

| Concepto | PSeInt | C# |
|---|---|---|
| Inicio de programa | `Algoritmo Nombre` | *(top-level statements)* |
| Declarar variable | `Definir x Como Entero` | `int x;` |
| Asignar valor | `x <- 5` | `x = 5;` |
| Mostrar en pantalla | `Escribir` | `Console.WriteLine()` |
| Leer del teclado | `Leer` | `Console.ReadLine()` |
| Igualdad | `=` | `==` |
| Y lógico | `Y` | `&&` |
| O lógico | `O` | `\|\|` |
| Negación | `NO` | `!` |
| Verdadero / Falso | `Verdadero` / `Falso` | `true` / `false` |

---
layout: center
class: text-center
---

# ¡Manos a la obra!

Practiquemos en **PSeInt** y luego traduzcamos a **C#**

<div class="pt-8 opacity-70">
  PSeInt: pseint.sourceforge.net &nbsp;·&nbsp; .NET 10 SDK: dotnet.microsoft.com/download
</div>