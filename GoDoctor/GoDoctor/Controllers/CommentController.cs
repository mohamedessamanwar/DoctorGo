using BusinessAccessLayer.DataViews.CommentView;
using BusinessAccessLayer.Sevices.CommentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace GoDoctor.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment([FromBody]CommentAddView commentAddView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid comment data." });
            }
            var UserId = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
            if (UserId == null)
            {
                RedirectToAction("Login", "Auth");
            }
            var result = await commentService.AddComment(UserId, commentAddView);
            if (result == null)
            {
                return BadRequest(new { Message ="Something Wrong"});
            }
            return Ok(new { Data = result });
        }
    }
}
