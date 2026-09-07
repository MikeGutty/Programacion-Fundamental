Algoritmo MenuOperaciones
	
	Definir opcion Como Entero
	Definir numero1, numero2, resultado Como Real
	
	Repetir
		
		Escribir "===== MENÚ DE OPCIONES ====="
		Escribir "1. Sumar dos números"
		Escribir "2. Restar dos números"
		Escribir "3. Salir"
		Escribir "============================"
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
				Escribir "Saliendo del programa..."
				
			De Otro Modo:
				Escribir "Error: opción inválida. Intente nuevamente."
				
		FinSegun
		
	Hasta Que opcion = 3
	
	Escribir "¡Gracias por utilizar el programa!"

FinAlgoritmo