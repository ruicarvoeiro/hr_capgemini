using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_DAL;
using HR_DAL.Data;
using WCFDAL.Contract;

namespace WCFDAL
{
    public class ServiceGestaoSV : IServiceHR
    {
        ServiceGestaoDB serviceDB = new ServiceGestaoDB();

        public void AddAvaliacaoEntrevista(int IdEntrevista, int IdEscalaAval, string Desc)
        {
            try
            {
                serviceDB.AddAvaliacaoEntrevista(IdEntrevista, IdEscalaAval, Desc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CriarCandidatos(string Nome, string Nif, DateTime DataNascimento, int Escolaridade)
        {
            try
            {
                ListaCandidatoSV lista = new ListaCandidatoSV();
                lista = GetCandidatos("", Nif);

                if (lista.Lista.Count() == 0)
                {

                    CandidatoDB candidato = new CandidatoDB();
                    serviceDB.CriarCandidatos(Nome, Nif, DataNascimento, Escolaridade);
                    return "";
                }
                else return "Já existe este candidato";
                    

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CriarEntrevistas(int Id, DateTime HoraEntrevista)
        {
            try
            {
                ListaEntrevistasSV lista = new ListaEntrevistasSV();
                lista = GetEntrevistas(Id);

                    CandidatoDB candidato = new CandidatoDB();
                    serviceDB.CriarEntrevistas(Id, HoraEntrevista);
                    return "";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCandidatos(int id)
        {
            try
            {
                serviceDB.DeleteCandidatos(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteEntrevistas(int id)
        {
            try
            {
                serviceDB.DeleteEntrevistas(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ListaCandidatoSV GetCandidatos(string Nome, string Nif)
        {
            ListaCandidatoDB listaDb = serviceDB.GetCandidatos(Nome, Nif);
            ListaCandidatoSV lista = new ListaCandidatoSV();
            lista.Lista = new List<CandidatoSV>();
            if (!listaDb.HasError & listaDb.Lista.Count > 0)
            {
                foreach (CandidatoDB item in listaDb.Lista)
                {
                    CandidatoSV candidato = new CandidatoSV();
                    candidato.Nif = item.Nif;
                    candidato.id = item.id;
                    candidato.DataNascimento = item.DataNascimento.Date;
                    candidato.Escolaridade = item.Escolaridade;
                    candidato.Nome = item.Nome;
                    lista.Lista.Add(candidato);
                }
            }
            else
            {
                lista.HasError = listaDb.HasError;
                lista.HasRows = false;
                lista.ErrorMessage = listaDb.ErrorMessage;
            }
            return lista;
        }

        public ListaEntrevistasSV GetEntrevistas(int Id)
        {
            ListaEntrevistasDB listaDb = serviceDB.GetEntrevistas(Id);
            ListaEntrevistasSV lista = new ListaEntrevistasSV();
            lista.Lista = new List<EntrevistasSV>();
            if (!listaDb.HasError & listaDb.Lista.Count > 0)
            {
                foreach (EntrevistasDB item in listaDb.Lista)
                {
                    //CandidatoId	DataHora	Descricao	Id	IdEntrevista
                    EntrevistasSV entrevista = new EntrevistasSV();
                    entrevista.DataHora = item.DataHora;
                    entrevista.Nome = item.Nome;
                    entrevista.EscaDescricao = item.EscaDescricao;
                    entrevista.EntDescricao = item.EntDescricao;
                    entrevista.candidato = new CandidatoSV();
                    entrevista.candidato.id = item.candidato.id;
                    entrevista.candidato.Nome = item.candidato.Nome;


                    entrevista.Nota = item.Nota;
                    entrevista.Descricao = item.Descricao;
                    entrevista.escalaAvaliacao = new EscalaAvaliacaoSV();
                    entrevista.Id = item.Id;
                    entrevista.escalaAvaliacao.Nota = item.escalaAvaliacao.Nota;

                    lista.Lista.Add(entrevista);
                }
            }
            else
            {
                lista.HasError = listaDb.HasError;
                lista.HasRows = false;
                lista.ErrorMessage = listaDb.ErrorMessage;
            }
            return lista;
        }

        public ListaEscalaAvaliacaoSV GetEscalaAvaliacao()
        {
            ListaEscalaAvaliacaoDB listaDb = serviceDB.GetEscalaAvaliacao();
            ListaEscalaAvaliacaoSV lista = new ListaEscalaAvaliacaoSV();
            lista.Lista = new List<EscalaAvaliacaoSV>();
            if (!listaDb.HasError & listaDb.Lista.Count > 0)
            {
                foreach (EscalaAvaliacaoDB item in listaDb.Lista)
                {
                    EscalaAvaliacaoSV escalaAvaliacoes = new EscalaAvaliacaoSV();
                    escalaAvaliacoes.id = item.id;
                    escalaAvaliacoes.Nota = item.Nota;
                    escalaAvaliacoes.Descricao = item.Descricao;
                    lista.Lista.Add(escalaAvaliacoes);
                }
            }
            else
            {
                lista.HasError = listaDb.HasError;
                lista.HasRows = false;
                lista.ErrorMessage = listaDb.ErrorMessage;
            }
            return lista;
        }

        public ListaTipoEscolaridadeSV GetTipoescolaridade()
        {
            ListaTipoEscolaridadeDB listaDb = serviceDB.GetTipoescolaridade();
            ListaTipoEscolaridadeSV lista = new ListaTipoEscolaridadeSV();
            lista.Lista = new List<TipoEscolaridadeSV>();
            if (!listaDb.HasError & listaDb.Lista.Count > 0)
            {
                foreach (TipoEscolaridadeDB item in listaDb.Lista)
                {
                    TipoEscolaridadeSV tipoEscolaridade = new TipoEscolaridadeSV();
                    tipoEscolaridade.id = item.id;
                    tipoEscolaridade.Descricao = item.Descricao;
                    lista.Lista.Add(tipoEscolaridade);
                }
            }
            else
            {
                lista.HasError = listaDb.HasError;
                lista.HasRows = false;
                lista.ErrorMessage = listaDb.ErrorMessage;
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Nome"></param>
        /// <param name="Nif"></param>
        /// <param name="DataNascimento"></param>
        /// <param name="Escolaridade"></param>
        public void UpdateCandidatos(int id, string Nome, string Nif, DateTime DataNascimento, int Escolaridade)
        {
            try
            {
                serviceDB.UpdateCandidatos(id, Nome, Nif, DataNascimento, Escolaridade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateEntrevistas(int Id, DateTime HoraEntrevista)
        {
            try
            {
                serviceDB.UpdateEntrevistas(Id, HoraEntrevista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}