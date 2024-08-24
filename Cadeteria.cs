using System;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listaCadetes;

    //public string nombre { get; set; }

    public Cadeteria()
    {
        listaCadetes = new List<Cadete>();
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
            listaCadetes.Add(nuevoCadete);
        }
    }
}
