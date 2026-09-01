Algoritmo SisPromedio
	// Variable
	Definir cantidad, num, i Como Entero;
    Definir suma, promedio Como Real;
	
	// 1.
	Repetir
        Escribir "Ingrese la cantidad de numeros a sumar:";
        Leer cantidad;
        Si cantidad <= 0 Entonces
            Escribir "Debe ingresar un numero mayor a 0";
        FinSi
    Hasta Que cantidad > 0
	
	// 2.y 3.
	suma <- 0;
    Para i <- 1 Hasta cantidad Con Paso 1 Hacer
        Escribir "Ingrese el numero ", i, ":";
        Leer num;
        suma <- suma + num;
    FinPara
	
	promedio <- suma/cantidad
	
	Escribir "La suma total es: ", suma
	Escribir "El promedio es: ", promedio
	
FinAlgoritmo
