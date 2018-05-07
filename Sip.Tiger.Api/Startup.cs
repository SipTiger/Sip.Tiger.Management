using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PartialResponse.Extensions.DependencyInjection;
using Sip.Tiger.Api.Filters;
using Sip.Tiger.Api.MediatR;
using Sip.Tiger.Api.Swagger;
using Sip.Tiger.Management.Business;
using Sip.Tiger.Management.Business.Behaviours;
using Sip.Tiger.Management.Business.RiskProfilling;
using Swashbuckle.AspNetCore.Swagger;

namespace Sip.Tiger.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(typeof(ApiClientValidationExceptionAttribute));
                    options.Filters.Add(typeof(FluentValidationExceptionAttribute));
                    options.Filters.Add(typeof(ValidateModelAttribute));
                    options.OutputFormatters.RemoveType<JsonOutputFormatter>();
                })
                .AddPartialJsonFormatters();
            services.AddMediatR(typeof(AssemblyMarker));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IValidatorFactory, FluentValidatorFactory>();

            services.AddScoped<IValidator<RiskProfillingCommand>, RiskProfillingValidator>();

            services.AddSwaggerGen(sw =>
            {
                sw.DescribeAllEnumsAsStrings();
                sw.DescribeStringEnumsInCamelCase();
                sw.DescribeAllParametersInCamelCase();
                sw.MapType<Guid>(() => new Schema
                {
                    Type = "string",
                    Format = "uuid",
                    Example = Guid.NewGuid().ToString(),
                    Pattern = "([0-9][a-f][A-F]){8}-(([0-9][a-f][A-F]){4}-){3}([0-9][a-f][A-F]){12}"
                });

                sw.SwaggerDoc("v1", new Info { Title = "SIP tiger API", Version = "v1" });
            });
            services.AddScoped<IMediator, SynchronousMediator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1");
            });
        }
    }
}
