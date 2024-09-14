﻿namespace IASI.Equipamentos.Domain.Dtos
{
    /// <summary>
    /// Data Transfer Object para Equipamento.
    /// </summary>
    public class EquipamentoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Localizacao { get; set; }
        public DateTime? DataInstalacao { get; set; }
        public string Estado { get; set; }
    }
}
