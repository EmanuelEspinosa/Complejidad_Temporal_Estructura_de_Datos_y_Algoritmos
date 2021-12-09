using System;

namespace Práctica_2___Árbol_Binario___Heap_Binaria
{
	public class BuildHeap
	{
//		
		private bool flag;
		private int tamañoArreglo;
		public BuildHeap(bool flag)
		{
			this.flag = flag;
		}
		
		public void BuildHeapM(int[] arr){
			tamañoArreglo = arr.Length - 1;
			for (int i = tamañoArreglo / 2; i  >= 0; i--)
				acomodar(arr, i);
		}
		
		private void acomodar(int[] arr, int index){
			int hijoIzquiero = index * 2;
			int hijoDerecho = (index * 2) + 1;
			int masGrande = index;
			
			if(flag)
			{
				if(hijoIzquiero <= tamañoArreglo && arr[hijoIzquiero] > arr[masGrande])
					masGrande = hijoIzquiero;
				if(hijoDerecho <= tamañoArreglo && arr[hijoDerecho] > arr[masGrande])
					masGrande = hijoDerecho;
				if(masGrande != index){
					int temp = arr[index];
					arr[index] = arr[masGrande];
					arr[masGrande] = temp;				
					acomodar(arr, masGrande);
				}
			}
			if(! flag)
			{
				if(hijoIzquiero <= tamañoArreglo && arr[hijoIzquiero] < arr[masGrande])
					masGrande = hijoIzquiero;
				if(hijoDerecho <= tamañoArreglo && arr[hijoDerecho] < arr[masGrande])
					masGrande = hijoDerecho;
				if(masGrande != index){
					int temp = arr[index];
					arr[index] = arr[masGrande];
					arr[masGrande] = temp;				
					acomodar(arr, masGrande);
				}
			}
					
		}
		public void muestroHeap(int[] arr, int tamaño){
			for (int i = 0; i < tamaño; i++) 
				Console.Write(arr[i] + " ");
			Console.WriteLine();
		}
	}
}
