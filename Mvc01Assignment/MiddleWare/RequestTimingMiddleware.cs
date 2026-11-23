using System.Diagnostics;

namespace Mvc01Assignment.MiddleWare
{
    // Rules written in the file:
    // 1] RequestDelegate next [Inject ctor]
    // 2] Method name InvokeAsync , Invoke [HttpContext context]
    // 3] Call await next(context)
    // 4] Register with app.UseMiddleware<RequestTimingMiddleware>()

    public class RequestTimingMiddleWare
    {
        // Holds a reference to the next middleware delegate in the pipeline[cite: 1, 14]
        private readonly RequestDelegate _next;

        // Injects RequestDelegate next through the constructor
        public RequestTimingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        // Entry point invoked for each request (in the screenshot, typing 'co...' for 'context')[cite: 1, 14]
        public async Task InvokeAsync(HttpContext context)
        {
            // Starts the stopwatch as the request enters the middleware
            var watch = Stopwatch.StartNew(); 

            // Passes control to the remaining middleware and action execution
            await _next(context);

            // Stops the stopwatch after the response comes back up through the pipeline
            //response
            watch.Stop();

            // Logs the requested URL path and total elapsed time in milliseconds to the console
            Console.WriteLine($"{context.Request.Path} ==> {watch.ElapsedMilliseconds} ms");
}
    }
    }

