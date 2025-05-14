using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3.Models;
using Practica3.Services;

namespace Practica3.Pages.Usuarios
{
    public class EliminarModel : PageModel
    {
        private readonly UsuarioService _usuarioService;

        [BindProperty]
        public Usuario Usuario { get; set; }

        public EliminarModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult OnGet(int id)
        {
            Usuario = _usuarioService.ObtenerPorId(id);
            if (Usuario == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var resultado = _usuarioService.Eliminar(id);
            if (!resultado)
            {
                return NotFound();
            }

            return RedirectToPage("/Index");
        }
    }
} 