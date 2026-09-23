# Taller de Structs en C#: Organizando datos como profesionales

¡Bienvenido/a al mundo de los structs! Hasta ahora guardabas datos sueltos en variables; hoy aprenderás a **agruparlos en una sola "ficha"** que represente algo real: un estudiante, un producto o un punto en un mapa. Verás que tu código se vuelve más ordenado, más claro y mucho más parecido a los programas que se usan en la vida real. ¡Manos a la obra!

---

## Ejercicio 1: La ficha del estudiante

**Enunciado:** La biblioteca de la universidad necesita registrar a un estudiante. Crea un struct llamado `Estudiante` que guarde su nombre, su código y su edad. El programa debe pedir estos datos por consola, guardarlos en una variable de tipo `Estudiante` y mostrarlos ordenadamente en pantalla.

**Objetivo de aprendizaje:** Declarar un struct, crear una variable de ese tipo y acceder a sus campos con el operador punto (`.`) para asignar y leer valores.

**Pistas técnicas:**
- Declara el struct fuera del método `Main`, con campos públicos:
  ```csharp
  struct Estudiante
  {
      public string Nombre;
      public int Codigo;
      public int Edad;
  }
  ```
- Dentro de `Main`, crea la variable así: `Estudiante e = new Estudiante();`
- Usa `int.Parse(Console.ReadLine())` para leer números.

**Restricciones:**
- Trabaja con un solo estudiante.
- No uses arreglos, métodos adicionales ni constructores personalizados.

**Ejemplo de entrada y salida:**
```
Ingrese el nombre: Camila Rojas
Ingrese el código: 20261045
Ingrese la edad: 18

--- Ficha del estudiante ---
Nombre: Camila Rojas
Código: 20261045
Edad: 18 años
```

---

## Ejercicio 2: Distancia entre dos puntos

**Enunciado:** Estás creando una app de mapas sencilla. Define un struct `Punto` con las coordenadas `X` e `Y` (tipo `double`). Pide al usuario las coordenadas de dos puntos, y calcula y muestra la distancia entre ellos. Para ello, crea un método estático `CalcularDistancia` que reciba los dos puntos como parámetros y devuelva el resultado.

**Objetivo de aprendizaje:** Usar structs como parámetros de un método, y combinar datos agrupados con operaciones matemáticas.

**Pistas técnicas:**
- Fórmula de la distancia: `√((x2 − x1)² + (y2 − y1)²)`
- Usa `Math.Sqrt()` y `Math.Pow()`.
- Firma sugerida: `static double CalcularDistancia(Punto a, Punto b)`

**Restricciones:**
- No uses arreglos.
- No uses métodos que no sean `CalcularDistancia` (más allá de `Main`).

**Ejemplo de entrada y salida:**
```
Punto A - X: 1
Punto A - Y: 2
Punto B - X: 4
Punto B - Y: 6

La distancia entre los puntos es: 5.00
```

---

## Ejercicio 3: Inventario de la tienda

**Enunciado:** La tienda del barrio quiere controlar cinco productos. Crea un struct `Producto` con nombre, precio y cantidad en stock. Guarda los 5 productos en un arreglo de structs, pídelos por consola con un bucle, y al final muestra la lista completa junto con el **valor total del inventario** (suma de precio × cantidad de cada producto) y el nombre del producto **más caro**.

**Objetivo de aprendizaje:** Manejar arreglos de structs, recorrerlos con bucles para llenar y consultar datos, y realizar cálculos acumulados sobre sus campos.

**Pistas técnicas:**
- Declara el arreglo: `Producto[] inventario = new Producto[5];`
- Dentro del bucle, accede a cada elemento así: `inventario[i].Precio`
- Usa una variable auxiliar para guardar la posición del producto más caro.

**Restricciones:**
- Usa exactamente 5 productos (arreglo de tamaño fijo).
- No uses `List<T>`, ni `foreach` con colecciones avanzadas (basta con `for`).

**Ejemplo de entrada y salida (con 3 productos para abreviar):**
```
Producto 1 - Nombre: Arroz
Producto 1 - Precio: 5.5
Producto 1 - Cantidad: 10
Producto 2 - Nombre: Aceite
Producto 2 - Precio: 12
Producto 2 - Cantidad: 4
Producto 3 - Nombre: Azúcar
Producto 3 - Precio: 4
Producto 3 - Cantidad: 20

--- Inventario ---
Arroz  | Bs 5.50  | Stock: 10
Aceite | Bs 12.00 | Stock: 4
Azúcar | Bs 4.00  | Stock: 20

Valor total del inventario: Bs 183.00
Producto más caro: Aceite
```

---

## Ejercicio 4: Agenda de cumpleaños con structs anidados

**Enunciado:** Crea una pequeña agenda de cumpleaños para 4 amigos. Define un struct `Fecha` (día, mes) y un struct `Amigo` que contenga un nombre y un campo de tipo `Fecha`. Llena el arreglo por consola y luego pide al usuario un mes (1 a 12): el programa debe mostrar quiénes cumplen años en ese mes, o un mensaje amable si nadie cumple. Usa un método estático `MostrarCumpleaneros` que reciba el arreglo y el mes.

**Objetivo de aprendizaje:** Anidar un struct dentro de otro, acceder a campos en varios niveles (`amigos[i].Cumple.Mes`), y combinar arreglos, bucles, condicionales y métodos con structs.

**Pistas técnicas:**
- Define primero `Fecha` y luego `Amigo`:
  ```csharp
  struct Fecha
  {
      public int Dia;
      public int Mes;
  }

  struct Amigo
  {
      public string Nombre;
      public Fecha Cumple;
  }
  ```
- Firma sugerida: `static void MostrarCumpleaneros(Amigo[] amigos, int mes)`
- Usa una bandera (`bool encontrado`) para saber si hubo al menos una coincidencia.

**Restricciones:**
- Usa exactamente 4 amigos.
- No es necesario validar que el día sea correcto para el mes (por ejemplo, 31 de febrero).
- No uses `List<T>`, LINQ ni clases.

**Ejemplo de entrada y salida:**
```
Amigo 1 - Nombre: Luis
Amigo 1 - Día: 15
Amigo 1 - Mes: 3
Amigo 2 - Nombre: Ana
Amigo 2 - Día: 8
Amigo 2 - Mes: 7
Amigo 3 - Nombre: Pedro
Amigo 3 - Día: 22
Amigo 3 - Mes: 3
Amigo 4 - Nombre: Sofía
Amigo 4 - Día: 30
Amigo 4 - Mes: 11

¿Qué mes quieres consultar? 3

Cumpleaños en el mes 3:
- Luis (día 15)
- Pedro (día 22)
```

---

## Criterios de evaluación sugeridos

| Ejercicio | Qué se evalúa | Peso sugerido |
|-----------|---------------|---------------|
| **1. La ficha del estudiante** | Declaración correcta del struct; asignación y lectura de campos con el operador punto; conversión de tipos al leer datos; salida clara y ordenada. | 15 % |
| **2. Distancia entre dos puntos** | Uso de structs como parámetros; método estático con retorno correcto; aplicación de la fórmula con `Math`; formato de salida con decimales. | 20 % |
| **3. Inventario de la tienda** | Uso de arreglos de structs; recorrido con `for` para llenar y mostrar; cálculo correcto del acumulado y del máximo; claridad en la presentación. | 30 % |
| **4. Agenda de cumpleaños** | Anidación correcta de structs; acceso a campos en varios niveles; lógica de búsqueda con condicional y bandera; uso adecuado de un método con arreglo como parámetro. | 35 % |
| **Transversal (todos)** | Nombres de variables descriptivos, código indentado y legible, comentarios breves y ausencia de conceptos no permitidos. | Incluido en cada ejercicio |