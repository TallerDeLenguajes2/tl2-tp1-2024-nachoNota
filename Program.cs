using System;
using System.Reflection;
using System.Linq;

Console.Clear();

var Cadeteria = new Cadeteria();
Cadeteria.CargarCadeteria(@"ArchivosCsv\Cadeteria.csv", @"ArchivosCsv\Cadetes.csv");

int opcion = 0;
int cont = 0;

while(cont <= 10) //simulo unos 10 pedidos entregados
{
    Console.WriteLine("----- MENU -----");
    Console.WriteLine("1- Dar de alta pedidos");
    Console.WriteLine("2- Asignar cadete a pedido");
    Console.WriteLine("3- Cambiar estado del pedido");
    Console.WriteLine("4- Asignar pedido a otro cadete");
    Console.Write("Opcion: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
       case 1:
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

            Pedidos NuevoPedido = new Pedidos(Observacion, Nombre, Direccion, Telefono, DatosRef);

            Cadeteria.AgregarPedido(NuevoPedido);

        case 2:
            var idCadete = Cadeteria.IdCadeteAleatorio();
            var idPedido = Cadeteria.IdPedidoPendiente();
            if(idPedido != -1)
            {
                Cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
            }
            else
            {
                Console.WriteLine("No existen pedidos para ser asignados");
            }
                
                
            break;
    }
}

/*Console.WriteLine("--- Informe jornal ---");

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
*/