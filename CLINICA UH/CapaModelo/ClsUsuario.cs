using System;

namespace CLINICA_UH.CapaModelo
{
    public class ClsUsuario
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Medico { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public string NumeroConsulta { get; set; }
        public DateTime FechaAtencion { get; set; }
        public DateTime HoraAtencion { get; set; }
        public string Consultorio { get; set; }
        public string Tipo { get; set; } 
    }
}
