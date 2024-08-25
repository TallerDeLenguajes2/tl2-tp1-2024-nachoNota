Console.Clear();

var cadeteria = new Cadeteria();
cadeteria.CargarCadeteria("Cadeteria.csv", "Cadetes.csv");

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
            if(NuevoPedido == null)
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
            
            if(NuevoPedido == null)
            {
                Console.WriteLine("Debe realizar un pedido para poder asignarselo al cadete");
            }
            else
            {
                int random = new Random().Next(0, cadeteria.listaCadetes.Count);
                cadeteria.AsignarPedido(random, NuevoPedido);
                NuevoPedido = null;
            }

            break;
        case 3:
            Console.WriteLine("El estado actual del pedido es");
            break;
        case 4: 
            break;
    }

    Console.Write("Seguir? 1=No, 0=Si");
    seguir = int.Parse(Console.ReadLine());

} while (seguir != 1);