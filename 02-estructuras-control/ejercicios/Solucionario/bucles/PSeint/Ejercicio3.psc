Algoritmo ValidarContrasena
	
	Definir contrasena, contrasenaCorrecta Como Caracter
	
	contrasenaCorrecta <- "clave123"
	
	Repetir
		Escribir "Ingrese la contraseña:"
		Leer contrasena
		
		Si contrasena <> contrasenaCorrecta Entonces
			Escribir "Contraseña incorrecta. Intente nuevamente."
		FinSi
		
	Hasta Que contrasena = contrasenaCorrecta
	
	Escribir "¡Bienvenido! Contraseña correcta."

FinAlgoritmo