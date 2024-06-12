using Terminal.Gui;

namespace Judoon;

public static class Program
{
    public static void Main(string[] args)
    {
        Application.Run<MainWindow>();

        Application.Shutdown();
    }
}
