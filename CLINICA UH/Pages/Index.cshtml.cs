using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CLINICA_UH.CapaNegocio;
using CLINICA_UH.CapaModelo;
using System.Collections.Generic;

namespace CLINICA_UH.Pages
{
    public class UsuariosModel : PageModel
    {
        private readonly Usuario_Logica usuarioLogica = new Usuario_Logica();

        public List<ClsUsuario> Usuarios { get; set; }

        public void OnGet()
        {
            Usuarios = usuarioLogica.ObtenerUsuarios();
        }

        public IActionResult OnPostAgregar(string Nombre, string Apellido, string Cedula, string Telefono, string Tipo)
        {
            ClsUsuario nuevoUsuario = new ClsUsuario
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Cedula = Cedula,
                Telefono = Telefono,
                Tipo = Tipo
            };

            usuarioLogica.InsertarUsuario(nuevoUsuario);
            return RedirectToPage();
        }

        public IActionResult OnPostEliminar(int idUsuario)
        {
            usuarioLogica.EliminarUsuario(idUsuario);
            return RedirectToPage();
        }
    }
}
