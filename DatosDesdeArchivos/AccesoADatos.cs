using System;
using CadeteriaLibrary;

namespace DatosDesdeArchivos
{
    public abstract class AccesoADatos
    {
	    public abstract Cadeteria CargarCadeteria(string rutaCadeteria);
        public abstract List<Cadete> CargarCadetes(string rutaCadetes);
    }
}