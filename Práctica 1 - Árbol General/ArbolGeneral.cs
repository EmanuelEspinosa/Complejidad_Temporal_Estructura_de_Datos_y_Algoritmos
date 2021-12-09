using System;
using System.Collections.Generic;

namespace Práctica_1___Árbol_General
{
	public class ArbolGeneral<T>
	{
		private NodoGeneral<T> raiz; /*Nodo Raiz del árbol. La clase ArbolGeneral solamente conoce*/
                                    /*donde esta la raiz. */
        public ArbolGeneral(T dato)
        {
            this.raiz = new NodoGeneral<T>(dato); /*Se instancia un árbol y se le pasa el dato de la raiz*/
        }                                        /*A la variable raiz de tipo NodoGeneral se le asigna el*/
                                                /*valor de la variable pasada como parametro*/
        private ArbolGeneral(NodoGeneral<T> Nodo)   /*este constructor es de uso interno*/
        {                                           /*Toma como argumento un nodo*/
            this.raiz = Nodo;        /*Se asigna a la raiz el valor del nodo pasadado como parametro*/
        }
        private NodoGeneral<T> getRaiz()  /*retorna un nodo. En este caso el nodo raiz*/
        {                                /*Es privado porque el usuario va a trabajar siempre con árboles*/
            return raiz;
        }
        public T getDatoRaiz() /*Este metodo devuelve el dato del nodo raiz*/         
        {
            return this.getRaiz().getDato();  /*getRaiz() es el metodo creado anteriormente que retorna el*/
        }                                /*nodo raiz. Entonces como getRaiz() es un nodo, invoca al metodo*/
                                        /*getDato() de la clase NodoGeneral que retorna el valor del dato*/
                                        /*que contiente el mismo*/
        public List<ArbolGeneral<T>> getHijos() /*Este metodo retorna una lista de arboles hijos*/
        {
            List<ArbolGeneral<T>> temp = new List<ArbolGeneral<T>>(); /*Se crea una lista de arboles, en principio esta vacia*/
            foreach (var item in this.raiz.getHijos()) /*el nodo raiz invoca al metodo de su clase "getHijos()" que devuelve*/
            {                                       /*la lista de nodos hijos. Se recorre con el foreach*/
                temp.Add(new ArbolGeneral<T>(item)); /*Por cada hijo del nodo raiz, se crea un arbol, usando el*/
            }                                       /*constructor privado y se lo agrega a la lista de arboles hijos "temp"*/
            return temp; /*Se retorna la lista de arboles hijos, que se corresponden con los hijos del nodo raiz*/
        }
        public void agregarHijo(ArbolGeneral<T> hijo) /*Se agrega un hijo*/
        {
            this.raiz.getHijos().Add(hijo.getRaiz()); /*hijo.getRaiz() devuelve el nodo raiz del arbol pasado*/
        }                   /*como parametro. El nodo raiz invoca al metodo getHijos() de su clase que retorna*/
                           /*la lista de nodos hijos y agrega a esa lista el nodo raiz del arbol pasado como parametro*/
        
        public void eleminarHijo(ArbolGeneral<T> hijo) /*Es identico al método anterior, con la diferencia que*/
        {                                              /*este, elimina un hijo, en vez de agregarlo*/
            this.raiz.getHijos().Remove(hijo.getRaiz());
        }
        public bool esHoja()
        {
            return this.getHijos().Count == 0 && this.raiz != null; 
        }
        public bool esVacio()
        {
            return this.raiz == null;
        }
        public int altura()
        {
            int alturaMaxima = 0;
            int altura;
            if(this.esHoja())
            {
                return alturaMaxima;
            }
            else
            {
                foreach (var item in this.getHijos())
                {
                    altura = item.altura();
                    if(altura > alturaMaxima)
                        alturaMaxima = altura;    
                }
            }
            return alturaMaxima + 1;
        }
        public int ancho()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;
            int ancho = 0, contArboles = 0;
            c.encolar(this);
            c.encolar(null);

            while (! c.esVacia())
            {
                arbolAux = c.desencolar();
                if(arbolAux == null)
                {
                    if (contArboles > ancho)
                    {
                        ancho = contArboles;
                    }
                    contArboles = 0;
                    if(! c.esVacia())
                        c.encolar(null);
                }
                else{
                    contArboles++;
                    foreach (var hijos in arbolAux.getHijos())
                        c.encolar(hijos);
                }
            }
            return ancho;
        }
        public int nivel(T dato) 
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;
            int contNiv = 0, nivel = 0;
            c.encolar(this);
            c.encolar(null);

            while(! c.esVacia())
            {
                arbolAux = c.desencolar();
                if(arbolAux == null)
                {
                    contNiv++;
                    if(! c.esVacia())
                        c.encolar(null);
                }
                if(arbolAux!= null && dato.Equals(arbolAux.getDatoRaiz()))
                {
                    nivel = contNiv;
                }
                else{ 
                    if(arbolAux!= null && arbolAux.getHijos().Count != 0)
                    {
                        foreach (var hijo in arbolAux.getHijos())
                        c.encolar(hijo);
                    }    
                }
            }
            return nivel; 
        }
        public static int minimoCaudal(ArbolGeneral<int> arbol)
        {
            int caudalHijos, min = int.MaxValue;
            Cola<ArbolGeneral<int>> cola = new Cola<ArbolGeneral<int>>();
            ArbolGeneral<int> arbolAux;
            cola.encolar(arbol);

            while(! cola.esVacia())
            {
                arbolAux = (ArbolGeneral<int>)cola.desencolar();
                if(arbolAux.getHijos().Count != 0)
                {
                    caudalHijos = arbolAux.getDatoRaiz() / arbolAux.getHijos().Count;
                    if(caudalHijos < min)
                        min = caudalHijos;

                    foreach (var hijo in arbolAux.getHijos())
                    {
                        hijo.getRaiz().setDato(caudalHijos);
                        cola.encolar(hijo);
                    }
                }
                else
                    min = arbolAux.getDatoRaiz();
            }
            return min;
        }

        //RECORRIDOS

        /*En el metodo de preorden primero se procesa la raiz y luego los hijos,
        se van procesando los subarboles de izquierda a derecha*/
        public void preOrden()
        {
            if(! this.esVacio())
                Console.Write(this.getDatoRaiz() + " ");
            if(! this.esHoja())
                foreach (var hijo in this.getHijos())
                    hijo.preOrden();
        }
        /*Se procesan primero los hijos luego la raiz*/
        public void postOrden()
        {
            if(! this.esVacio())
            {
                if(! this.esHoja())
                    foreach (var hijo in this.getHijos())
                        hijo.postOrden(); 
                Console.Write(this.getDatoRaiz() + " ");                                              
            }
        }
        public void inOrden()
        {
            //Primero se procesa el primer hijo recursivamente
            if(! this.esHoja())
                this.getHijos()[0].inOrden();
            //Luego la raiz
            Console.WriteLine(this.getDatoRaiz() + " ");
            //Por ultimo los restantes hijos recursivamente
            if(this.getHijos().Count > 1)
                for (int i = 1; i < this.getHijos().Count; i++)
                    this.getHijos()[i].inOrden();         
        }

        public void porNiveles()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;
            c.encolar(this);

            while(! c.esVacia())
            {
                arbolAux = c.desencolar();
                Console.Write(arbolAux.getDatoRaiz() + " ");

                foreach (var hijos in arbolAux.getHijos())
                {
                    c.encolar(hijos);
                }
            }
        }
	}
}
