using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TuiTask.Aggregator;
using TuiTask.Common.Repositories;
using TuiTask.Common.Services.Dictionary;
using TuiTask.Common.Services.Price;
using TuiTask.Common.Services.Search;
using TuiTask.Common.Services.Settings;
using TuiTask.OtherProvider.Providers;
using TuiTask.OtherProvider.Repositories;
using TuiTask.StandartProvider.Providers;
using TuiTask.StandartProvider.Repositories;
using Web.Settings;

namespace Web
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
            services.AddControllers();
            services
                .AddMemoryCache()
                .AddSingleton<ITourRepository,TourRepository>()
                .AddSingleton<IOtherTourRepository,OtherTourRepository>()
                .AddTransient<IStandartProvider, StandartProvider>()
                .AddTransient<IOtherProvider, OtherProvider>()
                .AddTransient<ISearchService, SearchAggregator>()
                .AddTransient<IDictService, DictionaryAggregator>()
                .AddTransient<IPriceCalculator, PriceCalculator>()
                .AddTransient<ISettings, Settings.Settings>()
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITourRepository tourRepository, IOtherTourRepository otherTourRepository)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            tourRepository.Populate();
            otherTourRepository.Populate();
        }
    }
}
