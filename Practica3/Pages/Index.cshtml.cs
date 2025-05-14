using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica3.Models;
using Practica3.Services;

namespace Practica3.Pages;

public class IndexModel : PageModel
{
    private readonly UsuarioService _usuarioService;

    public List<Usuario> Usuarios { get; set; }

    public IndexModel(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public void OnGet()
    {
        Usuarios = _usuarioService.ObtenerTodos();
    }
}
