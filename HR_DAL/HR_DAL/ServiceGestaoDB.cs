using HR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_DAL
{
    /// <summary>
    /// Serviço que oferece os metodos a serem utilizados pelo cliente para gestao de candidatos
    /// </summary>
    public class ServiceGestaoDB
    {
        //faz a ligacao a base de dados
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceGestaoConnectionString"].ConnectionString);
        #region Candidatos
        /// <summary>
        /// Cria
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Nif"></param>
        /// <param name="DataNascimento"></param>
        /// <param name="Escolaridade"></param>
        public void CriarCandidatos(string Nome, string Nif, DateTime DataNascimento, int Escolaridade)
        {
            try
            {
                String sql = "[dbo].[CreateCandidato]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nome", System.Data.DbType.String).Value = Nome;
                cmd.Parameters.AddWithValue("@Nif", System.Data.DbType.String).Value = Nif;
                cmd.Parameters.AddWithValue("@DataNasc", System.Data.DbType.Date).Value = DataNascimento;
                cmd.Parameters.AddWithValue("@TipoEscolaridadeId", System.Data.DbType.Int32).Value = Escolaridade;
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw new Exception("Erro na criação de candidato.");
            }
            finally
            {
                con.Close();
            }
        }
        public ListaCandidatoDB GetCandidatos(string Nome, string Nif)
        {
            ListaCandidatoDB ListaCandidato = new ListaCandidatoDB();
            ListaCandidato.Lista = new List<CandidatoDB>();
            try
            {
                String sql = "dbo.GetCandidatos";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nome", System.Data.DbType.String).Value = Nome;
                cmd.Parameters.AddWithValue("@Nif", System.Data.DbType.String).Value = Nif;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool output = false;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        CandidatoDB candidato = new CandidatoDB()
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            Nome = Convert.ToString(reader["Nome"]),
                            Nif = Convert.ToString(reader["NIF"]),
                            DataNascimento = Convert.ToDateTime(reader["DataNasc"]).Date,
                            Escolaridade = Convert.ToInt32(reader["TipoEscolaridadeId"])
                        };
                        ListaCandidato.Lista.Add(candidato);
                        output = true;
                    }
                    else output = false;
                    if (!output)
                    {
                        ListaCandidato.ErrorMessage = "A pesquisa não devolveu registos";
                        ListaCandidato.HasError = true;
                    }
                }
            }
            catch (Exception e)
            {
                ListaCandidato.ErrorMessage = "Erro de SQL na Transação";
                ListaCandidato.HasError = true;
            }
            finally
            {
                con.Close();
            }
            return ListaCandidato;
        }
        public void UpdateCandidatos(int id, string Nome, string Nif, DateTime DataNascimento, int Escolaridade)
        {
            try
            {
                String sql = "[dbo].[UpdateCandidato]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CandidatoId", System.Data.DbType.Int32).Value = id;
                cmd.Parameters.AddWithValue("@Nome", System.Data.DbType.String).Value = Nome;
                cmd.Parameters.AddWithValue("@Nif", System.Data.DbType.String).Value = Nif;
                cmd.Parameters.AddWithValue("@DataNasc", System.Data.DbType.Date).Value = DataNascimento;
                cmd.Parameters.AddWithValue("@TipoEscolaridadeId", System.Data.DbType.Int32).Value = Escolaridade;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro de SQL na Transação");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteCandidatos(int id)
        {
            try
            {
                String sql = "[dbo].[DeleteCandidato]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CandidatoId", System.Data.DbType.Int32).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro de SQL na Transação");
            }
            finally
            {
                con.Close();
            }
        }
        #endregion Candidatos

        #region Entrevistas
        public void CriarEntrevistas(int Id, DateTime HoraEntrevista)
        {
            try
            {
                String sql = "[dbo].[CreateEntrevista]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CandidatoId", System.Data.DbType.Int32).Value = Id;
                cmd.Parameters.AddWithValue("@DataHora", System.Data.DbType.DateTime).Value = HoraEntrevista;
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw new Exception("Erro ao criar entrevista");
            }
            finally
            {
                con.Close();
            }
        }
        public ListaEntrevistasDB GetEntrevistas(int Id)
        {
            ListaEntrevistasDB ListaEntrevista = new ListaEntrevistasDB();
            ListaEntrevista.Lista = new List<EntrevistasDB>();
            try
            {
                String sql = "dbo.GetEntrevistas";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CandidatoId", System.Data.DbType.Int32).Value = Id;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool output = false;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {

                        EntrevistasDB entrevista = new EntrevistasDB()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            DataHora = Convert.ToDateTime(reader["DataHora"]),
                            Descricao = Convert.ToString((reader["EntDescricao"])),
                            Nome = Convert.ToString((reader["Nome"])),
                            EscaDescricao = Convert.ToString((reader["EscaDescricao"])),
                            EntDescricao = Convert.ToString((reader["EntDescricao"])),
                            Nota = Convert.ToString((reader["Nota"])),
                            candidato = new CandidatoDB
                            {
                                id = Convert.ToInt32(reader["CandidatoId"]),
                                Nome = Convert.ToString((reader["Nome"])),
                                Nif = Convert.ToString((reader["Nif"]))
                            },
                            escalaAvaliacao = new EscalaAvaliacaoDB
                            {
                                id = reader["EscalaAvaliacaoId"].ToString() == "" ? 0 : Convert.ToInt32(reader["EscalaAvaliacaoId"]),
                                Descricao = Convert.ToString((reader["EscaDescricao"])),
                                Nota = Convert.ToString((reader["Nota"]))
                            }
                        };
                        ListaEntrevista.Lista.Add(entrevista);
                        output = true;
                    }
                    else output = false;
                    if (!output)
                    {
                        ListaEntrevista.ErrorMessage = "A pesquisa não devolveu registos";
                        ListaEntrevista.HasError = true;
                    }
                }
            }
            catch (Exception e)
            {
                ListaEntrevista.ErrorMessage = "Erro de SQL na Transação";
                ListaEntrevista.HasError = true;
            }
            finally
            {
                con.Close();
            }
            return ListaEntrevista;
        }
        public void UpdateEntrevistas(int Id, DateTime HoraEntrevista)
        {
            try
            {
                String sql = "[dbo].[UpdateEntrevista]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EntrevistaId", System.Data.DbType.Int32).Value = Id;
                cmd.Parameters.AddWithValue("@DataHora", System.Data.DbType.DateTime).Value = HoraEntrevista;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro de SQL na Transação");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteEntrevistas(int id)
        {
            try
            {
                String sql = "[dbo].[DeleteEntrevista]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EntrevistaId", System.Data.DbType.Int32).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro de SQL na Transação");
            }
            finally
            {
                con.Close();
            }
        }
        public void AddAvaliacaoEntrevista(int IdEntrevista, int IdEscalaAval, string Desc)
        {
            try
            {
                String sql = "[dbo].[AddAvaliacaoEntrevista]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EntrevistaId", System.Data.DbType.Int32).Value = IdEntrevista;
                cmd.Parameters.AddWithValue("@EscalaAvaliacaoId", System.Data.DbType.Int32).Value = IdEscalaAval;
                cmd.Parameters.AddWithValue("@Descricao", System.Data.DbType.String).Value = Desc;

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro de SQL na Transação");
            }
            finally
            {
                con.Close();
            }
        }
        #endregion Entrevistas

        public ListaEscalaAvaliacaoDB GetEscalaAvaliacao()
        {
            ListaEscalaAvaliacaoDB ListaEscala = new ListaEscalaAvaliacaoDB();
            ListaEscala.Lista = new List<EscalaAvaliacaoDB>();
            try
            {
                String sql = "[dbo].[GetEscalaAvaliacao]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool output = false;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        EscalaAvaliacaoDB escalaAvaliacao = new EscalaAvaliacaoDB()
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            Descricao = Convert.ToString(reader["Descricao"]),
                            Nota = Convert.ToString(reader["Nota"])
                        };
                        ListaEscala.Lista.Add(escalaAvaliacao);
                        output = true;
                    }
                    else output = false;
                    if (!output)
                    {
                        ListaEscala.ErrorMessage = "A pesquisa não devolveu registos";
                        ListaEscala.HasError = true;
                    }
                }
            }
            catch (Exception e)
            {
                ListaEscala.ErrorMessage = "Erro de SQL na Transação";
                ListaEscala.HasError = true;
            }
            finally
            {
                con.Close();
            }
            return ListaEscala;
        }

        public ListaTipoEscolaridadeDB GetTipoescolaridade()
        {
            ListaTipoEscolaridadeDB ListaEscala = new ListaTipoEscolaridadeDB();
            ListaEscala.Lista = new List<TipoEscolaridadeDB>();
            try
            {
                String sql = "[dbo].[GetTipoEscolaridade]";
                SqlCommand cmd = new SqlCommand(sql, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool output = false;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TipoEscolaridadeDB tipoEscolaridade = new TipoEscolaridadeDB()
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            Descricao = Convert.ToString(reader["Descricao"])
                        };
                        ListaEscala.Lista.Add(tipoEscolaridade);
                        output = true;
                    }
                    else output = false;
                    if (!output)
                    {
                        ListaEscala.ErrorMessage = "A pesquisa não devolveu registos";
                        ListaEscala.HasError = true;
                    }
                }
            }
            catch (Exception e)
            {
                ListaEscala.ErrorMessage = "Erro de SQL na Transação";
                ListaEscala.HasError = true;
            }
            finally
            {
                con.Close();
            }
            return ListaEscala;
        }
    }
}