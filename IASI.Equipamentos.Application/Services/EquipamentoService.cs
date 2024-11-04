using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Dtos;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;

namespace IASI.Equipamentos.Application.Services
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentoService(IEquipamentoRepository equipamentoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
        }

        public async Task<IEnumerable<EquipamentoDTO>> ObterTodosAsync()
        {
            var equipamentos = await _equipamentoRepository.GetAllAsync();
            return equipamentos.Select(e => new EquipamentoDTO
            {
                Id = e.Id,
                Nome = e.NomeEquipamento,
                Tipo = e.TipoEquipamento,
                Localizacao = e.LocalizacaoEquipamento,
                DataInstalacao = e.DataInstalacaoEquipamento,
                Estado = e.EstadoEquipamento
            });
        }

        public async Task<EquipamentoDTO> ObterPorIdAsync(int id)
        {
            var equipamento = await _equipamentoRepository.GetByIdAsync(id);
            if (equipamento == null) return null;

            return new EquipamentoDTO
            {
                Id = equipamento.Id,
                Nome = equipamento.NomeEquipamento,
                Tipo = equipamento.TipoEquipamento,
                Localizacao = equipamento.LocalizacaoEquipamento,
                DataInstalacao = equipamento.DataInstalacaoEquipamento,
                Estado = equipamento.EstadoEquipamento
            };
        }

        public async Task<bool> AdicionarAsync(EquipamentoDTO equipamentoDto)
        {
            var equipamento = new Equipamento
            {
                NomeEquipamento = equipamentoDto.Nome,
                TipoEquipamento = equipamentoDto.Tipo,
                LocalizacaoEquipamento = equipamentoDto.Localizacao,
                DataInstalacaoEquipamento = equipamentoDto.DataInstalacao,
                EstadoEquipamento = equipamentoDto.Estado
            };

            await _equipamentoRepository.AddAsync(equipamento);
            return true;
        }

        public async Task<bool> AtualizarAsync(int id, EquipamentoDTO equipamentoDto)
        {
            var equipamento = await _equipamentoRepository.GetByIdAsync(id);
            if (equipamento == null) return false;

            equipamento.NomeEquipamento = equipamentoDto.Nome;
            equipamento.TipoEquipamento = equipamentoDto.Tipo;
            equipamento.LocalizacaoEquipamento = equipamentoDto.Localizacao;
            equipamento.DataInstalacaoEquipamento = equipamentoDto.DataInstalacao;
            equipamento.EstadoEquipamento = equipamentoDto.Estado;

            await _equipamentoRepository.UpdateAsync(equipamento);
            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            await _equipamentoRepository.DeleteAsync(id);
            return true;
        }
    }
}
