using DynamicFormDemo.Business.Abstract;
using DynamicFormDemo.Business.Utilities.Validation.FluentValidation;
using DynamicFormDemo.Business.Utilities.Validation.FluentValidation.ValidationTool;
using DynamicFormDemo.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace DynamicFormDemo.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        private readonly IFieldService _fieldService;
        public FormController(IFormService formService, IFieldService fieldService)
        {
            _formService = formService;
            _fieldService = fieldService;
        }

        public IActionResult Index()
        {
            var result = _formService.FindWithUser();
            return View(result);
        }

        public IActionResult Forms(int id)
        {
            var result = _fieldService.FindByFormId(id);
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Form form)
        {

            FormValidator validator = new();
            var results = ValidationTool.Validate(validator, form);
            if (results == null)
            {

                await _formService.CreateAsync(form);
                return RedirectToAction("Index", "Form");

            }

            foreach (var item in results)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();

        }


        public PartialViewResult PartialGetForms()
        {
            var result = _formService.AsQueryable();
            return PartialView(result);
        }
    }
}
