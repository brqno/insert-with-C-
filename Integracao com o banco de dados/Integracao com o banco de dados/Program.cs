using Microsoft.Data.SqlClient;
internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "Server=DESKTOP-9LK813Q;Database=USERS;Trusted_Connection=True;TrustServerCertificate=True";

        //nome
        Console.WriteLine("Por favor, digite seu nome: ");
        string nome = Console.ReadLine();

        //usuário
        string user;
        do
        {
            Console.WriteLine("Agora, nos informe seu user (mínimo 4 caracteres): ");
            user = Console.ReadLine();
            if (user.Length < 4)
            {
                Console.WriteLine("Erro: Nome de usuário deve ter mais de 4 caracteres.");
            }
        } while (user.Length < 4);

        //senha
        string senha;
        do
        {
            Console.WriteLine("Por favor, nos informe uma senha (mínimo 3 caracteres): ");
            senha = Console.ReadLine();
            if (senha.Length < 3)
            {
                Console.WriteLine("Erro: Senha deve ter mais de 3 caracteres.");
            }
        } while (senha.Length < 3);

        //email
        string email;
        do
        {
            Console.WriteLine("Digite seu e-mail (somente gmail, hotmail ou outlook): ");
            email = Console.ReadLine();
            if (!IsValidEmail(email))
            {
                Console.WriteLine("Erro: Insira um e-mail válido.");
            }
        } while (!IsValidEmail(email));

        // Conexão e inserção
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conexão criada com sucesso.");

                string query = "INSERT INTO usuarios (nome, usuario, senha, email) VALUES (@Nome, @UserName, @Senha, @Email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@UserName", user);
                    command.Parameters.AddWithValue("@Senha", senha);
                    command.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Dados inseridos com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao inserir os dados.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na operação: {ex.Message}");
        }

        bool IsValidEmail(string email)
        {
            return email.EndsWith("gmail.com") || email.EndsWith("hotmail.com") || email.EndsWith("outlook.com");
        }
    }
}