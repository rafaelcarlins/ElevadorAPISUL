using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevadorAPISUL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevadorController : ControllerBase
    {
        IElevadorService _elevadorService;
        public ElevadorController(IElevadorService elevadorService)
        {
            _elevadorService = elevadorService;
        }

        [Route("andarMenosUtilizado")]
        [HttpGet]
        public ActionResult<List<int>> GetAndarMenosUtilizado()
        {
            List<int> ListaRetorno = new List<int>();
            return ListaRetorno = _elevadorService.andarMenosUtilizado();

        }

        [Route("elevadorMaisFrequentado")]
        [HttpGet]
        public ActionResult<List<char>> GetElevadorMaisFrequentado()
        {
            List<char> ListaRetorno = new List<char>();
            return ListaRetorno = _elevadorService.elevadorMaisFrequentado();

        }

        [Route("periodoMaiorFluxoElevadorMaisFrequentado")]
        [HttpGet]
        public ActionResult<string> GetPeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            char elevadorMaisFrequentado = _elevadorService.elevadorMaisFrequentado().First();

            List<char> ListaRetorno = new List<char>();
            ListaRetorno = _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

            return "Elevador: " + elevadorMaisFrequentado + " no período: " + ListaRetorno.FirstOrDefault();
        }

        [Route("elevadorMenosFrequentado")]
        [HttpGet]
        public ActionResult<string> GetElevadorMenosFrequentado()
        {
            List<char> ListaRetorno = new List<char>();
            ListaRetorno = _elevadorService.elevadorMenosFrequentado();

            return "";
        }

        [Route("periodoMaiorUtilizacaoConjuntoElevadores")]
        [HttpGet]
        public ActionResult <List<char>> GetPeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            List<char> ListaRetorno = new List<char>();
            ListaRetorno = _elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();

            return ListaRetorno;
        }

        [Route("periodoMenorFluxoElevadorMenosFrequentado")]
        [HttpGet]
        public ActionResult<string> GetPeriodoMenorFluxoElevadorMenosFrequentado()
        {
            char ElevadorMenosFrequentado = _elevadorService.elevadorMenosFrequentado().First();
            List<char> ListaRetorno = new List<char>();
            ListaRetorno = _elevadorService.periodoMenorFluxoElevadorMenosFrequentado();

            
            return "Elevador menos frequentado é: " + ElevadorMenosFrequentado + " período: " + ListaRetorno.FirstOrDefault();
        }

        [Route("percentualDeUsoElevadorA")]
        [HttpGet]
        public ActionResult<float> GetpercentualDeUsoElevadorA()
        {

            float Retorno = new float();
            Retorno = _elevadorService.percentualDeUsoElevadorA();

            return Retorno;
        }

        [Route("percentualDeUsoElevadorB")]
        [HttpGet]
        public ActionResult<float> GetpercentualDeUsoElevadorB()
        {

            float Retorno = new float();
            Retorno = _elevadorService.percentualDeUsoElevadorB();

            return Retorno;
        }

        [Route("percentualDeUsoElevadorC")]
        [HttpGet]
        public ActionResult<float> GetpercentualDeUsoElevadorC()
        {

            float Retorno = new float();
            Retorno = _elevadorService.percentualDeUsoElevadorC();

            return Retorno;
        }

        [Route("percentualDeUsoElevadorD")]
        [HttpGet]
        public ActionResult<float> GetpercentualDeUsoElevadorD()
        {

            float Retorno = new float();
            Retorno = _elevadorService.percentualDeUsoElevadorD();

            return Retorno;
        }

        [Route("percentualDeUsoElevadorE")]
        [HttpGet]
        public ActionResult<float> GetpercentualDeUsoElevadorE()
        {

            float Retorno = new float();
            Retorno = _elevadorService.percentualDeUsoElevadorE();

            return Retorno;
        }
    }
}
