# Tarea 3: Herencia en C#

**Carrera:** Ingeniería de Sistemas
**Temas:** herencia, modificadores de acceso (`public`, `private` y `protected`), `base` para llamar al constructor del padre, además de clases, constructores, getters/setters y `List<T>`

---

## Instrucciones generales

- Resuelve los **7 ejercicios** en C#. Están ordenados de menor a mayor dificultad.
- Cada ejercicio debe tener su propio proyecto de consola (o una carpeta separada dentro de la solución).
- Cada clase debe ir en su propio archivo `.cs`, salvo que el ejercicio indique lo contrario.
- Usa la convención de C#: `PascalCase` para clases, métodos y propiedades, y `camelCase` para atributos y parámetros.
- Respeta los modificadores de acceso indicados en cada ejercicio (`public`, `private` o `protected`). Forman parte de lo que se evalúa.
- En las clases hijas, **todo constructor debe llamar al constructor del padre con `base`** cuando el padre tenga constructor con parámetros.
- **Importante:** como aún no vimos cómo redefinir métodos del padre, **no repitas en la clase hija el nombre de un método de la clase padre**. Por eso, en los ejercicios los métodos de las clases hijas tienen nombres distintos (por ejemplo, `MostrarDispositivo()` en el padre y `MostrarCelular()` en el hijo).
- Comenta brevemente tu código explicando qué hace cada clase y cada método.
- Entrega el código fuente (`.cs`) y una captura de pantalla de la ejecución de cada ejercicio.

---

## Material de apoyo: Herencia

### ¿Qué es la herencia?

La **herencia** permite crear una clase nueva (**clase hija**, derivada o subclase) a partir de otra ya existente (**clase padre**, base o superclase). La clase hija **hereda** los atributos y métodos del padre y además puede agregar los suyos propios.

Sirve para **reutilizar código** y para representar relaciones del tipo **"es un"**:

- Un `Perro` **es un** `Animal`.
- Un `Estudiante` **es una** `Persona`.
- Un `Celular` **es un** `Dispositivo`.

> Si la relación no es "es un", probablemente no debas usar herencia. Un `Auto` **tiene** un `Motor`, pero un `Auto` **no es** un `Motor`.

### Sintaxis

Se usa `:` seguido del nombre de la clase padre:

```csharp
class Animal
{
    public string nombre;
    public int edad;

    public void MostrarAnimal()
    {
        Console.WriteLine(nombre + " - " + edad + " años");
    }
}

class Perro : Animal      // Perro hereda de Animal
{
    public string raza;

    public void Ladrar()
    {
        Console.WriteLine(nombre + " dice: ¡Guau!");   // usa 'nombre' heredado
    }
}
```

Uso desde el `Main`:

```csharp
Perro p = new Perro();
p.nombre = "Toby";        // atributo heredado de Animal
p.edad = 4;               // atributo heredado de Animal
p.raza = "Labrador";      // atributo propio de Perro
p.MostrarAnimal();        // método heredado
p.Ladrar();               // método propio
```

> En C# una clase solo puede heredar de **una** clase padre, pero se pueden formar cadenas: `C` hereda de `B`, y `B` hereda de `A` (herencia en varios niveles).

### Modificadores de acceso y herencia

| Modificador | ¿Se ve dentro de la misma clase? | ¿Se ve en la clase hija? | ¿Se ve fuera (por ejemplo, en el `Main`)? |
|---|---|---|---|
| `public` | Sí | Sí | Sí |
| `protected` | Sí | **Sí** | No |
| `private` | Sí | **No** | No |

- **`public`:** accesible desde cualquier lugar.
- **`private`:** solo accesible dentro de la clase que lo declara. **La clase hija hereda el atributo, pero no puede verlo ni usarlo directamente.**
- **`protected`:** funciona como `private` hacia el exterior, pero **permite que las clases hijas lo usen**.

```csharp
class Persona
{
    private string documento;     // solo Persona lo ve
    protected string nombre;      // Persona y sus hijas lo ven
    public int edad;              // todos lo ven
}

class Estudiante : Persona
{
    public void Mostrar()
    {
        Console.WriteLine(nombre);       // ✅ protected: permitido
        Console.WriteLine(edad);         // ✅ public: permitido
        Console.WriteLine(documento);    // ❌ ERROR: private, no es accesible desde la hija
    }
}
```

Y desde el `Main`:

```csharp
Estudiante e = new Estudiante();
e.edad = 20;           // ✅
e.nombre = "Ana";      // ❌ ERROR: protected no es accesible desde fuera
```

Si la clase hija necesita trabajar con un atributo privado del padre, debe hacerlo mediante un **método o propiedad pública** (getter/setter) que ofrezca el padre.

### Constructores y `base`

Cuando se crea un objeto de la clase hija, **primero se ejecuta el constructor del padre** y luego el de la hija. Para indicar qué constructor del padre se usa (y con qué valores) se escribe `: base(...)` después de los parámetros del constructor de la hija:

```csharp
class Persona
{
    protected string nombre;
    protected int edad;

    public Persona(string nombre, int edad)
    {
        this.nombre = nombre;
        this.edad = edad;
    }

    public void MostrarPersona()
    {
        Console.WriteLine(nombre + " - " + edad + " años");
    }
}

class Estudiante : Persona
{
    private string carrera;

    // Los parámetros nombre y edad se envían al constructor del padre con base(...)
    public Estudiante(string nombre, int edad, string carrera) : base(nombre, edad)
    {
        this.carrera = carrera;      // el hijo solo se encarga de lo suyo
    }

    public void MostrarEstudiante()
    {
        MostrarPersona();                      // método heredado
        Console.WriteLine("Carrera: " + carrera);
    }
}
```

```csharp
Estudiante e = new Estudiante("Ana", 20, "Ingeniería de Sistemas");
e.MostrarEstudiante();
```

**Reglas importantes:**

1. Si el padre tiene **solo constructores con parámetros**, la clase hija **está obligada** a llamar a uno de ellos con `: base(...)`. Si lo olvidas, el compilador muestra el error *"There is no argument given that corresponds to the required parameter..."*.
2. Si el padre tiene un constructor sin parámetros (o ninguno), el hijo lo llama automáticamente y no necesitas escribir `base`.
3. `base(...)` solo se escribe en la **declaración del constructor** de la hija, junto a los dos puntos.
4. En una herencia de varios niveles, cada clase llama al constructor de su padre inmediato: `C : B`, `B : A`.

```csharp
class A { public A(string x) { } }
class B : A { public B(string x, int y) : base(x) { } }
class C : B { public C(string x, int y, bool z) : base(x, y) { } }
```

### Un objeto hijo también es un objeto del padre

Como un `Perro` **es un** `Animal`, puedes enviar un objeto hijo allí donde se espera un objeto padre (por ejemplo, como parámetro de un método). Sin embargo, dentro de ese método solo podrás usar lo que **el padre** ofrece.

```csharp
class Personaje
{
    public int vida = 100;
    public void RecibirDano(int d) { vida -= d; }
}

class Guerrero : Personaje
{
    public void Atacar(Personaje objetivo)    // acepta cualquier Personaje (o hijo suyo)
    {
        objetivo.RecibirDano(10);
    }
}
```

### Errores comunes

| Error | Causa |
|---|---|
| *"... is inaccessible due to its protection level"* | Intentas usar un atributo `private` o `protected` desde un lugar donde no es visible. |
| *"There is no argument given that corresponds to the required parameter..."* | El padre no tiene constructor sin parámetros y la hija no usó `: base(...)`. |
| Advertencia *"hides inherited member"* | Declaraste en la hija un método con el mismo nombre que uno del padre. En esta tarea, usa nombres distintos. |

---

## Ejercicio 1: Clases `Animal`, `Perro` y `Gato` (Nivel: Muy fácil)

**Conceptos:** herencia simple, atributos públicos heredados, métodos propios.

Crea la clase padre `Animal` con:

- Atributos **públicos**: `nombre` (string) y `edad` (int).
- Método `MostrarAnimal()`: imprime el nombre y la edad.

Crea las clases hijas:

- `Perro : Animal`, con el atributo público `raza` (string) y los métodos `Ladrar()` y `MostrarPerro()` (este último muestra los datos del animal usando `MostrarAnimal()` y luego la raza).
- `Gato : Animal`, con el atributo público `esDeInterior` (bool) y los métodos `Maullar()` y `MostrarGato()`.

**Nota:** en este ejercicio **no se usan constructores**; los datos se asignan directamente a los atributos.

En el `Main`:

1. Crea un `Perro` y un `Gato` y asigna sus datos (incluyendo los heredados).
2. Llama a todos sus métodos.
3. **Experimento:** agrega temporalmente al padre un atributo `private string chip;` e intenta usarlo en el método `MostrarPerro()`. Anota en un comentario el error del compilador y por qué ocurre. Luego elimina o comenta esa línea.

**Salida esperada (ejemplo):**

```
Toby - 4 años
Raza: Labrador
Toby dice: ¡Guau!
Michi - 2 años
Vive en interior: Sí
Michi dice: ¡Miau!
```

---

## Ejercicio 2: Clases `Dispositivo`, `Celular` y `Laptop` (Nivel: Fácil)

**Conceptos:** constructores con `base`, atributos privados y propiedades.

### Clase `Dispositivo` (padre)

- Atributos **privados**: `numeroSerie` (string), `marca` (string) y `modelo` (string).
- Propiedades públicas de **solo lectura** `NumeroSerie`, `Marca` y `Modelo`.
- Constructor que reciba los tres valores.
- `MostrarDispositivo()`: imprime número de serie, marca y modelo.

### Clase `Celular : Dispositivo`

- Atributos **privados**: `almacenamientoGB` (int) y `bateria` (int, de 0 a 100).
- Propiedad `Bateria` con validación en el `set` (solo valores de 0 a 100) y propiedad de solo lectura `AlmacenamientoGB`.
- Constructor que reciba número de serie, marca, modelo y almacenamiento (llamando a `base`). La batería inicia en `100`.
- `Usar(int minutos)`: cada 10 minutos de uso consume 1 % de batería (sin bajar de 0).
- `Cargar(int porcentaje)`: aumenta la batería sin superar 100.
- `MostrarCelular()`: muestra los datos del dispositivo (usando `MostrarDispositivo()`), el almacenamiento y la batería.

### Clase `Laptop : Dispositivo`

- Atributos **privados**: `ramGB` (int) y `tieneSSD` (bool).
- Constructor que reciba número de serie, marca, modelo, RAM y si tiene SSD (llamando a `base`).
- `EsParaProgramar()`: retorna `true` si la RAM es de 8 GB o más y tiene SSD.
- `MostrarLaptop()`.

En el `Main`:

1. Crea un celular y una laptop, y prueba todos sus métodos.
2. Usa la propiedad `NumeroSerie` desde el `Main` (leerla funciona; asignarla no).
3. **Experimento:** dentro de la clase `Celular`, intenta escribir `Console.WriteLine(numeroSerie);`. Anota en un comentario el error y la razón. Luego comenta la línea y utiliza la propiedad `NumeroSerie` en su lugar.

---

## Ejercicio 3: Clases `Transporte`, `Bus` y `Taxi` (Nivel: Fácil-Medio)

**Conceptos:** `protected`, `private`, `public`, constructores con `base`, acceso a atributos heredados.

### Clase `Transporte` (padre)

- Atributo **privado**: `placa` (string), con propiedad pública de solo lectura `Placa`.
- Atributos **protected**: `marca` (string), `modelo` (string) y `capacidadPasajeros` (int).
- Constructor que reciba los cuatro valores (la capacidad debe ser mayor a 0; si no, se asigna `1`).
- `MostrarTransporte()`: imprime placa, marca, modelo y capacidad.

### Clase `Bus : Transporte`

- Atributos **privados**: `ruta` (string) y `costoPasaje` (double).
- Constructor con todos los datos necesarios (llamando a `base`).
- `CalcularRecaudacion(int pasajeros)`: retorna el dinero recaudado. Si los pasajeros superan la capacidad, solo se cuentan los que caben (usa el atributo **protected** `capacidadPasajeros`).
- `MostrarBus()`: muestra todos los datos.

### Clase `Taxi : Transporte`

- Atributos **privados**: `licencia` (string) y `tarifaPorKm` (double).
- Constructor con todos los datos necesarios (llamando a `base`). La capacidad de un taxi siempre es `4` (envíalo directamente en `base(...)`).
- `CalcularCarrera(double km)`: retorna `km × tarifaPorKm`, con una tarifa mínima de `10`.
- `MostrarTaxi()`: debe imprimir la marca y el modelo **directamente desde los atributos protected** (por ejemplo `Console.WriteLine("Taxi " + marca + " " + modelo)`), además de la licencia y la tarifa.

En el `Main`:

1. Crea dos buses y dos taxis, y prueba todos sus métodos (incluye un caso en que los pasajeros superen la capacidad del bus y una carrera corta que active la tarifa mínima).
2. **Experimento:** intenta escribir `bus.marca` en el `Main` y `placa` dentro de la clase `Bus`. Anota en un comentario qué error aparece en cada caso y la diferencia entre `protected` y `private`.

---

## Ejercicio 4: Clases `Cuenta`, `CuentaAhorro` y `CuentaCorriente` (Nivel: Medio)

**Conceptos:** herencia con `protected` para modificar estado, validaciones, reglas distintas en cada clase hija.

### Clase `Cuenta` (padre)

- Atributo **privado**: `numeroCuenta` (string), con propiedad de solo lectura `NumeroCuenta`.
- Atributo **protected**: `saldo` (double), con propiedad pública de solo lectura `Saldo`.
- Propiedad `Titular` (string) con validación (no vacío).
- Constructor que reciba número de cuenta, titular y saldo inicial (si es negativo, queda en `0`).
- `Depositar(double monto)`: solo si el monto es mayor a 0.
- `Retirar(double monto)`: solo si el monto es mayor a 0 y hay saldo suficiente. Retorna `true` o `false`.
- `MostrarCuenta()`: imprime número, titular y saldo.

### Clase `CuentaAhorro : Cuenta`

- Atributos **privados**: `tasaInteres` (double, por ejemplo `0.03` para 3 %) y `retirosRealizados` (int).
- Constructor que reciba los datos de la cuenta y la tasa (llamando a `base`).
- `AplicarInteres()`: suma al saldo `saldo × tasaInteres` (modifica directamente el atributo **protected** `saldo`).
- `RetirarAhorro(double monto)`: solo permite **máximo 3 retiros** por ciclo; usa el método `Retirar` heredado y cuenta el retiro solo si fue exitoso.
- `ReiniciarRetiros()`: vuelve el contador a 0.
- `MostrarCuentaAhorro()`.

### Clase `CuentaCorriente : Cuenta`

- Atributo **privado**: `limiteSobregiro` (double).
- Constructor que reciba los datos de la cuenta y el límite (llamando a `base`).
- `RetirarConSobregiro(double monto)`: permite que el saldo quede negativo **hasta el límite de sobregiro** (por ejemplo, con saldo `100` y límite `500`, puede retirar hasta `600`). Modifica directamente el atributo **protected** `saldo`. Retorna `true` o `false`.
- `CalcularDisponible()`: retorna `saldo + limiteSobregiro`.
- `MostrarCuentaCorriente()`.

En el `Main`:

1. Crea una cuenta de ahorro y una corriente.
2. En la de ahorro: realiza depósitos, 4 retiros seguidos (el cuarto debe rechazarse), aplica interés y reinicia los retiros.
3. En la corriente: realiza retiros dentro del saldo, retiros que usen el sobregiro y uno que lo supere.
4. Muestra el estado de ambas cuentas después de cada operación.

---

## Ejercicio 5: Jerarquía de `Personaje` (Nivel: Medio-Difícil)

**Conceptos:** herencia en **varios niveles**, `base` encadenado, `protected`, colaboración entre objetos (un objeto hijo recibido como parámetro del tipo padre).

### Clase `Personaje` (padre)

- Atributos **protected**: `nombre` (string), `vida` (int) y `vidaMaxima` (int).
- Propiedad calculada de solo lectura `EstaVivo` (`true` si `vida > 0`).
- Propiedad de solo lectura `Nombre`.
- Constructor que reciba nombre y vida máxima; la vida inicia al máximo.
- `RecibirDano(int dano)`: resta vida sin bajar de `0`. Muestra un mensaje si el personaje muere.
- `Curar(int cantidad)`: suma vida sin superar `vidaMaxima`.
- `MostrarPersonaje()`: imprime nombre y vida (`vida/vidaMaxima`).

### Clase `Guerrero : Personaje`

- Atributos **privados**: `fuerza` (int) y `armadura` (int).
- Constructor que reciba nombre, vida máxima, fuerza y armadura (llamando a `base`).
- `Atacar(Personaje objetivo)`: el objetivo recibe un daño igual a la `fuerza`. Solo puede atacar si el guerrero y el objetivo están vivos.
- `MostrarGuerrero()`.

### Clase `Mago : Personaje`

- Atributos **privados**: `mana` (int) y `poder` (int).
- Constructor que reciba nombre, vida máxima, maná y poder (llamando a `base`).
- `LanzarHechizo(Personaje objetivo)`: cuesta `20` de maná y causa un daño igual a `poder`. Si no hay maná suficiente, muestra un mensaje y no ataca.
- `RecuperarMana(int cantidad)`.
- `MostrarMago()`.

### Clase `Paladin : Guerrero` (tercer nivel)

- Atributo **privado**: `fe` (int).
- Constructor que reciba nombre, vida máxima, fuerza, armadura y fe (llamando a `base` del `Guerrero`).
- `CurarConFe()`: cuesta `10` de fe y recupera `30` de vida. Debe modificar directamente el atributo **protected** `vida` (sin pasar de `vidaMaxima`), demostrando que `protected` se mantiene accesible a través de varios niveles.
- `MostrarPaladin()`.

En el `Main`:

1. Crea un `Guerrero`, un `Mago` y un `Paladin`.
2. Simula un combate por turnos entre dos personajes (por ejemplo, el `Mago` contra el `Paladin`) usando un ciclo `while` que termine cuando uno de los dos muera. En cada turno, muestra el estado de ambos.
3. Haz que el `Paladin` se cure con fe cuando su vida sea menor al 40 % y mientras le quede fe.
4. Al final, muestra quién ganó.

---

## Ejercicio 6: Catálogo de `Contenido`, `Pelicula` y `Serie` (Nivel: Difícil)

**Conceptos:** herencia, `base`, `protected`, `List<T>` con diferentes clases hijas, métodos de búsqueda y cálculo.

### Clase `Contenido` (padre)

- Atributo **privado**: `id` (int), con propiedad de solo lectura `Id`.
- Atributos **protected**: `titulo` (string), `duracionMinutos` (int) y `edadMinima` (int).
- Propiedades públicas de solo lectura: `Titulo` y `DuracionMinutos`.
- Constructor que reciba id, título, duración y edad mínima (la duración debe ser mayor a 0 y la edad mínima no puede ser negativa; si no se cumple, usa `1` y `0` respectivamente).
- `PuedeVer(int edad)`: retorna `true` si la edad es mayor o igual a la edad mínima.
- `MostrarContenido()`: imprime id, título, duración y edad mínima.

### Clase `Pelicula : Contenido`

- Atributos **privados**: `director` (string) y `anio` (int).
- Constructor que reciba todos los datos (llamando a `base`).
- `MostrarPelicula()`.

### Clase `Serie : Contenido`

- Atributos **privados**: `temporadas` (int) y `episodiosPorTemporada` (int).
- En una serie, la `duracionMinutos` heredada representa la **duración de cada episodio**.
- Constructor que reciba id, título, duración por episodio, edad mínima, temporadas y episodios por temporada (llamando a `base`).
- `CalcularDuracionTotal()`: retorna `temporadas × episodiosPorTemporada × duracionMinutos` (usa directamente el atributo **protected**).
- `MostrarSerie()`.

### Clase `Catalogo`

- Atributos **privados**: `List<Pelicula>` y `List<Serie>`.
- `AgregarPelicula(Pelicula p)` y `AgregarSerie(Serie s)`: **no se permiten ids repetidos**, ni dentro de la misma lista ni entre ambas.
- `BuscarPelicula(string titulo)` y `BuscarSerie(string titulo)`: retornan el objeto o `null`.
- `MostrarContenidoPara(int edad)`: muestra las películas y series que esa edad puede ver (usando `PuedeVer`).
- `CalcularHorasTotales()`: retorna la cantidad de horas de todo el catálogo (película = su duración; serie = su duración total), dividido por 60.
- `MostrarSerieMasLarga()`: muestra la serie con mayor duración total (o un mensaje si no hay series).
- `MostrarCatalogo()`: lista todas las películas y luego todas las series.

En el `Main`:

- Registra al menos 4 películas y 3 series (con distintas edades mínimas e incluyendo un intento de id repetido).
- Muestra el catálogo, el contenido apto para un menor de 10 años y para un adulto, las horas totales, la serie más larga y el resultado de buscar títulos existentes e inexistentes.

---

## Ejercicio 7: Sistema de Gestión de una Clínica (Nivel: Muy difícil)

**Conceptos:** integración de todos los temas: herencia, `protected`, `private`, `base`, propiedades, validaciones, listas de objetos, relaciones entre clases y menú interactivo.

Desarrolla un sistema de gestión de citas médicas con las siguientes clases:

### Clase `Persona` (padre)

- Atributo **privado**: `documento` (string), con propiedad de solo lectura `Documento`.
- Atributos **protected**: `nombre` (string) y `edad` (int).
- Propiedad `Nombre` con validación (no vacío) y propiedad `Edad` con validación (entre 0 y 120). Las validaciones deben aplicarse también desde el constructor.
- Constructor que reciba documento, nombre y edad.
- `MostrarPersona()`.

### Clase `Paciente : Persona`

- Atributos **privados**: `tipoSangre` (string, solo se aceptan `"A+"`, `"A-"`, `"B+"`, `"B-"`, `"AB+"`, `"AB-"`, `"O+"`, `"O-"`; si no es válido se asigna `"Desconocido"`) y `List<string>` de diagnósticos (historial).
- Constructor (llamando a `base`).
- `AgregarDiagnostico(string diagnostico)`.
- `MostrarHistorial()`: lista los diagnósticos del paciente (o un mensaje si no tiene).
- `MostrarPaciente()`.

### Clase `Medico : Persona`

- Atributos **privados**: `especialidad` (string), `tarifaConsulta` (double, mayor a 0) y `consultasRealizadas` (int).
- Propiedad `ConsultasRealizadas` con `private set`.
- Propiedad calculada `IngresosGenerados` (`consultasRealizadas × tarifaConsulta`).
- Constructor (llamando a `base`).
- `RegistrarConsulta()`: incrementa el contador de consultas.
- `MostrarMedico()`.

### Clase `Cita` (no hereda de nada)

- Atributos **privados**: `numero` (int), `paciente` (Paciente), `medico` (Medico), `fecha` (string) y `atendida` (bool).
- Propiedades de solo lectura para `Numero`, `Paciente`, `Medico` y `Fecha`; propiedad `Atendida` con `private set`.
- Constructor que reciba número, paciente, médico y fecha.
- `Atender(string diagnostico)`: si la cita no estaba atendida, la marca como atendida, agrega el diagnóstico al historial del paciente y registra la consulta en el médico. Retorna `true` o `false`.
- `MostrarCita()`.

### Clase `Clinica`

- Atributos **privados**: listas de pacientes, médicos y citas, y un contador para numerar las citas automáticamente.
- `RegistrarPaciente(Paciente p)` y `RegistrarMedico(Medico m)`: **un documento no puede repetirse** entre pacientes y médicos.
- `AgendarCita(string docPaciente, string docMedico, string fecha)`: valida que ambos existan y crea la cita con el siguiente número.
- `AtenderCita(int numeroCita, string diagnostico)`: busca la cita y la atiende.
- `MostrarCitasPendientes()`.
- `MostrarHistorialPaciente(string documento)`.
- `CalcularIngresosClinica()`: suma los ingresos generados por todos los médicos.
- `MostrarMedicoConMasConsultas()`.

### Programa principal
Implementa un **menú por consola** con las siguientes opciones:

```
1. Registrar paciente
2. Registrar médico
3. Agendar cita
4. Atender cita
5. Ver citas pendientes
6. Ver historial de un paciente
7. Ver ingresos de la clínica
8. Ver médico con más consultas
9. Salir
```

El menú debe repetirse hasta que el usuario elija la opción 9. Antes de entregar, precarga al menos 3 pacientes y 2 médicos para probar el sistema.

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