---
theme: default
title: "Tema 5: Estructuras de Datos Básicas"
info: |
  ## Programación I
  Introducción a arrays, cadenas y estructuras simples.
  Comparación PSeInt vs C#.
class: text-center
highlighter: shiki
lineNumbers: true
drawings:
  persist: false
transition: slide-left
mdc: true
css: unocss
fonts:
  sans: 'Inter'
  mono: 'Fira Code'
---

<style>
.brand-title {
  background: linear-gradient(90deg, #38bdf8, #6366f1, #a855f7);
  -webkit-background-clip: text;
  background-clip: text;
  color: transparent;
  font-weight: 800;
}
h1 { letter-spacing: -0.02em; }
.badge {
  display: inline-block;
  padding: 0.15rem 0.75rem;
  border-radius: 999px;
  font-size: 0.75rem;
  font-weight: 600;
  letter-spacing: 0.05em;
  text-transform: uppercase;
}
.badge-blue   { background: rgba(56,189,248,0.15); color: #38bdf8; border: 1px solid rgba(56,189,248,0.4); }
.badge-purple { background: rgba(168,85,247,0.15); color: #a855f7; border: 1px solid rgba(168,85,247,0.4); }
.badge-green  { background: rgba(34,197,94,0.15); color: #22c55e; border: 1px solid rgba(34,197,94,0.4); }
.two-cols-block { display: grid; grid-template-columns: 1fr 1fr; gap: 1.5rem; }
.card {
  border: 1px solid rgba(148,163,184,0.25);
  border-radius: 0.75rem;
  padding: 1rem 1.25rem;
  background: rgba(148,163,184,0.06);
}
.center-box { display:flex; align-items:center; justify-content:center; height:100%; }
</style>

<!-- ============================================================ -->
<!-- 1. PORTADA -->
<!-- ============================================================ -->

# <span class="brand-title">Estructuras de Datos Básicas</span>

### Arrays, cadenas y estructuras simples

<div class="mt-4 flex gap-2 justify-center">
  <span class="badge badge-blue">Tema 5</span>
  <span class="badge badge-purple">Subtema 5.1</span>
  <span class="badge badge-green">Programación Fundamental</span>
</div>

<br>

<div class="text-sm opacity-70">
Docente: Gerald Michael Gutierrez Maldonado
</div>

<div class="abs-br m-6 text-xs opacity-50">
PSeInt · C#
</div>

<!--
Bienvenida al Tema 5. Presentar el objetivo general: pasar de manejar
datos sueltos a manejar colecciones organizadas de datos, usando
primero PSeInt para la lógica y luego C# para la implementación real.
-->

---
layout: default
---

# Objetivos de aprendizaje

Al finalizar esta sesión, el estudiante será capaz de:

<div class="grid grid-cols-2 gap-x-8 gap-y-3 mt-6 text-sm">

<div>

- ✅ Comprender qué es una estructura de datos
- ✅ Diferenciar una variable simple de una estructura de datos
- ✅ Comprender el concepto de array/arreglo
- ✅ Declarar, inicializar y acceder a elementos de un array
- ✅ Recorrer arrays con estructuras repetitivas

</div>

<div>

- ✅ Comprender el concepto de cadenas de caracteres
- ✅ Manipular cadenas con operaciones básicas
- ✅ Comprender qué son las estructuras simples
- ✅ Relacionar PSeInt con su implementación en C#
- ✅ Crear un proyecto con arrays, cadenas y estructuras

</div>

</div>

<!--
Leer los objetivos en voz alta y aclarar que la sesión sigue una
progresión: primero concepto, luego PSeInt, luego C#, y al final
un proyecto integrador.
-->

---
layout: section
---

# Introducción

## ¿Por qué necesitamos algo más que variables simples?

---

# El problema: muchos datos, muchas variables

Imagina que necesitas registrar las notas de 5 estudiantes:

```text
nota1
nota2
nota3
nota4
nota5
```

<v-click>

Funciona... pero ¿qué pasa si son 100 estudiantes? 😰

- 100 variables distintas
- 100 nombres que recordar
- Imposible recorrerlas con un ciclo

</v-click>

<v-click>

<div class="mt-4 card">
La solución: agrupar los datos en <b>una sola estructura</b>

```text
notas[5]
```
</div>

</v-click>

<!--
Este es el gancho de la clase. Pedir a los estudiantes que imaginen
escribir 100 variables individuales y luego preguntar cómo harían
para calcular el promedio de todas sin un array.
-->

---

# ¿Qué es una estructura de datos?

<div class="two-cols-block mt-4">

<div class="card">

### 📦 Variable

Almacena **un solo dato**.

```csharp
int nota = 85;
```

Como una **caja** que guarda un objeto.

</div>

<div class="card">

### 🗄️ Estructura de datos

Almacena y **organiza varios datos relacionados**, permitiendo manipularlos como un conjunto.

```csharp
int[] notas = {80, 75, 90};
```

Como un **estante con varias cajas ordenadas**.

</div>

</div>

<v-click>

<div class="mt-6 text-sm opacity-80">

**En resumen:** una estructura de datos es una forma organizada de almacenar y manipular información, de modo que se pueda acceder, recorrer y modificar de manera eficiente.

</div>

</v-click>

<!--
Reforzar la analogía de la caja vs el estante. Es la idea central
que se repetirá durante toda la presentación.
-->

---

# Dato, variable y estructura de datos

| Concepto | Descripción | Ejemplo |
|---|---|---|
| **Dato** | Valor concreto | `85`, `"Ana"`, `20` |
| **Variable** | Espacio con nombre que guarda un dato | `int nota = 85;` |
| **Estructura de datos** | Conjunto organizado de datos relacionados | `int[] notas = {80,75,90};` |

<v-click>

### Ejemplos cotidianos de estructuras de datos

- 📋 La lista de contactos de tu celular (varios nombres y números)
- 🎵 Una playlist (varias canciones en orden)
- 🧾 Un carrito de compras (varios productos)
- 🏫 La lista de asistencia de un curso

</v-click>

<!--
Pedir ejemplos a los estudiantes de estructuras de datos que usan
todos los días sin saberlo (contactos, playlists, etc).
-->

---
layout: section
---

# Parte I

## Arrays

---

# ¿Qué es un array?

Un **array** (arreglo) es una estructura que almacena **varios elementos del mismo tipo**, organizados en posiciones consecutivas identificadas por un **índice**.

<div class="mt-6">

```text
Índice:    0     1     2     3     4
          ┌─────┬─────┬─────┬─────┬─────┐
Array:    │ 10  │ 20  │ 30  │ 40  │ 50  │
          └─────┴─────┴─────┴─────┴─────┘
```

</div>

<v-clicks>

- **Elementos**: los valores almacenados (10, 20, 30...)
- **Índice**: la posición de cada elemento
- **Tamaño**: cantidad total de elementos (5 en este caso)
- **Tipo de dato**: todos los elementos son del mismo tipo

</v-clicks>

<v-click>

<div class="card mt-4">
⚠️ En <b>C#</b>, los índices siempre comienzan en <code>0</code>.
</div>

</v-click>

<!--
Insistir en el índice 0 porque es la fuente #1 de errores para
estudiantes que vienen de PSeInt, donde a veces se trabaja desde 1.
-->

---

# Arrays vs. variables individuales

<div class="two-cols-block">

<div class="card">

### ❌ Con variables sueltas

```csharp
int nota1 = 80;
int nota2 = 75;
int nota3 = 90;
int nota4 = 85;
```

- Difícil de escalar
- No se puede recorrer con un ciclo
- Código repetitivo

</div>

<div class="card">

### ✅ Con un array

```csharp
int[] notas = { 80, 75, 90, 85 };
```

- Un solo nombre para todos los datos
- Se puede recorrer con `for`
- Escalable a cientos de elementos

</div>

</div>

<!--
Este contraste es clave para justificar por qué vale la pena
aprender arrays en lugar de seguir usando variables sueltas.
-->

---

# Declaración e inicialización en C#

Existen varias formas de crear un array:

```csharp {all|1|2|3}
int[] numeros = new int[5];              // Array vacío de tamaño 5
int[] numeros = { 10, 20, 30, 40, 50 };  // Inicializado directamente
int[] numeros = new int[] { 10, 20, 30 };// Forma explícita con new
```

<v-click>

<div class="grid grid-cols-3 gap-3 mt-4 text-sm">
<div class="card"><b>tipo[]</b><br>Define un array de ese tipo</div>
<div class="card"><b>new int[5]</b><br>Reserva espacio para 5 enteros (en 0)</div>
<div class="card"><b>{ }</b><br>Lista de valores iniciales</div>
</div>

</v-click>

<!--
Explicar que cuando se usa "new int[5]" sin valores, C# rellena
automáticamente con 0 (para tipos numéricos).
-->

---

# Arrays en PSeInt

En PSeInt, un array se declara con `Dimension`:

```text {all|1-2|4|6-10}
Definir numeros Como Entero
Dimension numeros[5]

// Asignación elemento por elemento

numeros[1] <- 10
numeros[2] <- 20
numeros[3] <- 30
numeros[4] <- 40
numeros[5] <- 50
```

<v-click>

<div class="card mt-4">
📌 <b>Diferencia clave:</b> en PSeInt es común indexar desde <code>1</code>,
mientras que en C# el índice <b>siempre</b> comienza en <code>0</code>.
</div>

</v-click>

<!--
Este es el segundo recordatorio de la diferencia de indexación,
ahora mostrando el código de PSeInt en paralelo.
-->

---

# Acceso a elementos

Comparemos cómo se accede al **mismo elemento lógico** en ambos lenguajes:

<div class="two-cols-block">

<div class="card">

### PSeInt (índice desde 1)

```text
Escribir numeros[3]
```

Accede al **tercer** elemento.

</div>

<div class="card">

### C# (índice desde 0)

```csharp
Console.WriteLine(numeros[2]);
```

También accede al **tercer** elemento.

</div>

</div>

<v-click>

<div class="mt-4 text-sm opacity-80">
Las posiciones "no coinciden numéricamente" porque PSeInt cuenta desde 1
y C# cuenta desde 0. El <b>tercer elemento</b> está en el índice <code>3</code>
en PSeInt, pero en el índice <code>2</code> en C#.
</div>

</v-click>

<!--
Este es el punto donde más se confunden los estudiantes. Usar el
dibujo del array anterior si es necesario para señalar la posición
física vs el número de índice.
-->

---

# Recorrido de un array

Recorrer un array significa **visitar cada uno de sus elementos**, generalmente con un ciclo.

```text
Inicio
  ↓
Elemento 1 → Elemento 2 → Elemento 3 → ... → Fin
```

<div class="two-cols-block mt-6">

<div class="card">

### PSeInt

```text
Para i <- 1 Hasta 5 Hacer
    Escribir numeros[i]
FinPara
```

</div>

<div class="card">

### C#

```csharp
for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine(numeros[i]);
}
```

</div>

</div>

<!--
Aquí conviene ejecutar mentalmente el ciclo con el grupo, contando
en voz alta las iteraciones en ambos lenguajes.
-->

---

# Anatomía del ciclo `for` en C#

```csharp
for (int i = 0; i < numeros.Length; i++)
{
    Console.WriteLine(numeros[i]);
}
```

<v-clicks>

- `int i = 0` → **variable de control**, inicia el recorrido en el índice 0
- `i < numeros.Length` → **condición**, se repite mientras sea verdadera
- `i++` → **incremento**, avanza al siguiente índice
- `numeros.Length` → propiedad que indica **cuántos elementos** tiene el array
- `numeros[i]` → accede al elemento ubicado en la posición `i`

</v-clicks>

<!--
Este desglose es fundamental: muchos errores de "índice fuera de
rango" vienen de no entender bien la condición del for.
-->

---
layout: section
---

# Ejemplo práctico

## Promedio de 5 notas

---

# Análisis del problema

> Solicitar 5 notas, almacenarlas en un array y calcular el promedio.

<div class="grid grid-cols-2 gap-4 mt-6 text-sm">

<div class="card">

**Datos de entrada**
- 5 notas (números reales)

**Proceso**
- Guardar cada nota en un array
- Sumar todas las notas
- Dividir la suma entre 5

</div>

<div class="card">

**Salida esperada**
```text
Ingrese la nota 1: 80
Ingrese la nota 2: 75
Ingrese la nota 3: 90
Ingrese la nota 4: 85
Ingrese la nota 5: 70
Promedio: 80
```

</div>

</div>

<!--
Insistir en el análisis antes de programar: identificar entradas,
proceso y salida es un hábito que se debe reforzar desde ya.
-->

---

# Solución en PSeInt

```text
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

<!--
Recorrer el algoritmo paso a paso: declaración, inicialización de
suma en 0, ciclo de lectura y acumulación, y cálculo final.
-->

---

# Solución en C#

```csharp {all|1-2|4-10|12|14}
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

<v-click>

<div class="text-sm opacity-80 mt-2">
Observa que se usa <code>i + 1</code> solo para <b>mostrar</b> el número
de nota al usuario, ya que el índice real sigue comenzando en 0.
</div>

</v-click>

<!--
Explicar double.Parse y Console.ReadLine como la forma estándar de
leer datos numéricos desde consola en C#. Señalar el uso de "!"
para indicar que no será null.
-->

---
layout: section
---

# Parte II

## Cadenas de caracteres

---

# ¿Qué es una cadena?

Una **cadena** (string) es una secuencia de caracteres, mientras que un **carácter** es un único símbolo.

<div class="two-cols-block mt-4">

<div class="card">

### Carácter

```text
'A'
```

Un solo símbolo.

</div>

<div class="card">

### Cadena

```text
"Hola"
"Michael"
"Programación"
```

Una secuencia de caracteres.

</div>

</div>

<v-click>

<div class="mt-4 text-sm">
En C#:
<ul>
<li><code>char</code> → almacena <b>un solo carácter</b></li>
<li><code>string</code> → almacena <b>una cadena de texto</b></li>
</ul>
</div>

</v-click>

<!--
Aclarar desde ya que char usa comillas simples y string usa comillas
dobles en C#, para evitar errores de sintaxis comunes.
-->

---

# Cadenas en PSeInt

```text
Definir nombre Como Cadena

nombre <- "Carlos"

Escribir nombre
```

<v-click>

Las cadenas permiten almacenar:

- Nombres de personas
- Mensajes para el usuario
- Textos, direcciones, descripciones, etc.

</v-click>

<!--
Recordar que en PSeInt el tipo se llama "Cadena" y en C# se llama
"string" — es la misma idea con distinto nombre.
-->

---

# Cadenas en C#

```csharp
string nombre = "Carlos";

Console.WriteLine(nombre);
```

### Concatenación e interpolación

```csharp
string nombre = "Carlos";
int edad = 20;

Console.WriteLine("Nombre: " + nombre);
Console.WriteLine($"Nombre: {nombre}, Edad: {edad}");
```

<v-click>

<div class="grid grid-cols-2 gap-3 mt-4 text-sm">
<div class="card"><b>Concatenación (+)</b><br>Une texto y variables con el operador <code>+</code></div>
<div class="card"><b>Interpolación ($"")</b><br>Inserta variables directamente dentro del texto con <code>{ }</code></div>
</div>

</v-click>

<!--
La interpolación suele ser más legible; mencionarla como la forma
recomendada en código moderno de C#.
-->

---

# Operaciones básicas con cadenas

```csharp
string texto = "Programacion";

Console.WriteLine(texto.Length);     // Longitud
Console.WriteLine(texto.ToUpper());  // MAYÚSCULAS
Console.WriteLine(texto.ToLower());  // minúsculas
Console.WriteLine(texto[0]);         // Acceso a un carácter
```

<v-clicks>

- `.Length` → cantidad de caracteres de la cadena
- `.ToUpper()` → convierte todo el texto a mayúsculas
- `.ToLower()` → convierte todo el texto a minúsculas
- `texto[0]` → accede al **primer carácter** (índice 0, igual que en arrays)

</v-clicks>

<!--
Conectar con el tema anterior: una cadena se comporta, en cuanto a
indexación, como un array de caracteres.
-->

---

# Ejemplo práctico con cadenas

> Solicitar el nombre y apellido de un estudiante y mostrar un mensaje personalizado.

<div class="two-cols-block mt-4">

<div class="card">

### PSeInt

```text
Definir nombre, apellido Como Cadena

Escribir "Ingrese su nombre:"
Leer nombre
Escribir "Ingrese su apellido:"
Leer apellido

Escribir "Bienvenido/a, ", nombre, " ", apellido
```

</div>

<div class="card">

### C#

```csharp
Console.Write("Ingrese su nombre: ");
string nombre = Console.ReadLine()!;

Console.Write("Ingrese su apellido: ");
string apellido = Console.ReadLine()!;

Console.WriteLine($"Bienvenido/a, {nombre} {apellido}");
```

</div>

</div>

<!--
Este ejemplo prepara el terreno para el proyecto integrador, donde
también se pedirán datos de texto al usuario.
-->

---

# Extensión: contar caracteres del nombre

<div class="two-cols-block">

<div class="card">

### PSeInt

```text
Escribir "La longitud de su nombre es: "
Escribir Longitud(nombre)
```

</div>

<div class="card">

### C#

```csharp
Console.WriteLine(
    $"La longitud de su nombre es: {nombre.Length}"
);
```

</div>

</div>

<v-click>

<div class="mt-4 text-sm opacity-80">
Nota: la función de longitud puede variar según la versión de PSeInt
utilizada; el concepto es el mismo que <code>.Length</code> en C#.
</div>

</v-click>

<!--
Aclarar la equivalencia conceptual, ya que el nombre exacto de la
función en PSeInt puede variar.
-->

---
layout: section
---

# Parte III

## Estructuras simples

---

# ¿Qué son las estructuras simples?

Una **estructura simple** agrupa **varios datos relacionados** que describen a una misma entidad, incluso si son de **distinto tipo**.

```text
Estudiante
├── nombre    (texto)
├── edad      (número entero)
├── carrera   (texto)
└── promedio  (número real)
```

<v-click>

<div class="card mt-4">
A diferencia de un array (mismo tipo, muchos elementos), una estructura
agrupa <b>datos de distinto tipo</b> que pertenecen a una misma entidad.
</div>

</v-click>

<!--
Esta es una distinción importante: array = mismos datos repetidos;
estructura = datos distintos pero relacionados entre sí.
-->

---

# Estructuras simples en PSeInt

PSeInt no tiene un tipo "estructura" formal en sus versiones básicas; se aproxima usando **variables relacionadas**:

```text
Definir nombre Como Cadena
Definir edad Como Entero
Definir promedio Como Real

nombre <- "Ana"
edad <- 20
promedio <- 85.5
```

<v-click>

### Limitación

Estas variables **no están agrupadas realmente**: si quisiéramos manejar varios estudiantes, tendríamos que crear un array por cada dato (uno para nombres, otro para edades, otro para promedios), perdiendo la relación directa entre ellos.

</v-click>

<!--
Esto motiva la necesidad de "struct" en C#: agrupar los datos de
verdad en una sola unidad.
-->

---

# Estructuras simples en C#: `struct`

```csharp
struct Estudiante
{
    public string Nombre;
    public int Edad;
    public double Promedio;
}
```

### Crear y utilizar una variable de tipo `struct`

```csharp
Estudiante estudiante;

estudiante.Nombre = "Ana";
estudiante.Edad = 20;
estudiante.Promedio = 85.5;

Console.WriteLine(estudiante.Nombre);
```

<v-click>

<div class="text-sm opacity-80 mt-2">
📌 Por ahora, <code>struct</code> es solo un <b>agrupador de datos</b>.
Más adelante, en temas posteriores, se profundizará en clases,
propiedades y programación orientada a objetos.
</div>

</v-click>

<!--
Ser explícito en que esto es una introducción; evitar entrar en
constructores, métodos o herencia en esta sesión.
-->

---
layout: section
---

# Parte IV

## Integración: arrays + cadenas + estructuras

---

# Combinando todo

> Crear un pequeño programa que almacene información de varios estudiantes y permita mostrar sus datos.

```csharp
struct Estudiante
{
    public string Nombre;
    public int Edad;
    public double Promedio;
}

Estudiante[] estudiantes = new Estudiante[3];
```

<v-click>

Ahora tenemos **un array de estructuras**: cada posición del array guarda un `Estudiante` completo (nombre, edad y promedio juntos).

</v-click>

<!--
Este es el "aha moment" de la clase: arrays y structs se combinan
para modelar colecciones de entidades del mundo real.
-->

---

# Almacenar y recorrer los datos

```csharp {all|1-6|8-15}
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

<!--
Señalar que el acceso combina dos ideas ya vistas: índice de array
( estudiantes[i] ) y acceso a un campo de la estructura ( .Nombre ).
-->

---
layout: section
---

# Proyecto práctico

## Sistema básico de estudiantes

---

# Planteamiento del problema

**Sistema básico de estudiantes**

El proyecto debe permitir:

<v-clicks>

1. Registrar estudiantes
2. Almacenar nombre
3. Almacenar edad
4. Almacenar promedio
5. Mostrar todos los estudiantes
6. Calcular el promedio general del curso

</v-clicks>

<!--
Presentar el proyecto como el cierre práctico de todo lo visto:
arrays, cadenas y estructuras trabajando juntos.
-->

---

# Análisis del proyecto

```text
ENTRADA
   ↓
Datos de N estudiantes (nombre, edad, promedio)
   ↓
PROCESAMIENTO
   ↓
Almacenamiento en un array de estructuras
Cálculo del promedio general
   ↓
SALIDA
   ↓
Listado de estudiantes + promedio general del curso
```

<!--
Repasar el esquema entrada-proceso-salida antes de mostrar el
código, tal como se hizo en el ejemplo del promedio de notas.
-->

---

# Implementación en PSeInt (parte1: registro)

```text {all|1-4|6-9|11-18}
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
```

---

# Implementación en PSeInt (parte2: reporte)

```text {all|1|2-5|7}
sumaGeneral <- 0
Para i <- 1 Hasta n Hacer
    Escribir nombres[i], " - ", edades[i], " años - Promedio: ", promedios[i]
    sumaGeneral <- sumaGeneral + promedios[i]
FinPara

Escribir "Promedio general del curso: ", sumaGeneral / n
```
<!--
En PSeInt se usan tres arrays paralelos porque no se maneja struct
de forma nativa. Esto refuerza por qué struct en C# es una mejora.
-->

---

# Implementación en C# (parte 1: registro)

```csharp
struct Estudiante
{
    public string Nombre;
    public int Edad;
    public double Promedio;
}

int n = 3;
Estudiante[] estudiantes = new Estudiante[n];

for (int i = 0; i < n; i++)
{
    Console.Write($"Nombre del estudiante {i + 1}: ");
    estudiantes[i].Nombre = Console.ReadLine()!;

    Console.Write("Edad: ");
    estudiantes[i].Edad = int.Parse(Console.ReadLine()!);

    Console.Write("Promedio: ");
    estudiantes[i].Promedio = double.Parse(Console.ReadLine()!);
}
```

<!--
Notar que se usa una sola estructura (Estudiante[]) en lugar de tres
arrays paralelos como en PSeInt: esta es la mejora clave de struct.
-->

---

# Implementación en C# (parte 2: reporte)

```csharp
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

<v-click>

<div class="card mt-4 text-sm">
✅ El programa reutiliza exactamente la misma lógica del ejemplo de
"promedio de notas", solo que ahora cada elemento del array es un
<code>Estudiante</code> completo en lugar de un simple número.
</div>

</v-click>

<!--
Cerrar el proyecto conectándolo explícitamente con el primer
ejemplo de la clase (promedio de notas), mostrando la progresión.
-->

---

# Comparación PSeInt vs C#

| Concepto | PSeInt | C# |
|---|---|---|
| Array | `Dimension` | `tipo[]` |
| Recorrido | `Para` | `for` |
| Cadena | `Cadena` | `string` |
| Longitud | Función de longitud disponible | `.Length` |
| Estructura | Variables relacionadas | `struct` |
| Salida | `Escribir` | `Console.WriteLine()` |

<v-click>

<div class="mt-4 text-sm opacity-80">
PSeInt es ideal para <b>desarrollar la lógica</b> del programa sin
preocuparse por la sintaxis. C# permite llevar esa misma lógica a un
<b>lenguaje de programación real</b>, utilizado en el mundo profesional.
</div>

</v-click>

<!--
Esta tabla resume visualmente todo lo aprendido y sirve como
referencia rápida para el estudiante.
-->

---

# Errores frecuentes

<div class="grid grid-cols-2 gap-4 text-sm mt-4">

<div class="card">

**Con arrays**
- Confundir el índice con la posición real
- Acceder a una posición que no existe
- Olvidar inicializar el array antes de usarlo
- Usar mal `.Length` (por ejemplo, `<=` en vez de `<`)

</div>

<div class="card">

**Con cadenas y estructuras**
- Confundir `char` (comillas simples) con `string` (comillas dobles)
- Acceder a un índice fuera de los límites del array o cadena
- Olvidar asignar valores a todos los campos de un `struct`

</div>

</div>

<v-click>

```csharp {monaco-diff}
// ❌ Incorrecto: recorre un elemento de más
for (int i = 0; i <= numeros.Length; i++) { }

// ✅ Correcto
for (int i = 0; i < numeros.Length; i++) { }
```

</v-click>

<!--
Si el bloque monaco-diff no está disponible en el entorno, se puede
sustituir por dos bloques de código normales lado a lado.
-->

---

# Buenas prácticas

<v-clicks>

- 🏷️ Utilizar nombres descriptivos (`notas`, `estudiantes`, no `x`, `a1`)
- 🔁 Evitar repetir código: usar ciclos para recorrer estructuras
- 📏 Controlar siempre los límites del array (`.Length`)
- ✅ Validar los datos ingresados por el usuario
- 🧹 Mantener el código organizado y bien indentado
- 💬 Comentar solo cuando aporte claridad, no de más

</v-clicks>

<!--
Estas prácticas se seguirán reforzando en los siguientes temas del
curso, así que vale la pena que las interioricen desde ahora.
-->

---
layout: section
---

# Ejercicio guiado

---

# Enunciado

> Crear un programa que almacene las edades de 10 personas en un array y determine:
>
> - La edad mayor
> - La edad menor
> - El promedio
> - Cuántas personas son mayores de edad

<v-click>

<div class="card mt-6 text-sm">
⏱️ Tómense unos minutos para pensar en el <b>análisis</b> antes de
programar: ¿cuáles son las entradas, el proceso y la salida?
</div>

</v-click>

<!--
Dar tiempo real a los estudiantes para pensar el análisis antes de
mostrar las pistas. Se puede resolver en parejas.
-->

---

# Pistas

<v-clicks>

- Necesitarás un array de tamaño 10 para las edades
- Usa variables para guardar la edad mayor y la edad menor mientras recorres el array
- Antes del ciclo, ¿con qué valor inicial conviene comenzar la edad mayor y la menor?
- Un contador puede llevar la cuenta de cuántas personas son mayores de edad (≥ 18)
- El promedio se calcula igual que en el ejemplo de las notas

</v-clicks>

<!--
No revelar la solución todavía. Dejar que los estudiantes intenten
resolverlo con estas pistas antes de pasar a la siguiente diapositiva.
-->

---

# Solución en PSeInt (parte 1)

```text
Definir edades Como Entero
Definir i, mayorEdad, menorEdad, contador Como Entero
Definir suma, promedio Como Real

Dimension edades[10]
suma <- 0
contador <- 0
```

<!--
Explicar por qué se usa "Si i = 1" para inicializar mayor y menor
con el primer valor leído, en lugar de un valor arbitrario fijo.
-->

---

# Solución en PSeInt (parte 2)

```text
Para i <- 1 Hasta 10 Hacer
    Escribir "Ingrese la edad ", i, ":"
    Leer edades[i]
    suma <- suma + edades[i]

    Si i = 1 Entonces
        mayorEdad <- edades[i]
        menorEdad <- edades[i]
    SiNo
        Si edades[i] > mayorEdad Entonces
            mayorEdad <- edades[i]
        FinSi
        Si edades[i] < menorEdad Entonces
            menorEdad <- edades[i]
        FinSi
    FinSi

    Si edades[i] >= 18 Entonces
        contador <- contador + 1
    FinSi
FinPara
```

---

# Solución en PSeInt (parte 3)

```text
promedio <- suma / 10

Escribir "Edad mayor: ", mayorEdad
Escribir "Edad menor: ", menorEdad
Escribir "Promedio: ", promedio
Escribir "Personas mayores de edad: ", contador
```

---

# Solución en C# (parte 1)

```csharp {all|1-3|5-23|7-9|11-22}
int[] edades = new int[10];
double suma = 0;
int mayorEdad = 0, menorEdad = 0, contador = 0;

for (int i = 0; i < edades.Length; i++)
{
    Console.Write($"Ingrese la edad {i + 1}: ");
    edades[i] = int.Parse(Console.ReadLine()!);
    suma += edades[i];

    if (i == 0)
    {
        mayorEdad = edades[i];
        menorEdad = edades[i];
    }
    else
    {
        if (edades[i] > mayorEdad) mayorEdad = edades[i];
        if (edades[i] < menorEdad) menorEdad = edades[i];
    }

    if (edades[i] >= 18) contador++;
}
```

<!--
Notar el paralelo exacto entre "Si i = 1" en PSeInt e "if (i == 0)"
en C#: misma idea, diferente punto de partida del índice.
-->

---

# Solución en C# (parte 2)

```csharp {all|1|3-6}
double promedio = suma / edades.Length;

Console.WriteLine($"Edad mayor: {mayorEdad}");
Console.WriteLine($"Edad menor: {menorEdad}");
Console.WriteLine($"Promedio: {promedio}");
Console.WriteLine($"Personas mayores de edad: {contador}");
```

---

# Resumen del tema

```text
ESTRUCTURAS DE DATOS
        │
        ├── Arrays
        │     ├── Índices
        │     ├── Elementos
        │     └── Recorrido
        │
        ├── Cadenas
        │     ├── string
        │     ├── Caracteres
        │     └── Operaciones
        │
        └── Estructuras simples
              ├── Datos relacionados
              └── struct
```

<!--
Repasar el mapa completo del tema antes de pasar a las preguntas
de repaso, conectando cada rama con lo visto en clase.
-->

---
layout: section
---

# Preguntas de repaso

---

# Preguntas (1/2)

<v-clicks>

1. ¿Qué es un array?
2. ¿Qué es un índice?
3. ¿Por qué en C# los índices comienzan normalmente en 0?
4. ¿Qué diferencia existe entre `char` y `string`?
5. ¿Qué hace `.Length`?

</v-clicks>

<!--
Dar tiempo para que los estudiantes respondan verbalmente antes de
avanzar a las siguientes preguntas y luego a las respuestas.
-->

---

# Preguntas (2/2)

<v-clicks>

6. ¿Para qué sirve `struct`?
7. ¿Qué ventaja tiene utilizar un array en lugar de variables sueltas?
8. ¿Cuándo conviene utilizar una estructura de datos?
9. ¿Qué diferencia existe entre PSeInt y C# al trabajar con arrays?
10. ¿Qué información agruparías en un `struct` para representar un "Libro"?

</v-clicks>

<!--
La pregunta 10 es abierta y sirve como puente hacia el siguiente
tema; se puede discutir brevemente en grupo.
-->

---

# Respuestas clave

<div class="text-sm">

<v-clicks>

- **Array**: estructura que almacena varios elementos del mismo tipo bajo un solo nombre, accesibles por índice
- **Índice**: número que indica la posición de un elemento dentro del array
- **Índice en C# desde 0**: por convención del lenguaje (y de muchos lenguajes derivados de C)
- **`char` vs `string`**: `char` es un solo carácter, `string` es una secuencia de caracteres
- **`.Length`**: propiedad que indica la cantidad de elementos (array) o caracteres (cadena)
- **`struct`**: agrupa datos relacionados de distinto tipo en una sola entidad
- **Ventaja del array**: permite manejar muchos datos con un solo nombre y recorrerlos con ciclos
- **Cuándo usar una estructura de datos**: cuando se necesita organizar, recorrer o relacionar múltiples datos
- **PSeInt vs C#**: PSeInt suele indexar desde 1 y no tiene `struct` nativo; C# indexa desde 0 y sí tiene `struct`

</v-clicks>

</div>

<!--
Revisar cada respuesta con el grupo, permitiendo que ellos mismos
las completen antes de mostrar el texto completo.
-->

---
layout: center
class: text-center
---

# ¡Gracias!

### Próximo tema: estructuras de datos dinámicas

<div class="mt-6 text-sm opacity-70">
Preguntas y dudas sobre arrays, cadenas o estructuras simples
</div>

<!--
Cerrar la sesión indicando que los siguientes temas cubrirán listas
enlazadas, pilas, colas y otras estructuras más avanzadas.
-->