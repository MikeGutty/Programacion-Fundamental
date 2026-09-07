Algoritmo SumaNumerosPares
	
	Definir numeroInicial, numeroFinal, i, suma Como Entero
	
	Escribir "Ingrese el número inicial:"
	Leer numeroInicial
	
	Escribir "Ingrese el número final:"
	Leer numeroFinal
	
	Si numeroInicial > numeroFinal Entonces
		Escribir "Error: el número inicial debe ser menor o igual al número final."
	SiNo
		suma <- 0
		
		Para i <- numeroInicial Hasta numeroFinal Con Paso 1 Hacer
			
			Si i MOD 2 = 0 Entonces
				suma <- suma + i
			FinSi
			
		FinPara
		
		Escribir "La suma de los números pares es: ", suma
	FinSi
	
FinAlgoritmo