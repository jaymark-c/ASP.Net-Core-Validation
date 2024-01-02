using Microsoft.AspNetCore.Mvc;
using ModelBinding_Validation_ECommerceApp.Models;

namespace ModelBinding_Validation_ECommerceApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                string error = string.Join("", ModelState.Values.SelectMany(x => x.Errors).SelectMany(c => c.ErrorMessage)); 
                return BadRequest(error);
            }
            
            Random random = new Random();
            order.OrderNo = random.Next(int.MaxValue);
            return Json(new { orderNumber = order.OrderNo});
            /*return Content($"OrderNo: {order.OrderNo}");*/
        }
    }
}
