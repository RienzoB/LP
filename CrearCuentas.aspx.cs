using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_03._2
{
    public partial class CrearCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizarLabel();
            }
        }
        protected void actualizarLabel()
        {
            Label3.Text = "";
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            foreach (DataRowView dr in dv)
            {

                DataRow row = dr.Row;
                Label3.Text += row["descripcion"].ToString() + " - ";
            }
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                int result = SqlDataSource1.Insert();

                if (result != 0)
                {
                    Label2.Text = "Se ha creado " + result.ToString() + " Nueva Cuenta";
                    actualizarLabel();
                }
                else
                {
                    Label2.Text = "No se pudo crear la cuenta";
                }
            }
            else
            {
                Label2.Text = "Debe ingresar una descripcion ";
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataSource2.DataSourceMode = SqlDataSourceMode.DataReader;
            SqlDataReader reader = (SqlDataReader)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            if (reader.Read())
            {
                TextBox2.Text = reader["descripcion"].ToString();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataSource1.DeleteParameters["id"].DefaultValue = ListBox1.SelectedValue;
            int result = SqlDataSource1.Delete();

            if (result != 0)
            {
                Label2.Text = "Se ha ELIMINADO " + result.ToString() + " Cuenta";
                actualizarLabel();
                TextBox2.Text = "";
            }
            else
            {
                Label2.Text = "No se pudo eliminar la cuenta";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlDataSource1.UpdateParameters["id"].DefaultValue = ListBox1.SelectedValue;
            SqlDataSource1.UpdateParameters["descripcion"].DefaultValue = TextBox2.Text;
            int result = SqlDataSource1.Update();

            if (result != 0)
            {
                Label2.Text = "Se ha Actualizado " + result.ToString() + " Cuenta";
                actualizarLabel();
                TextBox2.Text = "";
            }
            else
            {
                Label2.Text = "No se pudo actualizar la cuenta";
            }
        }
    }
}
