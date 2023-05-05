using Heroes.API.Contexts;
using Heroes.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Heroes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HeroContext>(options => options.UseInMemoryDatabase("Heroes"));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<HeroContext>();
                AddTestData(context);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        private static void AddTestData(HeroContext context)
        {
            var heroes = new List<Hero>()
            {
                    new Hero { Id = 12, Name = "Dr. Nice" },
                    new Hero { Id = 13, Name = "Bombasto" },
                    new Hero { Id = 14, Name = "Celeritas" },
                    new Hero { Id = 15, Name = "Magneta" },
                    new Hero { Id = 16, Name = "RubberMan" },
                    new Hero { Id = 17, Name = "Dynama" },
                    new Hero { Id = 18, Name = "Dr. IQ" },
                    new Hero { Id = 19, Name = "Magma" },
                    new Hero { Id = 20, Name = "Tornado" }
            };

            foreach (var hero in heroes)
            {
                context.Heroes.Add(hero);
            }

            context.SaveChanges();
        }
    }
}