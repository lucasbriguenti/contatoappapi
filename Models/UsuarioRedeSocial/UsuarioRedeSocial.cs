namespace ContatoAppApi.Models.UsuarioRedeSocial;

public class UsuarioRedeSocial
{
    public long Id { get; set; }
    public string Url { get; set; }
    public RedeSocial.RedeSocial RedeSocial { get; set; }
    public Usuario.Usuario Usuario { get; set; }
}
