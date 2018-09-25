using GestaoCandidatos.ServiceGestao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCandidatos
{
    public partial class AddCandidato : System.Web.UI.Page
    {
        ServiceHRClient servico = new ServiceHRClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopularDropDownList();
        }

        protected void sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidatos.aspx");
        }

        protected void submeter_Click(object sender, EventArgs e)
        {
            string nome = tb_Nome.Text;
            string nif = tb_Nif.Text;
            int escolaridade = Convert.ToInt32(dl_Escolaridade.SelectedValue.ToString());

            bool erro = false;

            DateTime data = new DateTime() ;
            string dataConverter = tb_Data.Text;

            if (nome == "")
            {
                erro = true;
                MessageBox.Show(this, "O campo nome está vazio");
            }

            if (nome.Length < 3 || nome.Length > 50)
            {
                erro = true;
                MessageBox.Show(this, "Tamanho do nome inválido.");
            }


            if (nif == "")
            {
                erro = true;
                MessageBox.Show(this, "O campo nif está vazio");
            }


            if (nif.Length != 9)
            {
                erro = true;
                MessageBox.Show(this, "O NIF tem de ter 9 digitos");
            }

            if (dataConverter == "")
            {
                erro = true;
                MessageBox.Show(this, "A data está vazia");
            }
            else
            {
                data = Convert.ToDateTime(dataConverter);
            }
            if(DateTime.Now <= data)
            {
                erro = true;
                MessageBox.Show(this, "Data de Nascimento inválida");
            }
            
            if (!erro)
            {
                string repetido = servico.CriarCandidatos(nome, nif, data, escolaridade);
                if (repetido != "")
                {
                    MessageBox.Show(this, "O Candidato já existe");
                }
                else
                {
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