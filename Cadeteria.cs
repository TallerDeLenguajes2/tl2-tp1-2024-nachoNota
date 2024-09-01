using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;

public class Cadeteria
{
    private string nombre;
    private string telefono;

    public List<Cadete> ListaCadetes { get; set; }
    public List<Pedidos> ListaPedidos { get; set; }

    public Cadeteria()
    {
        ListaCadetes = new List<Cadete>();
        ListaPedidos = new List<Pedidos>();
    }

    public int JornalACobrar(int idCadete)
    {
        int cont = 0;
        var cadete = ListaCadetes.Find(c => c.VerId() == idCadete);
        
        foreach(var pedido in ListaPedidos)
        {
            if(pedido.VerIdCadete() == idCadete)
            {
                if(pedido.VerEstado() == estado.Entregado)
                {
                    cont += 500;
                }
            }
        }

        return cont;
    }

    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        var pedido = ListaPedidos.Find(p => p.VerNumero() == idPedido);
        pedido.AsignarCadete(idCadete);
    }

    public void AgregarPedido(Pedidos pedido)
    {
        ListaPedidos.Add(pedido);
    }

    private Cadete CadeteAleatorio()
    {
        var indexRandom = new Random().Next(ListaCadetes.Count);
        var cadete = ListaCadetes[indexRandom];
        return cadete;
    }

    public int IdCadeteAleatorio()
    {
        var cadete = CadeteAleatorio();
        return cadete.VerId();
    }

    public int IdPedidoPendiente()
    {
        if(ListaPedidos.Count > 0)
        {
            return ListaPedidos[0].VerNumero();
        } else
        {
            return -1;
        }
    }

    public void AsignarPedido(int nroCadete, Pedidos pedido)
    {
        ListaCadetes[nroCadete].AñadirPedido(pedido);
    }

    public Pedidos EncontrarPedido(int nroPedido)
    {
        foreach (var cadete in ListaCadetes)
        {
            foreach (var pedido in cadete.ListaPedidos)
            {
                if (nroPedido == pedido.VerNumero())
                {
                    return pedido;   
                }
            }
        }
        return null;
    }

    public Cadete EncontrarCadetePorPedido(Pedidos pedido)
    {
        return ListaCadetes.Find(cadete => cadete.ListaPedidos.Contains(pedido));
    }

    public void MostrarCadetes()
    {
        foreach(var cadete in ListaCadetes)
        {
            Console.WriteLine($"{cadete.VerId()} | {cadete.VerNombre()}");
        }
    }

    public void CargarCadeteria(string rutaCadeteria, string rutaCadetes)
    {
        string[] datos = File.ReadAllText(rutaCadeteria).Split(',');
        nombre = datos[0];
        telefono = datos[1];

        CargarDatosCadetes(rutaCadetes);
    }

    public void CargarDatosCadetes(string ruta)
    {
        string[] lineas = File.ReadAllLines(ruta);

        foreach(var linea in lineas)
        {
            string[] datos = linea.Split(',');
            var nuevoCadete = new Cadete(int.Parse(datos[0]), datos[1], datos[2], datos[3]);
            ListaCadetes.Add(nuevoCadete);
        }
    }

    public void MostrarPedidosPendientes()
    {
        foreach (var cadete in ListaCadetes)
        {
            foreach (var pedido in cadete.ListaPedidos)
            {
                if (pedido.VerEstado() == estado.Pendiente)
                {
                    Console.WriteLine($"Nro: {pedido.VerNumero()}, Nombre del cliente: {pedido.VerCliente().VerNombre()}, Cadete: {cadete.VerNombre()}");
                }
            }
        }
    }
}
