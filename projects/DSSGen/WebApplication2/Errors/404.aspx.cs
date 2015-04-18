using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebUtilities;

namespace WebApplication2.Errors
{
    public partial class Error404 : BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set status code and message; you could also use the HttpStatusCode enum:
            // System.Net.HttpStatusCode.NotFound
            Response.StatusCode = 404;
            Response.StatusDescription = "Page Not Found";
        }
    }
}
