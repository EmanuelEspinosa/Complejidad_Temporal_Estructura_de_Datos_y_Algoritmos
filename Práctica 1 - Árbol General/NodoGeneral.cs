using System;
using System.Collections.Generic;

namespace Práctica_1___Árbol_General
{
	
	public class NodoGeneral<T>
	{
		private T dato;
        private List<NodoGeneral<T>> hijos;

        /*Constructor*/
        public NodoGeneral(T dato)
        {
            this.dato = dato;
            hijos = new List<NodoGeneral<T>>();
        }
        public T getDato()
        {
            return this.dato;
        }
        public List<NodoGeneral<T>> getHijos()
        {
            return this.hijos;
        }
        public void setDato(T dato)
        {
            this.dato = dato;
        }
        public void setHijos(List<NodoGeneral<T>> hijos)
        {
            this.hijos = hijos;
        }
	}
}
