using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContextLibrary;
using Ejercicio_1EntityFramework.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebPersonasMascotas.Data;

namespace Empty
{
  
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IMascotaRepository, MascotaRepository>();
            services.AddTransient<IPersona_MascotaRepository, Persona_MascotaRepository>();

            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),  b => b.MigrationsAssembly("WebPersonasMascotas")));


            //services.AddSingleton<IPersonaRepository, MockPersona>();
            //services.AddSingleton<IMascotaRepository, MockMascota>();
            //services.AddSingleton<IPersona_MascotaRepository, MockPersona_Mascota>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
