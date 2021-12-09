using System;

namespace Práctica_2___Árbol_Binario___Heap_Binaria
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			ArbolBinario<int> arbolBinarioA = new ArbolBinario<int>(1);

			ArbolBinario<int> hijoIzquierdo = new ArbolBinario<int>(2);
			hijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(3));
			hijoIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(4));

			ArbolBinario<int> hijoDerecho = new ArbolBinario<int>(5);
			hijoDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(6));
			hijoDerecho.agregarHijoDerecho(new ArbolBinario<int>(7));

			arbolBinarioA.agregarHijoIzquierdo(hijoIzquierdo);
			arbolBinarioA.agregarHijoDerecho(hijoDerecho);
			
			//arbolBinarioA.preorden();
            //arbolBinarioA.inorden();
            //arbolBinarioA.postorden();
            //arbolBinarioA.recorridoPorNiveles();
            //Console.WriteLine(arbolBinarioA.contarHojas());
            //arbolBinarioA.recorridoEntreNiveles(1, 2);
            int num = 2;
			Console.WriteLine(arbolBinarioA.incluye(num));
			
			
//			Heap heap = new Heap(25,true);
//			heap.agregar(41);
//			heap.agregar(2);
//			heap.agregar(3);
//			heap.agregar(4);
//			heap.agregar(51);
//			heap.agregar(6);
//			heap.agregar(1);
//			
//			heap.print();
//			Console.WriteLine();
//			
//			heap.eliminar();
//			
//			Console.WriteLine();
//			heap.print();
//			
//			Console.WriteLine();
//			heap.eliminar();
//			
//			Console.WriteLine();
//			heap.print();
//			
//			
//			Console.WriteLine();
//			heap.eliminar();
//			
//			Console.WriteLine();
//			heap.print();
//			
//			Console.WriteLine();
//			heap.eliminar();
//			
//			Console.WriteLine();
//			heap.print();
			
			/*true = BuildHeap Max / false = BuildHeap Min*/
			
			BuildHeap heap = new BuildHeap(false);
			int[] arreglo = new int[]{14, 10, 20, 9, 7, 8, 4, 15};
			int n = arreglo.Length;
			
			heap.BuildHeapM(arreglo);
			heap.muestroHeap(arreglo,n);
			
			Console.ReadKey(true);
		}
	}
}