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
        var pedidoPendiente = ListaPedidos.FirstOrDefault(p => p.VerEstado() == estado.Pendiente);

        if(pedidoPendiente != null)
        {
            return pedidoPendiente.VerNumero();
        }
        else
        {
            return -1;
        }
    }

    public void ReasignarPedido(int numeroPedido, int idCadete)
    {
        var pedido = ListaPedidos.Find(p => p.VerNumero() == numeroPedido);
        pedido.AsignarCadete(idCadete);
    }

    public void CambiarEstadoPedido(int numero)
    {
        var pedido = ListaPedidos.Find(p => p.VerNumero() == numero);

        Console.WriteLine($"Su estado actual es {pedido.VerEstado()}, cual será su nuevo estado?");
        Console.WriteLine("0 = Cancelado");
        Console.WriteLine("1 = Entregado");
        Console.Write("Opcion: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 0:
                pedido.CambiarEstado(estado.Cancelado);
                break;
            case 1:
                pedido.CambiarEstado(estado.Entregado);
                break;
        }
    }

    public bool ExistePedido(int numero)
    {
        return ListaPedidos.Any(p => p.VerNumero() == numero);
    }

    public bool ExisteCadete(int id)
    {
        return ListaCadetes.Any(c => c.VerId() == id);
    }

    public void MostrarPedidosPendientes()
    {
        foreach (var pedido in ListaPedidos)
        {
            if (pedido.VerEstado() == estado.Pendiente)
            {
                Console.WriteLine($"Numero: {pedido.VerNumero()}, Cliente: {pedido.VerCliente().VerNombre()} | " +
                    $"Cadete: {(pedido.VerIdCadete() != null ? "Asignado" : "Sin Asignar")}");
            }
        }
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

}
