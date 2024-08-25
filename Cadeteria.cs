using System;
using System.ComponentModel.DataAnnotations;

public class Cadeteria
{
    private string nombre;
    private string telefono;

    public List<Cadete> ListaCadetes {  get; set; }

    public Cadeteria()
    {
        ListaCadetes = new List<Cadete>();
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
                if (nroPedido == pedido.Numero)
                {
                    return pedido;   
                }
            }
        }
        return null;
    }

    public void MostrarCadetes()
    {
        foreach(var cadete in ListaCadetes)
        {
            Console.WriteLine($"{cadete.VerIdCadete()} | {cadete.VerNombreCadete()}");
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
