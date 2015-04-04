using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.WebUtilities;

namespace WebApplication2
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        MySession sesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion = MySession.Current;
            if (!IsPostBack)
            {
            }
        }

        //Visibilidad de los controles
        private void VisibilidadControles()
        {
            if (sesion.IsLoged())
            {
                user_image.Visible = true;
                user_label.Visible = true;
                button_desloguear.Visible = true;
            }
            else
            {
                user_image.Visible = false;
                user_label.Visible = false;
                button_desloguear.Visible = false;
            }
        }
    }
}
