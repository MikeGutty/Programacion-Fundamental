# 📚 Tema 2: Tipos de Datos, Variables y Operadores

## 🎯 Propósito

En este tema aprenderemos a representar información dentro de nuestros programas mediante **tipos de datos y variables**, y a realizar operaciones utilizando **operadores**.

Estos conceptos serán fundamentales para los siguientes temas, especialmente cuando empecemos a construir expresiones y estructuras de control.

---

## 1. 🧩 Tipos de datos

Un tipo de dato define qué clase de información puede almacenar una variable.

Algunos de los tipos más utilizados en C# son:

| Tipo      | Uso                                             | Ejemplo   |
| --------- | ----------------------------------------------- | --------- |
| `int`     | Números enteros                                 | `25`      |
| `double`  | Números decimales                               | `25.5`    |
| `decimal` | Valores decimales que requieren mayor precisión | `150.75m` |
| `char`    | Un carácter                                     | `'A'`     |
| `string`  | Texto                                           | `"Hola"`  |
| `bool`    | Verdadero o falso                               | `true`    |

> 💡 **Idea clave:** Antes de crear una variable debemos preguntarnos **qué tipo de información necesitamos almacenar**.

---

## 2. 📦 Variables

Una variable permite almacenar un valor que puede utilizarse durante la ejecución del programa.

Por ejemplo:

```csharp
int edad = 20;
string nombre = "Carlos";
double promedio = 85.5;
bool estudianteActivo = true;
```

Podemos interpretar:

```text
int edad = 20;
│   │      │
│   │      └── Valor
│   └───────── Nombre
└───────────── Tipo
```

Una variable puede cambiar su valor:

```csharp
int edad = 20;

edad = 21;
```

Sin embargo, su tipo no cambia.

> 📌 **Recuerda:** una variable tiene un tipo, un nombre y un valor.

---

## 3. 🏷️ Nombres de variables

Los nombres deben permitir comprender qué información representa la variable.

### ❌ Poco descriptivo

```csharp
int x = 20;
double n = 85.5;
```

### ✅ Más descriptivo

```csharp
int edad = 20;
double promedio = 85.5;
```

Una buena práctica es utilizar nombres claros y consistentes.

En C# es habitual utilizar `camelCase` para variables locales:

```csharp
string nombreCompleto;
int cantidadProductos;
double precioTotal;
```

---

## 4. 🔢 Operadores

Los operadores permiten realizar operaciones con valores y variables.

Los principales operadores que estudiaremos son:

### Operadores aritméticos

| Operador | Operación      |
| -------- | -------------- |
| `+`      | Suma           |
| `-`      | Resta          |
| `*`      | Multiplicación |
| `/`      | División       |
| `%`      | Módulo         |

Ejemplo:

```csharp
int resultado = 10 + 5;
```

### Operadores de comparación

| Operador | Significado   |
| -------- | ------------- |
| `==`     | Igual         |
| `!=`     | Diferente     |
| `>`      | Mayor         |
| `<`      | Menor         |
| `>=`     | Mayor o igual |
| `<=`     | Menor o igual |

Estos operadores producen un resultado booleano:

```csharp
int edad = 20;

bool esMayor = edad >= 18;
```

### Operadores lógicos

| Operador | Significado |   |    |
| -------- | ----------- | - | -- |
| `&&`     | AND         |   |    |
| `        |             | ` | OR |
| `!`      | NOT         |   |    |

Los utilizaremos principalmente cuando trabajemos con condiciones.

---

## 5. 📝 Asignación

El operador `=` permite asignar un valor a una variable:

```csharp
int edad = 20;
```

También podemos actualizar su valor:

```csharp
edad = 21;
```

No debemos confundir:

```csharp
=
```

con:

```csharp
==
```

El primero **asigna** y el segundo **compara**.

---

## 6. 🧮 Expresiones

Una expresión combina valores, variables y operadores para producir un resultado.

Por ejemplo:

```csharp
int precio = 100;
int cantidad = 3;

int total = precio * cantidad;
```

La expresión:

```text
precio * cantidad
```

produce:

```text
300
```

Podemos utilizar paréntesis para controlar el orden de las operaciones:

```csharp
int resultado = (10 + 5) * 2;
```

---

## 7. ⚠️ Consideraciones importantes

### División entre enteros

Cuando trabajamos con valores `int`, debemos tener cuidado con la división:

```csharp
int resultado = 5 / 2;
```

El resultado es:

```text
2
```

Si necesitamos conservar la parte decimal, debemos trabajar con un tipo apropiado:

```csharp
double resultado = 5.0 / 2;
```

Resultado:

```text
2.5
```

### Compatibilidad de tipos

C# utiliza un sistema de tipos que ayuda a detectar operaciones incompatibles antes de ejecutar el programa.

Por ejemplo:

```csharp
int edad = 20;
bool activo = true;
```

No podemos realizar directamente una operación como:

```csharp
// ❌ No válido
// int resultado = edad + activo;
```

Esto es parte de la **seguridad de tipos** del lenguaje.

---

## 8. 💻 Ejemplo de integración

Los conceptos del tema pueden combinarse en un pequeño programa:

```csharp
string producto = "Teclado";
double precio = 150.50;
int cantidad = 2;

double total = precio * cantidad;

Console.WriteLine($"Producto: {producto}");
Console.WriteLine($"Precio: {precio}");
Console.WriteLine($"Cantidad: {cantidad}");
Console.WriteLine($"Total: {total}");
```

Aquí estamos utilizando:

* `string`
* `double`
* `int`
* Variables
* Asignación
* Multiplicación
* Expresiones
* Interpolación de cadenas

---

## 🧠 Para recordar

Antes de continuar con el siguiente tema, asegúrate de comprender estas ideas:

```text
Tipo de dato
     ↓
¿Qué clase de información voy a almacenar?

Variable
     ↓
¿Dónde voy a almacenar esa información?

Operador
     ↓
¿Qué operación necesito realizar?

Expresión
     ↓
¿Qué resultado quiero obtener?
```

---

## 🔗 Material relacionado

* 📊 [Presentación del Tema 2](../presentacion/slides.md)
* 💻 [Ejemplos](../ejemplos/)
* ✏️ [Ejercicios](../ejercicios/ejercicios.md)

### 📖 Documentación recomendada

* [Sistema de tipos de C# — Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/types/)
* [Tipos integrados de C# — Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/types/built-in-types)
* [Operadores y expresiones — Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/operators/)

---

> 🎓 **Recomendación del docente**
>
> No intentes memorizar todos los tipos y operadores. Lo importante es aprender a identificar **qué información necesita un problema, cómo representarla y qué operaciones debemos realizar sobre ella**.
