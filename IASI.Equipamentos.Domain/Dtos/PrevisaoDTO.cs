namespace IASI.Equipamentos.Domain.Dtos
{
    /// <summary>
    /// Data Transfer Object para Previsão.
    /// </summary>
    public class PrevisaoDTO
    {
        public int Id { get; set; }
        public int IdEquipamento { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string TipoPrevisao { get; set; }
        public string Descricao { get; set; }
        public float Probabilidade { get; set; }
    }
}
