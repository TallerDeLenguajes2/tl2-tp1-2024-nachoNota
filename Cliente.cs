using System;

public class Cliente
{
	private string nombre;
	private string direccion;
	private string telefono;
	private string datosReferenciaDireccion;

	public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
	{
		this.nombre = nombre;
		this.direccion = direccion;
		this.telefono = telefono;
		this.datosReferenciaDireccion = datosReferenciaDireccion;
	}
}
