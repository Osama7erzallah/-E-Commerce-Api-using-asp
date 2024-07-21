
using Ecommerce.Core.IRepo;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.Repo;
using Ecommarce.API.Mapping_Profile;
using Microsoft.AspNetCore.Mvc;
namespace Ecommarce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options => {
                options.CacheProfiles.Add("cache100", new CacheProfile()
                {
                    Duration = 100,
                    Location = ResponseCacheLocation.Any
                });
                options.CacheProfiles.Add("cache60", new CacheProfile()
                {
                    Duration = 60,
                    Location = ResponseCacheLocation.Any
                });
            }

            );

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IProductsRepo), typeof(ProductsRepo));
            builder.Services.AddScoped(typeof(IOrdersRepo), typeof(OrdersRepo));

            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            builder.Services.AddAutoMapper(typeof(MappingProfile));




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
    }
}
