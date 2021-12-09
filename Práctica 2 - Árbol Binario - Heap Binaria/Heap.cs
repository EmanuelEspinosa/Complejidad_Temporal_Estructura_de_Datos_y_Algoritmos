using System;

namespace Práctica_2___Árbol_Binario___Heap_Binaria
{
	public class Heap
	{
		private int[] heap;
		private bool es = false;
		private int cantElem;
		
		//Constructor para crear Heap vacio
		public Heap(int cantElementos, bool es)
		{
			heap = new int[cantElementos + 1]; //Se esta agregando cantidadElementos + 1, porque el indice 0 quedara vacio.
			this.es = es;
			this.cantElem = 0;	
		}
		public void agregar(int dato)
		{
			if(es == false){
				heap[cantElem + 1] = dato;
				cantElem++;
				FiltradoAbajoHaciaArribaMin(cantElem);
			}
			if(es == true){
				heap[cantElem + 1] = dato;
				cantElem++;
				FiltradoAbajoHaciaArribaMax(cantElem);
			}
		}
		public int eliminar()
		{
			int valorElim = tope();
			if(es == false){
				heap[1] = heap[cantElem];
				cantElem--;
				FiltradoArribaHaciaAbajoMin(1);
			}
			if(es == true){
				heap[1] = heap[cantElem];
				cantElem--;
				FiltradoArribaHaciaAbajoMax(1);
			}
			return valorElim;
		}
		public int tope(){
			return heap[1];
		}
		public bool esVacia(){
			if(cantElem == 0)
				return true;
			else
				return false;
		}
		public void FiltradoAbajoHaciaArribaMin(int index){
			int padre = index / 2;
			if(index <= 1)
				return;
			if(heap[index] < heap[padre]){
				int aux = heap[index];
				heap[index] = heap[padre];
				heap[padre] = aux;
			}
			FiltradoAbajoHaciaArribaMin(padre);
		}
		public void FiltradoArribaHaciaAbajoMin(int index){
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
			FiltradoArribaHaciaAbajoMin(menor);
		}
		public void FiltradoAbajoHaciaArribaMax(int index){
			int padre = index / 2;
			if(index <= 1)
				return;
			if(heap[index] > heap[padre]){
				int aux = heap[index];
				heap[index] = heap[padre];
				heap[padre] = aux;
			}
			FiltradoAbajoHaciaArribaMax(padre);
		}
		public void FiltradoArribaHaciaAbajoMax(int index){
			int hijoIzquierdo = index * 2;
			int hijoDerecho = (index * 2) + 1;
			int mayor = 0;
			
			if(cantElem < hijoIzquierdo)
				return;
			if(cantElem == hijoIzquierdo){
				if(heap[index] < heap[hijoIzquierdo]){
					int temp = heap[index];
					heap[index] = heap[hijoIzquierdo];
					heap[hijoIzquierdo] = temp;
				}
				return;
			}
			else{
				if(heap[hijoIzquierdo] > heap[hijoDerecho])
					mayor = hijoIzquierdo;
				else
					mayor = hijoDerecho;
				if(heap[index] < heap[mayor]){
					int temp2 = heap[index];
					heap[index] = heap[mayor];
					heap[mayor] = temp2;
				}
			}
			FiltradoArribaHaciaAbajoMax(mayor);
		}
		public void print(){
			for (int i = 1; i <= cantElem ; i++) {
				Console.Write(heap[i] + " ");
			}
		}	
	}
}
