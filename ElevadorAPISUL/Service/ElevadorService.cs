using ElevadorAPISUL.Model;
using Newtonsoft.Json;
using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElevadorAPISUL.Service
{
    public class ElevadorService : IElevadorService
    {
        List<Administracao> ListaElevadores = new List<Administracao>();

        public List<int> andarMenosUtilizado()
        {
            List<int> ListAndar = new List<int>();

            ListaElevadores = LerArquivo();
            
            ListaElevadores.ForEach(e => ListAndar.Add(e.Andar));

            var RetListaAndarMenosUtilizado = (from a in ListAndar
                                          group a by a into grupo
                                          orderby grupo.Count() ascending
                                          select grupo.Key).ToList();

            return RetListaAndarMenosUtilizado.ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {

            List<char> Elevadores = new List<char>();
            ListaElevadores = LerArquivo();

            ListaElevadores.ForEach(e => Elevadores.Add(e.Elevador));
            

            var RetElevadoresMaisFrequentados = (from e in Elevadores
                                              group e by e into grupo
                                              orderby grupo.Count() descending
                                              select grupo.Key).ToList();

            return RetElevadoresMaisFrequentados;
        }

        public List<char> elevadorMenosFrequentado()
        {
            List<char> elevadores = new List<char>();
            ListaElevadores = LerArquivo();
            ListaElevadores.ForEach(e => elevadores.Add(e.Elevador));

            var RetElevadoresMenosFrequentados = (from e in elevadores
                                               group e by e into grupo
                                               orderby grupo.Count() ascending
                                               select grupo.Key).ToList();
            RetElevadoresMenosFrequentados.ForEach(e => Console.WriteLine(e));

            return RetElevadoresMenosFrequentados.ToList();
        }

        public float percentualDeUsoElevadorA()
        {
            char elevador = 'A';
            var RetornoPercentual = calculaPercentualDeUso(elevador);

            return RetornoPercentual;
        }

        public float percentualDeUsoElevadorB()
        {
            char elevador = 'B';
            var RetornoPercentual = calculaPercentualDeUso(elevador);

            return RetornoPercentual;
        }

        public float percentualDeUsoElevadorC()
        {
            char elevador = 'C';
            var RetornoPercentual = calculaPercentualDeUso(elevador);

            return RetornoPercentual;
        }

        public float percentualDeUsoElevadorD()
        {
            char elevador = 'D';
            var RetornoPercentual = calculaPercentualDeUso(elevador);

            return RetornoPercentual;
        }

        public float percentualDeUsoElevadorE()
        {
            char elevador = 'E';
            var RetornoPercentual = calculaPercentualDeUso(elevador);

            return RetornoPercentual;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            ListaElevadores = LerArquivo();
            char ElevadorMaisFrequentado = elevadorMaisFrequentado().First();

            var RetPeriodos = (from e in this.ListaElevadores
                            where e.Elevador == ElevadorMaisFrequentado
                            group e.Turno by e.Turno into grupo
                            orderby grupo.Count() descending
                            select grupo.Key).ToList();
           
            return RetPeriodos;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            ListaElevadores = LerArquivo();
            List<char> RetPeriodos = new List<char>();
            ListaElevadores.ForEach(e => RetPeriodos.Add(e.Turno));

            var periodoMaiorUtilizacao = (from p in RetPeriodos
                                          group p by p into grupo
                                          orderby grupo.Count() descending
                                          select grupo.Key).First();

            RetPeriodos = new List<char>();
            RetPeriodos.Add(periodoMaiorUtilizacao);

            return RetPeriodos;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            ListaElevadores = LerArquivo();
            char ElevadorMenosFrequentado = elevadorMenosFrequentado().First();

            var RetPeriodo = (from e in ListaElevadores
                            where e.Elevador == ElevadorMenosFrequentado
                            group e.Turno by e.Turno into grupo
                            orderby grupo.Count() ascending
                            select grupo.Key).ToList();

            return RetPeriodo;
        }

        public List<Administracao> LerArquivo()
        {
            List<Administracao> RetornoItems = new List<Administracao>();

            using (StreamReader r = new StreamReader(@".\input.json"))
            {
                string json = r.ReadToEnd();
                RetornoItems = JsonConvert.DeserializeObject<List<Administracao>>(json);
            }

            return RetornoItems;

        }

        private float calculaPercentualDeUso(char elevador)
        {
            ListaElevadores = LerArquivo();

            List<int> elevadores = new List<int>();
            ListaElevadores.ForEach(e => elevadores.Add(e.Elevador));

            var RetornoPercentual = ((float)elevadores.Count(i => i == elevador)) / elevadores.Count * 100;

            return RetornoPercentual;
        }
    }
}
