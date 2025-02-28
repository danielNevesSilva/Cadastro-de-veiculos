using Cadastro_de_veiculos.Data;
using Cadastro_de_veiculos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cadastro_de_veiculos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var provider = builder.Services.BuildServiceProvider();
            var configurantio = provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<BancoContext>(item => item.UseSqlServer(configurantio.GetConnectionString("Database")));
            builder.Services.AddScoped<IveiculoRepository, veiculoRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=CadastrodeVeiculos}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
