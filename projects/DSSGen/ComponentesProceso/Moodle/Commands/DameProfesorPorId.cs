﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Clase que representa una operación para obtener un profesor por id
    public class DameProfesorPorId : IDameProfesor
    {
        //Código de profesor
        private int cod;

        //Constructor a partir del código de profesor
        public DameProfesorPorId(int id)
        {
            this.cod = id;
        }

        //Propiedades
        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        //Método de consulta
        public ProfesorEN Execute(ISession sesion)
        {
            ProfesorCAD cad = new ProfesorCAD(sesion);
            ProfesorCEN cen = new ProfesorCEN(cad);

            return cen.ReadCod(cod);
        }
    }
}
