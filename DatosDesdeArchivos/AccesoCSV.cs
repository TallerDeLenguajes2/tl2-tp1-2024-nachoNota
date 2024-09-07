using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace DatosDesdeArchivos
{
    public class AccesoCSV : AccesoADatos
    {
        public override Cadeteria CargarCadeteria(string rutaCadeteria)
        {
            string[] datos = File.ReadAllText(rutaCadeteria).Split(',');
            var cadeteria = new Cadeteria(datos[0], datos[1]);

            return cadeteria;
        }

        public override List<Cadete> CargarCadetes(string rutaCadetes)
        {
            var listaCadetes = new List<Cadete>();
            string[] lineas = File.ReadAllLines(rutaCadetes);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');
                var cadete = new Cadete(int.Parse(datos[0]), datos[1], datos[2], datos[3]);
                listaCadetes.Add(cadete);
            }
            return listaCadetes;
        }
    }
}
