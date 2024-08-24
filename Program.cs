
var cadeteria = new Cadeteria();
cadeteria.CargarCadeteria("Cadeteria.csv", "Cadetes.csv");

int opcion = 0;
Console.WriteLine("----- MENU -----");
Console.WriteLine("1- Dar de alta pedidos");
Console.WriteLine("2- Asignar pedido a cadete");
Console.WriteLine("3- Cambiar estado del pedido");
Console.WriteLine("4- Asignar pedido a otro cliente");
Console.Write("Opcion: ");

switch (opcion)
{
    case 1: Console.WriteLine("Necesitamos tus datos para tomar el pedido");
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

        var NuevoPedido = new Pedidos(Observacion, Nombre, Direccion, Telefono, DatosRef);
        break;
    case 2:
        break;
    case 3:
        break;
    case 4:
        break;
}