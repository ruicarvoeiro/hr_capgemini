using GestaoCandidatos.ServiceGestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCandidatos
{
    public partial class UpdateCandidato : System.Web.UI.Page
    {
        ServiceHRClient servico = new ServiceHRClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                poeOQuejaEstava();
                PopularDropDownList();
            }
            
        }

        private void poeOQuejaEstava()
        {
            string nome = Request.QueryString["nome"];
            string dataNasc = Request.QueryString["dataNasc"];
            string nif = Request.QueryString["nif"];
            tb_Nome.Text = nome;
            tb_Data.Text = dataNasc;
            tb_Nif.Text = nif;
        }

        protected void sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidatos.aspx");

        }

        protected void submeter_Click(object sender, EventArgs e)
        {
            string idsttring = Request.QueryString["id"];
            int id = Convert.ToInt32(idsttring);
            string nome = tb_Nome.Text;
            string nif = tb_Nif.Text;
            string dataConverter = tb_Data.Text;
            if(dataConverter == "") MessageBox.Show(this, "A data está vazia");
            DateTime data = Convert.ToDateTime(dataConverter);
            int escolaridade = Convert.ToInt32(dl_Escolaridade.SelectedValue.ToString());

            if (nome == "") MessageBox.Show(this, "O campo nome está vazio");
            else if (nif == "") MessageBox.Show(this, "O campo nif está vazio");
            else if (dataConverter == "") MessageBox.Show(this, "O campo data está vazio");
            else
            {
                if (nif.Length != 9) MessageBox.Show(this, "O NIF tem de ter 9 digitos");
                else
                {
                    servico.UpdateCandidatos(id, nome, nif, data, escolaridade);
                    Response.Redirect("Candidatos.aspx");
                }
            }
            
        }
        private void PopularDropDownList()
        {
            foreach (TipoEscolaridadeSV te in servico.GetTipoescolaridade().Lista)
            {
                ListItem item = new ListItem(te.Descricao, te.id.ToString());
                dl_Escolaridade.Items.Add(item);
            }
        }
    }
}