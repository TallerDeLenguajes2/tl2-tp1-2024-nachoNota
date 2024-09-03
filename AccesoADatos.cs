using System;
using System.IO;
using System.Text.Json;


public class AccesoADatos
{
	public virtual string LeerArchivo(string rutaArchivo) { }
}

public class AccesoCSV : AccesoADatos
{
    public override string LeerArchivo(string rutaArchivo)
    {

        return ;
    }
}

public class AccesoJson : AccesoADatos
{
    public override string LeerArchivo(string rutaArchivo)
    {
        string linea;
        using (FileStream archivo = new FileStream(rutaArchivo, File.Open))
        {
            using (StreamReader st = new StreamReader(archivo))
            {
                linea = sr.ReadToEnd();
                sr.Close();
            }
        }
    |   return linea;
    }
}