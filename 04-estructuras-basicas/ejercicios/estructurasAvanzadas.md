# Ejercicios Prácticos - Tema 5.2: Structs Avanzados

¡De vuelta al taller! Ya sabes declarar structs, anidarlos y usarlos como parámetros. Ahora vamos a combinarlos con todo lo que ya conoces —**condicionales, bucles, funciones, procedimientos, arreglos y strings**— para resolver problemas un poco más exigentes. Todo se resuelve igual que hasta ahora: structs con campos públicos y métodos `static` (funciones o procedimientos) fuera de ellos, sin constructores personalizados ni métodos dentro del struct.

---

## Ejercicio 1: Cuenta bancaria con validaciones

**Enunciado:** Define un struct `CuentaBancaria` con `Titular`, `Saldo` y `NumeroCuenta`. Crea dos **procedimientos estáticos**, `Depositar` y `Retirar`, que reciban la cuenta por referencia (`ref CuentaBancaria`) y el monto de la operación, y que actualicen el saldo solo si la operación es válida (no se permite depositar montos negativos ni retirar más de lo que hay en el saldo). El programa debe crear una cuenta y luego simular 5 operaciones que el usuario ingresa (tipo: `D` para depósito o `R` para retiro, y el monto), mostrando el saldo actualizado después de cada operación y un mensaje de error cuando una operación no sea válida.

**Objetivo de aprendizaje:** Usar el parámetro `ref` para que un procedimiento modifique un struct recibido como argumento (recordando que los structs se copian por valor), y aplicar validaciones con condicionales dentro de un procedimiento.

**Pistas técnicas:**
- Firma sugerida:
  ```csharp
  static void Depositar(ref CuentaBancaria cuenta, double monto)
  {
      if (monto < 0)
          Console.WriteLine("Error: no se puede depositar un monto negativo.");
      else
      {
          cuenta.Saldo += monto;
          Console.WriteLine("Depósito exitoso. Saldo actual: Bs " + cuenta.Saldo.ToString("0.00"));
      }
  }
  ```
- Sin `ref`, los cambios hechos dentro del procedimiento no se reflejarían en la variable original, porque el struct viaja por valor.
- Usa un bucle `for` de 5 repeticiones para las operaciones, y dentro un condicional para distinguir entre `D` y `R`.

**Restricciones:**
- No uses excepciones (`try/catch`) para las validaciones; usa condicionales.
- Trabaja con una sola cuenta (no arreglo de cuentas).

**Ejemplo de entrada y salida:**
```
Titular: Marco Vidal
Número de cuenta: 001-2233
Saldo inicial: 500

Operación 1 (D/R): D
Monto: 200
Depósito exitoso. Saldo actual: Bs 700.00

Operación 2 (D/R): R
Monto: 1000
Error: saldo insuficiente. Saldo actual: Bs 700.00
```

---

## Ejercicio 2: El mejor promedio del curso

**Enunciado:** Crea un struct `Estudiante` con `Nombre` y un arreglo interno de 4 `Notas` (tipo `double`). Crea una **función estática** `CalcularPromedio` que reciba un arreglo de notas y devuelva el promedio. Pide los datos de 6 estudiantes (nombre y sus 4 notas), guárdalos en un arreglo de `Estudiante`, y muestra al final la lista con el promedio de cada uno (usando la función), además de indicar quién tiene **el mejor promedio** y quién está **en riesgo** (promedio menor a 51).

**Objetivo de aprendizaje:** Anidar un arreglo de tamaño fijo dentro de un struct (no solo otro struct), y escribir una función que reciba ese arreglo interno como parámetro para devolver un valor calculado.

**Pistas técnicas:**
- Declaración sugerida:
  ```csharp
  struct Estudiante
  {
      public string Nombre;
      public double[] Notas; // tamaño 4
  }

  static double CalcularPromedio(double[] notas)
  {
      double suma = 0;
      for (int i = 0; i < notas.Length; i++)
          suma += notas[i];
      return suma / notas.Length;
  }
  ```
- Recuerda inicializar el arreglo interno antes de llenarlo: `estudiantes[i].Notas = new double[4];`
- Para saber el promedio de un estudiante en cualquier parte del programa, llama a `CalcularPromedio(estudiantes[i].Notas)`.
- Usa una variable auxiliar para rastrear el índice del mejor promedio mientras recorres el arreglo de estudiantes.

**Restricciones:**
- Usa exactamente 6 estudiantes y 4 notas por estudiante.
- No uses `List<T>` ni LINQ; todo con `for`.

**Ejemplo de entrada y salida (2 estudiantes para abreviar):**
```
Estudiante 1 - Nombre: Diego
Nota 1: 60
Nota 2: 70
Nota 3: 55
Nota 4: 80
Estudiante 2 - Nombre: Valeria
Nota 1: 40
Nota 2: 45
Nota 3: 50
Nota 4: 38

--- Resultados ---
Diego   | Promedio: 66.25
Valeria | Promedio: 43.25 (en riesgo)

Mejor promedio: Diego (66.25)
```

---

## Ejercicio 3: Reuniones sin cruces

**Enunciado:** Una oficina quiere revisar si su agenda del día tiene reuniones que se solapan. Define un struct `Reunion` con `Nombre`, `HoraInicio` y `HoraFin` (usa `int` en formato de 24 horas, ej. 14 para las 2pm). Pide al usuario los datos de 5 reuniones, guárdalas en un arreglo, y detecta **todos los pares de reuniones que se cruzan en el tiempo**, mostrando un mensaje por cada cruce encontrado (o un mensaje de que no hay cruces).

**Objetivo de aprendizaje:** Comparar todos los pares posibles dentro de un arreglo de structs (recorrido con dos bucles anidados) y aplicar una función que devuelva un valor booleano según una condición sobre dos structs.

**Pistas técnicas:**
- Dos reuniones A y B se solapan si: `A.HoraInicio < B.HoraFin && B.HoraInicio < A.HoraFin`
- Para no comparar una reunión consigo misma ni repetir pares (A con B y luego B con A), el segundo bucle debe empezar en `j = i + 1`.
- Crea una función `static bool HaySolape(Reunion a, Reunion b)` que devuelva `true` o `false`.

**Restricciones:**
- Usa exactamente 5 reuniones.
- No valides que `HoraFin` sea mayor que `HoraInicio` (asume que el usuario ingresa datos correctos).
- No uses `List<T>` ni LINQ.

**Ejemplo de entrada y salida (3 reuniones para abreviar):**
```
Reunión 1 - Nombre: Ventas
Reunión 1 - Hora inicio: 9
Reunión 1 - Hora fin: 11
Reunión 2 - Nombre: Marketing
Reunión 2 - Hora inicio: 10
Reunión 2 - Hora fin: 12
Reunión 3 - Nombre: Finanzas
Reunión 3 - Hora inicio: 13
Reunión 3 - Hora fin: 14

--- Cruces detectados ---
Ventas se cruza con Marketing

No se encontraron más cruces.
```

---

## Ejercicio 4: Fusión de inventarios de dos sucursales

**Enunciado:** Una tienda tiene dos sucursales, cada una con su propio inventario de 4 productos. Define un struct `Producto` con `Nombre` y `Cantidad`. Pide los datos de los 4 productos de la Sucursal A y los 4 de la Sucursal B, y crea una función `FusionarInventarios` que combine ambos arreglos en un **inventario consolidado**: si un producto (mismo nombre) aparece en las dos sucursales, sus cantidades se suman en una sola entrada; si aparece solo en una, se agrega tal cual. Muestra el inventario consolidado final.

**Objetivo de aprendizaje:** Escribir una función que reciba dos arreglos de structs, busque coincidencias por nombre (comparación de strings) recorriendo un arreglo dentro de otro, y construya un arreglo de resultado de tamaño variable usando un contador auxiliar.

**Pistas técnicas:**
- Firma sugerida: `static Producto[] FusionarInventarios(Producto[] sucursalA, Producto[] sucursalB)`
- Como no sabes de antemano cuántos productos únicos habrá, crea el arreglo de resultado con el tamaño máximo posible (`Producto[] consolidado = new Producto[8];`) y usa un contador (`int total = 0;`) para saber cuántas posiciones se llenaron realmente.
- Para comparar nombres sin importar mayúsculas/minúsculas, usa `nombre1.ToLower() == nombre2.ToLower()`.
- Recorre primero la Sucursal A copiando todos sus productos al consolidado. Luego, para cada producto de la Sucursal B, usa una bandera (`bool encontrado`) para revisar si ya existe en el consolidado: si existe, suma la cantidad; si no, agrégalo como una nueva entrada.

**Restricciones:**
- Usa exactamente 4 productos por sucursal.
- No uses `List<T>`, LINQ ni diccionarios (`Dictionary`).
- Al mostrar el resultado, recorre solo hasta la cantidad real de productos consolidados (usa el contador `total`, no el tamaño del arreglo).

**Ejemplo de entrada y salida (2 productos por sucursal para abreviar):**
```
--- Sucursal A ---
Producto 1 - Nombre: Arroz
Producto 1 - Cantidad: 10
Producto 2 - Nombre: Aceite
Producto 2 - Cantidad: 4

--- Sucursal B ---
Producto 1 - Nombre: arroz
Producto 1 - Cantidad: 6
Producto 2 - Nombre: Azúcar
Producto 2 - Cantidad: 15

--- Inventario consolidado ---
Arroz  | Cantidad: 16
Aceite | Cantidad: 4
Azúcar | Cantidad: 15
```

---

## Ejercicio 5: Torneo de eliminación directa

**Enunciado:** Simula la primera ronda de un torneo con 8 jugadores. Define un struct `Jugador` con `Nombre` y `Puntaje` (un número ingresado por consola que representa su nivel). Organiza a los jugadores en 4 enfrentamientos consecutivos del arreglo (jugador 1 vs 2, 3 vs 4, 5 vs 6, 7 vs 8), determina el ganador de cada uno (el de mayor `Puntaje`; si hay empate, gana el que apareció primero) y guarda a los 4 ganadores en un nuevo arreglo. Muestra el cuadro de la primera ronda y la lista de clasificados.

**Objetivo de aprendizaje:** Recorrer un arreglo de structs "de dos en dos" para simular enfrentamientos, aplicar una regla de desempate con condicionales, y construir un segundo arreglo de structs a partir de los resultados del primero.

**Pistas técnicas:**
- Recorre el arreglo original con un `for` que avance de 2 en 2: `for (int i = 0; i < 8; i += 2)`.
- El arreglo de ganadores tendrá la mitad de tamaño: `Jugador[] ganadores = new Jugador[4];`
- Usa un índice separado (`indiceGanador`) para ir llenando el arreglo de ganadores dentro del bucle, y auméntalo manualmente en cada vuelta.
- Puedes crear una función `static Jugador ObtenerGanador(Jugador j1, Jugador j2)` que devuelva el jugador ganador del enfrentamiento.

**Restricciones:**
- Usa exactamente 8 jugadores.
- No uses `List<T>`, LINQ ni recursividad.
- No es necesario simular más rondas, solo la primera.

**Ejemplo de entrada y salida (4 jugadores para abreviar, 2 enfrentamientos):**
```
Jugador 1 - Nombre: Rojas / Puntaje: 85
Jugador 2 - Nombre: Vega / Puntaje: 90
Jugador 3 - Nombre: Mamani / Puntaje: 78
Jugador 4 - Nombre: Flores / Puntaje: 78

--- Cuadro de la ronda 1 ---
Rojas (85) vs Vega (90) -> Gana: Vega
Mamani (78) vs Flores (78) -> Gana: Mamani (por orden de aparición)

Clasificados: Vega, Mamani
```