using System;

namespace Práctica_1___Árbol_General
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Ingrese cantidad de litros de agua que ingresan al caño maestro: ");		
			ArbolGeneral<int> arbol = new ArbolGeneral<int>(Convert.ToInt32(Console.ReadLine()));
			
			/*se establecen en 0 los valores de los "caudales", ya que seran seteados al ser procesados por el algoritmo*/
            ArbolGeneral<int> arbol2 = new ArbolGeneral<int>(0);
            
            arbol.agregarHijo(arbol2); 
            arbol.agregarHijo(new ArbolGeneral<int>(0));
            arbol.agregarHijo(new ArbolGeneral<int>(0)); 
            arbol.agregarHijo(new ArbolGeneral<int>(0));
            
            arbol2.agregarHijo(new ArbolGeneral<int>(0));
            arbol2.agregarHijo(new ArbolGeneral<int>(0));
            arbol2.agregarHijo(new ArbolGeneral<int>(0));
            
            Console.WriteLine("El minimo caudal de agua que recibe una casa es de [{0}] litros",ArbolGeneral<int>.minimoCaudal(arbol));
			Console.ReadKey(true);
		}
	}
}