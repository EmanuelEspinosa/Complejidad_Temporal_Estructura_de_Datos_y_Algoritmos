using System;

namespace Práctica_3___Árbol_AVL
{

	public class AVL{
		
		private IComparable dato;
		private AVL hijoIzquierdo;
		private AVL hijoDerecho;
		private int altura;
		
		public AVL(IComparable dato){
			this.dato = dato;
		}
		
		public IComparable getDatoRaiz(){
			return this.dato;
		}
		
		public AVL getHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public AVL getHijoDerecho(){
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(AVL hijo){
			this.hijoIzquierdo=hijo;
		}

		public void agregarHijoDerecho(AVL hijo){
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo(){
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho(){
			this.hijoDerecho=null;
		}
		
		public AVL agregar(IComparable elem) 
		{	
			if (elem.CompareTo(this.getDatoRaiz()) > 0) //Si el elem es mayor que el dato almancenado en la raiz
			{
				if (this.getHijoDerecho() == null)
					this.agregarHijoDerecho(new AVL(elem));
				else
					this.agregarHijoDerecho(this.getHijoDerecho().agregar(elem));
			}
			if (elem.CompareTo(this.getDatoRaiz()) < 0)
			{
				if (this.getHijoIzquierdo() == null)
					this.agregarHijoIzquierdo(new AVL(elem));
				else
					this.agregarHijoIzquierdo(this.getHijoIzquierdo().agregar(elem));
			}
			this.actualizarAltura(); //Actualizar la altura
			//Control de Desbalance
			AVL nuevaRaiz = this;
			int balance = this.CalcularDesbalance();
			if (balance > 1)   //Desbalance del lado derecho
			{	
				if (elem.CompareTo(this.getHijoDerecho().getDatoRaiz()) > 0) //Si elem es mayor que hijo derecho, entonces rotacion simple con derecho
					nuevaRaiz = this.rotacionSimpleDerecha();
				else		
					nuevaRaiz = this.rotacionDobleDerecha(); //Si elem es menor o igual, entonces rotacion doble con derecha
			}
			if (balance < -1) //Desbalance del lado izquierdo
			{	
				if (elem.CompareTo(this.getHijoIzquierdo().getDatoRaiz()) <= 0) //Si elem es menor que hijo izquierdo, entonces rotacion simple con izquierdo
					nuevaRaiz = this.rotacionSimpleIzquierda();
				else		
					nuevaRaiz = this.rotacionDobleIzquierda(); //Si elem es mayor, entonces rotacion doble con izquierdo
			}
			return nuevaRaiz;
		}

		private int CalcularDesbalance()
		{
			int AlturaIzquierdo = -1;
			int AlturaDerecho = -1;

			if (this.getHijoIzquierdo() != null)
				AlturaIzquierdo = this.getHijoIzquierdo().altura;
			if (this.getHijoDerecho() != null)
				AlturaDerecho = this.getHijoDerecho().altura;

			return AlturaDerecho - AlturaIzquierdo;
		}

		private void actualizarAltura()
		{
			int AlturaIzquierdo = -1;
			int AlturaDerecho = -1;

			if (this.getHijoIzquierdo() != null)
				AlturaIzquierdo = this.getHijoIzquierdo().altura;
			if (this.getHijoDerecho() != null)
				AlturaDerecho = this.getHijoDerecho().altura;

			if (AlturaDerecho > AlturaIzquierdo)
				this.altura = AlturaDerecho + 1;
			else
				this.altura = AlturaIzquierdo + 1;
		}

		private AVL rotacionSimpleDerecha() //rotacion simple CON derecho
		{
			AVL nuevaRaiz = this.getHijoDerecho();
			this.agregarHijoDerecho(nuevaRaiz.getHijoIzquierdo());
			nuevaRaiz.agregarHijoIzquierdo(this);
			this.actualizarAltura();
			nuevaRaiz.actualizarAltura();
			return nuevaRaiz;
		}

		private AVL rotacionSimpleIzquierda() //rotacion simple CON izquierdo
		{	
			AVL nuevaRaiz = this.getHijoIzquierdo(); // Referencia a nueva raiz luego de la rotación
			this.agregarHijoIzquierdo(nuevaRaiz.getHijoDerecho()); // Cambio hijo izquierdo de la raiz actual (this)			
			nuevaRaiz.agregarHijoDerecho(this);  // Cambiar hijo derecho de nueva raiz	
			this.actualizarAltura();  // Actualizar la altura de antigua raiz (this)	
			nuevaRaiz.actualizarAltura(); // Actualizar la altura de nueva raiz	
			return nuevaRaiz; // Se retorna la nueva raiz
		}

		private AVL rotacionDobleDerecha() //Rotacion doble CON derecho
		{	
			AVL nuevoHijoDerecho = this.getHijoDerecho().rotacionSimpleIzquierda(); //Rotacion simple con izquierdo en hijo derecho. Esto retorna un nuevo hijo.
			this.agregarHijoDerecho(nuevoHijoDerecho); //Este se asigna como nuevo hijo de (this)
			return this.rotacionSimpleDerecha(); //Rotacion simple con derecho
		}
		
		private AVL rotacionDobleIzquierda() //Rotacion doble CON izquierdo
		{
			AVL nuevoHijoIzquierdo = this.getHijoIzquierdo().rotacionSimpleDerecha(); //Rotacion simple con derecho en hijo izquierdo. Esto retorna un nuevo hijo.
			this.agregarHijoIzquierdo(nuevoHijoIzquierdo); //Este se asigna como nuevo hijo de (this)
			return this.rotacionSimpleIzquierda(); //Rotacion simple con izquierdo
		}

		public void preorden()
		{	
			Console.Write(this.dato + " "); /*Primero la raiz*/	
			if (this.getHijoIzquierdo() != null) /*Luego hijo izquierdo recursivamente*/
				this.getHijoIzquierdo().preorden();	
			if (this.getHijoDerecho() != null) /*Por ultimo hijo derecho recursivamente*/
				this.getHijoDerecho().preorden();
		}

		public void inorden()
		{	
			if (this.getHijoIzquierdo() != null) /*Primero el hijo izquierdo recursivamente*/
				this.getHijoIzquierdo().inorden();	
			Console.Write(this.dato + " "); /*Luego la raiz*/	
			if (this.getHijoDerecho() != null) /*Por ultimo el hijo derecho recursivamente*/
				this.getHijoDerecho().inorden();
		}

		public void postorden()
		{	
			if (this.getHijoIzquierdo() != null) /*Primero el hijo izquierdo recursivamente*/
				this.getHijoIzquierdo().postorden();	
			if (this.getHijoDerecho() != null) /*Luego el hijo derecho*/
				this.getHijoDerecho().postorden();	
			Console.Write(this.dato + " "); /*Por ultimo la raiz*/
		}

		public void recorridoPorNiveles()
		{
			Cola<AVL> lista = new Cola<AVL>();
			AVL arbolAux;
			lista.encolar(this);

			while (!lista.esVacia())
			{
				arbolAux = lista.desencolar();
				Console.Write(arbolAux.getDatoRaiz() + " ");
				if (arbolAux.getHijoIzquierdo() != null)
					lista.encolar(arbolAux.getHijoIzquierdo());
				if (arbolAux.getHijoDerecho() != null)
					lista.encolar(arbolAux.getHijoDerecho());
			}
		}
	}
}