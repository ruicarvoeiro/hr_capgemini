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
    public partial class AddEntrevista : System.Web.UI.Page
    {
        ServiceHRClient servico = new ServiceHRClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submeter_Click(object sender, EventArgs e)
        {
            bool erro = false;
            if (tb_Nome.Text == "")
            {
                erro = true;
                MessageBox.Show(this, "O campo nome está vazio");
            }
            else
            {
                string dataConverter = tb_Data.Text;

                DateTime data = new DateTime();

                if (dataConverter == "")
                {
                    erro = true;
                    MessageBox.Show(this, "Data de Entrevista vazia");
                }
                else
                {
                    string hora = tb_Hora.Text;
                    string union = (dataConverter + " " + hora);
                    data = Convert.ToDateTime(union);
                }

                if (DateTime.Now >= data)
                {
                    erro = true;
                    MessageBox.Show(this, "Data de entrevista inválida");
                }
                if (tb_Id.Text == "" && tb_Nome.Text == "")
                {
                    erro = true;
                    MessageBox.Show(this, "Pelo menos um dos campos (Nif ou Nome) tem de estar preenchido");
                }
                if (!erro)
                {
                    if (tb_Id.Text == "")
                    {
                        int id = ReturnId(tb_Nome.Text);
                        string repetido = servico.CriarEntrevistas(id, data);
                        if (repetido != "")
                        {
                            MessageBox.Show(this, "A entrevista já existe");
                        }
                        else
                        {
                            Response.Redirect("Candidatos.aspx");
                        }
                    }
                    if (tb_Nome.Text == "")
                    {
                        int id = Convert.ToInt32(tb_Id.Text);
                        string repetido = servico.CriarEntrevistas(id, data);
                        if (repetido != "")
                        {
                            MessageBox.Show(this, "A entrevista já existe");
                        }
                        else
                        {
                            Response.Redirect("Candidatos.aspx");
                        }
                    }

                }
            }
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

        protected void sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entrevistas.aspx");
        }
    }
}