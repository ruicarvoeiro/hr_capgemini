using HR_DAL;
using HR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDAL
{
    class Program
    {
        private static ListaCandidatoDB a;

        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("Escreve o nome");
                //string nome = Console.ReadLine();
                ServiceGestaoDB servico = new ServiceGestaoDB();
                //servico.CriarCandidatos("Luis", 123236789, new DateTime(2018, 09, 19), 2);
                //servico.DeleteCandidatos(1003);

                //servico.UpdateCandidatos(1002, "Rui Carvoeiro", 123456789, new DateTime(2000, 01, 01), 1);
                //a = servico.GetCandidatos("Rui Carvoeiro", 123456789);
                //TesteGetCandidatos(a);
                Console.ReadLine();
            }
            catch(Exception ex)
            {

            }

            
        }
        private static void TesteGetCandidatos(ListaCandidatoDB lista)
        {
            if (!lista.HasError)
            {
                foreach(CandidatoDB item in lista.Lista)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", item.Nome, item.Nif, item.id, item.Escolaridade, item.Descricao);
                }
            }
        }
    }
}
