using System;

namespace Práctica_3___Árbol_AVL
{
	public class ArbolBinarioBusqueda {

		private IComparable dato;
		private ArbolBinarioBusqueda hijoIzquierdo;
		private ArbolBinarioBusqueda hijoDerecho;

		public ArbolBinarioBusqueda(IComparable dato) {
			this.dato = dato;
		}

		public IComparable getDatoRaiz() {
			return this.dato;
		}

		public ArbolBinarioBusqueda getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}

		public ArbolBinarioBusqueda getHijoDerecho() {
			return this.hijoDerecho;
		}

		public void agregarHijoIzquierdo(ArbolBinarioBusqueda hijo) {
			this.hijoIzquierdo = hijo;
		}

		public void agregarHijoDerecho(ArbolBinarioBusqueda hijo) {
			this.hijoDerecho = hijo;
		}

		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo = null;
		}

		public void eliminarHijoDerecho() {
			this.hijoDerecho = null;
		}

		public void agregar(IComparable elem) 
		{
			if (elem.CompareTo(this.getDatoRaiz()) > 0)
			{
				if (this.getHijoDerecho() == null)
				{
					this.agregarHijoDerecho(new ArbolBinarioBusqueda(elem));
				}
				else
				{
					this.getHijoDerecho().agregar(elem);
				}
			}
			if (elem.CompareTo(this.getDatoRaiz()) < 0)
			{
				if (this.getHijoIzquierdo() == null)
				{
					this.agregarHijoIzquierdo(new ArbolBinarioBusqueda(elem));
				}  
				else
				{
					this.getHijoIzquierdo().agregar(elem);
				}
			}
		}

		public bool incluye(IComparable elem)
		{
			bool flag = false;
			Cola<ArbolBinarioBusqueda> listaABB = new Cola<ArbolBinarioBusqueda>();
			ArbolBinarioBusqueda arbolAux;
			listaABB.encolar(this);

			while(! listaABB.esVacia())
            {
				arbolAux = listaABB.desencolar();
				if (arbolAux.getDatoRaiz().CompareTo(elem) == 0)
                {
					flag = true;
					break;
				}
				if (arbolAux.getHijoIzquierdo() != null)
					listaABB.encolar(arbolAux.getHijoIzquierdo());
				if (arbolAux.getHijoDerecho() != null)
					listaABB.encolar(arbolAux.getHijoDerecho());
            }
			return flag;
		}

		public void preorden() 
		{
			/*Primero la raiz*/
			Console.Write(this.dato + " ");
			/*Luego hijo izquierdo recursivamente*/
			if (this.getHijoIzquierdo() != null)
				this.getHijoIzquierdo().preorden();
			/*Por ultimo hijo derecho recursivamente*/
			if (this.getHijoDerecho() != null)
				this.getHijoDerecho().preorden();
		}
		
		public void inorden() 
		{
			/*Primero el hijo izquierdo recursivamente*/
			if (this.getHijoIzquierdo() != null)
				this.getHijoIzquierdo().inorden();
			/*Luego la raiz*/
			Console.Write(this.dato + " ");
			/*Por ultimo el hijo derecho recursivamente*/
			if (this.getHijoDerecho() != null)
				this.getHijoDerecho().inorden();
		}
		
		public void postorden() 
		{
			/*Primero el hijo izquierdo recursivamente*/
			if (this.getHijoIzquierdo() != null)
				this.getHijoIzquierdo().postorden();
			/*Luego el hijo derecho*/
			if (this.getHijoDerecho() != null)
				this.getHijoDerecho().postorden();
			/*Por ultimo la raiz*/
			Console.Write(this.dato + " ");
		}
	}
}