using MelonBookshelf.Business.Contracts;
using MelonBookshelf.Business.DTOs;
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
            var model = new RequestEditViewModel(await requestService.GetAddNewRequest());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RequestEditViewModel model)
        {
            
            RequestEditDto dto = new RequestEditDto
            {
                CategoryIds = model.CategoryIds,
                Priority = model.Priority,
                Title = model.Title,
                Author = model.Author,
                Justification = model.Justification
            };
            await requestService.AddNewRequestAsync(dto, GetUserId());
            return RedirectToAction(nameof(All));
        }
    }
}
