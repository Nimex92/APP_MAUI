﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotec
{
    public class Zonas
    {
        public Zonas() { }

        [Key]
        public int IdZona { get; set; }
        public string Nombre { get; set; }
        public ICollection<Grupo_Trabajo> GruposTrabajo { get; set; } = new List<Grupo_Trabajo>();

        public Zonas(String nombre)
        {
            this.Nombre = nombre;
        }
    }
}
