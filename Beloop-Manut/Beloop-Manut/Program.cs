namespace Beloop_Manut;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Telas.Login.FrmLogin());
    }
}
