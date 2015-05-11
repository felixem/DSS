using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using ComponentesProceso.Moodle.Commands;
using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle;
using BindingComponents.Moodle.Commands;

namespace BindingComponents.Moodle
{
    public class FechaBinding : BasicBinding
    {
        public FechaBinding() : base() { }
        public FechaBinding(ISession sesion) : base(sesion) { }

        public void VincularDameAnyos(DateTime tnow,IBinderListaFecha binder)
        {
            ArrayList lista = new ArrayList();
            for (int i = tnow.Year-10; i <= tnow.Year + 10; i++)
                lista.Add(i);

            binder.Vincular(lista);
        }
        public void VincularDameMeses(IBinderListaFecha binder)
        {
            ArrayList months = new ArrayList();
                for (int i = 1; i <= 12; i++)
                {
                    months.Add(i);
                }
            binder.VincularMes(months);
        }
        public void VincularDameDias(int month, int year,IBinderListaFecha binder)
        {
            ArrayList aday = new ArrayList();

            //Comprobar el mes de la fecha
            switch (month)
            {

                case 1:

                case 3:

                case 5:

                case 7:

                case 8:

                case 10:

                case 12:

                    //Añadir los días al array
                    for (int i = 1; i <= 31; i++)
                        aday.Add(i);

                    break;

                case 2:

                    //Si el mes es febrero, comprobar si se generan 29 o 28 días
                    if (CheckLeapYear(year))
                    {
                        for (int j = 1; j <= 29; j++)
                            aday.Add(j);
                    }

                    //No bisiesto
                    else
                    {

                        for (int j = 1; j <= 28; j++)
                            aday.Add(j);

                    }

                    break;

                case 4:

                case 6:

                case 9:

                case 11:

                    //Meses de 30 días
                    for (int j = 1; j <= 30; j++)
                        aday.Add(j);

                    break;
            }
            binder.Vincular(aday);
        }
        //Función para detectar año bisiesto
        private bool CheckLeapYear(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))

                return true;

            else return false;
        }
    }
}
