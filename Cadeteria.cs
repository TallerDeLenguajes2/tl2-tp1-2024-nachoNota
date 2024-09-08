﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

public class Cadeteria
{
    [JsonInclude]
    private string nombre;
    [JsonInclude]
    private string telefono;
    private List<Cadete> listaCadetes;
    private List<Pedidos> listaPedidos; 

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listaCadetes = new List<Cadete>();
        listaPedidos = new List<Pedidos>();
    }

    public int JornalACobrar(int idCadete)
    {
        int salario = 0;
        var cadete = listaCadetes.Find(c => c.VerId() == idCadete);
        bool cadeteEncontrado = cadete != null;

        if(cadeteEncontrado)
        {
            foreach(var pedido in listaPedidos)
            {
                if(pedido.VerIdCadete() == idCadete)
                {
                    if(pedido.VerEstado() == EstadoPedido.Entregado)
                    {
                        salario += 500;
                    }
                }
            }
        } else
        {
            salario = -1;
        }

        return salario;
    }

    public int ConsultarCantCadetes()
    {
        return listaCadetes.Count;
    }

    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        var pedido = listaPedidos.Find(p => p.VerNumero() == idPedido);
        pedido.AsignarCadete(idCadete);
    }

    public void AgregarPedido(Pedidos pedido)
    {
        listaPedidos.Add(pedido);
    }

    public void AgregarCadete(int id, string nombre, string direccion, string telefono)
    {
        var nuevoCadete = new Cadete(id, nombre, direccion, telefono);
        listaCadetes.Add(nuevoCadete);
    }

    private Cadete GenerarCadeteAleatorio()
    {
        var indexRandom = new Random().Next(listaCadetes.Count);
        var cadete = listaCadetes[indexRandom];
        return cadete;
    }

    public int IdCadeteAleatorio()
    {
        var cadete = GenerarCadeteAleatorio();
        return cadete.VerId();
    }

    public int ObtenerNumeroPedidoPendiente()
    {
        var pedidoPendiente = listaPedidos.FirstOrDefault(p => p.VerEstado() == EstadoPedido.Pendiente);

        bool pedidoEncontrado = pedidoPendiente != null;
             
        if(pedidoEncontrado)
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
        var pedido = listaPedidos.Find(p => p.VerNumero() == numeroPedido);
        pedido.AsignarCadete(idCadete);
    }

    public void CambiarEstadoPedido(int numeroPedido, int opcionEstado)
    {
        var pedido = listaPedidos.Find(p => p.VerNumero() == numeroPedido);

        switch (opcionEstado)
        {
            case 0:
                pedido.CambiarEstado(EstadoPedido.Cancelado);
                break;
            case 1:
                pedido.CambiarEstado(EstadoPedido.Entregado);
                break;
        }
    }

    public bool ExistePedido(int numero)
    {
        return listaPedidos.Any(p => p.VerNumero() == numero);
    }

    public bool ExisteCadete(int id)
    {
        return listaCadetes.Any(c => c.VerId() == id);
    }

    public string[] ObtenerPedidosPendientes()
    {
        int cantPedidosPendientes = listaPedidos.Count(p => p.VerEstado() == EstadoPedido.Pendiente);
        string[] arregloPedidosPendientes = new string[cantPedidosPendientes];
        int i = 0;

        foreach (var pedido in listaPedidos)
        {
            if (pedido.VerEstado() == EstadoPedido.Pendiente)
            {
                arregloPedidosPendientes[i] = $"Numero: {pedido.VerNumero()}, Cliente: {pedido.VerCliente().VerNombre()} | " +
                    $"Cadete: {(pedido.VerIdCadete() >= 0 ? "Asignado" : "Sin Asignar")}";
                i++;
            }
        }

        return arregloPedidosPendientes;
    }

    public string[] ObtenerCadetes()
    {
        int cantidadCadetes = listaCadetes.Count;
        string[] arregloCadetes = new string[cantidadCadetes];
        int i = 0;
        
        foreach (var cadete in listaCadetes)
        {
            arregloCadetes[i] = $"{cadete.VerId()} |  {cadete.VerNombre()}";
            i++;
        }

        return arregloCadetes;
    }
}
