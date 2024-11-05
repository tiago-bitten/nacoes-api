namespace SistemaNacoes.Shared.Helpers;

public static class SenhaHelper
{
    #region ProvisionarSenha
    public static string Provisionar()
    {
        var diaHoje = DateTime.Now.Day;
        var mesHoje = DateTime.Now.Month;
        var anoHoje = DateTime.Now.Year;
        
        var senha = $"{diaHoje}{mesHoje}{anoHoje}";
        
        return Encriptar(senha);
    }
    #endregion
    
    #region EncriptarSenha
    public static string Encriptar(string senha)
    {
        var bcryptSalt = BCrypt.Net.BCrypt.GenerateSalt();
        var customSalt = "emili_alves";

        var salt = bcryptSalt + customSalt;
        
        return BCrypt.Net.BCrypt.HashPassword(senha, salt);
    }
    #endregion

    public static bool Verificar(string senha, string senhaEncriptada)
    {
        return BCrypt.Net.BCrypt.Verify(senha, senhaEncriptada);
    }
}