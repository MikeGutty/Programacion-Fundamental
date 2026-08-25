---
theme: default
title: Tema 3 - Estructuras de Control
info: |
  ## Estructuras de Control
  Condicionales, Bucles e Iteraciones
  Comparativa C# vs PSeint
class: text-center
transition: slide-left
mdc: true
fonts:
  sans: 'Inter'
  mono: 'Fira Code'
---

# Tema 3: Estructuras de Control

### Condicionales y Bucles en C# vs PSeint

<br>

<div class="pt-8">
  <span class="text-sm opacity-70">Usa las flechas del teclado para navegar →</span>
</div>

---
layout: default
---

# Agenda

<br>

<v-clicks>

- 📌 **3.1** Estructuras condicionales: `if`, `else`, `if-else`, `switch`
  - Concepto y sintaxis
  - Comparativa C# vs PSeint
  - Algoritmo práctico resuelto en ambos lenguajes

- 🔁 **3.2** Bucles e iteraciones: `for`, `while`, `do-while`
  - Concepto y sintaxis
  - Comparativa C# vs PSeint
  - Algoritmo práctico resuelto en ambos lenguajes

- ✅ Comparación general y conclusiones

</v-clicks>

---
layout: section
---

# 3.1 Estructuras Condicionales

if · else · if-else · switch

---

# ¿Qué son las estructuras condicionales?

<br>

Permiten que un programa **tome decisiones** y ejecute distintos bloques de código según si una condición es **verdadera** o **falsa**.

<br>

<div grid="~ cols-2 gap-6">
<div>

### 🧩 Tipos principales

- **if**: ejecuta un bloque si la condición es verdadera
- **if-else**: ejecuta un bloque u otro según la condición
- **if-else if-else**: evalúa varias condiciones en cadena
- **switch**: selecciona un bloque entre múltiples casos posibles

</div>
<div>

### 💡 ¿Cuándo usarlas?

- Validar datos de entrada
- Clasificar valores (rangos, categorías)
- Tomar decisiones según opciones de un menú
- Controlar el flujo según reglas de negocio

</div>
</div>

---

# Sintaxis básica: `if / else`

<div grid="~ cols-2 gap-4">
<div>

### C#

```csharp {all}
if (condicion)
{
    // se ejecuta si es verdadera
}
else
{
    // se ejecuta si es falsa
}
```

</div>
<div>

### PSeint

```text
Si condicion Entonces
    // se ejecuta si es verdadera
SiNo
    // se ejecuta si es falsa
FinSi
```

</div>
</div>

<br>

<div class="text-sm opacity-70">

⚠️ En C# las condiciones van entre paréntesis `()` y el bloque entre llaves `{}`.
En PSeint, el bloque **Si...Entonces...SiNo...FinSi** no usa paréntesis ni llaves.

</div>

---

# Sintaxis: `switch` / `Segun`

<div grid="~ cols-2 gap-4">
<div>

### C#

```csharp
switch (opcion)
{
    case 1:
        Console.WriteLine("Uno");
        break;
    case 2:
        Console.WriteLine("Dos");
        break;
    default:
        Console.WriteLine("Otro");
        break;
}
```

</div>
<div>

### PSeint

```text
Segun opcion Hacer
    1:
        Escribir "Uno";
    2:
        Escribir "Dos";
    De Otro Modo:
        Escribir "Otro";
FinSegun
```

</div>
</div>

<br>

<div class="text-sm opacity-70">

🔑 En C# cada caso requiere <code>break;</code> para no continuar al siguiente.
En PSeint, cada opción de <b>Segun</b> ya es independiente, no requiere una instrucción equivalente.

</div>

---
layout: section
---

# Algoritmo práctico 3.1

Clasificación de un estudiante según su nota final

---

# Problema práctico

<br>

> **Enunciado:** Desarrollar un algoritmo que reciba la **nota final** de un estudiante (0 a 100) y muestre su **calificación** según el siguiente criterio:

<br>

| Rango de nota | Calificación |
|---|---|
| 90 - 100 | Excelente |
| 70 - 89  | Bueno |
| 50 - 69  | Regular |
| 0 - 49   | Reprobado |

<br>

Se debe validar que la nota ingresada esté entre **0 y 100**; si no, mostrar un mensaje de error.

---

# Solución en PSeint

<div class="code-compact">

```text {all|1-3|4-6|7-16|17-20}
Algoritmo ClasificacionEstudiante
    Definir nota Como Entero;
    Escribir "Ingrese la nota final del estudiante (0-100):";
    Leer nota;

    Si nota < 0 O nota > 100 Entonces
        Escribir "Error: la nota debe estar entre 0 y 100";
    SiNo
        Si nota >= 90 Entonces
            Escribir "Calificacion: Excelente";
        SiNo
            Si nota >= 70 Entonces
                Escribir "Calificacion: Bueno";
            SiNo
                Si nota >= 50 Entonces
                    Escribir "Calificacion: Regular";
                SiNo
                    Escribir "Calificacion: Reprobado";
                FinSi
            FinSi
        FinSi
    FinSi
FinAlgoritmo
```

</div>

---

# Solución en C#

<div class="code-compact">

```csharp {all|1-3|5-6|8-21|all}
using System;

class ClasificacionEstudiante
{
    static void Main()
    {
        Console.WriteLine("Ingrese la nota final del estudiante (0-100):");
        int nota = Convert.ToInt32(Console.ReadLine());

        if (nota < 0 || nota > 100)
        {
            Console.WriteLine("Error: la nota debe estar entre 0 y 100");
        }
        else if (nota >= 90)
        {
            Console.WriteLine("Calificacion: Excelente");
        }
        else if (nota >= 70)
        {
            Console.WriteLine("Calificacion: Bueno");
        }
        else if (nota >= 50)
        {
            Console.WriteLine("Calificacion: Regular");
        }
        else
        {
            Console.WriteLine("Calificacion: Reprobado");
        }
    }
}
```

</div>

---

# Comparación del algoritmo 3.1

<br>

| Aspecto | PSeint | C# |
|---|---|---|
| Declaración de variables | `Definir nota Como Entero;` | `int nota;` |
| Entrada de datos | `Leer nota;` | `Console.ReadLine()` + conversión |
| Condicional múltiple | `Si...SiNo Si...FinSi` anidado | `if...else if...else` |
| Operador lógico OR | `O` | `\|\|` |
| Salida de datos | `Escribir "texto";` | `Console.WriteLine("texto");` |
| Fin de instrucción | `;` | `;` |

<br>

💡 **Idea clave**: la lógica de decisión es **idéntica** en ambos; solo cambia la **sintaxis** propia de cada herramienta.

---
layout: section
---

# 3.2 Bucles e Iteraciones

for · while · do-while

---

# ¿Qué son los bucles?

<br>

Permiten **repetir** un bloque de instrucciones varias veces, mientras se cumpla una condición, evitando escribir código repetido.

<br>

<div grid="~ cols-2 gap-6">
<div>

### 🔁 Tipos principales

- **for**: se usa cuando se conoce el número de repeticiones
- **while**: repite mientras la condición sea verdadera (se evalúa **antes**)
- **do-while**: repite al menos **una vez**, evalúa la condición **al final**

</div>
<div>

### 💡 ¿Cuándo usarlos?

- Recorrer listas, arreglos o rangos de valores
- Acumular sumas, contadores, promedios
- Validar datos ingresados por el usuario (repetir hasta que sean correctos)
- Menús interactivos que se repiten hasta salir

</div>
</div>

---

# Sintaxis: `for`

<div grid="~ cols-2 gap-4">
<div>

### C#

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
```

</div>
<div>

### PSeint

```text
Para i <- 1 Hasta 5 Con Paso 1 Hacer
    Escribir i;
FinPara
```

</div>
</div>

<br>

<div class="text-sm opacity-70">

🔑 El <b>for</b> de C# tiene tres partes: inicialización, condición e incremento.
El <b>Para</b> de PSeint usa <b>Hasta</b> para el límite y <b>Con Paso</b> para el incremento (opcional, por defecto es 1).

</div>

---

# Sintaxis: `while` y `do-while`

<div grid="~ cols-2 gap-4">
<div>

### C#

```csharp
// while
int i = 1;
while (i <= 5)
{
    Console.WriteLine(i);
    i++;
}

// do-while
int j = 1;
do
{
    Console.WriteLine(j);
    j++;
} while (j <= 5);
```

</div>
<div>

### PSeint

```text
// Mientras (equivalente a while)
i <- 1;
Mientras i <= 5 Hacer
    Escribir i;
    i <- i + 1;
FinMientras

// Repetir (equivalente a do-while)
j <- 1;
Repetir
    Escribir j;
    j <- j + 1;
Hasta Que j > 5
```

</div>
</div>

<div class="text-sm opacity-70 mt-2">

⚠️ Ojo: <b>Repetir...Hasta Que</b> en PSeint termina cuando la condición se cumple (es lo contrario a "mientras sea verdadera").

</div>

---
layout: section
---

# Algoritmo práctico 3.2

Suma de números y validación con reintento

---

# Problema práctico

<br>

> **Enunciado:** Desarrollar un algoritmo que solicite al usuario **cuántos números** desea sumar (debe ser mayor a 0; si no, se le vuelve a pedir usando un bucle de validación). Luego, mediante un bucle **for**, pedir cada número y calcular la **suma total** y el **promedio**.

<br>

**Pasos:**
1. Pedir la cantidad de números (validar con `do-while` / `Repetir`)
2. Leer cada número con un bucle `for` / `Para`
3. Acumular la suma
4. Calcular y mostrar el promedio

---

# Solución en PSeint

<div class="code-compact">

```text {all|1-3|4-10|11-19|20-21}
Algoritmo SumaYPromedio
    Definir cantidad, numero, i Como Entero;
    Definir suma, promedio Como Real;

    Repetir
        Escribir "Ingrese la cantidad de numeros a sumar:";
        Leer cantidad;
        Si cantidad <= 0 Entonces
            Escribir "Debe ingresar un numero mayor a 0";
        FinSi
    Hasta Que cantidad > 0

    suma <- 0;
    Para i <- 1 Hasta cantidad Con Paso 1 Hacer
        Escribir "Ingrese el numero ", i, ":";
        Leer numero;
        suma <- suma + numero;
    FinPara

    promedio <- suma / cantidad;
    Escribir "La suma total es: ", suma;
    Escribir "El promedio es: ", promedio;
FinAlgoritmo
```

</div>

---

# Solución en C#

<div class="code-compact">

```csharp {all|1-3|5-6|8-18|20-28}
using System;

class SumaYPromedio
{
    static void Main()
    {
        int cantidad, numero;
        double suma = 0, promedio;

        do
        {
            Console.WriteLine("Ingrese la cantidad de numeros a sumar:");
            cantidad = Convert.ToInt32(Console.ReadLine());
            if (cantidad <= 0)
            {
                Console.WriteLine("Debe ingresar un numero mayor a 0");
            }
        } while (cantidad <= 0);

        for (int i = 1; i <= cantidad; i++)
        {
            Console.WriteLine($"Ingrese el numero {i}:");
            numero = Convert.ToInt32(Console.ReadLine());
            suma += numero;
        }

        promedio = suma / cantidad;
        Console.WriteLine($"La suma total es: {suma}");
        Console.WriteLine($"El promedio es: {promedio}");
    }
}
```

</div>

---

# Comparación del algoritmo 3.2

<br>

| Aspecto | PSeint | C# |
|---|---|---|
| Bucle de validación | `Repetir...Hasta Que` | `do { } while(...)` |
| Bucle contado | `Para i <- 1 Hasta n Hacer...FinPara` | `for (int i = 1; i <= n; i++) { }` |
| Acumulador | `suma <- suma + numero;` | `suma += numero;` |
| Tipo decimal | `Como Real` | `double` |
| Interpolación de texto | `Escribir "texto", variable;` | `$"texto {variable}"` |

<br>

💡 **Idea clave**: `Repetir...Hasta Que` **termina cuando la condición es verdadera**, mientras que `do-while` **continúa mientras sea verdadera** — ¡son lógicamente opuestos en su condición de salida!

---

# Cuadro comparativo general

<br>

| Estructura | PSeint | C# | Evalúa la condición |
|---|---|---|---|
| Condicional simple | `Si...FinSi` | `if { }` | — |
| Condicional doble | `Si...SiNo...FinSi` | `if { } else { }` | — |
| Selección múltiple | `Segun...FinSegun` | `switch { }` | — |
| Bucle contado | `Para...FinPara` | `for ( ; ; ) { }` | Antes de cada iteración |
| Bucle condicional | `Mientras...FinMientras` | `while ( ) { }` | Antes (0 o más veces) |
| Bucle con validación | `Repetir...Hasta Que` | `do { } while ( )` | Después (mínimo 1 vez) |

---
layout: center
class: text-center
---

# Conclusiones

<div class="text-left max-w-2xl mx-auto">

- Las **estructuras condicionales** permiten tomar decisiones; las **estructuras repetitivas** permiten automatizar tareas repetitivas.
- **PSeint** es ideal para diseñar y entender la lógica del algoritmo en español, antes de programar.
- **C#** traduce esa misma lógica a un lenguaje de programación real, con sintaxis más estricta (tipos, llaves, punto y coma).
- Practicar primero en PSeint facilita luego escribir el código equivalente en C#, ya que la **lógica no cambia**, solo la **sintaxis**.

</div>

<br>

## ¡Gracias! 🎓

<div class="text-sm opacity-60">Preguntas y práctica en clase</div>