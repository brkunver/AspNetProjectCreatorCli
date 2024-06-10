namespace AspNetProjectCreatorCli;
using Spectre.Console;
using System.Diagnostics;
using System.IO;

public static class CreateCommand
{
    public static void CreateEmptyMVC(string projectName, bool addTailwind = false)
    {
        try
        {
            // Get desktop and project path
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var projectPath = Path.Combine(desktopPath, projectName);

            if (!Directory.Exists(projectPath))
            {
                Directory.CreateDirectory(projectPath);
            }

            AnsiConsole.MarkupLine($"[darkblue]Creating MVC project '{projectName}' on Desktop...[/]");
            RunCommand($"dotnet new mvc -o \"{projectPath}\"");

            // Get shared folder path and layout file path
            var homeViewsFolderPath = Path.Combine(projectPath, "Views", "Home");
            var homeFilePath = Path.Combine(homeViewsFolderPath, "Index.cshtml");

            var sharedFolderPath = Path.Combine(projectPath, "Views", "Shared");
            var layoutFilePath = Path.Combine(sharedFolderPath, "_Layout.cshtml");

            // Delete all files in Shared folder except _Layout.cshtml
            if (Directory.Exists(sharedFolderPath))
            {
                var files = Directory.GetFiles(sharedFolderPath);
                foreach (var file in files)
                {
                    if (Path.GetFileName(file) != "_Layout.cshtml")
                    {
                        File.Delete(file);
                    }
                }
            }

            // Delete Privacy.cshtml file
            var privacyFilePath = Path.Combine(homeViewsFolderPath, "Privacy.cshtml");
            if (File.Exists(privacyFilePath))
            {
                File.Delete(privacyFilePath);
            }

            // Clear _Layout.cshtml file
            var layoutContent = MvcFiles.GetLayoutHtml(projectName, addTailwind);
            File.WriteAllText(layoutFilePath, layoutContent);

            // Clear Index.cshtml file
            var indexContent = MvcFiles.GetIndexHtml();
            File.WriteAllText(homeFilePath, indexContent);

            // Create _ViewImports.cshtml file
            var viewImportsFilePath = Path.Combine(sharedFolderPath, "_ViewImports.cshtml");
            var viewImportsContent = MvcFiles.GetViewImports(projectName);
            File.WriteAllText(viewImportsFilePath, viewImportsContent);

            // Clear wwwroot/css/site.css file
            var siteCssPath = Path.Combine(projectPath, "wwwroot", "css", "site.css");
            File.WriteAllText(siteCssPath, string.Empty);

            // Clear Controllers/HomeController.cs file
            var homeControllerFilePath = Path.Combine(projectPath, "Controllers", "HomeController.cs");
            var homeControllerContent = MvcFiles.GetHomeController(projectName);
            File.WriteAllText(homeControllerFilePath, homeControllerContent);

            // Delete everything inside wwwroot/lib folder
            var libFolderPath = Path.Combine(projectPath, "wwwroot", "lib");
            if (Directory.Exists(libFolderPath))
            {
                var files = Directory.GetFiles(libFolderPath);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }

            // Delete everything inside Models folder
            var modelsFolderPath = Path.Combine(projectPath, "Models");
            if (Directory.Exists(modelsFolderPath))
            {
                var files = Directory.GetFiles(modelsFolderPath);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }

            AnsiConsole.MarkupLine("[green]MVC project created successfully![/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error: {ex.Message}[/]");
        }
    }

    public static void CreateEmptyAPI()
    {
    }

    public static void CreateReactWebAPI(bool useTypescript, bool installTailwindcss)
    {
        AnsiConsole.MarkupLine("[darkblue]Creating React + Web API project...[/]");
    }

    public static void CreateAngularWebAPI()
    {
        AnsiConsole.MarkupLine("[darkblue]Creating Angular + Web API project...[/]");
    }

    private static void RunCommand(string command)
    {
        var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = new Process
        {
            StartInfo = processInfo
        };

        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        if (!string.IsNullOrWhiteSpace(output))
        {
            AnsiConsole.WriteLine(output);
        }

        if (!string.IsNullOrWhiteSpace(error))
        {
            AnsiConsole.WriteLine(error);
        }
    }
}
