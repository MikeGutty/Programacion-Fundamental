# Evaluación Continua: Programación Orientada a Objetos en C#

**Temas evaluados:** clases, atributos, métodos, constructores, instancia de objetos, encapsulamiento (`public` y `private`), getters y setters (propiedades), `List<T>` y herencia (`protected` y `base`).

---

## Indicaciones generales

- Resuelve los **7 ejercicios** en C#. Están ordenados de menor a mayor dificultad, pero puedes resolverlos en el orden que prefieras.
- Cada ejercicio debe estar en su propio proyecto de consola (o en una carpeta separada dentro de la solución).
- Cada clase debe ir en su propio archivo `.cs`, salvo que el ejercicio indique lo contrario.
- Usa la convención de C#: `PascalCase` para clases, métodos y propiedades, y `camelCase` para atributos y parámetros.
- Respeta los modificadores de acceso indicados (`public`, `private` o `protected`). Forman parte de la calificación.
- Cuando se pida una validación, esta debe hacerse **dentro de la clase** (en el `set` o en el constructor), nunca en el `Main`.
- En las clases hijas, todo constructor debe llamar al constructor del padre con `base` cuando este tenga parámetros.
- **No repitas en una clase hija el nombre de un método de la clase padre.** Usa los nombres indicados en cada ejercicio.
- Se evaluará que el programa **compile y funcione**, y también el uso correcto de los conceptos de POO. Un ejercicio incompleto puede recibir puntaje parcial.
- Material permitido: [completar según tu criterio].
- Al finalizar, comprime todo en un único `.zip` con el nombre `Apellido_Nombre_Evaluacion.zip` y súbelo a la plataforma.

---

## Ejercicio 1: Clase `Televisor` (Nivel: Muy fácil) — 8 pts

**Conceptos:** clase, atributos públicos, métodos, instancia de objetos.

Crea una clase `Televisor` con los atributos **públicos**:

- `marca` (string)
- `pulgadas` (int)
- `encendido` (bool)
- `volumen` (int)
- `canal` (int)

Y los siguientes métodos:

1. `Encender()` y `Apagar()`: cambian el estado del televisor e informan el cambio por consola.
2. `SubirVolumen(int cantidad)` y `BajarVolumen(int cantidad)`: solo funcionan si el televisor está encendido. El volumen debe mantenerse siempre entre `0` y `100`.
3. `CambiarCanal(int nuevoCanal)`: solo funciona si el televisor está encendido y el canal es mayor a 0.
4. `MostrarEstado()`: imprime todos los datos del televisor.

En el `Main`:

1. Crea **dos televisores** y asigna sus datos directamente a los atributos.
2. Intenta cambiar el volumen de uno estando apagado y comprueba que no cambia.
3. Enciéndelo, sube el volumen más allá de 100 y comprueba que se queda en 100.
4. Cambia de canal y muestra el estado de ambos televisores.

---

## Ejercicio 2: Clase `Fraccion` (Nivel: Fácil) — 10 pts

**Conceptos:** constructores (por defecto y parametrizado), métodos que reciben y retornan objetos.

Crea una clase `Fraccion` con los atributos **públicos** `numerador` y `denominador` (int).

Debe tener:

1. Un **constructor por defecto** que cree la fracción `0/1`.
2. Un **constructor parametrizado** que reciba numerador y denominador. Si el denominador es `0`, debe asignarse `1` y mostrarse un mensaje de advertencia.
3. `Sumar(Fraccion otra)`: retorna una **nueva** `Fraccion` con el resultado de la suma (sin modificar las originales).
4. `Multiplicar(Fraccion otra)`: retorna una **nueva** `Fraccion` con el producto.
5. `Simplificar()`: reduce la fracción dividiendo numerador y denominador por su máximo común divisor. Usa un método **privado** `CalcularMCD(int a, int b)` como apoyo.
6. `ObtenerValorDecimal()`: retorna el resultado de la división como `double`.
7. `MostrarFraccion()`: imprime la fracción con el formato `numerador/denominador`.

En el `Main`:

- Crea las fracciones `1/2` y `3/4`, súmalas y multiplícalas, simplifica los resultados y muestra cada fracción junto con su valor decimal.
- Crea una fracción con denominador `0` y una con el constructor por defecto.

**Salida esperada (ejemplo):**

```
1/2 + 3/4 = 10/8 -> simplificada: 5/4 (1.25)
1/2 x 3/4 = 3/8 (0.375)
```

---

## Ejercicio 3: Clase `Ascensor` (Nivel: Fácil-Medio) — 12 pts

**Conceptos:** encapsulamiento, propiedades con `private set`, validaciones, propiedades calculadas.

Crea una clase `Ascensor` con:

- Atributos **privados**: `pisoActual` (int), `pisoMaximo` (int), `capacidadPersonas` (int), `personasDentro` (int) y `pisosRecorridos` (int).
- Propiedades públicas de **solo lectura**: `PisoMaximo` y `CapacidadPersonas`.
- Propiedades públicas con `private set`: `PisoActual`, `PersonasDentro` y `PisosRecorridos`.
- Propiedad calculada `EstaVacio` (`true` si no hay personas dentro).
- Constructor que reciba el piso máximo y la capacidad (ambos deben ser mayores a 0; si no, usa `5` y `4` respectivamente). El ascensor inicia en el piso `0`, vacío y con `0` pisos recorridos.

Métodos:

1. `Entrar(int personas)`: agrega personas sin superar la capacidad. Si no caben todas, no entra ninguna y se informa el motivo.
2. `Salir(int personas)`: baja personas sin quedar con un valor negativo.
3. `IrAPiso(int piso)`: mueve el ascensor al piso indicado si está entre `0` y `PisoMaximo`. Debe sumar a `PisosRecorridos` la cantidad de pisos que se movió. **No puede moverse si está vacío.**
4. `MostrarEstado()`: imprime piso actual, personas dentro y pisos recorridos.

En el `Main`:

1. Crea un ascensor y prueba todos los métodos, incluyendo casos inválidos (pasar la capacidad, ir a un piso que no existe, moverlo vacío).
2. Intenta escribir `ascensor.PisoActual = 3;` y anota en un comentario el error del compilador y su razón (luego comenta la línea).

---

## Ejercicio 4: Clases `Item` y `Carrito` (Nivel: Medio) — 15 pts

**Conceptos:** varias clases, propiedades con validación, `List<T>`, búsquedas, cálculos.

### Clase `Item`

- Atributos **privados**: `nombre` (string), `precio` (double) y `cantidad` (int).
- Propiedad `Nombre` de solo lectura.
- Propiedad `Precio` con validación en el `set` (debe ser mayor a 0).
- Propiedad `Cantidad` con validación en el `set` (debe ser al menos `1`).
- Propiedad calculada `Subtotal` (`precio × cantidad`).
- Constructor que reciba nombre, precio y cantidad (usando las propiedades para que se validen).
- `MostrarItem()`.

### Clase `Carrito`

- Atributo **privado**: `List<Item>`.
- Propiedad `Cliente` (string, con `get` y `set`).
- `AgregarItem(Item nuevo)`: si ya existe un ítem con el **mismo nombre**, suma la cantidad al existente en lugar de duplicarlo.
- `QuitarItem(string nombre)`: elimina el ítem y retorna `true`, o retorna `false` si no existe.
- `CalcularTotal()`: retorna la suma de los subtotales.
- `CalcularTotalConDescuento(double porcentaje)`: retorna el total aplicando el descuento (el porcentaje debe estar entre 0 y 50; si no, no se aplica descuento). **No modifica** los precios de los ítems.
- `ObtenerItemMasCaro()`: retorna el ítem con mayor subtotal, o `null` si el carrito está vacío.
- `MostrarCarrito()`: lista todos los ítems y el total.

En el `Main`:

- Crea un carrito, agrega al menos 4 ítems (uno repetido para comprobar que se suman las cantidades), intenta agregar un ítem con precio inválido, quita uno existente y otro inexistente, y muestra el total, el total con 10 % de descuento y el ítem más caro.

---

## Ejercicio 5: Clases `Cliente`, `ClienteRegular` y `ClientePremium` (Nivel: Medio-Difícil) — 15 pts

**Conceptos:** herencia, `protected`, `private`, `base`, métodos propios en cada clase hija.

### Clase `Cliente` (padre)

- Atributo **privado**: `id` (int), con propiedad de solo lectura `Id`.
- Atributos **protected**: `nombre` (string) y `totalCompras` (double).
- Propiedad `Nombre` con validación en el `set` (no puede estar vacío) y propiedad de solo lectura `TotalCompras`.
- Constructor que reciba id y nombre (`totalCompras` inicia en `0`).
- `RegistrarCompra(double monto)`: suma el monto al total solo si es mayor a 0.
- `MostrarCliente()`: imprime id, nombre y total de compras.

### Clase `ClienteRegular : Cliente`

- Atributo **privado**: `puntos` (int), con propiedad `Puntos` de `private set`.
- Constructor (llamando a `base`).
- `ComprarRegular(double monto)`: registra la compra usando el método heredado y acumula **1 punto por cada 10 unidades** de monto (solo la parte entera).
- `CanjearPuntos(int cantidad)`: si el cliente tiene suficientes puntos, los descuenta y retorna un descuento de `cantidad / 10` unidades monetarias; si no, retorna `0` y muestra un mensaje.
- `MostrarClienteRegular()`.

### Clase `ClientePremium : Cliente`

- Atributo **privado**: `porcentajeDescuento` (double). Solo se aceptan valores entre `5` y `30`; si no es válido, se asigna `10`.
- Constructor que reciba id, nombre y descuento (llamando a `base`).
- `ComprarPremium(double monto)`: aplica el descuento al monto, suma el monto con descuento **directamente al atributo protected** `totalCompras` y retorna el monto final pagado. Solo funciona si el monto es mayor a 0.
- `EsClienteVIP()`: retorna `true` si el total de compras supera `5000`.
- `MostrarClientePremium()`.

En el `Main`:

1. Crea un cliente regular y uno premium.
2. Realiza varias compras con cada uno (incluyendo un monto inválido), canjea puntos (uno válido y otro que exceda los puntos disponibles) y verifica si el premium es VIP.
3. Muestra los datos finales de ambos clientes.
4. **Experimento:** intenta escribir `premium.totalCompras = 100;` en el `Main` y anota en un comentario el error y por qué ocurre (luego comenta la línea).

---

## Ejercicio 6: Clases `Miembro`, `MiembroMensual`, `MiembroAnual` y `Gimnasio` (Nivel: Difícil) — 20 pts

**Conceptos:** herencia con `base`, `protected`, `List<T>` con varias clases hijas, validaciones y reportes.

### Clase `Miembro` (padre)

- Atributo **privado**: `id` (int), con propiedad de solo lectura `Id`.
- Atributos **protected**: `nombre` (string) y `cuotaMensual` (double).
- Propiedad de solo lectura `Nombre`.
- Constructor que reciba id, nombre y cuota mensual (si la cuota no es mayor a 0, se asigna `100`).
- `MostrarMiembro()`.

### Clase `MiembroMensual : Miembro`

- Atributo **privado**: `mesesPagados` (int), con propiedad `MesesPagados` de `private set`.
- Constructor (llamando a `base`).
- `PagarMes()`: incrementa los meses pagados.
- `CalcularTotalPagado()`: retorna `mesesPagados × cuotaMensual` (usa el atributo **protected**).
- `MostrarMiembroMensual()`.

### Clase `MiembroAnual : Miembro`

- Atributos **privados**: `descuento` (double, entre `0` y `0.5`; si no es válido, se asigna `0.2`) y `anualidadPagada` (bool), con propiedad `AnualidadPagada` de `private set`.
- Constructor que reciba id, nombre, cuota mensual y descuento (llamando a `base`).
- `CalcularCostoAnual()`: retorna `cuotaMensual × 12 × (1 - descuento)`.
- `PagarAnualidad()`: si ya estaba pagada, retorna `false`; si no, la marca como pagada y retorna `true`.
- `MostrarMiembroAnual()`.

### Clase `Gimnasio`

- Atributos **privados**: `List<MiembroMensual>` y `List<MiembroAnual>`.
- Propiedad `NombreGimnasio` (string).
- `RegistrarMensual(MiembroMensual m)` y `RegistrarAnual(MiembroAnual m)`: **no se permiten ids repetidos**, ni dentro de la misma lista ni entre ambas.
- `BuscarMensual(int id)` y `BuscarAnual(int id)`: retornan el objeto o `null`.
- `PagarMes(int id)` y `PagarAnualidad(int id)`: buscan al miembro correspondiente y registran el pago, mostrando un mensaje claro si no existe o si el pago no es posible.
- `CalcularIngresosTotales()`: suma lo pagado por todos los miembros mensuales y el costo anual de los anuales que ya pagaron.
- `MostrarMorosos()`: muestra los miembros mensuales con `0` meses pagados y los anuales que no han pagado su anualidad.
- `MostrarMiembros()`: lista a todos los miembros.

En el `Main`:

- Registra al menos 3 miembros mensuales y 3 anuales (incluye un intento de id repetido).
- Registra varios pagos, intenta pagar dos veces la misma anualidad y paga a un id que no existe.
- Muestra los morosos, los ingresos totales y el listado completo.

---

## Ejercicio 7: Sistema de una Aerolínea (Nivel: Muy difícil) — 20 pts

**Conceptos:** integración de todos los temas: herencia, `protected`, `private`, `base`, propiedades, validaciones, listas de objetos, relaciones entre clases y menú interactivo.

Desarrolla un sistema para gestionar vuelos con las siguientes clases:

### Clase `Persona` (padre)

- Atributo **privado**: `documento` (string), con propiedad de solo lectura `Documento`.
- Atributos **protected**: `nombre` (string) y `edad` (int).
- Propiedad `Nombre` (no vacío) y propiedad `Edad` (entre 0 y 120), con validación en el `set`. Estas validaciones también deben aplicarse desde el constructor.
- Constructor que reciba documento, nombre y edad.
- `MostrarPersona()`.

### Clase `Pasajero : Persona`

- Atributo **privado**: `equipajeKg` (double), con propiedad `EquipajeKg` (no puede ser negativo).
- Constructor (llamando a `base`).
- `CalcularCargoEquipaje()`: los primeros `23` kg son gratis; cada kilo adicional cuesta `10`.
- `MostrarPasajero()`.

### Clase `Piloto : Persona`

- Atributos **privados**: `licencia` (string) y `horasVuelo` (int), con propiedad `HorasVuelo` de `private set`.
- Constructor (llamando a `base`).
- `PuedeVolar()`: retorna `true` si el piloto tiene al menos `500` horas de vuelo.
- `RegistrarHoras(int horas)`: suma horas de vuelo solo si el valor es mayor a 0.
- `MostrarPiloto()`.

### Clase `Vuelo` (no hereda de nada)

- Atributos **privados**: `codigo` (string), `origen` (string), `destino` (string), `capacidad` (int), `precioBase` (double), `duracionHoras` (int), `piloto` (Piloto, inicia en `null`), `finalizado` (bool) y una `List<Pasajero>`.
- Propiedad de solo lectura `Codigo` y propiedad calculada `AsientosDisponibles`.
- Constructor que reciba código, origen, destino, capacidad, precio base y duración.
- `AsignarPiloto(Piloto p)`: solo si el vuelo no tiene piloto y el piloto cumple `PuedeVolar()`. Retorna `true` o `false`.
- `AgregarPasajero(Pasajero p)`: solo si el vuelo tiene piloto, no está finalizado, hay asientos disponibles y el pasajero no está ya registrado (por documento). Retorna `true` o `false`.
- `QuitarPasajero(string documento)`: retorna `true` o `false`.
- `CalcularIngresos()`: suma, por cada pasajero, el precio base más el cargo por equipaje.
- `FinalizarVuelo()`: marca el vuelo como finalizado y suma al piloto las horas de duración. Retorna `false` si no tiene piloto o ya estaba finalizado.
- `MostrarVuelo()` y `MostrarPasajeros()`.

### Clase `Aerolinea`

- Atributos **privados**: listas de pilotos, pasajeros y vuelos.
- `RegistrarPiloto(Piloto p)` y `RegistrarPasajero(Pasajero p)`: no permiten documentos repetidos (ni siquiera entre pilotos y pasajeros).
- `CrearVuelo(Vuelo v)`: no permite códigos repetidos.
- `AsignarPilotoAVuelo(string codigoVuelo, string docPiloto)`.
- `ReservarAsiento(string codigoVuelo, string docPasajero)`.
- `CancelarReserva(string codigoVuelo, string docPasajero)`.
- `FinalizarVuelo(string codigoVuelo)`.
- `MostrarVuelos()`.
- `CalcularIngresosAerolinea()`: suma los ingresos de todos los vuelos.

Cada método de `Aerolinea` debe mostrar un mensaje claro según el resultado (por ejemplo, vuelo inexistente, piloto sin horas suficientes, vuelo lleno, reserva exitosa).

### Programa principal
Implementa un **menú por consola** con las siguientes opciones:

```
1. Registrar piloto
2. Registrar pasajero
3. Crear vuelo
4. Asignar piloto a vuelo
5. Reservar asiento
6. Cancelar reserva
7. Finalizar vuelo
8. Ver vuelos
9. Ver ingresos totales
10. Salir
```

El menú debe repetirse hasta que el usuario elija la opción 10. Precarga al menos 2 pilotos (uno con menos de 500 horas), 4 pasajeros y 2 vuelos para probar el sistema.

---

## Distribución del puntaje

| Ejercicio | Nivel | Puntaje |
|---|---|---|
| 1. Televisor | Muy fácil | 8 pts |
| 2. Fraccion | Fácil | 10 pts |
| 3. Ascensor | Fácil-Medio | 12 pts |
| 4. Item y Carrito | Medio | 15 pts |
| 5. Cliente, ClienteRegular y ClientePremium | Medio-Difícil | 15 pts |
| 6. Gimnasio | Difícil | 20 pts |
| 7. Aerolínea | Muy difícil | 20 pts |
| **Total** | | **100 pts** |

### Aspectos que se evalúan en cada ejercicio

| Aspecto | Descripción |
|---|---|
| Funcionamiento | El programa compila y cumple lo solicitado. |
| Uso correcto de POO | Clases, constructores, encapsulamiento, propiedades y herencia aplicados según el enunciado. |
| Validaciones | Se realizan dentro de la clase y cubren los casos indicados. |
| Claridad del código | Nombres adecuados, orden y comentarios breves. |

> **Nota:** El código copiado o compartido entre estudiantes anulará el ejercicio correspondiente.