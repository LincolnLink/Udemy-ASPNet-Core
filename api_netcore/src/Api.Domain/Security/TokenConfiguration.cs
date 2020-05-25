namespace Api.Domain.Security
{
    public class TokenConfiguration
    {
        //Publico
        public string Audience { get; set; }

        //Emissor
        public string Issuer { get; set; }

        //Segundos de validade
        public int Seconds { get; set; }
    }
}