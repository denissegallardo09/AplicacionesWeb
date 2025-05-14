using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3.Models;
using Practica3.Services;

namespace Practica3.Pages.Usuarios
{
    public class EditarModel : PageModel
    {
        private readonly UsuarioService _usuarioService;

        [BindProperty]
        public Usuario Usuario { get; set; }

        public EditarModel(UsuarioService usuarioService)
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var resultado = _usuarioService.Actualizar(Usuario);
            if (resultado == null)
            {
                return NotFound();
            }

            return RedirectToPage("/Index");
        }
    }
} 