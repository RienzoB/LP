using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace TP_03._2
{
    public partial class CrearRegCon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                completarTabla();
            }
        }

        protected void completarTabla()
        {
            try
            {
                DataView dv = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
                if (dv != null && dv.Count > 0)
                {
                    //Rellenar cabecera
                    TableRow headerRow = new TableRow();

                    TableCell headerCell = new TableCell();
                    headerCell.Text = "Descripcion";
                    headerRow.Cells.Add(headerCell);

                    TableCell headerCell2 = new TableCell();
                    headerCell2.Text = "Monto";
                    headerRow.Cells.Add(headerCell2);

                    TableCell headerCell3 = new TableCell();
                    headerCell3.Text = "Tipo";
                    headerRow.Cells.Add(headerCell3);

                    Table1.Rows.Add(headerRow);

                    //Rellenar Filas
                    foreach (DataRowView rowView in dv)
                    {
                        DataRow row = rowView.Row;
                        TableRow tableRow = new TableRow();

                        TableCell cell = new TableCell();
                        cell.Text = row["descripcion"].ToString();
                        tableRow.Cells.Add(cell);


                        TableCell cell2 = new TableCell();
                        cell2.Text = row["monto"].ToString();
                        tableRow.Cells.Add(cell2);


                        TableCell cell3 = new TableCell();
                        cell3.Text = row["tipo"].ToString();
                        tableRow.Cells.Add(cell3);

                        Table1.Rows.Add(tableRow);
                    }


                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "AlertScript", $"alert('Error');", true);
            }
        }

        protected void Alta_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {

                SqlDataSource2.InsertParameters["idCuenta"].DefaultValue = DropDownList1.SelectedValue;
                SqlDataSource2.InsertParameters["monto"].DefaultValue = TextBox1.Text;
                SqlDataSource2.InsertParameters["tipo"].DefaultValue = TextBox2.Text;

                int result = SqlDataSource2.Insert();


                if (result > 0)
                {
                    Label1.Text = "Se ha creado " + result.ToString() + " Nuevo Registro de Cuentas";

                    completarTabla();
                    TextBox1.Text = string.Empty; TextBox2.Text = string.Empty;
                }
                else
                {
                    Label1.Text = "No se pudo crear el Registro";
                }
            }
            else
            {
                Label1.Text = "Debe ingresar una descripcion ";
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            SqlDataSource2.DeleteParameters["id"].DefaultValue = DropDownList2.SelectedValue;
            
            int result = SqlDataSource2.Delete();
            if (result > 0)
            {
                Label2.Text = "Se ha eliminado" + result.ToString() + "Registro";
                completarTabla();
                TextBox1.Text = string.Empty; TextBox2.Text = string.Empty;

            }
            else
            {
                Label2.Text = "No se pudo eliminar el registro";
                completarTabla();
                TextBox1.Text = string.Empty; TextBox2.Text = string.Empty;

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = (DataView)SqlDataSource4.Select(DataSourceSelectArguments.Empty);
            if (dv != null && dv.Count > 0)
            {
                DataRowView row = dv[0];
                DropDownList1.SelectedValue = row["idCuenta"].ToString();
                TextBox1.Text = row["monto"].ToString();
                TextBox2.Text = row["tipo"].ToString();
            }
            completarTabla();
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            SqlDataSource2.UpdateParameters["id"].DefaultValue = DropDownList2.SelectedValue;
            SqlDataSource2.UpdateParameters["idCuenta"].DefaultValue = DropDownList1.SelectedValue;
            SqlDataSource2.UpdateParameters["monto"].DefaultValue = TextBox1.Text;
            SqlDataSource2.UpdateParameters["tipo"].DefaultValue = TextBox2.Text;
            
            int result = SqlDataSource2.Update();
            if (result > 0)
            {

                Label1.Text = "Actualizado " + result.ToString() + " registro.";
                completarTabla();
                TextBox1.Text = string.Empty; TextBox2.Text = string.Empty;
            }
            else
            {
                Label1.Text = "No se actualizaron los registros.";
            }
        }
    }
}