using System;
using System.Collections.Generic;
using System.Text;

namespace Práctica_2___Árbol_Binario___Heap_Binaria
{
    class ArbolBinario<T>
    {
        private T dato;
        private ArbolBinario<T> hijoIzquierdo;
        private ArbolBinario<T> hijoDerecho;

        public ArbolBinario(T dato)
        {
            this.dato = dato;
        }
        public T getDatoRaiz()
        {
            return this.dato;
        }
        public ArbolBinario<T> getHijoIzquierdo()
        {
            return this.hijoIzquierdo;
        }
        public ArbolBinario<T> getHijoDerecho()
        {
            return this.hijoDerecho;
        }
        public void agregarHijoIzquierdo(ArbolBinario<T> hijo)
        {
            this.hijoIzquierdo = hijo;
        }
        public void agregarHijoDerecho(ArbolBinario<T> hijo)
        {
            this.hijoDerecho = hijo;
        }
        public void eliminarHijoIzquierdo()
        {
            this.hijoIzquierdo = null;
        }
        public void eliminarHijoDerecho()
        {
            this.hijoDerecho = null;
        }
        public bool esHoja()
        {
            return this.hijoIzquierdo == null && this.hijoDerecho == null;
        }
        public void inorden()
        {
            if(this.getHijoIzquierdo() != null)
                this.getHijoIzquierdo().inorden();
            Console.WriteLine(this.getDatoRaiz() + " ");
            if(this.getHijoDerecho() != null)
                this.getHijoDerecho().inorden();
        }
        public void preorden()
        {
            Console.WriteLine(this.getDatoRaiz() + " ");
            if (this.getHijoIzquierdo() != null)
                this.getHijoIzquierdo().preorden();
            if (this.getHijoDerecho() != null)
                this.getHijoDerecho().preorden();
        }
        public void postorden()
        {
            if (this.getHijoIzquierdo() != null)
                this.getHijoIzquierdo().postorden();
            if (this.getHijoDerecho() != null)
                this.getHijoDerecho().postorden();
            Console.WriteLine(this.getDatoRaiz() + " ");
        }
        public void recorridoPorNiveles()
        {
            Cola<ArbolBinario<T>> lista = new Cola<ArbolBinario<T>>();
            ArbolBinario<T> arbolAux;
            lista.encolar(this);

            while (! lista.esVacia())
            {
                arbolAux = lista.desencolar();
                Console.Write(arbolAux.getDatoRaiz() + " ");
                if(arbolAux.getHijoIzquierdo() != null)
                    lista.encolar(arbolAux.getHijoIzquierdo());
                if(arbolAux.getHijoDerecho() != null)
                    lista.encolar(arbolAux.getHijoDerecho());
            }
        }
        public int contarHojas()
        {
            int contador = 0;
            Cola<ArbolBinario<T>> lista = new Cola<ArbolBinario<T>>();
            ArbolBinario<T> arbolAux;
            lista.encolar(this);
            while(!lista.esVacia())
            {
                arbolAux = lista.desencolar();
                if(arbolAux.getHijoIzquierdo() != null)
                    lista.encolar(arbolAux.getHijoIzquierdo());
                if (arbolAux.getHijoDerecho() != null)
                    lista.encolar(arbolAux.getHijoDerecho());
                if(arbolAux.getHijoDerecho() == null | arbolAux.getHijoIzquierdo() == null)
                    contador++;
            }
            return contador;
        }
        public void recorridoEntreNiveles(int n, int m)
        {
            Cola<ArbolBinario<T>> lista = new Cola<ArbolBinario<T>>();
            ArbolBinario<T> arbolAux;
            lista.encolar(this);
            lista.encolar(null);
            int contNiv = 0;
            while (!lista.esVacia())
            {
                if (contNiv <= m)
                {
                    arbolAux = lista.desencolar();
                    if (arbolAux != null)
                    {
                        if (contNiv >= n && contNiv <= m)
                            Console.Write(arbolAux.getDatoRaiz() + " ");
                        if (arbolAux.getHijoIzquierdo() != null)
                            lista.encolar(arbolAux.getHijoIzquierdo());
                        if (arbolAux.getHijoDerecho() != null)
                            lista.encolar(arbolAux.getHijoDerecho());
                    }
                    else
                    {
                        contNiv++;
                        if (!lista.esVacia())
                            lista.encolar(null);
                    }
                }
                else
                    break;
            }
        }
        public bool incluye(T elemento)
        {
            Cola<ArbolBinario<T>> lista = new Cola<ArbolBinario<T>>();
            ArbolBinario<T> arbolAux;
            bool esta = false;
            lista.encolar(this);

            while (! lista.esVacia())
            {
                arbolAux = lista.desencolar();
                if(arbolAux.getDatoRaiz().Equals(elemento))
                {
                    esta = true;
                    break;
                }
                if (arbolAux.getHijoIzquierdo() != null)
                    lista.encolar(arbolAux.getHijoIzquierdo());
                if (arbolAux.getHijoDerecho() != null)
                    lista.encolar(arbolAux.getHijoDerecho());
            }
            return esta;
        }
    }
}
