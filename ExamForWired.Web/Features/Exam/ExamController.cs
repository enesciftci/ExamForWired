using ExamForWired.Models;
using ExamForWired.Web.Controllers;
using ExamForWired.Web.Features.Article.Queries;
using ExamForWired.Web.Features.Exam.Commands;
using ExamForWired.Web.Features.Exam.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Exam
{
    [Route("exam")]
    public class ExamController : BaseController
    {
        private readonly IMediator _mediator;
        public ExamController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var examList = await _mediator.Send(new GetListExamQuery());
            return View("ExamList", examList);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteExamCommand(id));
            return Ok();
        }

        [HttpGet("builder")]
        public async Task<IActionResult> ExamBuilder()
        {
            var articleList = await _mediator.Send(new GetArticleListQuery());
            ViewBag.ArticleList = articleList;
            return View("ExamBuilder");
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostExam([FromForm] ExamModel exam)
        {
            exam.Questions.RemoveAll(p => p.Content == null || !p.Answers.Any());
            await _mediator.Send(new PostExamCommand(exam));
            return RedirectToAction("list");
        }

        [HttpGet("start/{id}")]
        public async Task<IActionResult> StartExam([FromRoute] long id)
        {
            var examModel = await _mediator.Send(new GetExamByIdQuery(id));
            return View("Exam", examModel);
        }
        [HttpPost("finish")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinishExam([FromBody] List<AnswerModel> answerModels)
        {
            answerModels = await _mediator.Send(new PostFinishExamCommand(answerModels));
            return Ok(answerModels);
        }
    }
}
