namespace AspNetProjectCreatorCli;
using Spectre.Console;

public static class Program
{
    public static void Main()
    {
        string[] project = ["React + Web API", "Empty MVC", "Empty API"];

        AnsiConsole.MarkupLine("[bold]Welcome to the ASP.NET Project Creator CLI[/]");
        var selectedProject = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Select a project type")
        .PageSize(project.Length)
        .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
        .AddChoices(project));

        AnsiConsole.MarkupLine($"[bold]Selected project[/]: {selectedProject}");

        switch (selectedProject)
        {
            case "Empty MVC":
                var useTailwind = EmptyMvcPrompts.Prompt();
                var projectName = AnsiConsole.Ask<string>("Enter project name: ");
                CreateCommand.CreateEmptyMVC(projectName, useTailwind);
                break;
            case "Empty API":
                AnsiConsole.MarkupLine("Creating Empty API project");
                break;
            case "React + Web API":
                var (useTypescript, useTailwindcss) = ReactAspPrompts.Prompt();

                CreateCommand.CreateReactWebAPI(AnsiConsole.Ask<string>("Enter project name: "), useTypescript, useTailwindcss);
                break;

            default:
                break;
        }
    }
}
