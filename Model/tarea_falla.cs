namespace SITEM_API_APP.Model
{
    public class tarea_falla
    {
        public int Id_tarea_falla { get; set; }
        public string Nom_tarea { get; set; }
        public string Descripcion_tarea { get; set; }
        public DateTime Fecha_publicacion_falla { get; set; }
        public DateTime Fecha_entrega_falla { get; set; }
        public int Idtareaestatus_falla { get; set; }
        public int Idusuario_admin { get; set; }
        public int Idusuario_encargado { get; set; }
        public int Idusuario_ayudante { get; set; }
        public int Idcatplanta { get; set; }
        public int Idtareaprioridad { get; set; }

    }
}
