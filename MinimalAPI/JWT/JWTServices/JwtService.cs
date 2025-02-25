namespace MinimalAPI.JWT.JwtServices;

public class JwtService : IJwtService
{
    //private readonly IOptions<ConfigurationSettings> _conf;


    //public JwtService(IOptions<ConfigurationSettings> conf) => _conf = conf;


    public string GeneraToken(string username)
    {
        // Convertir la clave secreta en bytes
        //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf.Value.SecretKey));
        //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Crear el token con una duración
        //var token = new JwtSecurityToken(
        //    audience: _conf.Value.Audiencia,
        //    expires: DateTime.Now.AddMinutes(_conf.Value.TokenExpiry),
        //    signingCredentials: credentials
        //);

        // Devolver el token como cadena
        //return new JwtSecurityTokenHandler().WriteToken(token);
        return null;
    }
}
