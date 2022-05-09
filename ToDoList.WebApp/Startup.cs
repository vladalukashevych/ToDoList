using AutoMapper;

namespace ToDoList.WebApp
{
    public class Startup
    { 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
        }
    }
}
