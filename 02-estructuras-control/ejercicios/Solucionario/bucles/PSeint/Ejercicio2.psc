Algoritmo Factorial
	
	Definir numero, i, factorial Como Entero
	
	Repetir
		Escribir "Ingrese un número entero no negativo:"
		Leer numero
	Hasta Que numero >= 0
	
	factorial <- 1
	
	Para i <- 1 Hasta numero Con Paso 1 Hacer
		factorial <- factorial * i
	FinPara
	
	Escribir "El factorial de ", numero, " es: ", factorial
	
FinAlgoritmo