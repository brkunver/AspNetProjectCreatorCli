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

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var projectPath = Path.Combine(desktopPath, projectName);


            if (!Directory.Exists(projectPath))
            {
                Directory.CreateDirectory(projectPath);
            }


            AnsiConsole.MarkupLine($"[darkblue]Creating MVC project '{projectName}' on Desktop...[/]");
            RunCommand($"dotnet new mvc -o \"{projectPath}\"");

            var layoutFilePath = Path.Combine(projectPath, "Views", "Shared", "_Layout.cshtml");
            var layoutContent = MvcFiles.GetLayoutHtml(projectName, addTailwind);
            File.WriteAllText(layoutFilePath, layoutContent);


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
