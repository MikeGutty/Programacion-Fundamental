# Ejercicios — Nivel Básico
## Funciones y Procedimientos

**Programación I · Ingeniería de Sistemas**

---

### 📋 Instrucciones generales

Para cada ejercicio debes:

1. Escribir el algoritmo en **PSeInt**, usando `Funcion` o `SubProceso` según corresponda.
2. Escribir el **equivalente en C#**.
3. Probar tu código con al menos **dos casos** de entrada distintos.
4. Indicar si usaste una **función** o un **procedimiento**, y por qué.

> 💡 Recuerda: si el ejercicio pide **calcular o devolver un valor**, es una función. Si solo pide **mostrar/hacer algo**, es un procedimiento.

---

## Ejercicio 1 — Saludo personalizado

Crea un **procedimiento** llamado `Saludar` que reciba el nombre de una persona como parámetro y muestre en pantalla el mensaje:

```
¡Hola, <nombre>! Que tengas un excelente día.
```

**Requisitos:**
- El procedimiento no debe devolver ningún valor.
- Debe recibir el nombre como parámetro (no debe pedirse `Leer`/`Console.ReadLine()` dentro del procedimiento).

**Ejemplo de uso:**
```
Entrada: "María"
Salida: ¡Hola, María! Que tengas un excelente día.
```

---

## Ejercicio 2 — Área de un rectángulo

Crea una **función** llamada `CalcularAreaRectangulo` que reciba como parámetros la base y la altura de un rectángulo, y **devuelva** su área.

**Requisitos:**
- La función debe recibir dos parámetros numéricos.
- Debe devolver el resultado (no debe imprimirlo dentro de la función).
- El programa principal debe leer los datos, llamar a la función y mostrar el resultado.

**Ejemplo de uso:**
```
Entrada: base = 4, altura = 5
Salida: El área es: 20
```

---

## Ejercicio 3 — Número par o impar

Crea una **función** llamada `EsPar` que reciba un número entero y devuelva `Verdadero`/`true` si el número es par, o `Falso`/`false` si es impar.

**Requisitos:**
- La función debe devolver un valor lógico (booleano).
- El programa principal debe leer un número, llamar a la función y mostrar un mensaje según el resultado.

**Ejemplo de uso:**
```
Entrada: 7
Salida: El número 7 es impar
```

---

## Ejercicio 4 — Conversión de temperatura

Crea una **función** llamada `CelsiusAFahrenheit` que reciba una temperatura en grados Celsius y devuelva su equivalente en Fahrenheit.

**Fórmula:** `F = (C * 9/5) + 32`

**Requisitos:**
- La función debe recibir un parámetro numérico y devolver un valor numérico.
- El programa principal debe leer la temperatura en Celsius, llamar a la función y mostrar el resultado en Fahrenheit.

**Ejemplo de uso:**
```
Entrada: 25
Salida: 25°C equivalen a 77°F
```

---

## Ejercicio 5 — Mostrar tabla de multiplicar

Crea un **procedimiento** llamado `MostrarTablaMultiplicar` que reciba un número entero y muestre en pantalla su tabla de multiplicar del 1 al 10.

**Requisitos:**
- El procedimiento no debe devolver ningún valor.
- Debe usar un ciclo (`Para`/`for`) dentro del procedimiento para recorrer del 1 al 10.

**Ejemplo de uso:**
```
Entrada: 5
Salida:
5 x 1 = 5
5 x 2 = 10
...
5 x 10 = 50
```

---

## ✅ Checklist antes de entregar

- [ ] Cada ejercicio tiene su versión en PSeInt **y** en C#.
- [ ] Usé `Funcion`/tipo de retorno cuando el ejercicio pedía devolver un valor.
- [ ] Usé `SubProceso`/`void` cuando el ejercicio solo pedía mostrar algo.
- [ ] Probé cada ejercicio con al menos dos entradas diferentes.
- [ ] Los nombres de mis funciones y variables son claros y descriptivos.