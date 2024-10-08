namespace ContatoAppApi.Models.Usuario;

public class Usuario : EntidadeBase
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string ChaveAcesso { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
