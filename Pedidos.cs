using System;

public enum estado
{
    Cancelado,
    Pendiente,
    Entregado
};

public class Pedidos
{
    private int numero;
    private string observacion;
    private Cliente cliente;

    public estado estado {  get; set; }

    public Pedidos(string observacion, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        numero = new Random().Next(0, 100000); //simulo una eleccion de numero unico para el pedido, ya se que puede repetirse pero bueno
        this.observacion = observacion;
        estado = estado.Pendiente;

        var cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
    }
}
