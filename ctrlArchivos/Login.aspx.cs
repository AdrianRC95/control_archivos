using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Modelo;

namespace MPlastic
{
    public partial class Login : System.Web.UI.Page
    {
        Usuario2 obj1 = new Usuario2();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String u = TextBox1.Text;
            String c = TextBox2.Text;

            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "bn2();", true);

            }

            else if (obj1.acceso(u, c) == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostrar", "Bn();", true);
                }

                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostrar", "Er();", true);

                    TextBox1.Focus();
                }

            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}