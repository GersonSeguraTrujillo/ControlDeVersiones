using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

using Capa_Entidad;
using Capa_Negocio;

namespace CapaMedico.Controllers
{
    [Authorize]
    public class FarmaciaController : Controller
    {
        // GET: Farmacia
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Medicamentos()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarMedicamento()
        {
            List<Medicamento> oLista = new List<Medicamento>();

            oLista = new CN_Medicamento().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarDetalleCita(int IdCita)
        {
            List<DetalleCita> olista = new List<DetalleCita>();
            olista = new CN_GastosMedicos().ListarDetalleCita(IdCita);
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult VerTotalCita(int IdCita)
        {
            TotalCita objeto = new CN_GastosMedicos().VerTotalCita(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult VerInfoCita(int IdCita)
        {
            InformacionCita objeto = new CN_GastosMedicos().VerInfoCita(IdCita);
            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarMedicamento(Medicamento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdDescripcionCita == 0)
            {

                resultado = new CN_Medicamento().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Medicamento().Editar(objeto, out mensaje);

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult EliminarMedicamenton(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Medicamento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        public JsonResult enviarCorreo(string correo ,string total)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta =  CN_EnviarCorreo.Enviar(correo,total, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


    }
}