using GestaoCandidatos.ServiceGestao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCandidatos
{
    public partial class AddClassificacao : System.Web.UI.Page
    {
        ServiceHRClient servico = new ServiceHRClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopularDropDownList();
        }

        private void PopularDropDownList()
        {
            foreach (EscalaAvaliacaoSV te in servico.GetEscalaAvaliacao().Lista)
            {
                ListItem item = new ListItem(te.Descricao, te.id.ToString());
                dl_Nota.Items.Add(item);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetEntidades(string pre)
        {
            List<string> allEntidades = new List<string>();
            using (HumanResourcesEntities dc = new HumanResourcesEntities())
            {
                allEntidades = (from a in dc.Candidato
                                where a.Nome.StartsWith(pre)
                                select a.Nome).ToList();
            }
            return allEntidades;
        }

        protected void submeter_Click(object sender, EventArgs e)
        {
            int idCandidato = ReturnId(tb_Nome.Text);
            
            int nota = Convert.ToInt32(dl_Nota.SelectedValue.ToString()); ;
            string comentario = tb_Comentario.Text;
            
            
            bool erro = false;
            if (tb_ID.Text == "" && tb_Nome.Text == "")
            {
                erro = true;
                MessageBox.Show(this, "Pelo menos um dos campos (Nif ou Nome) tem de estar preenchido");
            }
            if (!erro)
            {
                if (tb_ID.Text != "" && tb_Nome.Text != "")
                {
                    MessageBox.Show(this, "O ID não corresponde ao nome");
                }
                    if (tb_Nome.Text == "")
                {
                    int id = Convert.ToInt32(tb_ID.Text);
                    servico.AddAvaliacaoEntrevista(id, nota, comentario);
                    Response.Redirect("Classificacoes.aspx");
                }
                if(tb_ID.Text == "")
                {
                    int id = ReturnIdVerdadeiro(idCandidato);
                    servico.AddAvaliacaoEntrevista(id, nota, comentario);
                    Response.Redirect("Classificacoes.aspx");
                }
            }

        }

        private int ReturnIdVerdadeiro(int idCandidato)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceGestaoConnectionString"].ConnectionString);
            int idEntidade = 0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string query = cmd.CommandText = "SELECT [Id] FROM [Entrevistas] WHERE [CandidatoId]='" + idCandidato + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            idEntidade = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return idEntidade;
        }

        private int ReturnId(string text)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceGestaoConnectionString"].ConnectionString);
            int idEntidade = 0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string query = cmd.CommandText = "SELECT Id FROM Candidato WHERE NOME='" + text + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            idEntidade = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return idEntidade;
        }

        protected void sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Classificacoes.aspx");
        }
    }
}