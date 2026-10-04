# Ejercicios de Tarea: Git, GitHub, Validación de Entradas y Manejo de Errores

**Lenguaje:** C# (.NET)
**Modalidad:** Individual
**Temas:** Git y GitHub · Validación de entradas · Manejo de errores (excepciones)

---

## Instrucciones generales

- Todos los ejercicios de código deben hacerse en **C#** como aplicaciones de consola.
- Cada ejercicio de programación debe vivir en su propia carpeta/proyecto dentro del repositorio que crearás en el Ejercicio 1.
- Haz **commits pequeños y frecuentes** con mensajes claros (ejemplo: `Agrega validación de edad`, no `cambios`).
- El código debe compilar y ejecutarse sin errores.
- Entrega el **enlace de tu repositorio de GitHub** al finalizar.

---

## Ejercicio 1: Mi primer repositorio con Git (Git)

**Objetivo:** Practicar los comandos básicos de Git en un repositorio local.

### Enunciado

1. Crea una carpeta llamada `tarea-csharp` y, dentro de ella, inicializa un repositorio de Git.
2. Configura tu nombre y correo (solo si aún no lo hiciste):
   ```bash
   git config --global user.name "Tu Nombre"
   git config --global user.email "tu@correo.com"
   ```
3. Crea un proyecto de consola de C# dentro de la carpeta:
   ```bash
   dotnet new console -n Ejercicio3
   ```
4. Crea un archivo `README.md` con tu nombre completo y una breve descripción del repositorio.
5. Crea un archivo `.gitignore` que excluya las carpetas `bin/` y `obj/`. (Tip: puedes generarlo con `dotnet new gitignore`).
6. Haz al menos **3 commits** distintos:
   - Primer commit: solo el `README.md`.
   - Segundo commit: el archivo `.gitignore`.
   - Tercer commit: el proyecto de consola.
7. Revisa tu historial con:
   ```bash
   git log --oneline
   ```

### Entregable

- Captura de pantalla (o texto copiado) de la salida de `git log --oneline` mostrando tus 3 commits.
- Captura de `git status` mostrando que no hay cambios pendientes.

### Preguntas de reflexión (responde en 1-2 líneas cada una)

- ¿Qué diferencia hay entre `git add` y `git commit`?
- ¿Por qué es importante no subir las carpetas `bin/` y `obj/` al repositorio?

---

## Ejercicio 2: Validación de entradas con `TryParse` (Validación)

**Objetivo:** Evitar que el programa falle cuando el usuario ingresa datos incorrectos.

### Enunciado

Crea un programa de consola (`Ejercicio2`) que registre los datos de un estudiante pidiendo lo siguiente al usuario:

| Dato | Regla de validación |
|------|---------------------|
| Nombre | No puede estar vacío ni contener solo espacios |
| Edad | Debe ser un número entero entre **5 y 100** |
| Nota final | Debe ser un número decimal entre **0 y 20** |

### Requisitos

- Usa `int.TryParse` y `double.TryParse` (**no** uses `int.Parse` ni `Convert.ToInt32`).
- Si el usuario ingresa un dato inválido, muestra un mensaje de error claro y **vuelve a pedir el dato** (usa un ciclo `while` o `do...while`).
- Usa `string.IsNullOrWhiteSpace` para validar el nombre.
- Al final, muestra un resumen con los datos ingresados y si el estudiante **aprobó** (nota ≥ 10.5) o **reprobó**.

### Ejemplo de ejecución esperada

```
Ingrese el nombre: 
Error: el nombre no puede estar vacío.
Ingrese el nombre: Ana
Ingrese la edad: abc
Error: debe ingresar un número entero.
Ingrese la edad: 200
Error: la edad debe estar entre 5 y 100.
Ingrese la edad: 20
Ingrese la nota final: 15.5

--- Resumen ---
Nombre: Ana
Edad: 20
Nota: 15.5
Resultado: Aprobado
```

### Entregable

- Captura de pantalla de una ejecución donde pruebes entradas inválidas.

---

## Ejercicio 3: Calculadora segura con `try-catch-finally` (Manejo de errores)

**Objetivo:** Capturar y manejar excepciones comunes para que el programa no se detenga abruptamente.

### Enunciado

Crea una calculadora de consola (`Ejercicio3`) que:

1. Muestre un menú con las opciones: **Sumar, Restar, Multiplicar, Dividir y Salir**.
2. Pida dos números al usuario y realice la operación elegida.
3. Se repita hasta que el usuario elija **Salir**.

### Requisitos

- Usa `double.Parse` dentro de un bloque `try` y captura `FormatException` cuando el usuario escriba texto en lugar de un número.
- Al dividir, lanza y captura una `DivideByZeroException` con un mensaje personalizado cuando el divisor sea 0. (Pista: con `double` la división entre 0 no lanza excepción, por lo que debes validar y lanzarla tú con `throw new DivideByZeroException("...")`).
- Captura también `OverflowException` (por ejemplo, con números extremadamente grandes) y un `catch (Exception ex)` general como última opción.
- Usa un bloque `finally` que imprima `"Operación finalizada."` después de cada cálculo, ocurra o no un error.
- Los bloques `catch` deben ir ordenados **de lo más específico a lo más general**.

### Pistas

```csharp
try
{
    // código que puede fallar
}
catch (FormatException)
{
    // mensaje para el usuario
}
catch (Exception ex)
{
    Console.WriteLine($"Error inesperado: {ex.Message}");
}
finally
{
    Console.WriteLine("Operación finalizada.");
}
```

### Entregable

- Captura de pantalla donde se vea: una operación correcta, una división entre cero y un texto ingresado en lugar de un número.

### Pregunta de reflexión

- ¿Por qué es mala práctica usar únicamente `catch (Exception)` para todo?

---
