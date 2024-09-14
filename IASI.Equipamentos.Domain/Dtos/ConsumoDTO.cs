namespace IASI.Equipamentos.Domain.Dtos
{
    /// <summary>
    /// Data Transfer Object para Consumo.
    /// </summary>
    public class ConsumoDTO
    {
        public int Id { get; set; }
        public int IdEquipamento { get; set; }
        public DateTime DataConsumo { get; set; }
        public float QuantidadeConsumo { get; set; }
        public string TipoEnergia { get; set; }
        public float EmissaoGas { get; set; }
    }
}
