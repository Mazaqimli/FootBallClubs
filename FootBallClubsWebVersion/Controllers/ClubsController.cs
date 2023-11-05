using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Enums;
using FootballClubs.Core.Domain.Repositories;
using FootBallClubsWebVersion.Mappers;
using FootBallClubsWebVersion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace FootBallClubsWebVersion.Controllers
{
    public class ClubsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClubsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() 
        {
            List<Club> clubs = _unitOfWork.ClubRepository.Get();

            List<ClubModel> models = new List<ClubModel>();

            foreach (Club c in clubs)
            {
                ClubModel m = ClubMapper.Map(c);

                models.Add(m);

            }

            return View(models); 
        }

        [HttpGet]
        public IActionResult Add()
        {
            ClubModel model = new();
            this.FillPlans();

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ClubModel model)
        {
            if(ModelState.IsValid == false)
            {
                this.FillPlans();
                return View(model);
            }
            Club c = ClubMapper.Map(model);

            _unitOfWork.ClubRepository.Add(c);

            return RedirectToAction("Index");
        }

        private void FillPlans()
        {
            ViewBag.Plans = Enum.GetValues(typeof(TacticalPlan)).Cast<TacticalPlan>().
                Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString()
                }).ToList();
        }
    }
}
