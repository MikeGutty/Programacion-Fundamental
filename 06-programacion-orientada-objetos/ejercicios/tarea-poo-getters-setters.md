# Tarea 2: POO en C# con Getters y Setters

**Carrera:** Ingeniería de Sistemas
**Temas:** clases, atributos, métodos, constructores, instancia de objetos, encapsulamiento (`public` y `private`), **getters y setters** y uso de `List<T>`

---

## Instrucciones generales

- Resuelve los **7 ejercicios** en C#. Están ordenados de menor a mayor dificultad.
- Cada ejercicio debe tener su propio proyecto de consola (o una carpeta separada dentro de la solución).
- Cada clase debe ir en su propio archivo `.cs`, salvo que el ejercicio indique lo contrario.
- Usa la convención de C#: `PascalCase` para clases, métodos y propiedades, y `camelCase` para atributos privados y parámetros.
- **Los atributos deben ser privados**, y se accede a ellos únicamente mediante getters y setters (según lo que pida cada ejercicio).
- Cuando se indique una validación, esta debe hacerse **dentro del setter** (o del constructor, usando el setter).
- Comenta brevemente tu código explicando qué hace cada clase y cada método.
- Entrega el código fuente (`.cs`) y una captura de pantalla de la ejecución de cada ejercicio.

---

## Material de apoyo: Getters y Setters

### ¿Por qué existen?

Cuando un atributo es `private`, nadie fuera de la clase puede leerlo ni modificarlo. Para permitir ese acceso de forma **controlada** usamos:

- **Getter:** permite **leer** el valor de un atributo privado.
- **Setter:** permite **modificar** el valor de un atributo privado, pudiendo **validar** el nuevo valor antes de aceptarlo.

Así la clase decide qué valores son válidos y se protege de datos incorrectos (por ejemplo, una edad negativa).

### Forma 1: Getters y setters como métodos

Es la forma clásica (usada en Java y en muchos otros lenguajes). Se crea un método `Get...` y un método `Set...` por cada atributo.

```csharp
class Mascota
{
    private string nombre;
    private int edad;

    // Getter: retorna el valor del atributo
    public string GetNombre()
    {
        return nombre;
    }

    // Setter: recibe un valor y lo asigna al atributo
    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public int GetEdad()
    {
        return edad;
    }

    // Setter con validación
    public void SetEdad(int edad)
    {
        if (edad >= 0)
        {
            this.edad = edad;
        }
        else
        {
            Console.WriteLine("Error: la edad no puede ser negativa.");
        }
    }
}
```

Uso desde el `Main`:

```csharp
Mascota m = new Mascota();
m.SetNombre("Toby");
m.SetEdad(-3);                       // Muestra el error y NO modifica la edad
m.SetEdad(4);
Console.WriteLine(m.GetNombre() + " tiene " + m.GetEdad() + " años");
```

> `this.nombre` se refiere al **atributo** de la clase, y `nombre` (sin `this`) al **parámetro** del método. `this` sirve para diferenciarlos cuando tienen el mismo nombre.

### Forma 2: Propiedades (la forma propia de C#)

C# ofrece las **propiedades**, que cumplen la misma función con una sintaxis más limpia. Se usan como si fueran atributos, pero por dentro ejecutan un `get` y un `set`.

```csharp
class Persona
{
    private string nombre;       // atributo privado (camelCase)
    private int edad;

    // Propiedad (PascalCase) con get y set simples
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    // Propiedad con validación en el set
    public int Edad
    {
        get { return edad; }
        set
        {
            if (value >= 0 && value <= 120)
            {
                edad = value;
            }
            else
            {
                Console.WriteLine("Error: edad no válida.");
            }
        }
    }
}
```

Uso desde el `Main`:

```csharp
Persona p = new Persona();
p.Nombre = "Ana";                    // Llama al set de Nombre
p.Edad = 200;                        // Llama al set de Edad: muestra error
p.Edad = 21;
Console.WriteLine(p.Nombre + " - " + p.Edad);   // Llama a los get
```

**Puntos clave:**

- `value` es una palabra especial: contiene el valor que se está asignando (en `p.Edad = 21;`, `value` vale `21`).
- Se escribe **sin paréntesis**: `p.Edad`, no `p.Edad()`.
- El atributo privado y la propiedad **no pueden llamarse igual**. Por convención: atributo `edad`, propiedad `Edad`.

### Variantes útiles de propiedades

**a) Propiedad automática:** cuando no necesitas validar nada, C# crea el atributo privado por ti.

```csharp
public string Ciudad { get; set; }
```

**b) Propiedad de solo lectura (sin `set`):** se puede leer desde fuera, pero no modificar.

```csharp
private string codigo;

public string Codigo
{
    get { return codigo; }
}
```

**c) Propiedad con `set` privado:** se lee desde fuera, pero solo la propia clase puede modificarla.

```csharp
public int Velocidad { get; private set; }
```

**d) Propiedad calculada:** no guarda un valor, lo calcula a partir de otros atributos.

```csharp
public bool EsMayorDeEdad
{
    get { return edad >= 18; }
}
```

### Getters/setters y constructores

En el constructor conviene asignar usando la **propiedad** (con mayúscula), para que se aplique la validación del `set`:

```csharp
public Persona(string nombre, int edad)
{
    Nombre = nombre;     // Pasa por el set de Nombre
    Edad = edad;         // Pasa por el set de Edad (se valida)
}
```

### Error común: recursión infinita

```csharp
public int Edad
{
    get { return Edad; }     // ❌ Se llama a sí misma infinitamente
    set { Edad = value; }    // ❌ Igual
}
```

Esto produce un `StackOverflowException`. Dentro del `get` y del `set` siempre debes usar el **atributo privado** (`edad`), nunca la propiedad.

### ¿Cuándo usar cada forma?

| Necesidad | Qué usar |
|---|---|
| Leer y escribir sin validar | Propiedad automática `{ get; set; }` |
| Validar al asignar | Propiedad completa con `set` y validación |
| Solo se puede leer desde fuera | Solo `get`, o `{ get; private set; }` |
| Valor derivado de otros atributos | Propiedad calculada (solo `get`) |

> En esta tarea, el **Ejercicio 1** usa getters y setters como **métodos** (Forma 1) y los ejercicios **2 al 7** usan **propiedades** (Forma 2).

---

## Ejercicio 1: Clase `Mascota` (Nivel: Muy fácil)

**Conceptos:** clase, atributos privados, getters y setters como métodos.

Crea una clase `Mascota` con los atributos **privados**:

- `nombre` (string)
- `especie` (string)
- `edad` (int)

Implementa:

1. Un getter y un setter (como métodos `GetX` y `SetX`) para cada atributo.
2. En `SetEdad`, rechaza edades negativas mostrando un mensaje de error.
3. `MostrarFicha()`: imprime nombre, especie y edad.

En el `Main`:

1. Crea **dos mascotas** y asigna sus datos usando los setters.
2. Intenta asignar una edad negativa a una de ellas y verifica que no se modifica.
3. Muestra los datos usando los getters y también con `MostrarFicha()`.

**Salida esperada (ejemplo):**

```
Error: la edad no puede ser negativa.
Toby (Perro) - 4 años
Michi (Gato) - 2 años
```

---

## Ejercicio 2: Clase `Circulo` (Nivel: Fácil)

**Conceptos:** propiedades con `get`/`set`, validación en el `set`, propiedades calculadas.

Crea una clase `Circulo` con:

- Atributo **privado**: `radio` (double).
- Propiedad `Radio` con `get` y `set`. El `set` solo acepta valores **mayores a 0**; en caso contrario muestra un mensaje de error y no modifica el radio.
- Propiedad **calculada** `Area` (solo `get`).
- Propiedad **calculada** `Perimetro` (solo `get`).
- Un constructor que reciba el radio y lo asigne usando la propiedad `Radio`.
- Un método `MostrarInformacion()`.

En el `Main`:

1. Crea un círculo con radio válido y muestra su área y perímetro.
2. Cambia el radio a un valor válido y vuelve a mostrar los resultados.
3. Intenta asignar un radio de `-5` y comprueba que se rechaza.
4. Intenta escribir `c.Area = 10;` y anota en un comentario el error que muestra el compilador (luego comenta la línea).

---

## Ejercicio 3: Clase `Empleado` (Nivel: Fácil-Medio)

**Conceptos:** constructor por defecto y parametrizado, propiedades con validación, propiedad automática, método que modifica el estado.

Crea una clase `Empleado` con:

- Atributos **privados**: `nombre` (string) y `salario` (double).
- Propiedad `Nombre` (el `set` no permite cadenas vacías).
- Propiedad `Salario` (el `set` solo acepta valores mayores o iguales a `0`).
- Propiedad automática `Cargo` (string).
- Propiedad calculada `SalarioAnual` (salario × 12), de solo lectura.

Debe tener:

1. Un **constructor por defecto** que asigne `"Sin nombre"`, salario `0` y cargo `"Sin asignar"`.
2. Un **constructor parametrizado** que reciba nombre, salario y cargo (asignando mediante las propiedades para que se validen).
3. `AplicarAumento(double porcentaje)`: aumenta el salario según el porcentaje indicado, solo si el porcentaje es mayor a 0.
4. `MostrarEmpleado()`: imprime nombre, cargo, salario mensual y salario anual.

En el `Main`:

- Crea un empleado con el constructor por defecto y otro con el parametrizado.
- Intenta asignar un salario negativo y un nombre vacío, y comprueba que se rechazan.
- Aplica un aumento del 10 % a un empleado y muestra los datos antes y después.

---

## Ejercicio 4: Clase `Vehiculo` (Nivel: Medio)

**Conceptos:** propiedades con `private set`, lógica de negocio dentro de la clase, estados que dependen de varios atributos.

Crea una clase `Vehiculo` con:

- Propiedades **públicas de solo lectura** (con `private set`): `Placa` (string), `VelocidadActual` (int) y `Combustible` (double, en litros).
- Atributo constante o propiedad: la **capacidad máxima** del tanque (por ejemplo, 50 litros) y la **velocidad máxima** (por ejemplo, 180 km/h).
- Propiedad `Marca` (string), con `get` y `set` normales.
- Constructor que reciba placa y marca; el vehículo inicia con velocidad `0` y tanque vacío.

Métodos:

1. `CargarCombustible(double litros)`: suma los litros al tanque sin superar la capacidad máxima. Si se intenta cargar más, se llena hasta el tope y se informa cuántos litros sobraron.
2. `Acelerar(int cantidad)`: aumenta la velocidad sin superar la velocidad máxima. **No se puede acelerar si no hay combustible**. Cada vez que acelera consume `0.5` litros.
3. `Frenar(int cantidad)`: disminuye la velocidad sin bajar de `0`.
4. `MostrarEstado()`: imprime placa, marca, velocidad y combustible.

En el `Main`:

- Crea un vehículo, intenta acelerar sin combustible, carga combustible y realiza varias aceleraciones y frenadas.
- Intenta escribir `v.VelocidadActual = 100;` y anota en un comentario el error del compilador y la razón (luego comenta la línea).

---

## Ejercicio 5: Clases `Estudiante` y `Curso` (Nivel: Medio-Difícil)

**Conceptos:** varias clases, propiedades, constructores, `List<T>`, colaboración entre objetos.

### Clase `Estudiante`

- Atributos **privados**: `nombre` (string), `codigo` (int) y `nota` (double).
- Propiedad `Nombre`.
- Propiedad `Codigo` de **solo lectura** (se asigna únicamente en el constructor).
- Propiedad `Nota` con validación en el `set`: solo valores entre 0 y 100.
- Propiedad calculada `Aprobado` (bool): `true` si la nota es mayor o igual a 51.
- Constructor parametrizado (nombre, código y nota).
- `MostrarEstudiante()`.

### Clase `Curso`

- Atributos **privados**: `nombreCurso` (string) y una `List<Estudiante>`.
- Propiedad `NombreCurso`.
- Propiedad calculada `CantidadEstudiantes`.
- `Inscribir(Estudiante e)`: agrega al estudiante, **sin permitir códigos repetidos**.
- `BuscarPorCodigo(int codigo)`: retorna el estudiante o `null`.
- `CalcularPromedioCurso()`: retorna el promedio de las notas del curso (`0` si no hay estudiantes).
- `ObtenerMejorEstudiante()`: retorna el estudiante con la nota más alta (o `null` si no hay estudiantes).
- `MostrarAprobados()`: imprime solo los estudiantes aprobados.
- `MostrarListado()`: imprime todos los estudiantes.

En el `Main`:

- Crea un curso con al menos 6 estudiantes (con notas variadas, incluyendo un intento de nota inválida y un código repetido).
- Muestra el listado, el promedio del curso, el mejor estudiante y los aprobados.
- Busca un estudiante por código y modifica su nota usando la propiedad `Nota`.

---

## Ejercicio 6: Sistema de acceso `Usuario` (Nivel: Difícil)

**Conceptos:** encapsulamiento fuerte, propiedades de solo escritura lógica, validaciones complejas dentro de la clase, `List<T>`.

### Clase `Usuario`

- Atributos **privados**: `nombreUsuario` (string), `contrasenia` (string), `intentosFallidos` (int) y `bloqueado` (bool).
- Propiedad `NombreUsuario` de **solo lectura** (se asigna en el constructor).
- Propiedad `Bloqueado` con `private set`.
- **La contraseña no debe poder leerse desde fuera de la clase** (no crees ningún getter para ella).
- Constructor que reciba nombre de usuario y contraseña inicial. La contraseña debe cumplir las reglas de validación (ver abajo); si no las cumple, se asigna la contraseña `"Temporal123"`.

Métodos:

1. `CambiarContrasenia(string actual, string nueva)`: solo cambia la contraseña si la actual es correcta, la cuenta no está bloqueada y la nueva cumple las reglas. Retorna `true` o `false`.
2. `IniciarSesion(string contrasenia)`: si la contraseña es correcta, reinicia los intentos fallidos y retorna `true`. Si es incorrecta, suma un intento fallido; **al llegar a 3 intentos fallidos la cuenta se bloquea**. Una cuenta bloqueada no puede iniciar sesión.
3. `Desbloquear(string contraseniaAdmin)`: desbloquea la cuenta solo si la clave de administrador es `"admin2026"` y reinicia los intentos fallidos.
4. Un método privado `EsContraseniaValida(string clave)`: la contraseña debe tener **al menos 8 caracteres, al menos una letra mayúscula y al menos un número**.

### Clase `SistemaAcceso`

- Atributo **privado**: `List<Usuario>`.
- `RegistrarUsuario(string nombreUsuario, string contrasenia)`: crea el usuario si el nombre no existe ya.
- `BuscarUsuario(string nombreUsuario)`: retorna el usuario o `null`.
- `Login(string nombreUsuario, string contrasenia)`: busca al usuario y lo intenta autenticar, mostrando un mensaje claro según el resultado (usuario inexistente, cuenta bloqueada, contraseña incorrecta o acceso concedido).
- `MostrarUsuarios()`: imprime cada usuario con su estado (`Activo` o `Bloqueado`), **sin mostrar contraseñas**.

En el `Main`:

- Registra al menos 3 usuarios (uno con contraseña inválida) y prueba: inicios de sesión correctos e incorrectos, bloqueo por 3 intentos, desbloqueo y cambio de contraseña.

---

## Ejercicio 7: Sistema de Reservas de Hotel (Nivel: Muy difícil)

**Conceptos:** integración de todos los temas: varias clases, constructores, getters y setters, validaciones, listas de objetos, relaciones entre clases y menú interactivo.

Desarrolla un sistema de reservas con **cuatro clases**:

### Clase `Habitacion`
- Atributos **privados**: `numero` (int), `tipo` (string: `"Simple"`, `"Doble"` o `"Suite"`), `precioPorNoche` (double) y `ocupada` (bool).
- Propiedad `Numero` de solo lectura (asignada en el constructor).
- Propiedad `Tipo` con validación (solo acepta los tres tipos indicados).
- Propiedad `PrecioPorNoche` con validación (mayor a 0).
- Propiedad `Ocupada` con `private set`.
- Métodos `Ocupar()` y `Liberar()`, que retornan `true` o `false` según si el cambio fue posible.
- `MostrarHabitacion()`.

### Clase `Huesped`
- Atributos **privados**: `nombre` (string), `documento` (string) y `telefono` (string).
- Propiedades con validación: el nombre no puede estar vacío y el teléfono debe tener al menos 7 dígitos.
- Propiedad `Documento` de solo lectura.
- `MostrarHuesped()`.

### Clase `Reserva`
- Atributos **privados**: `huesped` (Huesped), `habitacion` (Habitacion), `noches` (int) y `activa` (bool).
- Propiedades de solo lectura para `Huesped`, `Habitacion` y `Noches`.
- Propiedad `Activa` con `private set`.
- Propiedad calculada `CostoTotal` (`noches × precio por noche`).
- Constructor que reciba huésped, habitación y número de noches (mayor a 0). La reserva se crea activa.
- `Finalizar()`: marca la reserva como no activa y libera la habitación.
- `MostrarReserva()`.

### Clase `Hotel`
- Atributo **público o propiedad**: `NombreHotel`.
- Atributos **privados**: listas de habitaciones, huéspedes y reservas.
- `RegistrarHabitacion(Habitacion h)` y `RegistrarHuesped(Huesped g)` (sin duplicados por número y por documento).
- `ReservarHabitacion(string documento, int numeroHabitacion, int noches)`: valida que existan el huésped y la habitación, que la habitación esté libre y que las noches sean válidas. Si todo es correcto, crea la reserva, ocupa la habitación y muestra el costo total.
- `FinalizarReserva(string documento, int numeroHabitacion)`: busca la reserva activa correspondiente y la finaliza.
- `MostrarHabitacionesDisponibles()`.
- `MostrarReservasActivas()`.
- `CalcularIngresosTotales()`: suma el costo total de **todas** las reservas finalizadas.

### Programa principal
Implementa un **menú por consola** con las siguientes opciones:

```
1. Registrar habitación
2. Registrar huésped
3. Reservar habitación
4. Finalizar reserva (check-out)
5. Ver habitaciones disponibles
6. Ver reservas activas
7. Ver ingresos totales
8. Salir
```

El menú debe repetirse hasta que el usuario elija la opción 8. Antes de entregar, precarga al menos 5 habitaciones (de distintos tipos) y 3 huéspedes para probar el sistema.

---

## Criterios de evaluación

| Criterio | Puntaje |
|---|---|
| Ejercicio 1 | 5 pts |
| Ejercicio 2 | 10 pts |
| Ejercicio 3 | 10 pts |
| Ejercicio 4 | 15 pts |
| Ejercicio 5 | 15 pts |
| Ejercicio 6 | 20 pts |
| Ejercicio 7 | 20 pts |
| Orden, nombres claros y comentarios en el código | 5 pts |
| **Total** | **100 pts** |

> **Nota:** Se penalizará el código copiado. Cualquier duda sobre los enunciados debe consultarse antes de la fecha de entrega.