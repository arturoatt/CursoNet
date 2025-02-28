namespace MinimalAPI.JWT.JwtServices;

public class JwtService : IJwtService
{
    private readonly IOptions<MiConfiguracion> _conf;


    public JwtService(IOptions<MiConfiguracion> conf) => _conf = conf;


    public string GeneraToken(string username)
    {
        // Convertir la clave secreta en bytes
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf.Value.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim> { new Claim(ClaimTypes.Role, "admin") };

        // Crear el token con una duración
        var token = new JwtSecurityToken(
            issuer: username,
            audience: "urls;claves;",
            claims: claims,
            expires: DateTime.Now.AddSeconds(10),
            signingCredentials: credentials
        );

        // Devolver el token como cadena
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
