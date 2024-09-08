﻿using System;

public enum EstadoPedido
{
    Cancelado,
    Pendiente,
    Entregado
};

public class Pedidos
{
    private string observacion;
    private EstadoPedido estado;
    private int numero;
    private Cliente cliente;
    
    private int idCadete;

    public Pedidos(string observacion, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        this.numero = new Random().Next(0, 100000); //simulo una eleccion de numero unico para el pedido, ya se que puede repetirse pero bueno
        this.observacion = observacion;
        this.estado = EstadoPedido.Pendiente;

        cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
    }

    public EstadoPedido VerEstado()
    {
        return estado;
    }

    public int VerNumero()
    {
        return numero;
    }

    public int VerIdCadete(){
        return idCadete;
    }

    public Cliente VerCliente()
    {
        return cliente;
    }

    public void AsignarCadete(int idCadete)
    {
        this.idCadete = idCadete;
    }

    public void CambiarEstado(EstadoPedido estado)
    {
        this.estado = estado;
    }
}
