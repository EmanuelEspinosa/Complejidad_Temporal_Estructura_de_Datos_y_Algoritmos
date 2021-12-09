using System;

namespace Práctica_3___Árbol_AVL
{
	class Program
	{
		public static void Main(string[] args)
		{
			ArbolBinarioBusqueda arbol1 = new ArbolBinarioBusqueda(5);
            arbol1.agregar(12);
            arbol1.agregar(3);
            arbol1.agregar(4);
            arbol1.agregar(1);
            arbol1.agregar(15);
            arbol1.agregar(8);

            arbol1.inorden();
            Console.WriteLine();

            AVL arbolAVL1 = new AVL(1);
            arbolAVL1 = arbolAVL1.agregar(10);

            for (int i = 1; i <= 10; i++)
                arbolAVL1 = arbolAVL1.agregar(i);
            arbolAVL1.recorridoPorNiveles();

            Console.ReadKey();
		}
	}
}