namespace API_Password_Home.Entities
{
    /// <summary>
    /// Modelo da base de dados que é mapeado pelo entity framework
    /// </summary>
    public class Data_Password_Services
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string UltimaModificacao { get; set; }    
    }
}
