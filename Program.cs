using System;
using System.Reflection;
using System.Linq;

Console.Clear();

var Cadeteria = new Cadeteria();
Cadeteria.CargarCadeteria(@"ArchivosCsv\Cadeteria.csv", @"ArchivosCsv\Cadetes.csv");

Pedidos NuevoPedido = null;
int opcion = 0;
int cont = 0;

while(cont <= 10) //simulo unos 10 pedidos entregados
{
    Console.WriteLine("----- MENU -----");
    Console.WriteLine("1- Dar de alta pedidos");
    Console.WriteLine("2- Asignar pedido a cadete");
    Console.WriteLine("3- Cambiar estado del pedido");
    Console.WriteLine("4- Asignar pedido a otro cadete");
    Console.Write("Opcion: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            if (NuevoPedido == null)
            {
                Console.WriteLine("Datos del cliente que tomará el pedido");
                Console.Write("Nombre: ");
                string Nombre = Console.ReadLine();

                Console.WriteLine("Direccion: ");
                string Direccion = Console.ReadLine();

                Console.WriteLine("Telefono: ");
                string Telefono = Console.ReadLine();

                Console.WriteLine("Datos de referencia de tu domicilio: ");
                string DatosRef = Console.ReadLine();

                Console.WriteLine("Alguna observacion? (si no tiene ninguna dejar en blanco): ");
                string Observacion = Console.ReadLine();

                NuevoPedido = new Pedidos(Observacion, Nombre, Direccion, Telefono, DatosRef);
            }
            else
            {
                Console.WriteLine("Tienes un pedido pendiente, asignalo a un cadete antes de continuar");
            }
            break;
        case 2:
            if (NuevoPedido == null)
            {
                Console.WriteLine("Debe realizar un pedido para poder asignarselo al cadete");
            }
            else
            {
                int random = new Random().Next(0, Cadeteria.ListaCadetes.Count);
                Cadeteria.AsignarPedido(random, NuevoPedido);
                NuevoPedido = null;
            }
            break;
        case 3:
            Console.WriteLine("Pedidos pendientes restantes: ");
            Cadeteria.MostrarPedidosPendientes();

            Console.Write("Ingrese el numero del pedido:");
            int NroPedido = int.Parse(Console.ReadLine());

            Pedidos pedido = Cadeteria.EncontrarPedido(NroPedido);

            if (pedido != null)
            {
                Console.WriteLine($"Pedido encontrado, su estado actual es {pedido.VerEstado()}, a cual quieres cambiarlo?");
                Console.WriteLine("1 - Entregado");
                Console.WriteLine("2 - Cancelado");
                int eleccionEstado = int.Parse(Console.ReadLine());
                switch (eleccionEstado)
                {
                    case 1: pedido.CambiarEstado(estado.Entregado);
                        cont++;

                        break;
                    case 2: pedido.CambiarEstado(estado.Cancelado);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Pedido no encontrado");
            }

            break;
        case 4:
            Console.WriteLine("Pedidos pendientes restantes: ");
            Cadeteria.MostrarPedidosPendientes();

            Console.Write("Ingrese el numero del pedido:");
            NroPedido = int.Parse(Console.ReadLine());

            pedido = Cadeteria.EncontrarPedido(NroPedido);
            if (pedido != null)
            {
                Console.WriteLine("Elija el cadete que tendrá el pedido: ");
                Cadeteria.MostrarCadetes();
                        
            } else
            {
                Console.WriteLine("Pedido no encontrado");
            }
                    
            break;
    }
}

Console.WriteLine("--- Informe jornal ---");

//creo lo que se llama un tipo anonimo, en el que encapsulo una serie de propiedades en un objeto sin definir un tipo explicitamente.
var InformeQuery = from cadete in Cadeteria.ListaCadetes
                    select new
                    {
                        Nombre = cadete.VerNombre(),
                        EnviosCompletados = cadete.ListaPedidos.Count(p => p.VerEstado() == estado.Entregado), //cuento la cant de envios completados que tiene
                        MontoRecaudado = cadete.ListaPedidos.Where(p => p.VerEstado() == estado.Entregado) //filtro los pedidos para quedarme solo con los que fueron entregados
                                                        .Sum(p => 500)
                    };

foreach(var cadete in InformeQuery)
{
    Console.WriteLine($"Cadete: {cadete.Nombre} | Envios completados: {cadete.EnviosCompletados} | Monto recaudado: {cadete.MontoRecaudado}");
}

var TotalRecuadado = InformeQuery.Sum(c => c.MontoRecaudado);
var EnviosTotales = InformeQuery.Sum(c => c.EnviosCompletados);
var EnviosPromedio = InformeQuery.Average(c => c.EnviosCompletados);

Console.WriteLine($"Total recaudado entre todos los cadetes: {TotalRecuadado}");
Console.WriteLine($"Envios totales: {EnviosTotales}");
Console.WriteLine($"Envios en promedio por cadete: {EnviosPromedio}");
