namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        // configure cors policy
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        // confiugre IIS Integration
        public static void ConfigureIISIntegeration(this IServiceCollection services)
        {
            //We do not initialize any of the properties inside
            //the options because we are fine with the default values for now
            services.Configure<IISOptions>(options =>
            {

            });
        }
    }
}
