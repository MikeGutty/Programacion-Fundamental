# Guía de Estudio — Tema 5: Estructuras de Datos Básicas

**Subtema 5.1 — Arrays, cadenas y estructuras simples**
Programación I — Ingeniería de Sistemas

---

## Cómo usar esta guía

Esta guía está pensada para **estudiar de forma autónoma**, ya sea antes de clase (para llegar con el concepto claro), durante clase (como material de apoyo) o antes de un examen (como repaso). Sigue el mismo orden lógico que la presentación:

```text
¿Qué es? → ¿Para qué sirve? → ¿Cómo funciona? → ¿Cómo se representa?
   → ¿Cómo se implementa en PSeInt? → ¿Cómo se implementa en C#?
      → ¿Cómo se aplica en un proyecto?
```

Cada sección incluye: **explicación**, **ejemplos comparados** (PSeInt / C#), **errores comunes** y **puntos clave para recordar**. Al final encontrarás un glosario, una tabla resumen y preguntas de autoevaluación con respuestas.

> 💡 Recomendación: no solo leas el código, **cópialo y ejecútalo tú mismo** en PSeInt y en un compilador de C# (por ejemplo con `dotnet run`).

---

## Índice

1. [Introducción: ¿por qué necesitamos estructuras de datos?](#1-introducción-por-qué-necesitamos-estructuras-de-datos)
2. [¿Qué es una estructura de datos?](#2-qué-es-una-estructura-de-datos)
3. [Arrays](#3-arrays)
4. [Cadenas de caracteres](#4-cadenas-de-caracteres)
5. [Estructuras simples (`struct`)](#5-estructuras-simples-struct)
6. [Integración: arrays + cadenas + structs](#6-integración-arrays--cadenas--structs)
7. [Proyecto guía: Sistema básico de estudiantes](#7-proyecto-guía-sistema-básico-de-estudiantes)
8. [Tabla comparativa PSeInt vs. C#](#8-tabla-comparativa-pseint-vs-c)
9. [Errores frecuentes y cómo evitarlos](#9-errores-frecuentes-y-cómo-evitarlos)
10. [Buenas prácticas](#10-buenas-prácticas)
11. [Ejercicios de autoestudio](#11-ejercicios-de-autoestudio)
12. [Glosario](#12-glosario)
13. [Preguntas de repaso (con respuestas)](#13-preguntas-de-repaso-con-respuestas)

---

## 1. Introducción: ¿por qué necesitamos estructuras de datos?

Imagina que debes registrar las notas de 5 estudiantes. Una primera idea sería crear una variable por cada nota:

```text
nota1
nota2
nota3
nota4
nota5
```

Esto **funciona para 5 datos**, pero se vuelve inmanejable si son 50, 100 o 1000:

- Tendrías que escribir cientos de nombres de variables distintos.
- No podrías recorrerlas con un ciclo (`for`/`Para`), porque cada una tiene un nombre diferente.
- Cualquier operación (sumar, ordenar, buscar) requeriría repetir código para cada variable.

La solución es agrupar todos esos datos bajo **un solo nombre**, organizados y accesibles por posición:

```text
notas[5]
```

Esta es la idea central de una **estructura de datos**: en lugar de datos sueltos, se organiza la información para poder **almacenarla, recorrerla y manipularla de forma eficiente**.

**Punto clave:** cada vez que te preguntes "¿necesito muchas variables para guardar datos parecidos?", probablemente necesitas una estructura de datos (en este tema, un array).

---

## 2. ¿Qué es una estructura de datos?

### Definición

Una **estructura de datos** es una forma organizada de almacenar y relacionar varios datos, de modo que se puedan **acceder, recorrer y modificar** de manera eficiente, tratándolos como un conjunto en lugar de elementos aislados.

### Variable vs. estructura de datos

| | Variable | Estructura de datos |
|---|---|---|
| Cantidad de datos | Uno solo | Varios datos relacionados |
| Analogía | Una caja que guarda un objeto | Un estante con varias cajas organizadas |
| Ejemplo | `int nota = 85;` | `int[] notas = {80, 75, 90};` |

### Dato, variable y estructura de datos

| Concepto | Descripción | Ejemplo |
|---|---|---|
| **Dato** | Un valor concreto | `85`, `"Ana"`, `20` |
| **Variable** | Espacio con nombre que guarda un dato | `int nota = 85;` |
| **Estructura de datos** | Conjunto organizado de datos relacionados | `int[] notas = {80, 75, 90};` |

### Ejemplos cotidianos

Sin darnos cuenta, usamos estructuras de datos todos los días:

- 📋 La lista de contactos de un celular (muchos nombres y números organizados).
- 🎵 Una playlist (varias canciones en un orden determinado).
- 🧾 Un carrito de compras (varios productos agregados).
- 🏫 La lista de asistencia de un curso.

**Punto clave:** una estructura de datos no es "más difícil" que una variable; es simplemente una forma de **organizar varias variables relacionadas** bajo un mismo concepto.

---

## 3. Arrays

### 3.1 ¿Qué es un array?

Un **array** (o arreglo) es una estructura que almacena **varios elementos del mismo tipo de dato**, ubicados en posiciones consecutivas, cada una identificada por un **índice**.

```text
Índice:    0     1     2     3     4
          ┌─────┬─────┬─────┬─────┬─────┐
Array:    │ 10  │ 20  │ 30  │ 40  │ 50  │
          └─────┴─────┴─────┴─────┴─────┘
```

Componentes clave:

- **Elementos**: los valores almacenados (10, 20, 30, 40, 50).
- **Índice**: la posición de cada elemento dentro del array.
- **Tamaño**: la cantidad total de elementos que puede contener (5, en este caso).
- **Tipo de dato**: todos los elementos deben ser del mismo tipo (todos enteros, todos texto, etc.).

> ⚠️ **Muy importante:** en **C#**, los índices siempre comienzan en `0`. El primer elemento está en la posición `0`, el segundo en la posición `1`, y así sucesivamente.

### 3.2 Arrays vs. variables individuales

**Con variables sueltas:**

```csharp
int nota1 = 80;
int nota2 = 75;
int nota3 = 90;
int nota4 = 85;
```

Problemas: difícil de escalar, no se puede recorrer con un ciclo, código repetitivo.

**Con un array:**

```csharp
int[] notas = { 80, 75, 90, 85 };
```

Ventajas: un solo nombre agrupa todos los datos, se puede recorrer con `for`, y escala fácilmente a cientos de elementos sin cambiar la lógica del programa.

### 3.3 Declaración e inicialización en C#

Existen varias formas equivalentes de crear un array:

```csharp
int[] numeros = new int[5];               // Array "vacío" de tamaño 5 (se llena con 0)
int[] numeros = { 10, 20, 30, 40, 50 };   // Inicializado directamente con valores
int[] numeros = new int[] { 10, 20, 30 }; // Forma explícita usando "new"
```

- `int[]` → indica que es un array de enteros.
- `new int[5]` → reserva espacio en memoria para 5 enteros (inicializados en `0` por defecto).
- `{ }` → lista de valores iniciales.

### 3.4 Arrays en PSeInt

```pseint
Definir numeros Como Entero
Dimension numeros[5]

numeros[1] <- 10
numeros[2] <- 20
numeros[3] <- 30
numeros[4] <- 40
numeros[5] <- 50
```

- `Dimension` reserva el tamaño del array.
- En PSeInt es común indexar **desde 1**, a diferencia de C#, que indexa **desde 0**.

### 3.5 Acceso a elementos

| | PSeInt (desde 1) | C# (desde 0) |
|---|---|---|
| Código | `Escribir numeros[3]` | `Console.WriteLine(numeros[2]);` |
| Accede a | El **tercer** elemento | El **tercer** elemento |

Las posiciones "no coinciden numéricamente" porque PSeInt cuenta desde 1 y C# cuenta desde 0. El tercer elemento lógico está en el índice `3` en PSeInt, pero en el índice `2` en C#. **Esta es la confusión #1 al pasar de PSeInt a C#**, así que conviene practicarla con varios ejemplos.

### 3.6 Recorrido de un array

Recorrer significa **visitar cada elemento del array**, generalmente con un ciclo:

```text
Inicio → Elemento 1 → Elemento 2 → Elemento 3 → ... → Fin
```

**PSeInt:**

```pseint
Para i <- 1 Hasta 5 Hacer
    Escribir numeros[i]
FinPara
```

**C#:**

```csharp
for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine(numeros[i]);
}
```

**Anatomía del `for` en C#:**

| Parte | Significado |
|---|---|
| `int i = 0` | Variable de control: inicia el recorrido en el índice 0 |
| `i < numeros.Length` | Condición: el ciclo se repite mientras sea verdadera |
| `i++` | Incremento: avanza al siguiente índice en cada vuelta |
| `numeros.Length` | Propiedad que indica cuántos elementos tiene el array |
| `numeros[i]` | Accede al elemento ubicado en la posición `i` |

> ⚠️ Error muy común: usar `i <= numeros.Length` en lugar de `i < numeros.Length`. Esto provoca un error de **índice fuera de rango**, porque el último índice válido es `Length - 1`, no `Length`.

### 3.7 Ejemplo práctico: promedio de 5 notas

**Problema:** solicitar 5 notas, almacenarlas en un array y calcular el promedio.

**Análisis:**
- **Entrada:** 5 notas (números reales).
- **Proceso:** guardar cada nota en un array, sumarlas, dividir entre 5.
- **Salida esperada:**

```text
Ingrese la nota 1: 80
Ingrese la nota 2: 75
Ingrese la nota 3: 90
Ingrese la nota 4: 85
Ingrese la nota 5: 70
Promedio: 80
```

**Solución en PSeInt:**

```pseint
Definir notas, suma, promedio Como Real
Definir i Como Entero

Dimension notas[5]

suma <- 0

Para i <- 1 Hasta 5 Hacer
    Escribir "Ingrese la nota ", i, ":"
    Leer notas[i]
    suma <- suma + notas[i]
FinPara

promedio <- suma / 5

Escribir "Promedio: ", promedio
```

**Solución en C#:**

```csharp
double[] notas = new double[5];
double suma = 0;

for (int i = 0; i < notas.Length; i++)
{
    Console.Write($"Ingrese la nota {i + 1}: ");
    notas[i] = double.Parse(Console.ReadLine()!);

    suma += notas[i];
}

double promedio = suma / notas.Length;

Console.WriteLine($"Promedio: {promedio}");
```

Nota: se usa `i + 1` solo para **mostrar** al usuario el número de nota (1, 2, 3...), pero el índice real del array sigue comenzando en 0.

---

## 4. Cadenas de caracteres

### 4.1 ¿Qué es una cadena?

Una **cadena** (`string`) es una secuencia de caracteres. Un **carácter** (`char`) es un único símbolo.

```text
'A'                    → carácter
"Hola"                 → cadena
"Michael"              → cadena
"Programación"         → cadena
```

En C#:
- `char` → almacena **un solo carácter** (comillas simples: `'A'`).
- `string` → almacena **una cadena de texto** (comillas dobles: `"Hola"`).

### 4.2 Cadenas en PSeInt

```pseint
Definir nombre Como Cadena

nombre <- "Carlos"

Escribir nombre
```

Las cadenas permiten almacenar nombres, mensajes, textos y descripciones en general.

### 4.3 Cadenas en C#

```csharp
string nombre = "Carlos";

Console.WriteLine(nombre);
```

**Concatenación e interpolación:**

```csharp
string nombre = "Carlos";
int edad = 20;

Console.WriteLine("Nombre: " + nombre);                      // Concatenación
Console.WriteLine($"Nombre: {nombre}, Edad: {edad}");         // Interpolación
```

| Técnica | Descripción |
|---|---|
| Concatenación (`+`) | Une texto y variables usando el operador `+` |
| Interpolación (`$""`) | Inserta variables directamente dentro del texto con `{ }` (más legible, forma recomendada) |

### 4.4 Operaciones básicas con cadenas

```csharp
string texto = "Programacion";

Console.WriteLine(texto.Length);     // 12 → Longitud
Console.WriteLine(texto.ToUpper());  // PROGRAMACION
Console.WriteLine(texto.ToLower());  // programacion
Console.WriteLine(texto[0]);         // 'P' → Acceso a un carácter
```

| Operación | Qué hace |
|---|---|
| `.Length` | Cantidad de caracteres de la cadena |
| `.ToUpper()` | Convierte todo el texto a mayúsculas |
| `.ToLower()` | Convierte todo el texto a minúsculas |
| `texto[0]` | Accede al primer carácter (índice 0, igual que en un array) |

**Punto clave:** una cadena se comporta, en cuanto a indexación, **como un array de caracteres**: por eso `texto[0]` funciona igual que `numeros[0]`.

### 4.5 Ejemplo práctico con cadenas

**Problema:** solicitar el nombre y apellido de un estudiante y mostrar un mensaje personalizado.

**PSeInt:**

```pseint
Definir nombre, apellido Como Cadena

Escribir "Ingrese su nombre:"
Leer nombre
Escribir "Ingrese su apellido:"
Leer apellido

Escribir "Bienvenido/a, ", nombre, " ", apellido
```

**C#:**

```csharp
Console.Write("Ingrese su nombre: ");
string nombre = Console.ReadLine()!;

Console.Write("Ingrese su apellido: ");
string apellido = Console.ReadLine()!;

Console.WriteLine($"Bienvenido/a, {nombre} {apellido}");
```

**Extensión — contar caracteres del nombre:**

```csharp
Console.WriteLine($"La longitud de su nombre es: {nombre.Length}");
```

---

## 5. Estructuras simples (`struct`)

### 5.1 ¿Qué son las estructuras simples?

Una **estructura simple** agrupa **varios datos relacionados**, incluso de **distinto tipo**, que describen a una misma entidad:

```text
Estudiante
├── nombre    (texto)
├── edad      (número entero)
├── carrera   (texto)
└── promedio  (número real)
```

**Diferencia clave con un array:** un array agrupa **muchos elementos del mismo tipo** (por ejemplo, 30 notas). Una estructura agrupa **pocos datos, de distinto tipo, pero relacionados entre sí** (nombre + edad + promedio de un mismo estudiante).

### 5.2 Estructuras simples en PSeInt

PSeInt, en sus versiones básicas, no tiene un tipo "estructura" formal; se aproxima con **variables relacionadas**:

```pseint
Definir nombre Como Cadena
Definir edad Como Entero
Definir promedio Como Real

nombre <- "Ana"
edad <- 20
promedio <- 85.5
```

**Limitación:** estas variables no están agrupadas realmente. Si quisiéramos manejar varios estudiantes, tendríamos que crear **un array por cada dato** (uno para nombres, otro para edades, otro para promedios), perdiendo la relación directa entre ellos. Esto es justamente lo que resuelve `struct` en C#.

### 5.3 Estructuras simples en C#: `struct`

```csharp
struct Estudiante
{
    public string Nombre;
    public int Edad;
    public double Promedio;
}
```

**Crear y utilizar una variable de tipo `struct`:**

```csharp
Estudiante estudiante;

estudiante.Nombre = "Ana";
estudiante.Edad = 20;
estudiante.Promedio = 85.5;

Console.WriteLine(estudiante.Nombre);
```

> 📌 Por ahora, `struct` es solo un **agrupador de datos**. En temas posteriores se profundizará en clases, propiedades, constructores y programación orientada a objetos — no es necesario (ni conveniente) adelantarse a esos conceptos todavía.

---

## 6. Integración: arrays + cadenas + structs

Podemos combinar todo lo aprendido creando un **array de estructuras**: cada posición del array guarda un `Estudiante` completo (nombre, edad y promedio juntos).

```csharp
struct Estudiante
{
    public string Nombre;
    public int Edad;
    public double Promedio;
}

Estudiante[] estudiantes = new Estudiante[3];
```

**Almacenar y recorrer los datos:**

```csharp
estudiantes[0].Nombre = "Ana";
estudiantes[0].Edad = 20;
estudiantes[0].Promedio = 85.5;

estudiantes[1].Nombre = "Luis";
estudiantes[1].Edad = 22;
estudiantes[1].Promedio = 78.0;

for (int i = 0; i < estudiantes.Length; i++)
{
    Console.WriteLine(
        $"Nombre: {estudiantes[i].Nombre}, " +
        $"Edad: {estudiantes[i].Edad}, " +
        $"Promedio: {estudiantes[i].Promedio}"
    );
}
```

El acceso combina dos ideas ya vistas: el **índice del array** (`estudiantes[i]`) y el **acceso a un campo de la estructura** (`.Nombre`, `.Edad`, `.Promedio`).

---

## 7. Proyecto guía: Sistema básico de estudiantes

**Planteamiento:** crear un pequeño programa llamado *"Sistema básico de estudiantes"* que permita:

1. Registrar estudiantes.
2. Almacenar nombre.
3. Almacenar edad.
4. Almacenar promedio.
5. Mostrar todos los estudiantes.
6. Calcular el promedio general del curso.

**Análisis:**

```text
ENTRADA → Datos de N estudiantes (nombre, edad, promedio)
PROCESAMIENTO → Almacenamiento en un array de estructuras + cálculo del promedio general
SALIDA → Listado de estudiantes + promedio general del curso
```

**Implementación en PSeInt** (usando tres arrays paralelos, ya que PSeInt no maneja `struct` de forma nativa):

```pseint
Definir nombres Como Cadena
Definir edades Como Entero
Definir promedios Como Real
Definir i, n, sumaGeneral Como Entero

n <- 3
Dimension nombres[n]
Dimension edades[n]
Dimension promedios[n]

Para i <- 1 Hasta n Hacer
    Escribir "Nombre del estudiante ", i, ":"
    Leer nombres[i]
    Escribir "Edad:"
    Leer edades[i]
    Escribir "Promedio:"
    Leer promedios[i]
FinPara

sumaGeneral <- 0
Para i <- 1 Hasta n Hacer
    Escribir nombres[i], " - ", edades[i], " años - Promedio: ", promedios[i]
    sumaGeneral <- sumaGeneral + promedios[i]
FinPara

Escribir "Promedio general del curso: ", sumaGeneral / n
```

**Implementación en C#** (usando un array de `struct`, más ordenado que tres arrays paralelos):

```csharp
struct Estudiante
{
    public string Nombre;
    public int Edad;
    public double Promedio;
}

int n = 3;
Estudiante[] estudiantes = new Estudiante[n];

// Registro
for (int i = 0; i < n; i++)
{
    Console.Write($"Nombre del estudiante {i + 1}: ");
    estudiantes[i].Nombre = Console.ReadLine()!;

    Console.Write("Edad: ");
    estudiantes[i].Edad = int.Parse(Console.ReadLine()!);

    Console.Write("Promedio: ");
    estudiantes[i].Promedio = double.Parse(Console.ReadLine()!);
}

// Reporte
double sumaGeneral = 0;

for (int i = 0; i < n; i++)
{
    Console.WriteLine(
        $"{estudiantes[i].Nombre} - {estudiantes[i].Edad} años" +
        $" - Promedio: {estudiantes[i].Promedio}"
    );

    sumaGeneral += estudiantes[i].Promedio;
}

Console.WriteLine($"Promedio general del curso: {sumaGeneral / n}");
```

**Idea central para retener:** el uso de `struct` evita tener que manejar varios arrays paralelos (uno por cada dato) y en su lugar agrupa toda la información de un estudiante en un solo lugar, dentro de un único array.

---

## 8. Tabla comparativa PSeInt vs. C#

| Concepto | PSeInt | C# |
|---|---|---|
| Array | `Dimension` | `tipo[]` |
| Índice inicial | Normalmente desde `1` | Siempre desde `0` |
| Recorrido | `Para ... Hasta ... Hacer` | `for (...; ...; ...)` |
| Cadena | `Cadena` | `string` |
| Carácter | (no siempre diferenciado) | `char` |
| Longitud | Función de longitud disponible | `.Length` |
| Estructura | Variables relacionadas | `struct` |
| Entrada | `Leer` | `Console.ReadLine()` |
| Salida | `Escribir` | `Console.WriteLine()` |

PSeInt es ideal para **desarrollar la lógica** del programa sin preocuparse por la sintaxis exacta de un lenguaje. C# permite llevar esa misma lógica a un **lenguaje de programación real**, utilizado en el ámbito profesional.

---

## 9. Errores frecuentes y cómo evitarlos

| Error | Por qué ocurre | Cómo evitarlo |
|---|---|---|
| Confundir el índice con la posición real | PSeInt suele indexar desde 1, C# desde 0 | Recordar siempre: en C#, el elemento *n* está en el índice *n-1* |
| Acceder a una posición inexistente | Usar `i <= Length` en vez de `i < Length`, o un índice negativo | Verificar siempre que `0 <= índice < Length` |
| Olvidar inicializar el array | Declarar el array pero no asignarle valores antes de usarlo | Inicializar con `new tipo[n]` o con valores directos `{ }` |
| Usar mal `.Length` | Confundir `.Length` (propiedad, sin paréntesis) con un método | Recordar: `.Length` no lleva `()` |
| Confundir `char` con `string` | `char` usa comillas simples (`'A'`), `string` usa comillas dobles (`"A"`) | Un solo carácter → `char`; texto → `string` |
| Acceder fuera de los límites del array o cadena | No validar el tamaño antes de acceder | Comparar el índice contra `.Length` antes de usarlo |
| No asignar todos los campos de un `struct` | Olvidar inicializar algún campo antes de usarlo | Asignar explícitamente cada campo (`Nombre`, `Edad`, `Promedio`) antes de leerlo |

---

## 10. Buenas prácticas

- 🏷️ Usa nombres descriptivos (`notas`, `estudiantes`), evita nombres genéricos como `x`, `a1`.
- 🔁 Evita repetir código: usa ciclos para recorrer estructuras en lugar de escribir instrucciones repetidas.
- 📏 Controla siempre los límites del array usando `.Length`.
- ✅ Valida los datos ingresados por el usuario antes de procesarlos.
- 🧹 Mantén el código organizado, bien indentado y con espacios consistentes.
- 💬 Comenta solo cuando aporte claridad real, no comentes lo obvio.

---

## 11. Ejercicios de autoestudio

Intenta resolver cada uno primero en PSeInt (para asegurar la lógica) y luego en C# (para practicar la sintaxis).

1. **Array simple:** crea un array de 6 números enteros, solicítalos al usuario y muestra la suma total.
2. **Máximo y mínimo:** dado un array de 8 números, determina el mayor y el menor valor.
3. **Cadena invertida (conceptual):** dado un nombre, muestra su longitud y su versión en mayúsculas.
4. **Contador de mayores de edad:** dado un array de 10 edades, cuenta cuántas personas son mayores o iguales a 18 años.
5. **Struct simple:** crea un `struct Libro` con `Titulo`, `Autor` y `Paginas`, crea una variable de ese tipo, asígnale valores y muéstralos.
6. **Integrador:** crea un array de 3 `struct Producto` (con `Nombre` y `Precio`), solicita los datos, muéstralos y calcula el precio total de todos los productos.

**Ejercicio guiado completo** (con pistas y solución paso a paso): ver la presentación (`presentacion/`) o la carpeta `ejercicios/` de este repositorio.

---

## 12. Glosario

| Término | Significado |
|---|---|
| **Array / arreglo** | Estructura que almacena varios elementos del mismo tipo, accesibles por índice |
| **Índice** | Número que indica la posición de un elemento dentro de un array o cadena |
| **Elemento** | Cada uno de los valores almacenados en un array |
| **`Length`** | Propiedad de C# que indica la cantidad de elementos (array) o caracteres (cadena) |
| **Cadena (`string`)** | Secuencia de caracteres que forma un texto |
| **Carácter (`char`)** | Un único símbolo de texto |
| **Concatenación** | Unir cadenas y variables usando el operador `+` |
| **Interpolación** | Insertar variables dentro de una cadena usando `$"texto {variable}"` |
| **Estructura simple (`struct`)** | Tipo que agrupa varios datos relacionados, posiblemente de distinto tipo |
| **Recorrido** | Proceso de visitar, uno por uno, todos los elementos de una estructura |
| **`Dimension`** | Instrucción de PSeInt para reservar el tamaño de un array |

---

## 13. Preguntas de repaso (con respuestas)

<details>
<summary><b>1. ¿Qué es un array?</b></summary>

Una estructura que almacena varios elementos del mismo tipo bajo un solo nombre, accesibles mediante un índice.
</details>

<details>
<summary><b>2. ¿Qué es un índice?</b></summary>

Un número que indica la posición de un elemento dentro del array.
</details>

<details>
<summary><b>3. ¿Por qué en C# los índices comienzan normalmente en 0?</b></summary>

Es una convención del lenguaje C# (heredada de C), donde el índice representa el "desplazamiento" desde el inicio del array en memoria; el primer elemento tiene desplazamiento 0.
</details>

<details>
<summary><b>4. ¿Qué diferencia existe entre <code>char</code> y <code>string</code>?</b></summary>

<code>char</code> almacena un único carácter (comillas simples), mientras que <code>string</code> almacena una secuencia de caracteres, es decir, un texto (comillas dobles).
</details>

<details>
<summary><b>5. ¿Qué hace <code>.Length</code>?</b></summary>

Indica la cantidad de elementos de un array o la cantidad de caracteres de una cadena.
</details>

<details>
<summary><b>6. ¿Para qué sirve <code>struct</code>?</b></summary>

Para agrupar varios datos relacionados, posiblemente de distinto tipo, en una sola entidad (por ejemplo, nombre, edad y promedio de un estudiante).
</details>

<details>
<summary><b>7. ¿Qué ventaja tiene utilizar un array en lugar de variables sueltas?</b></summary>

Permite manejar muchos datos bajo un solo nombre y recorrerlos con ciclos, evitando código repetitivo y facilitando la escalabilidad del programa.
</details>

<details>
<summary><b>8. ¿Cuándo conviene utilizar una estructura de datos?</b></summary>

Cuando se necesita almacenar, organizar, recorrer o relacionar múltiples datos de forma eficiente, en lugar de manejarlos como variables independientes.
</details>

<details>
<summary><b>9. ¿Qué diferencia existe entre PSeInt y C# al trabajar con arrays?</b></summary>

PSeInt suele indexar desde 1 y no maneja <code>struct</code> de forma nativa; C# indexa desde 0 y sí cuenta con <code>struct</code> como tipo agrupador de datos.
</details>

<details>
<summary><b>10. ¿Qué información agruparías en un <code>struct</code> para representar un "Libro"?</b></summary>

Por ejemplo: <code>Titulo</code> (string), <code>Autor</code> (string), <code>Paginas</code> (int) y <code>Precio</code> (double) — datos de distinto tipo que describen una misma entidad.
</details>

---

## Próximo tema

Una vez dominados arrays, cadenas y estructuras simples, el siguiente paso natural son las **estructuras de datos dinámicas**: listas enlazadas, pilas, colas y otras estructuras que crecen y se reorganizan en tiempo de ejecución. Este tema es la base indispensable para entenderlas.