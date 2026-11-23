using Microsoft.AspNetCore.Mvc;
using Mvc01Assignment.Models;

namespace Mvc01Assignment.Controllers
{
    public class ProductsController : Controller
    {

        #region Actions
        //Baseurl/Products/Test
        // Simple way to return text, but limited when you want full control over StatusCode or ContentType
        //public string Test()
        //{
        //    return $"Hello ";
        //}

        // ==========================================
        // Controls [Status code, Content type (default text/plain), Content]

        // Helper methods like Content() and NotFound()

        //[HttpGet]
        //public IActionResult Test()
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.ContentType = "text/html";
        //    //result.Content = $"Hello from test </br> Bye";
        //    //result.StatusCode = StatusCodes.Status200OK;
        //    //return result;

        //    if (true)
        //        return Content(content: $"Hello from test </br> Bye", contentType: "text/html");
        //    else
        //        return NotFound();
        //}

        // ==========================================
        // 3. Index action (Default / master action for the controller)
        // ==========================================
        // BaseUrl/Products or BaseUrl/Products/Index

        // Commented out during experimentation; when active, it returns a View
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // ==========================================
        // 4. Returning JSON data 
        // ==========================================

        //BaseUrl/Products/GetProducts
        // Instead of returning a View or raw text, Json(products) serializes the product list as JSON
        //BaseUrl/Products/GetProducts

        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    var products = new List<Product>()
        //    {
        //    new Product() { Id = 1, Name = "Mobile" },
        //    new Product() { Id = 2, Name = "Tablet" },
        //};

        //    return Json(products);
        //}


        // ==========================================
        // 5. Using [NonAction] to prevent routing to a method
        // ==========================================
        // Even though the method is public and returns IActionResult, [NonAction] hides it from routing
        // So it cannot be invoked directly via URL 

        //[NonAction] 
        //public IActionResult Test()
        //{ 
        //    return View();
        //} 

        // ==========================================
        //Returning different ActionResults based on input conditions
        // ==========================================

        // Uses IActionResult because different branches return different result types

        //BaseUrl/Products/GetProductById/10

        //public IActionResult GetProductById(int id)
        //{
        //    // Invalid negative ID -> returns 400 Bad Request
        //    if (id < 0)
        //        return BadRequest();

        //    // ID == 0 -> redirects to GetProducts action (302 redirect)

        //    else if (id == 0)
        //        //return RedirectToAction("GetProducts");
        //        return RedirectToAction(nameof(GetProducts));

        //    // ID < 10 (and >= 1) -> returns 404 Not Found
        //    else if (id < 10)
        //        return NotFound();

        //    // ID >= 10 -> returns product data serialized as JSON (200 OK)
        //    else
        //        return Json(new Product() { Id = id, Name = "Laptop" });
        //}


        // ==========================================
        //Redirect to an external/full URL 
        // ==========================================

        // Unlike RedirectToAction (which targets a controller action), Redirect(url) sends a 302 to any URL

        //BaseUrl/Products/RedirectAction
        //[HttpGet]
        //public IActionResult RedirectAction()
        //{
        //    return Redirect("https://docs.google.com/presentation/d/1L5uja6Tj_a38uHlXC-RmNYX1bYfsSqYT/edit?slide=id.p1#slide=id.p1");
        //}


        // ==========================================
        // Returning a file from wwwroot/files using FileAction
        // ==========================================

        // Reads bytes from wwwroot/files/PdfSample.pdf and returns a FileResult with MIME type "application/pdf"

        //BaseUrl/Products/FileAction
        //[HttpGet]
        //public IActionResult FileAction()
        //{
        //    byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/files/Mapping.pdf");
        //    return File(fileBytes, "application/pdf");
        //}
        #endregion

        #region Routing
        // ==========================================
        // URL Structure & Segment Types in Routing
        // ==========================================
        // General URL format:
        //BaseUrl/Controller/Action/Segment

        // Three types of route segments:
        // 1. Static segment (e.g., "Ten") =>  BaseUrl/Products/Test/Ten
        // 2. Variable segment: dynamic placeholder (e.g., "{Num}") => BaseUrl/Products/Test/{Num}
        // 3. Mixed segment: combines a static suffix with a variable (e.g., "X{Num}") => BaseUrl/Products/Test/X{Num}

        //Segment --> Static segement  , variable segement , mixed segement

        // Ways to pass parameters in a URL:
        // - As a route segment (part of the path)
        // - As a query string parameter (after '?' as key=value)

        //Param --> segement , query param
        //BaseUrl/Products/Test?num=10

        // ==========================================
        // Custom GET attribute route (No parameters)
        // ==========================================
        //BaseUrl/Products/TestRouting
        //[HttpGet("Products/Test01")]
        //public IActionResult TestRouting()
        //{
        //    return Json($"Hello from test routing");
        //}

        // ==========================================
        // Mixed segment with route constraint (:int)
        // ==========================================
        //[HttpGet("TestingRoute/Test{id:int}")]

        //public IActionResult TestRouting(int id)
        //{
        //    return Json($"Hello with id : {id}");
        //}

        // ==========================================
        // Conventional routing with multiple parameters
        //// ==========================================
        //public IActionResult TestRouting(int id, string name)
        //{
        //    return Json($"Hello from TestRouting : id -");
        //}

        // ==========================================
        // 1. Custom GET route returning JSON text
        // ==========================================
        //BaseUrl/json

        //[HttpGet("json")]

        //public IActionResult JsonAction()
        //{
        //    return Json("Hello from json action");
        //}

        // ==========================================
        // 2. GET route with an integer parameter (:int)
        // ==========================================

        //BaseUrl/ProductCode/10
        //[HttpGet("ProductCode/{code:int}")]
        //        public IActionResult GetProductByCode(int code)
        //        {
        //            return Json(new Product() { Id = code, Name = "Mobile" });
        //        }

        #endregion

        #region Model Binding

        // Action parameters can be simple data, complex data (user-defined types), or collections

        // ==========================================
        // Binding simple parameters
        // ==========================================

        //[HttpGet]
        ////BaseUrl/Products/GetById
        //public IActionResult GetById(int id, int anotherId)
        //{
        //    // Returns bound simple parameters as JSON
        //    return Json(new { id = id, anotherId = anotherId });
        //}

        // ==========================================
        // Binding simple parameters from query string ([FromQuery] & custom Name)
       
        //[HttpGet]
        ////BaseUrl/Products/GetById
        //public IActionResult GetById([FromQuery]int id ,[FromQuery(Name = "id2")] int anotherId)
        //{
        //    return Json(new {id = id , anotherId = anotherId});
        //}

        // ==========================================
        // Binding complex data object
        // ==========================================
        //Complex data
        //BaseUrl/Products/Search

        //[HttpGet]
        //public IActionResult Search(ProductFilter filter)
        //{
        //    return Content("Search completed");
        //}

        // ==========================================
        //Binding a collection parameter
        // ==========================================
        //Collection
        //BaseUrl/Products/GetByIds
        //[HttpGet]
        //public IActionResult GetByIds(int[] ids)
        //{
        //    // Returns the bound array inside a JSON object
        //    return Json(new
        //    {
        //        ids
        //    });
        //}




        #endregion
    }
}
