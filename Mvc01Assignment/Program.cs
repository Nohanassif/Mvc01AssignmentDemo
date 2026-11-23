using Mvc01Assignment.MiddleWare;

namespace Mvc01Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            //Service registiration
            //Register mvc services [Controllers , views]
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Register services for API Controller [API]
            //builder.Services.AddControllers();

            //Register services for Full MVC Framework [Controllers , Views , Razor pages]
            //builder.Services.AddMvc();


            var app = builder.Build();// Builds the application and creates the request pipeline

            // Middleware pipeline
            // Configure the HTTP request pipeline.
            //1] Exception handling middleware

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.
                //HSTS --> HTTP STRICT TRANSPORT SECURITY
                app.UseHsts();
            }
            //3] Redirect any incoming http request to https
            app.UseHttpsRedirection();

            //4] Serve public assets / files [wwwroot]
            //app.UseStaticFiles();

            //5] Match the incoming url with the available endpoints/actions

            app.UseRouting();

            //6] Cross origin resource sharing
            //app.UseCors();

            //7] Identifies who the current user is [login] [JWT , COOKIES]
            //app.UseAuthentication();

            //8] Enable the app to read and write session data
            //app.UseSession();

            //// ==========================================
            //// Inline middleware [Custom middleware]

            //app.Use(async (context, next) =>
            //{
            //    // Runs on the way down as the incoming HTTP request enters this middleware
            //    //Before next [Request]
            //    Console.WriteLine($"Hello");

            //    // Passes control to the next middleware in the pipeline
            //    //next
            //    await next(context);

            //    // Runs on the way back up as the HTTP response unwinds through the pipeline
            //    //After next [Response]
            //    Console.WriteLine($"Bye");
            //});


            //9] Authenticated user is allowed to access resource
            app.UseAuthorization();

            // Registers RequestTimingMiddleware into the pipeline so it runs for incoming requests
            app.UseMiddleware<RequestTimingMiddleWare>();

            app.MapStaticAssets();

            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id:int?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
