using GestaoCandidatos.ServiceGestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCandidatos
{
    public partial class Entrevistas : System.Web.UI.Page
    {
        EntrevistasSV[] listaEntrevistas;
        ServiceHRClient servico = new ServiceHRClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularLista();
            }
        }

        private void PopularLista()
        {
            
            ListaEntrevistasSV lista = servico.GetEntrevistas(0);
            listaEntrevistas = lista.Lista;
            gv_entrevistas.DataSource = listaEntrevistas;
            gv_entrevistas.DataBind();
        }

        protected void gv_entrevistas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_entrevistas.Rows[index];
                string id = row.Cells[2].Text;
                Response.Redirect("UpdateEntrevistas.aspx?Id=" + id);
            }
            if (e.CommandName == "DelButton")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_entrevistas.Rows[index];
                string id = row.Cells[2].Text;
                servico.DeleteEntrevistas(Convert.ToInt32(id));
                Response.Redirect("Entrevistas.aspx");
            }
        }
    }
}