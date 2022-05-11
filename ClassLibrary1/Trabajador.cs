﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotec
{
    public class Trabajador
    {
        public Trabajador()
        {

        }
        [Key]
        public int numero_tarjeta { get; set; }
        public string nombre { get; set; }
        public string perteneceaturnos { get; set; }
        public ICollection<EquipoTrabajo> equipo { get; set; } = new List<EquipoTrabajo>();
        public virtual Usuarios usuario { get; set; }
        

        public Trabajador(string nombre, EquipoTrabajo grupo,Usuarios user)
        {
            this.nombre = nombre;
            this.usuario = user;
        }
        public Trabajador(int numero_tarjeta, string nombre, EquipoTrabajo grupo)
        {
            this.numero_tarjeta = numero_tarjeta;
            this.nombre = nombre;
        }
    }
}
