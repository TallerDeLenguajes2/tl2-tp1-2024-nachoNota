using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var Cadeteria = new Cadeteria();
        Cadeteria.CargarCadeteria("Cadeteria.csv", "Cadetes.csv");

        Pedidos NuevoPedido = null;
        int opcion = 0;
        int seguir = 0;

        do
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

                    MostrarPedidosPendientes(Cadeteria);

                    Console.Write("Ingrese el numero del pedido:");
                    int NroPedido = int.Parse(Console.ReadLine());

                    Pedidos pedido = Cadeteria.EncontrarPedido(NroPedido);

                    if (pedido)
                    {
                        Console.WriteLine($"Pedido encontrado, su estado actual es {pedido.Estado}, a cual quieres cambiarlo?");
                        Console.WriteLine("1 - Entregado");
                        Console.WriteLine("2 - Cancelado");
                        int eleccionEstado = int.Parse(Console.ReadLine());
                        switch (eleccionEstado)
                        {
                            case 1:
                                pedido.Estado = estado.Entregado;
                                break;
                            case 2: pedido.Estado = estado.Cancelado;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Pedido no encontrado");
                    }

                    break;
                case 4:
                    MostrarPedidosPendientes(Cadeteria);

                    Console.Write("Ingrese el numero del pedido:");
                    int NroPedido = int.Parse(Console.ReadLine());

                    Pedidos pedido = Cadeteria.EncontrarPedido(NroPedido);
                    if (pedido)
                    {
                        Console.WriteLine("Elija el cadete que tendrá el pedido: ");
                        Cadeteria.MostrarCadetes();
                        
                    } else
                    {
                        Console.WriteLine("Pedido no encontrado");
                    }
                    
                    break;
            }

            Console.Write("Seguir? 1=No, 0=Si: ");
            seguir = int.Parse(Console.ReadLine());

        } while (seguir != 1);
    }

    private static void MostrarPedidosPendientes(Cadeteria cadeteria)
    {
        Console.WriteLine("Pedidos pendientes restantes: ");
        foreach (var cadete in cadeteria.ListaCadetes)
        {
            foreach (var pedido in cadete.ListaPedidos)
            {
                if (pedido.Estado == estado.Pendiente)
                {
                    Console.WriteLine($"Nro: {pedido.Numero}, Nombre del cliente: {pedido.Cliente.VerNombreCliente()}, Cadete: {cadete.VerNombreCadete()}");
                }
            }
        }
    }
}
