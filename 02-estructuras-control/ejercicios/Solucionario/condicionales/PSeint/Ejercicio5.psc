Algoritmo DescuentoTienda
	
	Definir edad Como Entero
	Definir monto, descuento, montoFinal Como Real
	Definir membresia Como Logico
	
	Escribir "Ingrese la edad del cliente:"
	Leer edad
	
	Escribir "Ingrese el monto de la compra:"
	Leer monto
	
	Escribir "¿Tiene membresía activa? (Verdadero/Falso):"
	Leer membresia
	
	Si edad >= 18 Y monto >= 50 Y membresia = Verdadero Entonces
		
		descuento <- monto * 0.15
		montoFinal <- monto - descuento
		
		Escribir "El cliente recibe un descuento del 15%."
		Escribir "Descuento aplicado: $", descuento
		Escribir "Monto final a pagar: $", montoFinal
		
	SiNo
		
		montoFinal <- monto
		
		Escribir "El cliente no recibe el descuento."
		Escribir "Monto final a pagar: $", montoFinal
		
	FinSi
	
FinAlgoritmo