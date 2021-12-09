using System;
using System.Collections.Generic;

namespace Práctica_7___Grafos
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		public Grafo()
		{
		}
		
		private List<Vertice<T>>vertices = new List<Vertice<T>>();
	
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}

	
		public List<Vertice<T>> getVertices() {
			return vertices;
		}

	
		public Vertice<T> vertice(int posicion) {
			return this.vertices[posicion];
		}
	

		public void DFS(Vertice<T> origen) {
			bool[] visitados = new bool[this.vertices.Count];
			this._DFS(origen,visitados);
		}
		
		void _DFS(Vertice<T> origen, bool[] visitados){
			//Primero se procesa el origen
			Console.Write(origen.getDato() + "| ");
			//Luego se lo marca como visitado
			visitados[origen.getPosicion() - 1] = true;
			
			foreach (var adyacente in origen.getAdyacentes()) {
				if(! visitados[adyacente.getDestino().getPosicion() - 1]) //Se chequea si el adyacente fué visitado
					this._DFS(adyacente.getDestino(),visitados);
			}
		}
		
		public void BFS(Vertice<T> origen) {
			bool[] visitados = new bool[this.vertices.Count];
			Cola<Vertice<T>> C = new Cola<Vertice<T>>();
			Vertice<T> verticeAux;
			C.encolar(origen);
			visitados[origen.getPosicion() - 1] = true;
			
			while(!C.esVacia())
			{
				verticeAux = C.desencolar();
				Console.Write(verticeAux.getDato() + "| ");
				
				foreach (var element in verticeAux.getAdyacentes()) {
					if(!visitados[element.getDestino().getPosicion() - 1])
					{
						C.encolar(element.getDestino());
						visitados[element.getDestino().getPosicion() - 1] = true;
					}		
				}
			}
		}
		
		public bool buscar_1_camino(Vertice<T> origen, Vertice<T> destino, List<Vertice<T>> camino)
		{
			bool[] visitados = new bool[this.vertices.Count];
			camino.Add(origen);
			visitados[origen.getPosicion() - 1] = true;
			if(origen == destino)
			{
				foreach (var element in camino) 
					Console.Write(element.getDato() + " ");
				return true;	
			}
			else
			{
				foreach (var adyacente in origen.getAdyacentes()) {
					if(!visitados[adyacente.getDestino().getPosicion() - 1])
					{
						bool ok = buscar_1_camino(adyacente.getDestino(), destino, camino);
						if(ok)
							return true;
						camino.RemoveAt(camino.Count-1);		
					}
				}
			}
			return false;	
		}
		
		
	}
}
