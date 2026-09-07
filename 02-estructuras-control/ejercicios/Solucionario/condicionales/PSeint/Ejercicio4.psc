Algoritmo MenuOperaciones
	
	Definir opcion Como Entero
	Definir numero1, numero2, resultado Como Real
	
	Escribir "===== MENÚ DE OPERACIONES ====="
	Escribir "1. Sumar"
	Escribir "2. Restar"
	Escribir "3. Multiplicar"
	Escribir "4. Dividir"
	Escribir "==============================="
	Escribir "Seleccione una opción:"
	Leer opcion
	
	Segun opcion Hacer
		
		1:
			Escribir "Ingrese el primer número:"
			Leer numero1
			
			Escribir "Ingrese el segundo número:"
			Leer numero2
			
			resultado <- numero1 + numero2
			
			Escribir "Resultado: ", resultado
			
		2:
			Escribir "Ingrese el primer número:"
			Leer numero1
			
			Escribir "Ingrese el segundo número:"
			Leer numero2
			
			resultado <- numero1 - numero2
			
			Escribir "Resultado: ", resultado
			
		3:
			Escribir "Ingrese el primer número:"
			Leer numero1
			
			Escribir "Ingrese el segundo número:"
			Leer numero2
			
			resultado <- numero1 * numero2
			
			Escribir "Resultado: ", resultado
			
		4:
			Escribir "Ingrese el primer número:"
			Leer numero1
			
			Escribir "Ingrese el segundo número:"
			Leer numero2
			
			Si numero2 = 0 Entonces
				Escribir "Error: no se puede dividir entre cero."
			SiNo
				resultado <- numero1 / numero2
				Escribir "Resultado: ", resultado
			FinSi
			
		De Otro Modo:
			Escribir "Error: la opción ingresada no es válida."
			
	FinSegun
	
FinAlgoritmo