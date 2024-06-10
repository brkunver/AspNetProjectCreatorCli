namespace AspNetProjectCreatorCli;

public static class MvcFiles
{
  public static string GetLayoutHtml(string projectName, bool addTailwind)
  {
    string tailwindCss = addTailwind ? "<link href=\"https://cdn.tailwindcss.com\" rel=\"stylesheet\" />" : "";

    return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>@ViewData[""Title""] - {projectName}</title>
    {tailwindCss}
</head>
<body>
    <main role=""main"">
        @RenderBody()
    </main>
    <script src=""~/js/site.js""></script>
</body>
</html>";
  }

  public static string GetIndexHtml()
  {

    string newContent = @"
@{
    ViewData[""Title""] = ""Home Page"";
}

<div class=""grid place-content-center"">
    <h1>Hello!</h1>
</div>
";

    return newContent;
  }

  public static string GetViewImports(string projectName)
  {
    string newContent = @"
@using " + projectName + @"
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
";

    return newContent;
  }

  public static string GetHomeController(string projectName)
  {
    string newContent = $@"
using Microsoft.AspNetCore.Mvc;

namespace {projectName}.Controllers
{{
    public class HomeController : Controller
    {{
        public HomeController()
        {{

        }}

        public IActionResult Index()
        {{
            return View();
        }}
    }}
}}
";

    return newContent;
  }


}
