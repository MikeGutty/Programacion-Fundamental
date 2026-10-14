# Tarea: Programación Orientada a Objetos en C#

**Tema:** Clases, atributos, métodos, constructores, instancias de objetos y encapsulamiento (`public` y `private`)

---

## Instrucciones generales

- Resuelve los **7 ejercicios** en C#. Los ejercicios están ordenados de menor a mayor dificultad.
- Cada ejercicio debe tener su propio proyecto de consola (o una carpeta separada dentro de la solución).
- Cada clase debe ir en su propio archivo `.cs`, salvo que el ejercicio indique lo contrario.
- Usa nombres de clases, atributos y métodos claros y con la convención de C# (`PascalCase` para clases y métodos, `camelCase` para atributos).
- Los atributos indicados como **privados** deben declararse con `private`. Solo se pueden usar y modificar **desde dentro de la propia clase** (en el constructor y en los métodos de la clase).
- Los atributos indicados como **públicos** se declaran con `public` y pueden usarse desde cualquier parte, incluido el `Main`.
- Comenta brevemente tu código explicando qué hace cada clase y cada método.
- Entrega el código fuente (`.cs`) y una captura de pantalla de la ejecución de cada ejercicio.

---

## Material de apoyo: la estructura `List<T>`

En los ejercicios **6 y 7** necesitarás guardar **varios objetos** dentro de otra clase (por ejemplo, varios productos dentro de una tienda). Para eso usaremos `List<T>`.

### ¿Qué es una `List<T>`?

Una `List<T>` es una **lista dinámica**: una colección ordenada de elementos del mismo tipo que **crece o se reduce automáticamente** según agregues o quites elementos. A diferencia de un arreglo (`int[]`), no necesitas definir su tamaño de antemano.

La `T` se reemplaza por el tipo de dato que guardará la lista:

- `List<int>`: lista de enteros.
- `List<string>`: lista de textos.
- `List<Producto>`: lista de objetos de tipo `Producto`.

### Cómo usarla

Para usar `List` debes agregar este `using` al inicio del archivo:

```csharp
using System.Collections.Generic;
```

> En proyectos nuevos de .NET suele estar incluido automáticamente, pero conviene escribirlo para que quede claro.

### Declarar e inicializar

```csharp
List<string> nombres = new List<string>();
```

Si la lista es un **atributo de una clase**, se declara arriba y se **inicializa en el constructor**:

```csharp
class Tienda
{
    private List<Producto> productos;

    public Tienda()
    {
        productos = new List<Producto>();   // ¡No olvidar esta línea!
    }
}
```

> **Error común:** si declaras la lista pero no escribes `new List<...>()`, la lista vale `null` y el programa se cae al usarla con el error `NullReferenceException`.

### Operaciones principales

| Operación | Código | Descripción |
|---|---|---|
| Agregar al final | `lista.Add(elemento);` | Añade un elemento a la lista. |
| Cantidad de elementos | `lista.Count` | Retorna cuántos elementos hay (es un valor, **sin paréntesis**). |
| Acceder por posición | `lista[0]` | Retorna el elemento de esa posición (la primera es la `0`). |
| Quitar por posición | `lista.RemoveAt(2);` | Elimina el elemento de la posición indicada. |
| Quitar un elemento | `lista.Remove(elemento);` | Elimina el elemento indicado (retorna `true` si lo encontró). |
| Verificar si existe | `lista.Contains(elemento)` | Retorna `true` si el elemento está en la lista. |
| Vaciar la lista | `lista.Clear();` | Elimina todos los elementos. |

### Ejemplo con tipos simples

```csharp
List<int> numeros = new List<int>();

numeros.Add(10);
numeros.Add(25);
numeros.Add(7);

Console.WriteLine(numeros.Count);   // 3
Console.WriteLine(numeros[1]);      // 25

numeros.RemoveAt(0);                // Elimina el 10
Console.WriteLine(numeros.Count);   // 2
```

### Recorrer una lista

Con `foreach` (recomendado cuando solo necesitas leer cada elemento):

```csharp
foreach (int n in numeros)
{
    Console.WriteLine(n);
}
```

Con `for` (cuando necesitas la posición):

```csharp
for (int i = 0; i < numeros.Count; i++)
{
    Console.WriteLine("Posición " + i + ": " + numeros[i]);
}
```

### Lista de objetos dentro de una clase

Este es el patrón que usarás en los ejercicios 6 y 7. Observa cómo la lista es **privada** y solo se manipula desde los métodos de la clase:

```csharp
class Producto
{
    public int codigo;
    public string nombre;

    public Producto(int codigo, string nombre)
    {
        this.codigo = codigo;
        this.nombre = nombre;
    }
}

class Tienda
{
    private List<Producto> productos;

    public Tienda()
    {
        productos = new List<Producto>();
    }

    // Agregar un objeto a la lista
    public void AgregarProducto(Producto p)
    {
        productos.Add(p);
    }

    // Mostrar todos los objetos de la lista
    public void MostrarInventario()
    {
        foreach (Producto p in productos)
        {
            Console.WriteLine(p.codigo + " - " + p.nombre);
        }
    }

    // Buscar un objeto por un atributo público
    public Producto BuscarProducto(int codigo)
    {
        foreach (Producto p in productos)
        {
            if (p.codigo == codigo)
            {
                return p;       // Lo encontró
            }
        }
        return null;            // No existe
    }
}
```

Uso desde el `Main`:

```csharp
Tienda tienda = new Tienda();
tienda.AgregarProducto(new Producto(1, "Mouse"));
tienda.AgregarProducto(new Producto(2, "Teclado"));

tienda.MostrarInventario();

Producto encontrado = tienda.BuscarProducto(2);
if (encontrado != null)
{
    Console.WriteLine("Encontrado: " + encontrado.nombre);
}
else
{
    Console.WriteLine("Producto no encontrado");
}
```

### Puntos importantes a recordar

1. La lista guarda **referencias** a los objetos: si modificas un objeto que está dentro de la lista (por ejemplo, llamando a `p.Vender(2)`), el cambio se refleja en la lista.
2. Siempre verifica si el resultado de una búsqueda es `null` **antes** de usarlo, o el programa fallará.
3. No modifiques (agregar o quitar elementos) una lista mientras la recorres con `foreach`, porque produce un error. Si necesitas quitar elementos mientras recorres, usa un `for`.
4. Para evitar duplicados, antes de agregar un elemento recorre la lista (o usa un método de búsqueda como `BuscarProducto`) y verifica que no exista.

---

## Ejercicio 1: Clase `Persona` (Nivel: Muy fácil)

**Conceptos:** clase, atributos públicos, instancia de objetos.

Crea una clase `Persona` con los siguientes atributos **públicos**:

- `nombre` (string)
- `edad` (int)
- `ciudad` (string)

En el `Main`:

1. Crea **dos objetos** de tipo `Persona`.
2. Asigna valores a sus atributos directamente.
3. Muestra por consola los datos de ambas personas.

**Salida esperada (ejemplo):**

```
Nombre: Ana | Edad: 20 | Ciudad: Cochabamba
Nombre: Luis | Edad: 22 | Ciudad: La Paz
```

---

## Ejercicio 2: Clase `Rectangulo` (Nivel: Fácil)

**Conceptos:** clase, atributos públicos, métodos.

Crea una clase `Rectangulo` con los atributos públicos `base` y `altura` (tipo `double`) y los siguientes métodos:

- `CalcularArea()`: retorna el área del rectángulo.
- `CalcularPerimetro()`: retorna el perímetro del rectángulo.
- `MostrarInformacion()`: imprime la base, la altura, el área y el perímetro.

En el `Main`:

1. Pide al usuario la base y la altura por consola.
2. Crea un objeto `Rectangulo` y asigna esos valores.
3. Llama a `MostrarInformacion()`.

---

## Ejercicio 3: Clase `Libro` con constructores (Nivel: Fácil-Medio)

**Conceptos:** constructores (por defecto y parametrizado), atributos públicos, métodos.

Crea una clase `Libro` con los atributos públicos:

- `titulo` (string)
- `autor` (string)
- `anioPublicacion` (int)
- `paginas` (int)

Debe tener:

1. Un **constructor por defecto** que inicialice el título y autor con `"Desconocido"` y el año y las páginas con `0`.
2. Un **constructor parametrizado** que reciba los cuatro valores.
3. Un método `MostrarFicha()` que imprima todos los datos del libro.
4. Un método `EsLibroAntiguo()` que retorne `true` si el libro fue publicado antes del año 2000.

En el `Main`:

- Crea un libro usando el constructor por defecto y otro usando el constructor parametrizado.
- Muestra la ficha de ambos y indica si cada uno es antiguo o no.

---

## Ejercicio 4: Clase `CuentaBancaria` (Nivel: Medio)

**Conceptos:** encapsulamiento (`public` y `private`), constructor, métodos que protegen un atributo privado.

Crea una clase `CuentaBancaria` con:

- Atributo **público**: `titular` (string).
- Atributo **privado**: `saldo` (double).

Debe tener:

1. Un constructor que reciba el titular y el saldo inicial. Si el saldo inicial es negativo, debe quedar en `0`.
2. `Depositar(double monto)`: suma el monto al saldo, solo si el monto es mayor a 0. Si no, muestra un mensaje de error.
3. `Retirar(double monto)`: resta el monto del saldo, solo si el monto es mayor a 0 **y** hay saldo suficiente. En caso contrario, muestra un mensaje de error.
4. `MostrarSaldo()`: imprime el titular y el saldo actual de la cuenta.

En el `Main`:

- Crea una cuenta y realiza varias operaciones (depósitos, retiros válidos y retiros inválidos), mostrando el saldo después de cada una.
- Intenta escribir `cuenta.saldo = 1000;` en el `Main`. Comprueba que el compilador muestra un error, **comenta esa línea** y escribe en un comentario el mensaje de error que apareció y por qué ocurre.

---

## Ejercicio 5: Clase `Estudiante` con validaciones (Nivel: Medio)

**Conceptos:** encapsulamiento, constructor con validaciones, atributos privados, métodos con lógica.

Crea una clase `Estudiante` con:

- Atributos **públicos**: `nombre` (string) y `codigo` (int).
- Atributos **privados**: `nota1`, `nota2` y `nota3` (double).

Debe tener:

1. Un constructor que reciba nombre, código y las tres notas. Si alguna nota no está entre 0 y 100, esa nota debe quedar en `0` y mostrarse un mensaje de advertencia.
2. `CalcularPromedio()`: retorna el promedio de las 3 notas.
3. `ObtenerEstado()`: retorna `"Aprobado"` si el promedio es mayor o igual a 51, o `"Reprobado"` en caso contrario.
4. `MostrarBoletin()`: imprime nombre, código, las tres notas, el promedio y el estado.
5. `EsMejorQue(Estudiante otro)`: retorna `true` si el promedio de este estudiante es mayor que el del estudiante recibido como parámetro.

En el `Main`:

- Crea al menos **3 estudiantes** con distintas notas (incluye uno con una nota inválida, por ejemplo 150).
- Muestra el boletín de cada uno.
- Usa `EsMejorQue` para comparar a dos estudiantes e indica cuál tiene mejor promedio.

---

## Ejercicio 6: Clases `Producto` y `Tienda` (Nivel: Medio-Difícil)

**Conceptos:** múltiples clases, colaboración entre objetos, encapsulamiento, listas de objetos.

> Revisa la sección **"Material de apoyo: la estructura `List<T>`"** antes de comenzar.

Crea la clase `Producto` con:

- Atributos **públicos**: `codigo` (int) y `nombre` (string).
- Atributos **privados**: `precio` (double) y `stock` (int).
- Constructor parametrizado con validación (el precio y el stock no pueden ser negativos; si lo son, quedan en `0`).
- `Vender(int cantidad)`: si la cantidad es mayor a 0 y hay stock suficiente, descuenta del stock, muestra el total a pagar (`precio * cantidad`) y retorna `true`; si no, muestra un mensaje de error y retorna `false`.
- `Reabastecer(int cantidad)`: aumenta el stock solo si la cantidad es mayor a 0.
- `CalcularValorEnStock()`: retorna `precio * stock`.
- `MostrarProducto()`: imprime los datos del producto.

Crea la clase `Tienda` con:

- Atributo **público**: `nombreTienda` (string).
- Atributo **privado**: una lista (`List<Producto>`) de productos.
- `AgregarProducto(Producto p)`: agrega un producto (no debe permitir códigos repetidos).
- `BuscarProducto(int codigo)`: retorna el producto o `null` si no existe.
- `VenderProducto(int codigo, int cantidad)`: busca el producto y, si existe, realiza la venta; si no existe, muestra un mensaje de error.
- `MostrarInventario()`: lista todos los productos.
- `CalcularValorInventario()`: retorna la suma del valor en stock de todos los productos.

En el `Main`:

- Registra al menos 5 productos, realiza ventas (válidas e inválidas), reabastece uno y muestra el inventario y su valor total al final.

---

## Ejercicio 7: Sistema de Biblioteca (Nivel: Difícil)

**Conceptos:** integración de todos los temas: varias clases, constructores, encapsulamiento, relación entre objetos y menú interactivo.

> Este ejercicio usa varias `List<T>`. Repasa la sección **"Material de apoyo: la estructura `List<T>`"**.

Desarrolla un pequeño sistema de gestión de biblioteca con **tres clases**:

### Clase `Libro`
- Atributos **públicos**: `isbn` (string), `titulo` (string) y `autor` (string).
- Atributo **privado**: `disponible` (bool). Al crear el libro, está disponible.
- Constructor parametrizado (isbn, título y autor).
- `Prestar()`: si el libro está disponible lo marca como prestado y retorna `true`; si ya estaba prestado, retorna `false`.
- `Devolver()`: si el libro estaba prestado lo marca como disponible y retorna `true`; si ya estaba disponible, retorna `false`.
- `MostrarLibro()`: imprime isbn, título, autor y si está `Disponible` o `Prestado`.

### Clase `Usuario`
- Atributos **públicos**: `nombre` (string) y `carnet` (int).
- Atributo **privado**: lista de libros prestados (`List<Libro>`), inicializada vacía en el constructor.
- Constructor parametrizado (nombre y carnet).
- Un usuario **no puede tener más de 3 libros prestados** al mismo tiempo.
- `AgregarLibro(Libro l)`: agrega el libro a su lista y retorna `true`, o retorna `false` si ya tiene 3 libros.
- `QuitarLibro(string isbn)`: quita de su lista el libro con ese ISBN y retorna `true`, o retorna `false` si el usuario no tiene ese libro.
- `MostrarPrestamos()`: imprime los libros que el usuario tiene actualmente prestados.

### Clase `Biblioteca`
- Atributo **público**: `nombre` (string).
- Atributos **privados**: lista de libros y lista de usuarios registrados.
- `RegistrarLibro(Libro l)` y `RegistrarUsuario(Usuario u)` (sin duplicados por ISBN y por carnet).
- `PrestarLibro(string isbn, int carnet)`: valida que el libro y el usuario existan, que el libro esté disponible y que el usuario no supere el límite de préstamos. Muestra un mensaje claro según el resultado.
- `DevolverLibro(string isbn, int carnet)`: valida que el usuario tenga ese libro y lo devuelve.
- `MostrarLibrosDisponibles()` y `MostrarPrestamosDeUsuario(int carnet)`.

### Programa principal
Implementa un **menú por consola** con las siguientes opciones:

```
1. Registrar libro
2. Registrar usuario
3. Prestar libro
4. Devolver libro
5. Ver libros disponibles
6. Ver préstamos de un usuario
7. Salir
```

El menú debe repetirse hasta que el usuario elija la opción 7. Antes de entregar, precarga al menos 4 libros y 2 usuarios para probar el sistema.
