namespace IASI.Equipamentos.Domain.Dtos
{
    /// <summary>
    /// Data Transfer Object para Manutenção.
    /// </summary>
    public class ManutencaoDTO
    {
        public int Id { get; set; }
        public int IdEquipamento { get; set; }
        public string TipoManutencao { get; set; }
        public DateTime DataManutencao { get; set; }
        public string Descricao { get; set; }
    }
}
