using System;

public class Cadete
{
    private int id;
    private string direccion;
    private string telefono;
    private string nombre;

    public List<Pedidos> ListaPedidos { get; set; }

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        Nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        ListaPedidos = new List<Pedidos>();
    }
    
    public int VerIdCadete()
    {
        return id;
    }

    public string VerNombreCadete()
    {
        return nombre;
    }

    public void AñadirPedido(Pedidos pedido)
    {
        ListaPedidos.Add(pedido);
    }
}
