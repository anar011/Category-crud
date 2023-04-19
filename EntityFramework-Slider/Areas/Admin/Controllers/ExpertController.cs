using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using EntityFramework_Slider.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Slider.Areas.Admin.Controllers
{
    [Area("Admin")]


    public class ExpertController : Controller
    {

        private readonly IExpertService _expertService;
        private readonly AppDbContext _context;
        public ExpertController(IExpertService expertService,
                                AppDbContext context )
        {
            _expertService = expertService;
            _context = context;
           
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ExpertHeader> expertHeaders = await _expertService.GetAll();
            return View(expertHeaders);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpertHeader expert)
        {

            try
            {
                
                var existData = await _context.ExpertHeaders.FirstOrDefaultAsync(m => m.Title.Trim().ToLower() == expert.Title.Trim().ToLower());

                if (existData is not null)  
                {
                    ModelState.AddModelError("Name", "This data already exist");
                    return View();
                }

                int num = 1;
                int num2 = 0;
                int result = num / num2;


                throw new Exception("Model statemiz bu gun bizi yolda qoydu");


               

                await _context.ExpertHeaders.AddAsync(expert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));



            }
            catch (Exception ex)
            {


                return RedirectToAction("Error", new { msj = ex.Message });
            }

        }




    }
}
