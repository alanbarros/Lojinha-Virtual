namespace sistemaVendaWebApi.Models
{
    public class InicializaDB
    {
        public static void InicializarUsuario(UsuarioContext context){

            context.Database.EnsureCreated();

            if(context.Usuarios.Local.Count > 0) return;

            context.AddRange(
                new Usuario(){Nome = "Alan Barros", Username = "alan", Senha = "1234"},
                new Usuario(){Nome = "João Paulo", Username = "joao", Senha = "5678"}
            );
            context.SaveChanges();
        }

        public static void InicializarCliente(ClienteContext context){
            context.Database.EnsureCreated();

            context.Add(new Cliente("Alan","41483454886",new System.DateTime(1993,04,17),"Ativo",'M'));
        }

    }
}