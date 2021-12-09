using System;
using System.Collections.Generic;

namespace Práctica_4___Hashing
{
	class Program
	{
		public static void Main(string[] args)
		{
			CrearEstructura();
			Empleado emp = new Empleado("Emanuel","38835779","445"); agregar(emp);
			Empleado emp1 = new Empleado("María","41230147","446"); agregar(emp1);
			Empleado emp2 = new Empleado("Rodrigo","96214369","447"); agregar(emp2);
			Empleado emp3 = new Empleado("Benjamin","12345678","448"); agregar(emp3);
			
			/*emp4 no pertence a la compañía*/
			Empleado emp4 = new Empleado("Alicia","78974115","445");
			
			
			verificarEmpleado("78974115");
			Console.ReadKey(true);
		}
		
		public static long getHashEntry(string Dni)
		{
			long hash = 5381;
			foreach (char c in Dni)
				hash = (hash * 7) + (int) c;
			return hash % 23;
		}
		
		public static List<Empleado>[] vector;
		
		public static void CrearEstructura(int t = 23)
		{
			vector = new List<Empleado>[t];
			for (int i = 0; i < vector.Length; i++) {
				vector[i] = new List<Empleado>();
			}
		}
		
		public static void agregar(Empleado empleado)
		{
			long pos = getHashEntry(empleado.getDni());
			if(! vector[pos].Contains(empleado))
				vector[pos].Add(empleado);
		}
			
		public static void verificarEmpleado(string DNI)
		{
			bool esta = false;
			long pas = getHashEntry(DNI);
			foreach (Empleado element in vector[pas]) {
				if(element.getDni() == DNI){
					esta = true;
					Console.WriteLine(element);
				}
			}
			if(!esta)
				Console.WriteLine("El DNI ingresado no se corresponde con ningun empleado de la compañía. ");
		}
	}
	class Empleado
	{
		private string nombre,NEmpleado, Dni;
		
		public Empleado(string nombre, string Dni, string NEmpleado)
		{
			this.nombre = nombre;
			this.Dni = Dni;
			this.NEmpleado = NEmpleado;
		}
		public string getNombre() { return nombre; }
		public string getDni() { return Dni; }
		public string getNEmpleado() { return NEmpleado; }
		
		public override string ToString()
		{
			return string.Format("[Nombre: {0}, N°Empleado: {1}, Dni: {2}]", nombre, NEmpleado, Dni);
		}
	}
}