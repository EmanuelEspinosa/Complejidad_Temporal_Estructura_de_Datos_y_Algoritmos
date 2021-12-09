using System;

namespace Práctica_2___Árbol_Binario___Heap_Binaria
{
	public class MinHeap
	{
		private int[] heap;
		private int cantElem;
		
		//Constructor para crear Heap vacio
		public MinHeap(int cantidadElementos){
			heap = new int[cantidadElementos + 1]; //Se esta agregando cantidadElementos + 1, porque el indice 0 quedara vacio. 
			cantElem = 0;
			
		}
		
		//Constructor para crear Heap a partir de un arreglo de números
		public MinHeap(int[] arr){
			this.cantElem = arr.Length;
			heap = arr;
		}
		
//		public void Insertar(int dato){
//			heap[cantElem + 1] = dato;
//			cantElem++;
//			FiltradoAbajoHaciaArriba(cantElem);	
//		}
		public void Insertar(int dato)
		{
			heap[cantElem + 1] = dato;
			cantElem++;
			FiltradoAbajoHaciaArriba(cantElem);
		}
		public int eliminar(){
			int valorElim = heap[1];
			heap[1] = heap[cantElem];
			cantElem--;
			FiltradoArribaHaciaAbajo(1);
			return valorElim;
		}
		public void FiltradoAbajoHaciaArriba(int index){
			int padre = index / 2;
			if(index <= 1)
				return;
			if(heap[index] < heap[padre]){
				int aux = heap[index];
				heap[index] = heap[padre];
				heap[padre] = aux;
			}
			FiltradoAbajoHaciaArriba(padre);
		}
		public void FiltradoArribaHaciaAbajo(int index){
			int hijoIzquierdo = index * 2;
			int hijoDerecho = (index * 2) + 1;
			int menor = 0;
			
			if(cantElem < hijoIzquierdo)
				return;
			if(cantElem == hijoIzquierdo){
				if(heap[index] > heap[hijoIzquierdo]){
					int temp = heap[index];
					heap[index] = heap[hijoIzquierdo];
					heap[hijoIzquierdo] = temp;
				}
				return;
			}
			else{
				if(heap[hijoIzquierdo] < heap[hijoDerecho])
					menor = hijoIzquierdo;
				else
					menor = hijoDerecho;
				if(heap[index] > heap[menor]){
					int temp2 = heap[index];
					heap[index] = heap[menor];
					heap[menor] = temp2;
				}
			}
			FiltradoArribaHaciaAbajo(menor);
		}
		public void mostrar(){
			for (int i = 1; i <= cantElem ; i++) {
				Console.Write(heap[i] + " ");
			}
		}
		
		
		
	}
}
