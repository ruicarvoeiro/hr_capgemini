using GestaoCandidatos.ServiceGestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCandidatos
{

    public partial class Classificacoes : System.Web.UI.Page
    {
        EntrevistasSV[] listaEntrevistas;
        ServiceHRClient servico = new ServiceHRClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopularLista();
        }

        private void PopularLista()
        {

            ListaEntrevistasSV lista = servico.GetEntrevistas(0);

            listaEntrevistas = lista.Lista;
            gv_Lista.DataSource = listaEntrevistas;
            gv_Lista.DataBind();
        }
    }
}