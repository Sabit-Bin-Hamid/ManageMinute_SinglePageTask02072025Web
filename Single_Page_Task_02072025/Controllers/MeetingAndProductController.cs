using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Single_Page_Task_02072025.Data;
using Single_Page_Task_02072025.Models;
using Single_Page_Task_02072025.Models.DTO;
using Single_Page_Task_02072025.Service.Interface;

namespace Single_Page_Task_02072025.Controllers
{
    public class MeetingAndProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMeetingMinutes _meetingMinutes;
        private readonly IMeetingMinutesService _minutesService;
        public MeetingAndProductController(AppDbContext cont, IMeetingMinutes mm,
            IMeetingMinutesService minutesService)
        {
            _context = cont;
            _meetingMinutes = mm;
            _minutesService = minutesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = new MeetingMinuteViewDTO
            {
                Meeting = new MeetingMinute
                {
                    MeetingDate = DateTime.Now.Date,
                    MeetingTime = DateTime.Now.TimeOfDay,
                    CustomerType = "Corporate"
                },
                Details = new List<MeetingMinuteDetail>()
                //{
                //    new MeetingMinuteDetail()
                //}
            };
            ViewBag.ProductList = await _context.Products_Service_Tbl.ToListAsync();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MeetingMinuteViewDTO meetingMinuteView)
        {
            if (meetingMinuteView?.Meeting == null)
            {
                ModelState.AddModelError("", "Invalid form.");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.ProductList = await _context.Set<ProductService>().AsNoTracking().ToListAsync();
                return View(meetingMinuteView!);
            }

            if (meetingMinuteView.Details == null)
            {
                meetingMinuteView.Details = new List<MeetingMinuteDetail>();
            }

            try
            {
                var newId =await _minutesService.SaveAsync(meetingMinuteView.Meeting, meetingMinuteView.Details);
                TempData["Success"] = $"Saved successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Save failed: {ex.Message}");
                ViewBag.ProductList = _context.Set<ProductService>().AsNoTracking().ToList();
                return View(meetingMinuteView);
            }
        }


        [HttpGet]
        [Route("MeetingAndProduct/GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers(string type)
        {
            if (string.IsNullOrEmpty(type)) return Json(new { });

            if (type == "Corporate")
            {
                var data = await _meetingMinutes.GetCorporateCustomerAsync();
                return Json(data);
            }
            else
            {
                var data = await _meetingMinutes.GetIndividualCustomerAsync();
                return Json(data);
            }
        }
    }
}
