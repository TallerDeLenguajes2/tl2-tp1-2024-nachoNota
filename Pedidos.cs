using System;

public enum estado
{
    Cancelado,
    Pendiente,
    Entregado
};

public class Pedidos
{
    private string observacion;

    public int Numero { get; set; }
    public estado Estado {  get; set; }
    public Cliente Cliente { get; set; }

    public Pedidos(string observacion, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        Numero = new Random().Next(0, 100000); //simulo una eleccion de numero unico para el pedido, ya se que puede repetirse pero bueno
        this.observacion = observacion;
        Estado = estado.Pendiente;

        Cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
    }
}
