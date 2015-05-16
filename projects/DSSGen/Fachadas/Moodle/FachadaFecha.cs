using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;
using WebUtilities;

namespace Fachadas.Moodle
{
    public class FachadaFecha
    {
        public void VincularDameAnyos(DropDownList ddl,int previos,int proximos) {

            FechaBinding fecha = new FechaBinding();
            DateTime tnow= DateTime.Now;
            BinderListaFechaDropDownList binder = new BinderListaFechaDropDownList(ddl);
            fecha.VincularDameAnyos(tnow, binder,previos,proximos);
        
        }
        public void VincularDameMeses(int anyo,DropDownList ddl) 
        {
            FechaBinding fecha = new FechaBinding();
            DateTime tnow = DateTime.Now;
            BinderListaFechaDropDownList binder = new BinderListaFechaDropDownList(ddl);
            fecha.VincularDameMeses(binder);

        }
        public void VincularDameDias(int month,int year,DropDownList ddl) {
            
            FechaBinding fecha = new FechaBinding();
            DateTime tnow = DateTime.Now;
            BinderListaFechaDropDownList binder = new BinderListaFechaDropDownList(ddl);
            fecha.VincularDameDias(month, year, binder);
        
        }
        public void VincularDameMesesNac(int anyo, DropDownList ddl)
        {
            FechaBinding fecha = new FechaBinding();
            DateTime tnow = DateTime.Now;
            BinderListaFechaDropDownList binder = new BinderListaFechaDropDownList(ddl);
            fecha.VincularDameMesesNac(anyo,binder);

        }
        public void VincularDameDiasNac(int month, int year, DropDownList ddl)
        {

            FechaBinding fecha = new FechaBinding();
            DateTime tnow = DateTime.Now;
            BinderListaFechaDropDownList binder = new BinderListaFechaDropDownList(ddl);
            fecha.VincularDameDiasNac(month, year, binder);

        }

    }
}
