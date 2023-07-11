using MelonBookshelf.Common.Contracts;
using MelonBookshelf.Data.Models.Enums;
using MelonBookshelf.Models.Choosable;
using MelonBookshelf.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MelonBookshelf.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public async Task<IActionResult> All()
        {
            var model = await requestService.GetAllRequests();

            return View(model.Select(x=>new ShowRequestViewModel(x)));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new RequestEditViewModel
            {
                Categories = new 
                {

                }
            }
        }

    }
}
