using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebApplication58.Entities;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLog.Extensions.Logging;

namespace WebApplication58
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            services.AddScoped<IHodldingsRepository, HodldingsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Holding, Dto.HoldingDto>()
                .ForMember(nameof(Dto.HoldingDto.Amount), (i) => { i.MapFrom(nameof(Entities.Holding.SecurityAmount)); })
                .ForMember(nameof(Dto.HoldingDto.Name), (i) => { i.MapFrom(nameof(Entities.Holding.SecurityName)); })
                .ForMember(nameof(Dto.HoldingDto.Number), (i) => { i.MapFrom(nameof(Entities.Holding.SecurityID)); })
                .ForMember(nameof(Dto.HoldingDto.Quantity), (i) => { i.MapFrom(nameof(Entities.Holding.SecurityQuantity)); })
                .ForMember(nameof(Dto.HoldingDto.Rate), (i) => { i.MapFrom(nameof(Entities.Holding.SecurityRate)); })
                .ForMember(nameof(Dto.HoldingDto.GroupId), (i) => { i.MapFrom(nameof(Entities.Holding.SecurityGroupId)); })
                .ForMember(nameof(Dto.HoldingDto.Date), (i) => { i.MapFrom(nameof(Entities.Holding.HoldingDate)); });
            });



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");
                            logger.LogError(500,
                                exceptionHandlerFeature.Error,
                                exceptionHandlerFeature.Error.Message);
                        }

                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");

                    });
                });
            }

            app.UseMvc();
        }
    }
}
