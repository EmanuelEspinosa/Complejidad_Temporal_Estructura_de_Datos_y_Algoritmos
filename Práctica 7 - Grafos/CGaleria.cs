using System;
using System.Collections.Generic;

namespace Práctica_7___Grafos
{
	public class CGaleria
	{
		public CGaleria()
		{
		}
		public List<Vertice<int>> caminoMaximo(Grafo<int> grafo, Vertice<int> origen)
		{
			List<List<Vertice<int>>> mejoresCaminos = new List<List<Vertice<int>>>();
			bool[] visitado = new bool[grafo.getVertices().Count]; //La longitud del arreglo sera igual a la cantidad de vertices del grafo
			
			foreach (Vertice<int> item in grafo.getVertices()) /*Para cada vertice del grafo...*/
			{
				List<Vertice<int>> caminos = new List<Vertice<int>>();
				List<Vertice<int>> mejorCaAuxiliar = new List<Vertice<int>>();
				this._caminoMaximo(caminos, mejorCaAuxiliar,origen, item, visitado);
				mejoresCaminos.Add(mejorCaAuxiliar);
			}
			List<Vertice<int>> mejorCamino = mejoresCaminos[0];
			foreach (var element in mejoresCaminos)
			{
				if (element.Count > mejorCamino.Count)
				{
					mejorCamino.Clear();
					mejorCamino.AddRange(element);	
				}
			}
			return mejorCamino;
		}
		
		private List<Vertice<int>> _caminoMaximo(List<Vertice<int>> Caminos, List<Vertice<int>> mejorCamino, Vertice<int> origen, Vertice<int> destino, bool[] visitado)
		{
			int tiempo;
			Caminos.Add(origen);
			visitado[origen.getPosicion() - 1] = true;
			if (origen == destino)
			{
				tiempo = 0;
				for (int i = 0; i < Caminos.Count; i++)
				{
					tiempo += Caminos[i].getDato();
					List<Arista<int>> adyacentes = Caminos[i].getAdyacentes();
					
					for (int j = 0; j < adyacentes.Count; j++)
						if (i != Caminos.Count - 1)
							if (adyacentes[j].getDestino() == Caminos[i + 1])
								tiempo += adyacentes[j].getPeso();
				}
				if(Caminos.Count >= mejorCamino.Count && tiempo <= 120)
				{
					mejorCamino.Clear();
					mejorCamino.AddRange(Caminos);
				}
			}
			else
			{
				foreach (var adyacente in origen.getAdyacentes())
				{
					if (!visitado[adyacente.getDestino().getPosicion() - 1])
					{
						this._caminoMaximo(Caminos, mejorCamino, adyacente.getDestino(), destino, visitado);
						visitado[adyacente.getDestino().getPosicion() - 1] = false;
						Caminos.RemoveAt(Caminos.Count - 1);
					}
				}
			}
			return null;	
		}
	}
}
