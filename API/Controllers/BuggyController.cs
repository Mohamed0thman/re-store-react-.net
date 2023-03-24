using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{


    public class BuggyController : BaseApiController
    {
        private readonly ILogger<BuggyController> _logger;

        public BuggyController(ILogger<BuggyController> logger)
        {
            _logger = logger;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }
        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "this is a bad request" });
        }

        [HttpGet("unauthorised")]
        public ActionResult GetUnauthorised()
        {
            return Unauthorized();
        }

        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("problem1", "dasdsadasd");
            ModelState.AddModelError("problem2", "dasdsadasd");

            return ValidationProblem();
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            throw new Exception("this is a server error");
        }
    }
}