using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

public class HomeController : Controller, IActionFilter, IResultFilter
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Action method is being executed.");
        return View();
    }

    // Implementing the IActionFilter interface methods
public override void OnActionExecuting(ActionExecutingContext context)
{
    _logger.LogInformation("Before the action method is invoked.");
}

public override void OnActionExecuted(ActionExecutedContext context)
{
    _logger.LogInformation("After the action method is completed.");
}


    // Implementing the IResultFilter interface methods
    public void OnResultExecuting(ResultExecutingContext context)
    {
        _logger.LogInformation("Before the result is executed.");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        _logger.LogInformation("After the result has been executed.");
    }
}
