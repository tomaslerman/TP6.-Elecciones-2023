using Microsoft.AspNetCore.Mvc;
using TP6_Elecciones.Models;

namespace TP6_Elecciones.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.ListadoPartidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido)
    {
         ViewBag.datosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.listaCandidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
    }
     public IActionResult VerDetalleCandidato(int idCandidato)
     {
        ViewBag.detalleCand = BD.VerInfoCandidato(idCandidato);
        return View("VerDetalleCandidato");
     }
     public IActionResult AgregarCandidato(int idPartido)
     {
        ViewBag.idPartido = idPartido;
        return View();
     }
     [HttpPost] public IActionResult GuardarCandidato(Candidato can)
     {
        BD.AgregarCandidato(can);
        int idPartido = can.IdPartido;
         ViewBag.datosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.listaCandidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
     }
     public IActionResult EliminarCandidato(int idCandidato, int idPartido)
     {
        BD.EliminarCandidato(idCandidato);
        ViewBag.datosPartido = BD.VerInfoPartido(idPartido);
        ViewBag.listaCandidatos = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");  
     }
     public IActionResult Elecciones()
     {
        return View();
     }
     public IActionResult Creditos()
     {
        return View();
     }
}
