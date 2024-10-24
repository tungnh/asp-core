using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OM.Application.Data.Repositories;
using OM.Application.Models.Member;
using OM.Application.Models.Paging;
using OM.Application.Services;

namespace OM.Web.Controllers
{
    public class MembersController : BaseController
    {
        private readonly IMemberService _memberService;
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberService memberService, IMemberRepository memberRepository)
        {
            _memberService = memberService;
            _memberRepository = memberRepository;
        }

        // GET: Members
        public async Task<IActionResult> Index(MemberRequestModel requestModel, Pageable pageable)
        {
            ViewData["Name"] = requestModel.Name;
            ViewData["Type"] = requestModel.Type;
            ViewData["PageIndex"] = pageable.PageIndex;
            ViewData["PageSize"] = pageable.PageSize;

            var model = await _memberService.FindAllAsync(requestModel.Name, pageable);

            return View(model);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _memberService.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Type,Address")] MemberInputModel model)
        {
            if (ModelState.IsValid)
            {
                await _memberService.AddAsync(model, "TungNH");
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _memberService.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Address")] MemberInputModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _memberService.UpdateAsync(model, "TungNH");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_memberRepository.ExistsById(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _memberService.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _memberService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
