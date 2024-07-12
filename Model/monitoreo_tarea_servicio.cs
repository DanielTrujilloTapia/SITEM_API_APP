namespace SITEM_API_APP.Model
{
    public class monitoreo_tarea_servicio
    {
        public int Id_monitoreo_servicio { get; set; }
        public int Idtareaservicio { get; set; }
        public DateTime Fecha_inicio_servicio { get; set; }
        public DateTime Fecha_finalizacion_servicio { get; set; }
    }
}
