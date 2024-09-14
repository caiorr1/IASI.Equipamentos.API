namespace IASI.Equipamentos.Domain.Dtos
{
    /// <summary>
    /// Data Transfer Object para Resíduo.
    /// </summary>
    public class ResiduoDTO
    {
        public int Id { get; set; }
        public int IdEquipamento { get; set; }
        public string TipoResiduo { get; set; }
        public float Quantidade { get; set; }
        public DateTime DataGeracao { get; set; }
        public string DestinoFinal { get; set; }
    }
}
