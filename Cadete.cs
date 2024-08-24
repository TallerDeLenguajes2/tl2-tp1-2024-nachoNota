using System;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedidos> listaPedidos;

    public Cadete()
    {
        listaPedidos = new List<Pedidos>();
    }
}
