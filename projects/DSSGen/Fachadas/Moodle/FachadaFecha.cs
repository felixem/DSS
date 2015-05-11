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
        public void VincularDameAnyos(DropDownList ddl) {

            FechaBinding fecha = new FechaBinding();
            DateTime tnow= DateTime.Now;
            BinderListaFechaDropDownList binder = new BinderListaFechaDropDownList(ddl);
            fecha.VincularDameAnyos(tnow, binder);
        
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

    }
}
