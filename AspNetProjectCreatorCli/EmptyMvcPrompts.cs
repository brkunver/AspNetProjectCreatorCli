namespace AspNetProjectCreatorCli;
using Spectre.Console;

public class EmptyMvcPrompts
{
  public static bool Prompt()
  {

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

    return installTailwindcss;
  }
}
