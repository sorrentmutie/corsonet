using FirstLibrary.Core.Conferenze;

namespace FirstDemo.BLazor.Server.Services;

public class UppercaseTransformation : ITrasformazioneTesto
{
    public string TrasformaTesto(string testo)
    {
        return testo.ToUpper();
    }
}
