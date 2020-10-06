using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIngresar_Click(Object sender, EventArgs e) {
        if (txtUsuario.Text.ToLower() == "admin" && this.txtClave.Text == "admin") {
            Page.Response.Write("Ingreso OK");
        } else {
            Page.Response.Write("Usuario y/o contrase&ntilde;a incorrecto");
        }
    }
    
    protected void lnkRecordarClave_Click(Object sender, EventArgs e)
    {
        //Redirecciono a otra pagina que deberia existir
        Response.Redirect("~/Default.aspx?msj=Es ustede un usuario muy descuidado, haga memoria");
    }
}