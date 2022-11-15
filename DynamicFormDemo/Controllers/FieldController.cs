using DynamicFormDemo.Business.Abstract;
using DynamicFormDemo.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFormDemo.Controllers
{
    public class FieldController : Controller
    {
        private readonly IFieldService _fieldService;
        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Field field)
        {
            await _fieldService.CreateAsync(field);
            return RedirectToAction("Index","Field");
        }
    }
}
