using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestaoCandidatos.ServiceGestao;

namespace GestaoCandidatos
{
    public partial class Candidatos : System.Web.UI.Page
    {
        CandidatoSV[] listaCandidato;
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

            ListaCandidatoSV lista = servico.GetCandidatos("", "");

            listaCandidato = lista.Lista;
            gv_GetCandidatos.DataSource = listaCandidato;
            gv_GetCandidatos.DataBind();
        }

        protected void gv_GetCandidatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_GetCandidatos.Rows[index];
                string dataNasc = row.Cells[2].Text;
                string escolaridade = row.Cells[3].Text;
                string nif = row.Cells[4].Text;
                string nome = row.Cells[5].Text;
                string id = row.Cells[6].Text;
                Response.Redirect("UpdateCandidato.aspx?nome=" + nome + "&dataNasc=" + dataNasc + "&nif=" + nif + "&id=" + id);
            }
            if (e.CommandName == "DelButton")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv_GetCandidatos.Rows[index];
                string id = row.Cells[6].Text;
                servico.DeleteCandidatos(Convert.ToInt32(id));
                Response.Redirect("Candidatos.aspx");
            }
        }



    }
}