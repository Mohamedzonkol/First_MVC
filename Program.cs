using First_MVC.Models;
using First_MVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Security.Principal;

internal class Program
{
    private static void Main(string[] args)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var conectionstring = config.GetSection("constr").Value;

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession(x =>x.IdleTimeout=TimeSpan.FromMinutes(30));
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conectionstring));
        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        builder.Services.AddScoped<IStudentServies, StudentServies>();
        builder.Services.AddScoped<IDepartmentServies,DepartmentServies>();
        
           
        var app = builder.Build();
        #region Inline Middleaware => anynoms Function
      
        //app.Use(async(context, next) =>
        //{
        //    //if you add to response 
        //   await context.Response.WriteAsync("1)MiddleWare (1)\n");
        //    //if you call next Middle
        //   await next.Invoke();
        //    await context.Response.WriteAsync("2)MiddleWare (1_2)\n");

        //});
        //app.Use(async (context, next) =>
        //{
        //    //if you add to response 
        //    await context.Response.WriteAsync("3)MiddleWare (2)\n");
        //    //if you call next Middle
        //    await next.Invoke();
        //    await context.Response.WriteAsync("4)MiddleWare (2_2)\n");

        //});
        //app.Run(async (context) =>
        //{
        //    await context.Response.WriteAsync("5)Terminte\n"); 
        //});
        ////مش هيوصل لدا لان مفيش next
        //app.Use(async (context, next) =>
        //{
        //    //if you add to response 
        //    await context.Response.WriteAsync("MiddleWare (4)");
        //    //if you call next Middle
        //    await next.Invoke();
        //});

        #endregion
        #region Built Middleware Component
        // Configure the HTTP request pipeline. - Set of MiddleWare Component
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();  //Front End (Html-Css_JS)

        app.UseRouting();      // Check Vaild URl  
        app.UseSession();      //Middleware for read from session.
     
        
        app.UseAuthentication(); //check cookie
        app.UseAuthorization(); //Check role
                                //هل انت ليك سماحيه تشوف
                                //url دا ولا 

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
        #endregion
    }
}