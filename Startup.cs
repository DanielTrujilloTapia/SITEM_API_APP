using Microsoft.OpenApi.Models;
using SITEM_API_APP.Data;
using SITEM_API_APP.Repositories;

namespace SITEM_API_APP
{
    public static class Startup
    {
        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MysqlConnection"));
            builder.Services.AddSingleton(mySQLConfiguration);

            builder.Services.AddScoped<IUsuarioRepository, Usu_UsuarioRepository>();
            builder.Services.AddScoped<ITipoUsuarioRepository, Usu_Tipo_UsuarioRepository>();
            builder.Services.AddScoped<IEstadoUsuarioRepository, Usu_Estado_UsuarioRepository>();
            builder.Services.AddScoped<IPuestoUsuarioRepository, Usu_Puesto_UsuarioRepository>();
            builder.Services.AddScoped<IDatosPersonalesRepository, Usu_Datos_PersonalesRepository>();

            builder.Services.AddScoped<IServiciosRepository, Cat_ServiciosRepository>();
            builder.Services.AddScoped<IPlantasRepository, Cat_PlantasRepository>();
            builder.Services.AddScoped<IEstatusRepository, Tareas_EstatusRepository>();
            builder.Services.AddScoped<IPrioridadRepository, Tareas_PrioridadRepository>();

            builder.Services.AddScoped<ITareaServicioRepository, Tarea_ServicioRepository>();
            builder.Services.AddScoped<ITareaFallaRepository, Tarea_FallaRepository>();

            builder.Services.AddScoped<IMonitoreoTareaServicioRepository, Monitoreo_Tarea_ServicioRepository>();
            builder.Services.AddScoped<IMonitoreo_Tarea_FallaRepository, Monitoreo_Tarea_FallaRepository>();

            builder.Services.AddScoped<ICatImgTareasRepository, Cat_Img_TareaRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("NuevaPolitica", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SITEM API", Version = "v1" });
            });
        }

        private static void Configure(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SITEM API V1");
            });

            app.UseHttpsRedirection();

            app.UseCors("NuevaPolitica");

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
