namespace SITEM_API_APP.Model
{
    public class tarea_servicio
    {
        public int Id_tarea_servicio { get; set; }
        public string Nom_tarea_servicio { get; set; }
        public int Idcatservicios { get; set; }
        public int Idusuusuario_encargado { get; set; }
        public int Idusuusuario_ayudante { get; set; }
        public int Idusuusuario_admin { get; set; }
        public int Idcatplantas { get; set; }
        public DateTime Fecha_publicacion_servicio { get; set; }
        public DateTime Fecha_entega_servicio { get; set; }
        public int Idtareaestatus_servicio { get; set; }
        public int Idtareasprioridad { get; set; }

    }
}
