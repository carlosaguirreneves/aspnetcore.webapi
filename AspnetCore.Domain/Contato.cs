namespace AspnetCore.Domain
{
    public class Contato
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public CanalEnum Canal { get; set; }
        public string Valor { get; set; }
        public string Obs { get; set; }
    }
}