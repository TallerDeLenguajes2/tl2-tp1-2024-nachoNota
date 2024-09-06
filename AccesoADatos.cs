using System;
using System.IO;
using System.Text.Json;


public abstract class AccesoADatos
{
	public abstract void CargarCadeteria(string rutaCadeteria, string rutaCadetes);
}

public class AccesoCSV : AccesoADatos
{
    public override void CargarCadeteria(string rutaCadeteria, string rutaCadetes)
    {
        string[] datos = File.ReadAllText(rutaCadeteria).Split(',');
        var cadeteria = new Cadeteria(datos[0], datos[1]);

        string[] lineas = File.ReadAllLines(rutaCadetes);
        foreach (var linea in lineas)
        {
            string[] datos = linea.Split(',');
            cadeteria.AgregarCadete(datos[0], datos[1], datos[2], datos[3]);
        }
    }
}

public class AccesoJson : AccesoADatos
{
    public override void CargarCadeteria(string rutaCadeteria, string rutaCadetes)
    {
        var cadeteria = JsonSerializer.Deserialize<Cadeteria>(rutaCadeteria);


        
    }
}