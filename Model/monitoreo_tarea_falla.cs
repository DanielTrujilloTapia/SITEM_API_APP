namespace SITEM_API_APP.Model
{
    public class monitoreo_tarea_falla
    {
        public int Id_monitoreo_falla { get; set; }
        public int Idtareafalla { get; set; }
        public DateTime Fecha_inicio_falla { get; set; }
        public DateTime Fecha_finalizacion_falla { get; set; }
    }
}
