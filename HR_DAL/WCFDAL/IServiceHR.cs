using HR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFDAL.Contract;

namespace WCFDAL
{
    [ServiceContract]
    public interface IServiceHR
    {
        [OperationContract]
        string CriarCandidatos(string Nome, string Nif, DateTime DataNascimento, int Escolaridade);
        [OperationContract]
        ListaCandidatoSV GetCandidatos(string Nome, string Nif);
        [OperationContract]
        void UpdateCandidatos(int id, string Nome, string Nif, DateTime DataNascimento, int Escolaridade);
        [OperationContract]
        void DeleteCandidatos(int id);
        [OperationContract]
        string CriarEntrevistas(int Id, DateTime HoraEntrevista);
        [OperationContract]
        ListaEntrevistasSV GetEntrevistas(int Id);
        [OperationContract]
        void UpdateEntrevistas(int Id, DateTime HoraEntrevista);
        [OperationContract]
        void DeleteEntrevistas(int id);
        [OperationContract]
        void AddAvaliacaoEntrevista(int IdEntrevista, int IdEscalaAval, string Desc);
        [OperationContract]
        ListaEscalaAvaliacaoSV GetEscalaAvaliacao();
        [OperationContract]
        ListaTipoEscolaridadeSV GetTipoescolaridade();

    }
}
