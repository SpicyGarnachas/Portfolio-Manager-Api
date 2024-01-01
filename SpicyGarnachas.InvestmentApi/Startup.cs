using Microsoft.OpenApi.Models;
using SpicyGarnachas.InvestmentApi.Services;
using SpicyGarnachas.InvestmentApi.Repositories;
using SpicyGarnachas.InvestmentApi.Repositories.Test;
using SpicyGarnachas.InvestmentApi.Repositories.Interfaces;
using SpicyGarnachas.InvestmentApi.Services.Interfaces;

namespace SpicyGarnachas.InvestmentApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                services.AddScoped<IPortfolioService, PortfolioService>();
                services.AddScoped<IPortfolioRepository, TestPortfolioRepository>();
                services.AddScoped<IInvestmentService, InvestmentService>();
                services.AddScoped<IInvestmentRepository, TestInvestmentRepository>();
            }
            else
            {
                services.AddScoped<IPortfolioService, PortfolioService>();
                services.AddScoped<IPortfolioRepository, PortfolioRepository>();
                services.AddScoped<IInvestmentService, InvestmentService>();
                services.AddScoped<IInvestmentRepository, InvestmentRepository>();
            }
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portafolio API", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

