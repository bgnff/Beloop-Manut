using System.Reflection;
namespace Beloop_Manut.Recursos;

internal static class Imagens
{
    // Os PNGs são recursos incorporados: continuam disponíveis após a publicação.
    public static Image Carregar(string nome)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var sufixo = ".Recursos.Imagens." + nome;
        var recurso = assembly.GetManifestResourceNames().Single(n => n.EndsWith(sufixo, StringComparison.Ordinal));
        using var fluxo = assembly.GetManifestResourceStream(recurso)!;
        using var imagem = Image.FromStream(fluxo);
        return new Bitmap(imagem);
    }
}
