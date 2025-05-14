using Practica3.Models;

namespace Practica3.Services
{
    public class UsuarioService
    {
        private static List<Usuario> _usuarios = new List<Usuario>();
        private static int _nextId = 1;

        public List<Usuario> ObtenerTodos()
        {
            return _usuarios;
        }

        public Usuario ObtenerPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario Crear(Usuario usuario)
        {
            usuario.Id = _nextId++;
            usuario.FechaRegistro = DateTime.Now;
            _usuarios.Add(usuario);
            return usuario;
        }

        public Usuario Actualizar(Usuario usuario)
        {
            var usuarioExistente = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Edad = usuario.Edad;
                usuarioExistente.Activo = usuario.Activo;
            }
            return usuarioExistente;
        }

        public bool Eliminar(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                return _usuarios.Remove(usuario);
            }
            return false;
        }
    }
} 