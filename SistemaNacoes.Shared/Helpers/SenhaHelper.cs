namespace SistemaNacoes.Shared.Helpers;

public static class SenhaHelper
{
    public static string ProvisionarSenha()
    {
        var diaHoje = DateTime.Now.Day;
        var mesHoje = DateTime.Now.Month;
        var anoHoje = DateTime.Now.Year;
        
        var senha = $"{diaHoje}{mesHoje}{anoHoje}";
        
        return EncriptarSenha(senha);
    }
    
    public static string EncriptarSenha(string senha)
    {
        var bcryptSalt = BCrypt.Net.BCrypt.GenerateSalt();
        var customSalt = "emili_alves";

        var salt = bcryptSalt + customSalt;
        
        return BCrypt.Net.BCrypt.HashPassword(senha, salt);
    }
}