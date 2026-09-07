Algoritmo CostoEnvio
	
	Definir peso, costo Como Real
	
	Escribir "Ingrese el peso del paquete en kg:"
	Leer peso
	
	Si peso < 0 Entonces
		Escribir "Error: el peso no puede ser negativo."
	SiNo
		Si peso <= 5 Entonces
			costo <- 5
			Escribir "El costo del envío es $", costo
		SiNo
			Si peso <= 15 Entonces
				costo <- 12
				Escribir "El costo del envío es $", costo
			SiNo
				Si peso <= 30 Entonces
					costo <- 20
					Escribir "El costo del envío es $", costo
				SiNo
					costo <- 35
					Escribir "El costo del envío es $", costo
				FinSi
			FinSi
		FinSi
	FinSi
	
FinAlgoritmo