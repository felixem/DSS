using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using WebUtilities;

namespace DSSGenNHibernate.Entrega
{
    public partial class entregar_practica : BasicPage
    {
        //Carga de los controles
        void CargarControles()
        {
            //Actualizar la imagen a enseñar y la url provisional
            if (Session["ImagenProvisional"] == null)
                Session.Add("ImagenProvisional", "");

            ImagenProvisional.Visible = false;
            ImagenProvisional.ImageUrl = Session["ImagenProvisional"].ToString();
            GuardarCambios.Visible = false;
        }

        //Evento ocurrido al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //La página se recarga
            if (Page.IsPostBack)
            {
                //Comprobar si el usuario está registrado
                if (Session["usuario"] == null)
                    Response.Redirect("inicio.aspx", false);

                CargarControles();
            }

            //La página se carga por primera vez
            else
            {
                //Comprobar si el usuario está registrado
                if (Session["usuario"] == null)
                    Response.Redirect("inicio.aspx", false);

                CargarControles();
            }
        }

        //Botón de subida
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //Variable para comprobar si la subida es satisfactoria
            bool todobien = false;

            //Archivo subido
            if (FileUploadControl.HasFile)
            {
                try
                {
                    //Imagen JPEG
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        //Tamaño máximo de la imagen
                        if (FileUploadControl.PostedFile.ContentLength < (3* 1024 * 1024))
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);

                            string direccion = "";

                            //Dirección física de guardado
                            direccion = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FotosFolder"]) + filename;
                            //Subir archivo al servidor
                            FileUploadControl.SaveAs(direccion);
                            StatusLabel.Text = "Estado de subida: Archivo pendiente de confirmación";

                            //Borrar del servidor la imagen anterior
                            string path = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FotosFolder"]) + Session["ImagenProvisional"].ToString();

                            //Borrar si no se ha vuelto a subir el mismo archivo
                            if (String.Compare(filename, Session["ImagenProvisional"].ToString()) != 0)
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                }

                            //Actualizar variables de comprobación
                            todobien = true;
                            Session["ImagenProvisional"] = filename;
                        }
                        else
                            //El archivo subido es demasiado pesado
                            StatusLabel.Text = "Estado de subida: El archivo debe pesar menos que 3Mb!";
                    }
                    else
                        //El archivo de subida no tiene la extensión correcta
                        StatusLabel.Text = "Estado de subida: Sólo se aceptan archivos JPEG";
                }
                catch (Exception ex)
                {
                    //Error de subida
                    StatusLabel.Text = "Estado de subida: El archivo no pudo ser subido. Ocurrió el siguiente error: " + ex.Message;
                }
            }

            else
                //Ningún fichero subido
                StatusLabel.Text = "Estado de subida: No se seleccionó ningún fichero ";

            //Si se ha cargado correctamente la imagen, se muestra
            if (todobien)
            {
                //Actualizar la imagen provisional
                GuardarCambios.Visible = true;
                ImagenProvisional.Visible = true;
                ImagenProvisional.ImageUrl =(System.Configuration.ConfigurationManager.AppSettings["FotosFolder"]) 
                    + Session["ImagenProvisional"].ToString();
            }

            //Si no se ha cargado correctamente la imagen, se oculta
            else
            {
                //No mostrar la imagen
                ImagenProvisional.Visible = false;
                ImagenProvisional.ImageUrl = "";
                GuardarCambios.Visible = false;

                //Borrar la imagen provisional en caso de error
                string path = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FotosFolder"]) + Session["ImagenProvisional"].ToString();

                //Borrar
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                //Modificar el nombre de la imagen
                Session["ImagenProvisional"] = "";
            }
                
        }

        //Confirmar la subida
        protected void GuardarCambios_Click(object sender, EventArgs e)
        {
            //Comprobaciones de seguridad
            if (Session["ImagenProvisional"] == null)
                return;

            if (Session["ImagenProvisional"].ToString().Equals(""))
                return;

            ENImagen img = new ENImagen();

            //Registrar la imagen en la base de datos
            img.Usuario = ((ENUsuario)Session["usuario"]).Nick;
            img.Url = (System.Configuration.ConfigurationManager.AppSettings["FotosFolder"])
                    + Session["ImagenProvisional"].ToString();

            string filename = img.PedirIdImagen().ToString();
            img.Id = Convert.ToInt32(filename);
            string direccion=System.Configuration.ConfigurationManager.AppSettings["FotosFolder"] + filename+".jpg";
            img.Url = direccion;
            img.RegistrarImagen();

            //Urls de dirección
            string pathOriginal = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FotosFolder"]) + Session["ImagenProvisional"].ToString();
            string pathFinal = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FotosFolder"]) + filename+".jpg";

            //Mover el archivo provisional hacia su ubicación final
            File.Move(pathOriginal, pathFinal);

            //Mover a la página de editar imagen
            Session.Remove("ImagenProvisional");
            Response.Redirect("editarimagen.aspx?img=" + filename);
        }
    }
}