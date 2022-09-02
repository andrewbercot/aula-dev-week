namespace src.Models
{

    public class Contrato
    {
        public Contrato()
        {
            this.DataCriacao=DateTime.Now;
            this.Valor=0;
            this.TokenID="000000";
            this.Pago=false;
        }

        public Contrato(double Valor,string TokenID)
        {
            this.DataCriacao=DateTime.Now;
            this.Valor=Valor;
            this.TokenID=TokenID;
             this.Pago=false;
        }

        public DateTime DataCriacao { get; set; }
        public string TokenID { get; set; }

        public double Valor { get; set; }
        public bool Pago { get; set; }
        
        public int Id { get; set; }
        public int PessoaId { get; set; }
    }
}