using LV.Apresentacao.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace LV.Apresentacao.MVC.Controllers
{
    public class VeiculoController : Controller
    {

        private readonly string servidorAPI = WebConfigurationManager.AppSettings["servidorApi"];
        private readonly string fipeMarcaApi = WebConfigurationManager.AppSettings["fipeMarcaApi"];
        private readonly string fipeModeloApi = WebConfigurationManager.AppSettings["fipeModeloApi"];

        #region GET
        [HttpGet]
        public ActionResult Listar()
        {
            try
            {
                IEnumerable<VeiculoViewModel> veiculoViewModel = ConsomeAPILista("api/veiculo", "GET");
                return View(veiculoViewModel);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Erro ao carregar os registros!";
                IEnumerable<VeiculoViewModel> veiculoViewModel = null;
                return View(veiculoViewModel);
            }
        }

        [HttpGet]
        public ActionResult Inserir()
        {
            VeiculoViewModel veiculoViewModel = new VeiculoViewModel();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(fipeMarcaApi);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    veiculoViewModel.Fabricantes = JsonConvert.DeserializeObject<List<Fabricante>>(streamReader.ReadToEnd());
                }
            }
            catch (Exception)
            {
                veiculoViewModel.Fabricantes = null;
            }
            
            return View(veiculoViewModel);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            try
            {
                VeiculoViewModel veiculoViewModel = ConsomeAPI("api/veiculo/", id.ToString(), "GET");
                return View(veiculoViewModel);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Erro ao carregar os registros!";
                IEnumerable<VeiculoViewModel> veiculoViewModel = null;
                return View(veiculoViewModel);
            }
        }

        [HttpGet]
        public ActionResult Pesquisar()
        {
            VeiculoViewModel veiculoViewModel = new VeiculoViewModel();
            veiculoViewModel.DataInicio = DateTime.Now;
            veiculoViewModel.DataFim = veiculoViewModel.DataInicio;
            veiculoViewModel.DataFim.AddDays(1);


            return View(veiculoViewModel);
        }
        #endregion


        #region POST
        [HttpPost]
        public ActionResult Inserir(VeiculoViewModel veiculoViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(veiculoViewModel.Fabricante) && !string.IsNullOrEmpty(veiculoViewModel.Modelo) &&
                veiculoViewModel.AnoModelo > 0 && veiculoViewModel.Categoria > 0 && veiculoViewModel.Valor > 0 &&
                veiculoViewModel.ValorFds > 0 && veiculoViewModel.ValorFidelidade > 0 && veiculoViewModel.ValorFidelidadeFds > 0)
                {
                    ConsomeAPI("api/veiculo/", "POST", veiculoViewModel);
                    return RedirectToAction("Listar");
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Erro ao inserir o registro!";
            }
            return View(veiculoViewModel);
        }

        [HttpPost]
        public ActionResult Excluir(VeiculoViewModel veiculoViewModel)
        {
            try
            {
                ConsomeAPI("api/veiculo/", veiculoViewModel.Id.ToString(), "DELETE");
                return RedirectToAction("Listar");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Erro ao excluir o registro!";
                return View("Excluir", veiculoViewModel);
            }
        }

        [HttpPost]
        public ActionResult Pesquisar(VeiculoViewModel veiculoViewModel)
        {
            DateTime dataInicial, dataFinal;
            try
            {
                if (veiculoViewModel.DataInicio == null || veiculoViewModel.DataFim == null)
                {
                    ViewBag.ErrorMessage = "Informe o período completo";
                }
                else if (veiculoViewModel.DataInicio == veiculoViewModel.DataFim)
                {
                    ViewBag.ErrorMessage = "Data inicial e data final não pode ser as mesmas.";
                }
                else
                {
                    dataInicial = veiculoViewModel.DataInicio;
                    dataFinal = veiculoViewModel.DataFim;
                    veiculoViewModel = ConsomeAPI("api/veiculo/PostPesquisa", "", "POST", veiculoViewModel);
                    veiculoViewModel.DataInicio = dataInicial;
                    veiculoViewModel.DataFim = dataFinal;
                }
                return View(veiculoViewModel);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;// "Erro ao pesquisar o registro!";
                return View(veiculoViewModel);
            }

        }
        #endregion


        #region METODOS
        public void ConsomeAPI(string metodoPath, string tipoMetodo, VeiculoViewModel veiculo)
        {
            VeiculoViewModel veiculoViewModel;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(servidorAPI + metodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = tipoMetodo;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(veiculo));
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    veiculoViewModel = JsonConvert.DeserializeObject<VeiculoViewModel>(streamReader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public VeiculoViewModel ConsomeAPI(string metodoPath, string parametros, string tipoMetodo, VeiculoViewModel veiculo = null)
        {
            VeiculoViewModel veiculoViewModel;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(servidorAPI + metodoPath + parametros);

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = tipoMetodo;

                if (tipoMetodo.Equals("POST"))
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(veiculo));
                    }
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    veiculoViewModel = JsonConvert.DeserializeObject<VeiculoViewModel>(streamReader.ReadToEnd());
                }
                return veiculoViewModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<VeiculoViewModel> ConsomeAPILista(string metodoPath, string tipoMetodo)
        {
            List<VeiculoViewModel> veiculoViewModel;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(servidorAPI + metodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = tipoMetodo;

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    veiculoViewModel = JsonConvert.DeserializeObject<List<VeiculoViewModel>>(streamReader.ReadToEnd());
                }
                return veiculoViewModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}