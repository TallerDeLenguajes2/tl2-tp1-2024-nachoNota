using System;

pubic enum estado
{
    Cancelado,
    Pendiente,
    Entregado
}

public class Pedidos
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private estado estado;

    public Pedidos(string observacion)
    {
        numero = new Random().Next(0, 100000);
        this.observacion = observacion;
        estado = estado.Pendiente;
        var nuevo_cliente = new Cliente();
    }
}
