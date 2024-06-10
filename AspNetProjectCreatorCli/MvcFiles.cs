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

}
