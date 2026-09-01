# Ejercicios — Nivel Avanzado
## Funciones y Procedimientos

**Programación I · Ingeniería de Sistemas**

---

### 📋 Instrucciones generales

Para cada ejercicio debes:

1. Escribir el algoritmo en **PSeInt**, usando `Funcion` o `SubProceso` según corresponda.
2. Escribir el **equivalente en C#**.
3. **Modularizar** tu solución: identifica si el problema requiere más de una función/procedimiento y sepáralas por responsabilidad.
4. Incluir **validación básica de datos** cuando el ejercicio lo amerite (por ejemplo, evitar divisiones entre cero o valores negativos donde no correspondan).
5. Probar tu código con al menos **tres casos** de entrada, incluyendo un caso límite o inválido.

> 💡 Estos ejercicios suelen requerir **más de una función**. Piensa qué tareas se repiten o qué partes del problema pueden separarse antes de programar.

---

## Ejercicio 1 — Calculadora con menú de operaciones

Crea un programa que simule una calculadora básica. Debe tener **una función distinta para cada operación**:

- `Sumar(a, b)`
- `Restar(a, b)`
- `Multiplicar(a, b)`
- `Dividir(a, b)`

Además, crea un **procedimiento** `MostrarMenu` que despliegue las opciones disponibles, y un **procedimiento** `MostrarResultado` que reciba la operación y el resultado, y lo imprima con formato.

**Requisitos:**
- El usuario debe elegir una operación (1-4) y luego ingresar dos números.
- La función `Dividir` debe **validar que el divisor no sea cero**; si lo es, debe manejarse el error sin que el programa se detenga (usa `Si`/`if` para validar, y en C# también puedes usar `try/catch`).
- No debe haber código duplicado al mostrar resultados.

**Ejemplo de uso:**
```
Entrada: operación = 4 (dividir), a = 10, b = 0
Salida: Error: no se puede dividir entre cero.
```

---

## Ejercicio 2 — Validador y analizador de contraseñas

Crea una **función** `EsContrasenaSegura` que reciba una cadena de texto y devuelva `Verdadero`/`true` solo si cumple **todas** estas condiciones:

- Tiene al menos 8 caracteres.
- Contiene al menos un número.
- Contiene al menos una letra mayúscula.

Crea además funciones auxiliares (`ContieneNumero`, `ContieneMayuscula`) que sean llamadas desde `EsContrasenaSegura`, en lugar de repetir la lógica dentro de una sola función gigante.

**Requisitos:**
- Ninguna función debe hacer más de una verificación.
- El programa principal debe leer una contraseña, llamar a `EsContrasenaSegura` y mostrar si es segura o no, indicando **qué requisito falta** si no lo es.

**Ejemplo de uso:**
```
Entrada: "abc123"
Salida: Contraseña insegura. Falta: longitud mínima, letra mayúscula.
```

---

## Ejercicio 3 — Estadísticas de una lista de calificaciones

Crea un programa que lea **5 calificaciones** de un curso (usando un arreglo/vector) y calcule, usando funciones separadas:

- `CalcularPromedio(notas)` → devuelve el promedio.
- `EncontrarMaximo(notas)` → devuelve la nota más alta.
- `EncontrarMinimo(notas)` → devuelve la nota más baja.
- `ContarAprobados(notas)` → devuelve cuántos estudiantes aprobaron (nota >= 51).

Crea un **procedimiento** `MostrarReporte` que reciba todos estos resultados y los imprima con formato ordenado.

**Requisitos:**
- No debe haber ningún cálculo dentro de `Main`/`Proceso Principal`; todo debe delegarse a funciones.
- Valida que las notas ingresadas estén en el rango 0-100; si el usuario ingresa un valor fuera de rango, debe pedírselo nuevamente.

**Ejemplo de uso:**
```
Entrada: [45, 78, 92, 60, 51]
Salida:
Promedio: 65.2
Nota máxima: 92
Nota mínima: 45
Aprobados: 4 de 5
```

---

## Ejercicio 4 — Sistema simple de inventario (refactorización)

Se te entrega la siguiente descripción de un programa **mal diseñado** (todo en un solo bloque, sin funciones):

> El programa pide el nombre de un producto, su precio y la cantidad en stock. Luego calcula el valor total del inventario (precio × cantidad), verifica si el stock es bajo (menor a 10 unidades) y muestra un reporte con toda la información. Todo esto se repite para 3 productos, por lo que el código para leer, calcular y mostrar se copia y pega tres veces.

**Tu tarea:**
1. Diseña la versión **modularizada** de este programa, identificando qué partes deben ser funciones/procedimientos (por ejemplo: `LeerProducto`, `CalcularValorTotal`, `EsStockBajo`, `MostrarReporteProducto`).
2. Usa un **ciclo** para repetir el proceso con los 3 productos, en lugar de copiar y pegar el código.
3. Implementa la solución completa en PSeInt y en C#.

**Requisitos:**
- Debes usar al menos una función que devuelva un valor y al menos un procedimiento.
- El código no debe tener bloques repetidos: si algo se repite 3 veces, debe estar dentro de una función o un ciclo.

---

## Ejercicio 5 — Verificador de números primos con manejo de errores

Crea una **función** `EsPrimo(numero)` que determine si un número entero es primo, usando un ciclo para verificar sus divisores.

Luego crea un **procedimiento** `MostrarPrimosEnRango(inicio, fin)` que recorra un rango de números y, usando la función `EsPrimo`, muestre en pantalla todos los números primos encontrados en ese rango.

**Requisitos:**
- `EsPrimo` no debe imprimir nada; solo debe devolver un valor booleano.
- `MostrarPrimosEnRango` debe validar que `inicio` sea menor que `fin`; si no lo es, debe mostrar un mensaje de error y no ejecutar el resto de la lógica (en C#, usa `int.TryParse` al leer los datos para evitar que el programa se caiga si el usuario ingresa texto).
- El número 1 y los números negativos no deben considerarse primos.

**Ejemplo de uso:**
```
Entrada: inicio = 1, fin = 20
Salida: Números primos: 2, 3, 5, 7, 11, 13, 17, 19
```

---

## ✅ Checklist antes de entregar

- [ ] Cada ejercicio tiene su versión en PSeInt **y** en C#.
- [ ] Separé el problema en varias funciones/procedimientos según su responsabilidad (nada de un solo bloque gigante).
- [ ] No hay código duplicado; usé funciones o ciclos para evitar repetir lógica.
- [ ] Incluí validación básica de datos donde correspondía (rangos, división entre cero, entradas inválidas).
- [ ] Probé cada ejercicio con al menos un caso límite o inválido, además de casos normales.