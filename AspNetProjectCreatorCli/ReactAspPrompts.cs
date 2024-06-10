namespace AspNetProjectCreatorCli;
using Spectre.Console;

public class ReactAspPrompts
{
  public static (bool useTs, bool useTailwind) Prompt()
  {
    var useTypescript = AnsiConsole.Prompt(
    new SelectionPrompt<bool>()
    .Title("Use TypeScript?")
    .PageSize(3)
    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
    .AddChoices([true, false]));

    if (useTypescript)
    {
      AnsiConsole.MarkupLine("[green]Typescript will be used[/]");
    }
    else
    {
      AnsiConsole.MarkupLine("[red]Typescript will not be used[/]");
    }

    var installTailwindcss = AnsiConsole.Prompt(
    new SelectionPrompt<bool>()
    .Title("Install Tailwind CSS?")
    .PageSize(3)
    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
   .AddChoices([true, false]));

    if (installTailwindcss)
    {
      AnsiConsole.MarkupLine("[green]Tailwind CSS will be added[/]");
    }
    else
    {
      AnsiConsole.MarkupLine("[red]Tailwind CSS will not be added[/]");
    }

    return (useTypescript, installTailwindcss);
  }
}
