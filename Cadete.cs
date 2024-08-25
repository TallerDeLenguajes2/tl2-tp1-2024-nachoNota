using System;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedidos> listaPedidos;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listaPedidos = new List<Pedidos>();
    }

    public void AñadirPedido(Pedidos pedido)
    {
        listaPedidos.Add(pedido);
    }
}
