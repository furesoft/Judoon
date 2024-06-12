using Spectre.Console;

namespace Judoon.Core;

public class Menu(Menu parentMenu)
{
    public Menu Parent = parentMenu;

    public Dictionary<string, IMenuCommand> Items { get; set; } = [];

    public void WaitAndShow()
    {
        Console.ReadKey();
        Show();
    }

    public string Show()
    {
        Console.Clear();
        var header = new FigletText("Judoon").Centered();

        var pnl = new Panel(header);
        pnl.BorderStyle(Style.Parse("Blue"));
        AnsiConsole.Write(pnl);

        var prompt = new SelectionPrompt<string>();

        if (Parent != null)
        {
            prompt.AddChoice("..");
        }

        foreach (var item in Items)
        {
            prompt.AddChoice(item.Key);
        }

        var selectedItem = AnsiConsole.Prompt(prompt);

        if (selectedItem == "..")
        {
            Parent.Show();
            return string.Empty;
        }

        Items[selectedItem]?.Invoke(this);

        return selectedItem;
    }
}