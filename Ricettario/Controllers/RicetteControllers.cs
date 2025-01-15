using Microsoft.AspNetCore.Mvc;
using Entities;
using DAOs;

namespace Ricettario.Controllers
{
    public class RicettaController : Controller
    {
        public IActionResult Elenco()
        {
            var ricette = DAORicette.GetInstance().GetRecords();
            return View(ricette);
        }

        public IActionResult Dettagli(int id)
        {
            var ricetta = (Ricetta?)DAORicette.GetInstance().FindRecord(id);
            if (ricetta == null)
            {
                return NotFound();
            }
            return View("Dettagli", ricetta);
        }

        public IActionResult Elimina(int id)
        {
            var dao = DAORicette.GetInstance();
            dao.DeleteRecord(id);
            return RedirectToAction("Elenco");
        }

        public IActionResult Aggiungi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Aggiungi(Ricetta ricetta)
        {
            if (ModelState.IsValid)
            {
                var dao = DAORicette.GetInstance();
                dao.CreateRecord(ricetta);
                return RedirectToAction("Elenco");
            }
            return View(ricetta);
        }

        [HttpPost]
        public IActionResult ModificaCampo(int id, string field, string value)
        {
            try
            {
                var dao = DAORicette.GetInstance();
                var ricetta = (Ricetta)dao.FindRecord(id);
                if (ricetta == null)
                {
                    return NotFound();
                }

                switch (field.ToLower())
                {
                    case "nome":
                        ricetta.Nome = value;
                        break;
                    case "categoria":
                        ricetta.Categoria = value;
                        break;
                    case "tipocucina":
                        ricetta.TipoCucina = value;
                        break;
                    case "tempopreparazione":
                        if (int.TryParse(value, out int tempo))
                        {
                            ricetta.TempoPreparazione = tempo;
                        }
                        break;
                    case "ingredienti":
                        ricetta.Ingredienti = value;
                        break;
                    case "istruzioni":
                        ricetta.Istruzioni = value;
                        break;
                    case "difficolta":
                        ricetta.Difficolta = value;
                        break;
                }

                dao.UpdateRecord(ricetta);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
