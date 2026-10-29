# Tarea 4: Polimorfismo y Clases Abstractas en C#

**Carrera:** Ingeniería de Sistemas
**Temas:** polimorfismo (`virtual` y `override`), clases abstractas (`abstract`), además de herencia, `base`, encapsulamiento, propiedades y `List<T>`

La tarea tiene dos partes:

- **Parte A (ejercicios 1 al 4):** solo **polimorfismo**. Las clases padre son clases normales (no abstractas).
- **Parte B (ejercicios 5 al 7):** **clases abstractas**.

La dificultad sube **dentro de cada parte**: el Ejercicio 1 es el más fácil de la Parte A y el Ejercicio 5 es el más fácil de la Parte B.

---

## Instrucciones generales

- Resuelve los **7 ejercicios** en C#.
- Cada ejercicio debe tener su propio proyecto de consola (o una carpeta separada dentro de la solución).
- Cada clase debe ir en su propio archivo `.cs`, salvo que el ejercicio indique lo contrario.
- Usa la convención de C#: `PascalCase` para clases, métodos y propiedades, y `camelCase` para atributos y parámetros.
- Respeta los modificadores de acceso indicados (`public`, `private` o `protected`).
- Las validaciones deben hacerse **dentro de las clases**, nunca en el `Main`.
- Todo constructor de una clase hija debe llamar al constructor del padre con `: base(...)` cuando el padre tenga parámetros.
- **Cambio respecto a la Tarea 3:** ahora sí se **redefinen** los métodos del padre en las clases hijas, usando el **mismo nombre** y la misma firma, con `virtual` en el padre y `override` en la hija.
- En todos los ejercicios, el `Main` debe aprovechar el polimorfismo: guardar objetos de distintas clases hijas en una variable o en una `List<>` del tipo **padre** y recorrerlos llamando a los métodos redefinidos.
- Comenta brevemente tu código explicando qué hace cada clase y cada método.
- Entrega el código fuente (`.cs`) y una captura de pantalla de la ejecución de cada ejercicio.

---

## Material de apoyo

### Parte A: Polimorfismo

#### ¿Qué es el polimorfismo?

**Polimorfismo** significa "muchas formas". En programación orientada a objetos permite que **un mismo mensaje (llamada a un método) produzca comportamientos distintos según el tipo real del objeto** que lo recibe.

Por ejemplo, todos los animales pueden "hacer un sonido", pero cada animal lo hace a su manera.

#### `virtual` y `override`

- En la clase **padre**, el método que podrá ser redefinido se marca con **`virtual`**.
- En la clase **hija**, el método que lo redefine se marca con **`override`**. Debe tener **el mismo nombre, el mismo tipo de retorno y los mismos parámetros**.

```csharp
class Animal
{
    protected string nombre;

    public Animal(string nombre)
    {
        this.nombre = nombre;
    }

    // virtual: las clases hijas PUEDEN redefinirlo
    public virtual void HacerSonido()
    {
        Console.WriteLine(nombre + " hace un sonido");
    }

    // Método normal: no se redefine, todos los animales lo comparten
    public void Presentarse()
    {
        Console.WriteLine("Soy " + nombre);
    }
}

class Perro : Animal
{
    public Perro(string nombre) : base(nombre) { }

    public override void HacerSonido()
    {
        Console.WriteLine(nombre + " dice: ¡Guau!");
    }
}

class Gato : Animal
{
    public Gato(string nombre) : base(nombre) { }

    public override void HacerSonido()
    {
        Console.WriteLine(nombre + " dice: ¡Miau!");
    }
}

class Pez : Animal
{
    public Pez(string nombre) : base(nombre) { }
    // No redefine HacerSonido: usará la versión del padre
}
```

> Una clase hija **no está obligada** a redefinir un método `virtual`. Si no lo hace, hereda la versión del padre.

#### El polimorfismo en acción

Como un `Perro` **es un** `Animal`, se puede guardar en una variable o lista de tipo `Animal`. Al llamar al método `virtual`, C# ejecuta **la versión del objeto real**, no la del tipo de la variable:

```csharp
List<Animal> animales = new List<Animal>();
animales.Add(new Perro("Toby"));
animales.Add(new Gato("Michi"));
animales.Add(new Pez("Nemo"));

foreach (Animal a in animales)
{
    a.HacerSonido();       // Cada objeto responde a su manera
}
```

**Salida:**

```
Toby dice: ¡Guau!
Michi dice: ¡Miau!
Nemo hace un sonido
```

```csharp
Animal x = new Perro("Rex");     // Variable del tipo padre, objeto de tipo hijo
x.HacerSonido();                 // Rex dice: ¡Guau!
x.Presentarse();                 // Soy Rex
```

> **Limitación:** a través de una variable del tipo padre solo se pueden usar los miembros que **el padre declara**. Si `Perro` tuviera un método propio `Ladrar()`, no se podría llamar desde una variable `Animal`. Por eso, para aprovechar el polimorfismo, lo que varía entre las clases hijas debe estar declarado como `virtual` en el padre.

#### Usar la versión del padre con `base.Metodo()`

Dentro de un método `override` se puede llamar a la versión del padre con `base.NombreMetodo()`. Es útil para **reutilizar** el cálculo del padre y solo agregar lo que cambia:

```csharp
class Entrada
{
    public virtual double CalcularPrecio()
    {
        return 50;
    }
}

class EntradaVIP : Entrada
{
    public override double CalcularPrecio()
    {
        return base.CalcularPrecio() * 2 + 10;    // 50 * 2 + 10 = 110
    }
}
```

> No confundas `base(...)` (en la declaración de un **constructor**) con `base.Metodo()` (dentro de un **método**).

#### Redefinir `ToString()`

Todas las clases en C# heredan de la clase `object`, que tiene un método `virtual` llamado `ToString()`. Puedes redefinirlo para que tus objetos se conviertan en texto de forma personalizada:

```csharp
class Punto
{
    public int x;
    public int y;

    public Punto(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return "(" + x + ", " + y + ")";
    }
}
```

```csharp
Punto p = new Punto(2, 3);
Console.WriteLine(p);                   // (2, 3)
Console.WriteLine("Punto: " + p);       // Punto: (2, 3)
```

`Console.WriteLine` y la concatenación con `+` llaman automáticamente a `ToString()`.

#### Errores comunes

| Mensaje del compilador | Causa |
|---|---|
| *CS0506: cannot override inherited member because it is not marked virtual, abstract, or override* | Usaste `override` en la hija, pero el método del padre no está marcado como `virtual`. |
| *CS0115: no suitable method found to override* | El método de la hija no coincide con el del padre (distinto nombre, parámetros o tipo de retorno). |
| Advertencia *CS0108: hides inherited member* | Declaraste en la hija un método con el mismo nombre que uno del padre, pero **sin** `override`. No se redefine: se "oculta", y el polimorfismo no funciona. |

---

### Parte B: Clases abstractas

#### ¿Qué es una clase abstracta?

Una **clase abstracta** es una clase pensada **solo para ser heredada**. Representa un concepto general (como "Figura" o "Método de pago") del que no tiene sentido crear objetos directamente.

- Se declara con la palabra **`abstract`**.
- **No se puede instanciar**: `new Figura()` produce un error de compilación.
- Puede tener **atributos, constructores y métodos normales** (con código), como cualquier otra clase.
- Puede tener **métodos abstractos**: métodos **sin cuerpo** que obligan a las clases hijas a implementarlos.

#### Métodos abstractos

Un método abstracto solo declara **qué** debe hacerse, no **cómo**. Termina en `;` y no lleva llaves. Las clases hijas **deben** implementarlo con `override`.

```csharp
abstract class Figura
{
    protected string nombre;

    // Las clases abstractas pueden tener constructor
    public Figura(string nombre)
    {
        this.nombre = nombre;
    }

    // Método abstracto: sin cuerpo, las hijas están obligadas a implementarlo
    public abstract double CalcularArea();

    // Método normal: tiene código y todas las hijas lo heredan
    public void MostrarFigura()
    {
        Console.WriteLine(nombre + " - Área: " + CalcularArea());
    }
}

class Cuadrado : Figura
{
    private double lado;

    public Cuadrado(double lado) : base("Cuadrado")
    {
        this.lado = lado;
    }

    public override double CalcularArea()
    {
        return lado * lado;
    }
}

class Circulo : Figura
{
    private double radio;

    public Circulo(double radio) : base("Círculo")
    {
        this.radio = radio;
    }

    public override double CalcularArea()
    {
        return Math.PI * radio * radio;
    }
}
```

Observa que `MostrarFigura()` (método normal del padre) llama a `CalcularArea()` (método abstracto): cada objeto ejecuta su propia versión. Esto combina clases abstractas con polimorfismo:

```csharp
List<Figura> figuras = new List<Figura>();
figuras.Add(new Cuadrado(3));
figuras.Add(new Circulo(1));

foreach (Figura f in figuras)
{
    f.MostrarFigura();
}
```

**Salida:**

```
Cuadrado - Área: 9
Círculo - Área: 3.141592653589793
```

```csharp
Figura f = new Figura("Genérica");    // ❌ ERROR: no se puede instanciar una clase abstracta
Figura g = new Cuadrado(5);           // ✅ Correcto: variable abstracta, objeto concreto
```

#### `virtual` vs `abstract`

| | Método `virtual` | Método `abstract` |
|---|---|---|
| ¿Tiene cuerpo (código) en el padre? | **Sí**, ofrece una versión por defecto. | **No**, solo la firma terminada en `;`. |
| ¿La hija debe redefinirlo? | No, es opcional. | **Sí**, es obligatorio. |
| ¿Dónde puede declararse? | En cualquier clase. | **Solo en clases abstractas.** |
| ¿Se usa `override` en la hija? | Sí. | Sí. |

#### Reglas importantes

1. Una clase con **al menos un método abstracto** debe declararse `abstract`.
2. Una clase hija de una clase abstracta debe implementar **todos** los métodos abstractos; si no, también debe declararse `abstract`.
3. Un método abstracto **no puede ser `private`** (las hijas deben poder implementarlo).
4. Una clase abstracta puede tener constructor; se invoca desde las hijas con `: base(...)`.
5. Una clase abstracta puede combinar métodos abstractos, métodos `virtual` y métodos normales.

#### Errores comunes

| Mensaje del compilador | Causa |
|---|---|
| *CS0144: cannot create an instance of the abstract type or interface* | Intentaste hacer `new` de una clase abstracta. |
| *CS0534: 'X' does not implement inherited abstract member 'Y'* | La clase hija no implementó (con `override`) un método abstracto del padre. |
| *CS0500: cannot declare a body because it is marked abstract* | Escribiste llaves `{ }` en un método abstracto. |
| *CS0513: abstract member in a non-abstract class* | Declaraste un método abstracto en una clase que no es `abstract`. |

---

# PARTE A: POLIMORFISMO

## Ejercicio 1: Clases `Instrumento`, `Guitarra`, `Piano`, `Bateria` y `Maraca` (Nivel: Muy fácil)

**Conceptos:** `virtual`, `override`, variable del tipo padre, lista polimórfica.

Crea la clase padre `Instrumento` (clase normal, **no abstracta**) con:

- Atributo **protected**: `nombre` (string).
- Constructor que reciba el nombre.
- Método `virtual` `Tocar()`: imprime `"[nombre] produce un sonido genérico."`.
- Método normal `Afinar()`: imprime `"Afinando [nombre]..."`.

Crea las clases hijas:

- `Guitarra`: redefine `Tocar()` para imprimir `"[nombre] (guitarra): ¡rasgueo de cuerdas!"`.
- `Piano`: redefine `Tocar()` para imprimir `"[nombre] (piano): ¡notas de teclas!"`.
- `Bateria`: redefine `Tocar()` para imprimir `"[nombre] (batería): ¡ritmo de tambores!"`.
- `Maraca`: **no redefine** `Tocar()` (usará la versión del padre).

Todas las clases hijas deben tener su constructor llamando a `base`.

En el `Main`:

1. Crea una variable `Instrumento i = new Guitarra("Fender");` y llama a `Tocar()`.
2. Crea una `List<Instrumento>` con al menos 5 instrumentos de distintos tipos (incluye una `Maraca`).
3. Recorre la lista con `foreach` llamando a `Afinar()` y luego a `Tocar()` de cada instrumento.
4. **Experimento:** quita temporalmente la palabra `virtual` del método `Tocar()` del padre y compila. Anota en un comentario el error que muestra el compilador y por qué ocurre. Luego restaura el código.

**Salida esperada (ejemplo):**

```
Afinando Fender...
Fender (guitarra): ¡rasgueo de cuerdas!
Afinando Yamaha...
Yamaha (piano): ¡notas de teclas!
Afinando Maraca roja...
Maraca roja produce un sonido genérico.
```

---

## Ejercicio 2: Sistema de `Notificacion` (Nivel: Fácil)

**Conceptos:** polimorfismo con métodos que retornan valores, constructores con `base`, clase que administra una lista polimórfica.

### Clase `Notificacion` (padre, clase normal)

- Atributos **protected**: `destinatario` (string) y `mensaje` (string).
- Constructor que reciba destinatario y mensaje.
- Método `virtual` `Enviar()`: imprime `"Enviando notificación a [destinatario]: [mensaje]"`.
- Método `virtual` `CalcularCosto()`: retorna `0`.

### Clases hijas

- `Email`: atributo privado `asunto`. Redefine `Enviar()` mostrando destinatario, asunto y mensaje con el formato `"EMAIL a [destinatario] | Asunto: [asunto] | [mensaje]"`. Redefine `CalcularCosto()` retornando `0.10`.
- `SMS`: redefine `Enviar()` con el formato `"SMS a [destinatario]: [mensaje]"`. Redefine `CalcularCosto()`: cuesta `0.50` **por cada 160 caracteres** (o fracción) del mensaje. Por ejemplo, un mensaje de 161 caracteres cuesta `1.00`.
- `PushNotification`: atributo privado `nombreApp`. Redefine **solo** `Enviar()` con el formato `"PUSH [nombreApp] a [destinatario]: [mensaje]"`. **No redefine** `CalcularCosto()` (usa el del padre, que es `0`).

### Clase `CentroNotificaciones`

- Atributo **privado**: `List<Notificacion>`.
- `Agregar(Notificacion n)`.
- `EnviarTodas()`: llama a `Enviar()` de cada notificación.
- `CalcularCostoTotal()`: suma el costo de todas las notificaciones.
- `ObtenerNotificacionMasCostosa()`: retorna la notificación con mayor costo, o `null` si no hay ninguna.

En el `Main`:

- Agrega al menos 6 notificaciones de los tres tipos (incluye un SMS con un mensaje largo, de más de 160 caracteres).
- Envía todas, muestra el costo total y el costo de la notificación más costosa.

---

## Ejercicio 3: Paquetería con `Envio` (Nivel: Medio)

**Conceptos:** polimorfismo con varios métodos `virtual`, reutilización con `base.Metodo()`, listas polimórficas con búsquedas y cálculos.

### Clase `Envio` (padre, clase normal)

- Atributos **protected**: `codigo` (string), `destino` (string) y `pesoKg` (double).
- Propiedad de solo lectura `Codigo`.
- Constructor que reciba código, destino y peso (si el peso no es mayor a 0, se asigna `1`).
- Método `virtual` `CalcularCosto()`: retorna `pesoKg × 5`.
- Método `virtual` `CalcularDiasEntrega()`: retorna `7`.
- Método `virtual` `MostrarEnvio()`: imprime código, destino, peso, costo y días de entrega.

### Clases hijas

- **`EnvioTerrestre`** (atributo privado `distanciaKm`, double):
  - `CalcularCosto()`: costo del padre (`base.CalcularCosto()`) `+ distanciaKm × 0.5`.
  - `CalcularDiasEntrega()`: `2 + (distanciaKm / 500)` con división entera.
  - `MostrarEnvio()`: llama a `base.MostrarEnvio()` y agrega una línea con `"Tipo: Terrestre | Distancia: [distanciaKm] km"`.
- **`EnvioAereo`** (atributo privado `esInternacional`, bool):
  - `CalcularCosto()`: costo del padre `+ 50`; si es internacional, ese resultado se multiplica por `1.5`.
  - `CalcularDiasEntrega()`: `1` si es nacional, `3` si es internacional.
  - `MostrarEnvio()`: llama a `base.MostrarEnvio()` y agrega una línea con el tipo y si es internacional.
- **`EnvioExpress`**:
  - `CalcularCosto()`: `base.CalcularCosto() × 2 + 20`.
  - `CalcularDiasEntrega()`: `1`.
  - `MostrarEnvio()`: llama a `base.MostrarEnvio()` y agrega `"Tipo: Express (prioridad máxima)"`.

### Clase `Paqueteria`

- Atributo **privado**: `List<Envio>`.
- `RegistrarEnvio(Envio e)`: no permite códigos repetidos.
- `MostrarEnvios()`.
- `CalcularIngresosTotales()`.
- `CalcularCostoPromedio()`: retorna `0` si no hay envíos.
- `ObtenerEnvioMasCaro()` y `ObtenerEnvioMasRapido()` (el de menos días de entrega); ambos retornan `null` si no hay envíos.
- `MostrarEnviosMasCarosQue(double monto)`.

En el `Main`:

- Registra al menos 6 envíos de los tres tipos (incluye un código repetido).
- Muestra todos los envíos, los ingresos totales, el costo promedio, el envío más caro, el más rápido y los envíos que cuestan más de `100`.

---

## Ejercicio 4: Ajedrez simplificado con `Pieza` (Nivel: Difícil)

**Conceptos:** polimorfismo con parámetros, redefinición de `ToString()`, validación de reglas, varias clases que colaboran.

Se simulará un tablero de ajedrez de 8×8 con solo cuatro tipos de piezas. **Para simplificar, no se valida que haya piezas en el camino** (por ejemplo, una torre puede "saltar" sobre otras piezas).

### Clase `Pieza` (padre, clase normal)

- Atributos **privados**: `esBlanca` (bool), `fila` (int) y `columna` (int).
- Propiedad de solo lectura `EsBlanca`. Propiedades `Fila` y `Columna` con `private set`.
- Constructor que reciba `esBlanca`, `fila` y `columna`.
- Método `ActualizarPosicion(int fila, int columna)`: cambia la posición de la pieza.
- Método `virtual` `EsMovimientoValido(int filaDestino, int columnaDestino)`: en el padre retorna `false` (una pieza genérica no se mueve).
- Método `ToString()` redefinido (`override`): en el padre retorna `"?"`.

### Clases hijas (todas redefinen `EsMovimientoValido` y `ToString`)

Todas deben retornar `false` si el destino es la misma casilla donde ya está la pieza. En `ToString()`, retornan la letra **mayúscula** si es blanca y **minúscula** si es negra.

| Clase | Movimiento válido | Letra |
|---|---|---|
| `Torre` | Misma fila **o** misma columna. | `T` / `t` |
| `Alfil` | Diagonal: la diferencia absoluta de filas es igual a la de columnas. | `A` / `a` |
| `Caballo` | En "L": diferencia de (1, 2) o (2, 1) entre filas y columnas. | `C` / `c` |
| `Rey` | Una casilla en cualquier dirección. | `R` / `r` |

> Usa `Math.Abs(...)` para trabajar con diferencias absolutas.

### Clase `Tablero`

- Atributo **privado**: `List<Pieza>`; atributos privados para contar las capturas de cada color, con propiedades de solo lectura `CapturasBlancas` (piezas blancas capturadas) y `CapturasNegras`.
- `AgregarPieza(Pieza p)`: retorna `true` solo si la posición está dentro del tablero (0 a 7) y la casilla está vacía.
- `BuscarPieza(int fila, int columna)`: retorna la pieza de esa casilla o `null`.
- `MoverPieza(int filaOrigen, int columnaOrigen, int filaDestino, int columnaDestino)`: retorna `true` si el movimiento se realizó, o `false` con un mensaje explicativo si falla. Debe validar, en este orden:
  1. Que origen y destino estén dentro del tablero.
  2. Que haya una pieza en el origen.
  3. Que en el destino no haya una pieza del **mismo color**.
  4. Que el movimiento sea válido llamando a `EsMovimientoValido` de la pieza (**polimorfismo**).

  Si en el destino hay una pieza del color contrario, esta se **captura**: se elimina de la lista y se actualiza el contador de capturas. Finalmente se actualiza la posición de la pieza movida.
- `ContarPiezas(bool blancas)`: cantidad de piezas de ese color que quedan en el tablero.
- `MostrarTablero()`: imprime el tablero de 8×8 usando un punto `.` para las casillas vacías y `ToString()` de cada pieza para las ocupadas.

En el `Main`:

1. Coloca al menos 3 piezas blancas y 3 negras (incluye al menos una de cada tipo). Intenta colocar una pieza en una casilla ocupada y otra fuera del tablero.
2. Muestra el tablero.
3. Realiza al menos 8 movimientos: algunos válidos, otros inválidos (movimiento ilegal para esa pieza, casilla de origen vacía, destino con pieza del mismo color, fuera del tablero) y **al menos dos capturas**.
4. Después de cada movimiento muestra el tablero. Al final muestra las capturas y la cantidad de piezas restantes de cada color.

---

# PARTE B: CLASES ABSTRACTAS

## Ejercicio 5: Métodos de pago con `MetodoPago` (Nivel: Fácil)

**Conceptos:** clase abstracta, métodos abstractos, método normal que usa métodos abstractos, impedir la instanciación.

### Clase `MetodoPago` (**abstracta**)

- Atributo **protected**: `titular` (string).
- Constructor que reciba el titular.
- Método **abstracto** `bool ProcesarPago(double monto)`: intenta realizar el pago del monto indicado.
- Método **abstracto** `double CalcularComision(double monto)`.
- Método **abstracto** `string ObtenerTipo()`.
- Método normal `MostrarMetodo()`: imprime `"[tipo] - Titular: [titular]"` (usando `ObtenerTipo()`).
- Método normal `RealizarCobro(double monto)`:
  1. Si el monto no es mayor a 0, muestra un error y termina.
  2. Calcula la comisión con `CalcularComision`.
  3. Calcula el total (`monto + comisión`) y llama a `ProcesarPago(total)`.
  4. Muestra `"Pago exitoso. Monto: X | Comisión: Y | Total: Z"` si se pudo, o `"Pago rechazado"` si no.

### Clases hijas

- **`Efectivo`**: atributo privado `dineroDisponible`. `ProcesarPago` descuenta el monto si alcanza el dinero disponible (retorna `true`) o retorna `false`. Comisión: `0`.
- **`TarjetaCredito`**: atributos privados `limiteCredito` y `saldoUsado` (inicia en `0`). `ProcesarPago` acepta el pago si `saldoUsado + monto <= limiteCredito` y lo suma al saldo usado. Comisión: `3 %` del monto.
- **`Transferencia`**: atributo privado `saldoCuenta`. `ProcesarPago` descuenta el monto si el saldo alcanza. Comisión fija de `2` por operación.

En el `Main`:

1. Intenta escribir `MetodoPago m = new MetodoPago("Ana");`. Anota en un comentario el error del compilador y por qué ocurre. Luego comenta la línea.
2. Crea una `List<MetodoPago>` con los tres tipos.
3. Recorre la lista mostrando cada método y realizando un cobro de `100` con cada uno.
4. Realiza cobros adicionales que fallen (por ejemplo, un monto mayor a lo disponible) y uno con monto inválido.

---

## Ejercicio 6: Parque de atracciones con `Atraccion` (Nivel: Medio)

**Conceptos:** clase abstracta con atributos, constructor y métodos normales; varios métodos abstractos; lista de objetos abstractos; cálculos y reportes.

### Clase `Atraccion` (**abstracta**)

- Atributos **protected**: `nombre` (string), `alturaMinima` (double, en metros) y `capacidadDiaria` (int).
- Propiedad `Visitantes` (int) con `private set`, que inicia en `0`.
- Propiedad de solo lectura `Nombre`.
- Constructor que reciba nombre, altura mínima y capacidad diaria.
- Método **abstracto** `double CalcularPrecio(int edad)`.
- Método **abstracto** `string ObtenerDescripcion()`.
- Método normal `PuedeSubir(double altura)`: retorna `true` si la altura es mayor o igual a la mínima.
- Método normal `RegistrarVisita(int edad, double altura)`: retorna el precio pagado, o `-1` si no pudo ingresar (altura insuficiente o capacidad diaria completa; en ambos casos muestra el motivo). Si ingresa, incrementa `Visitantes`.

### Clases hijas

- **`MontanaRusa`** (atributo privado `velocidadMaxima`, int km/h; altura mínima `1.2`): precio `20` para menores de 12 años, `15` para mayores o iguales a 60 años y `30` para el resto. La descripción incluye velocidad máxima y altura mínima.
- **`CasaEncantada`** (atributo privado `nivelSusto`, de 1 a 5; si no es válido se asigna `3`; altura mínima `0`): precio `10 + (nivelSusto × 2)` para todas las edades. La descripción incluye el nivel de susto.
- **`Carrusel`** (atributo privado `cantidadCaballos`; altura mínima `0.9`): gratis (`0`) para niños de hasta 5 años y `10` para el resto. La descripción incluye la cantidad de caballos.

### Clase `Parque`

- Atributos **privados**: `List<Atraccion>` y `recaudacion` (double).
- Propiedad `NombreParque`.
- `AgregarAtraccion(Atraccion a)`: no permite nombres repetidos.
- `VisitarAtraccion(string nombre, int edad, double altura)`: busca la atracción (mensaje si no existe), registra la visita y, si fue exitosa, suma el precio a la recaudación y muestra un mensaje de confirmación.
- `MostrarAtracciones()`: muestra la descripción y la cantidad de visitantes de cada atracción.
- `CalcularRecaudacion()`.
- `ObtenerAtraccionMasVisitada()`: retorna `null` si no hay atracciones.

En el `Main`:

- Crea un parque con al menos 3 atracciones (una de cada tipo, con capacidad diaria baja en alguna para probar que se llena).
- Simula al menos 12 visitas con distintas edades y alturas (incluye casos que no cumplen la altura mínima, una atracción llena y una atracción inexistente).
- Muestra las atracciones, la recaudación total y la atracción más visitada.

---

## Ejercicio 7: Sistema de Restaurante (Nivel: Difícil)

**Conceptos:** **dos jerarquías abstractas** (`Plato` y `Promocion`), polimorfismo, colaboración entre varias clases, listas, validaciones y menú interactivo.

### Clase `Plato` (**abstracta**)

- Atributos **protected**: `nombre` (string) y `precioBase` (double; si no es mayor a 0, se asigna `1`).
- Propiedad de solo lectura `Nombre`.
- Constructor que reciba nombre y precio base.
- Método **abstracto** `double CalcularPrecioFinal()`.
- Método **abstracto** `int ObtenerTiempoPreparacion()` (en minutos).
- Método normal `MostrarPlato()`: imprime nombre, precio final y tiempo de preparación.

### Clases hijas de `Plato`

| Clase | Atributo privado | Precio final | Tiempo de preparación |
|---|---|---|---|
| `Entrada` | `esVegetariana` (bool) | `precioBase` | `10` |
| `PlatoFuerte` | `porcionGrande` (bool) | `precioBase`; si la porción es grande, `precioBase × 1.25` | `25`; si es grande, `30` |
| `Postre` | `esHelado` (bool) | `precioBase × 1.10` (incluye servicio) | `5` si es helado, `15` en otro caso |
| `Bebida` | `mililitros` (int; si no es mayor a 0, se asigna `250`) | `precioBase × (mililitros / 250.0)` | `2` |

### Clase `Promocion` (**abstracta**)

- Atributo **protected**: `nombrePromocion` (string).
- Propiedad de solo lectura `NombrePromocion`.
- Constructor que reciba el nombre de la promoción.
- Método **abstracto** `double CalcularDescuento(double subtotal, int cantidadPlatos)`.
- Método normal `MostrarPromocion()`.

### Clases hijas de `Promocion`

- **`SinPromocion`**: el descuento es siempre `0`.
- **`PromocionPorcentaje`** (atributo privado `porcentaje`; solo se acepta entre 0 y 50, si no se asigna `0`): descuento = `subtotal × porcentaje / 100`.
- **`PromocionPorCantidad`** (atributos privados `cantidadMinima` y `descuentoFijo`): si la cantidad de platos es mayor o igual a la mínima, el descuento es el monto fijo (sin superar nunca el subtotal); en otro caso, `0`.

### Clase `Pedido`

- Atributos **privados**: `numero` (int), `mesa` (int), `List<Plato>`, `promocion` (Promocion, inicia como una `SinPromocion`) y `cerrado` (bool).
- Propiedades de solo lectura `Numero` y `Mesa`; propiedad `Cerrado` con `private set`.
- `AgregarPlato(Plato p)`: retorna `false` si el pedido está cerrado.
- `AplicarPromocion(Promocion p)`: retorna `false` si el pedido está cerrado.
- `CalcularSubtotal()`: suma los precios finales de los platos.
- `CalcularDescuento()`: usa la promoción aplicada (**polimorfismo**).
- `CalcularTotal()`: subtotal menos descuento.
- `CalcularTiempoEstimado()`: como los platos se preparan en paralelo, es el **mayor** tiempo de preparación entre los platos (`0` si no hay platos).
- `CerrarPedido()`: solo se puede cerrar si tiene al menos un plato y no estaba cerrado. Retorna `true` o `false`.
- `MostrarPedido()`: lista los platos y muestra subtotal, promoción aplicada, descuento, total y tiempo estimado.

### Clase `Restaurante`

- Atributos **privados**: `List<Plato>` (menú), `List<Pedido>`, `ingresos` (double) y un contador para numerar los pedidos automáticamente.
- `RegistrarPlato(Plato p)`: no permite nombres repetidos.
- `CrearPedido(int mesa)`: crea el pedido con el siguiente número y lo retorna.
- `AgregarPlatoAPedido(int numeroPedido, string nombrePlato)`: valida que existan el pedido y el plato.
- `AplicarPromocionAPedido(int numeroPedido, Promocion p)`.
- `CerrarPedido(int numeroPedido)`: cierra el pedido y suma su total a los ingresos.
- `MostrarMenu()`, `MostrarPedidosAbiertos()`.
- `CalcularIngresos()`.
- `ObtenerPlatoMasCaro()`: según el precio final; retorna `null` si el menú está vacío.

Cada método debe mostrar un mensaje claro según el resultado (pedido inexistente, plato inexistente, pedido cerrado, etc.).

### Programa principal
Implementa un **menú por consola** con las siguientes opciones:

```
1. Ver menú
2. Crear pedido
3. Agregar plato a un pedido
4. Aplicar promoción a un pedido
5. Ver pedidos abiertos
6. Cerrar pedido
7. Ver ingresos
8. Salir
```

- En la opción 4, el usuario elige entre sin promoción, porcentaje o por cantidad, e ingresa los datos necesarios.
- El menú debe repetirse hasta que se elija la opción 8.
- Antes de entregar, precarga el menú con al menos 6 platos (al menos uno de cada tipo).