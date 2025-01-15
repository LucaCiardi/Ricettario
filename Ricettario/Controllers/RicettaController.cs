using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ricettario.Data;
using Ricettario.Models;

namespace Ricettario.Controllers
{
    public class RicettaController : Controller
    {
        private readonly RicettarioContext _context;

        public RicettaController(RicettarioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Elenco()
        {
            var ricette = await _context.Ricette.OrderBy(r => r.Nome).ToListAsync();
            return View(ricette);
        }

        public IActionResult Aggiungi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Aggiungi(Ricetta ricetta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ricetta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Elenco));
            }
            return View(ricetta);
        }
        public IActionResult Test()
        {
            return Content("Controller is working");
        }

        public async Task<IActionResult> Dettagli(int? id)
        {
            if (id == null)
                return NotFound();

            var ricetta = await _context.Ricette.FindAsync(id);
            if (ricetta == null)
                return NotFound();

            return View(ricetta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificaCampo(int id, string field, string value)
        {
            var ricetta = await _context.Ricette.FindAsync(id);
            if (ricetta == null)
                return Json(new { success = false, message = "Ricetta non trovata" });

            try
            {
                switch (field)
                {
                    case "Nome":
                        ricetta.Nome = value;
                        break;
                    case "Categoria":
                        if (!new[] { "Antipasto", "Primo", "Secondo", "Contorno", "Dessert" }.Contains(value))
                            return Json(new { success = false, message = "Categoria non valida" });
                        ricetta.Categoria = value;
                        break;
                    case "TipoCucina":
                        ricetta.TipoCucina = value;
                        break;
                    case "TempoPreparazione":
                        if (!int.TryParse(value, out int tempo) || tempo < 1 || tempo > 480)
                            return Json(new { success = false, message = "Tempo non valido" });
                        ricetta.TempoPreparazione = tempo;
                        break;
                    case "Difficolta":
                        if (!new[] { "Facile", "Media", "Difficile" }.Contains(value))
                            return Json(new { success = false, message = "Difficoltà non valida" });
                        ricetta.Difficolta = value;
                        break;
                    case "Ingredienti":
                        ricetta.Ingredienti = value;
                        break;
                    case "Istruzioni":
                        ricetta.Istruzioni = value;
                        break;
                    default:
                        return Json(new { success = false, message = "Campo non valido" });
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Elimina(int id)
        {
            var ricetta = await _context.Ricette.FindAsync(id);
            if (ricetta == null)
                return NotFound();

            _context.Ricette.Remove(ricetta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Elenco));
        }
    }

}
