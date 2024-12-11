using Books.API.DbContexts;
using Books.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // register the DbContext on the container 
            builder.Services.AddDbContext<BooksContext>(options =>
                options.UseSqlite(
                    builder.Configuration["ConnectionStrings:BooksDBConnectionString"]));

            builder.Services.AddScoped<IBooksRepository, BooksRepository>();

            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
