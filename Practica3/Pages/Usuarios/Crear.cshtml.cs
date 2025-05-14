using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3.Models;
using Practica3.Services;

namespace Practica3.Pages.Usuarios
{
    public class CrearModel : PageModel
    {
        private readonly UsuarioService _usuarioService;

        [BindProperty]
        public Usuario Usuario { get; set; }

        public CrearModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void OnGet()
        {
            Usuario = new Usuario();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _usuarioService.Crear(Usuario);
            return RedirectToPage("/Index");
        }
    }
} 