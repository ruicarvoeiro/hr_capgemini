using GestaoCandidatos.ServiceGestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCandidatos
{
    public partial class UpdateEntrevistas : System.Web.UI.Page
    {
        ServiceHRClient servico = new ServiceHRClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entrevistas.aspx");
        }

        protected void submeter_Click(object sender, EventArgs e)
        {
            string dataConverter = tb_Data.Text;
            DateTime dataEntrevista = Convert.ToDateTime(dataConverter);
          
            string Id = Request.QueryString["id"];
            int id = Convert.ToInt32(Id);
            servico.UpdateEntrevistas(id, dataEntrevista);
            Response.Redirect("Entrevistas.aspx");
        }
    }
}