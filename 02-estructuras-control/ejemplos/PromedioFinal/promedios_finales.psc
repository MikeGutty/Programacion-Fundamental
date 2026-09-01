Algoritmo promedios_finales
	// Definiendo variables
	Definir nota Como Entero
	
	// Pidiendo datos
	Escribir "Introduzca su nota"
	Leer nota
	
	Si nota < 0 O nota > 100 Entonces
		Escribir "Ingrese una nota correcta"
	SiNo
		Si nota >= 90 Entonces
			Escribir "Excelente"
		SiNo
			Si nota >= 70 O nota <= 89 Entonces
				Escribir "Bueno"
			SiNo
				Si nota >= 50 O nota <= 69 Entonces
					Escribir "Regular"
				SiNo
					Escribir "Reprobado"
				FinSi
			FinSi
		FinSi
	Fin Si
	
	
FinAlgoritmo
