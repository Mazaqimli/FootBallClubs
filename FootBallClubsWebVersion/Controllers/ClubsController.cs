using FootballClubs.Core.Domain.Entities;
using FootballClubs.Core.Domain.Enums;
using FootballClubs.Core.Domain.Repositories;
using FootBallClubsWebVersion.Mappers;
using FootBallClubsWebVersion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Reflection;

namespace FootBallClubsWebVersion.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult Update(int clubId)
        {
            Club c = _unitOfWork.ClubRepository.Get(clubId);

            this.FillPlans();
            ClubModel model = new()
            {
                Id = c.Id,
                Name = c.Name,
                TacticalPlan = c.TacticalPlan,
                TotalPower = c.TotalPower,
                LeagueId = c.LeagueId,
                CountryId = c.CountryId
            };

            return View(model);
        }   
        [HttpPost]
        public IActionResult Update(ClubModel model)
        {
            if(ModelState.IsValid == false)
            {
                this.FillPlans();
                return View(model);
            }
            Club club = new()
            {
                Id = model.Id,
                Name = model.Name,
                TacticalPlan = model.TacticalPlan,
                TotalPower = model.TotalPower,
                LeagueId = model.LeagueId,
                CountryId = model.CountryId
            };

            _unitOfWork.ClubRepository.Update(club);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int clubId)
        {
            return View(new ClubModel { Id = clubId });
        }  
        [HttpPost]
        public IActionResult Delete(ClubModel model)
        {
            _unitOfWork.ClubRepository.Delete(model.Id);

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
