using Moq;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IASI.Equipamentos.API.Controllers;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Domain.Dtos;
using System.Collections.Generic;

namespace IASI.Equipamentos.Test
{
    public class EquipamentoControllerTests
    {
        private readonly Mock<IEquipamentoService> _equipamentoServiceMock;
        private readonly EquipamentoController _controller;

        public EquipamentoControllerTests()
        {
            _equipamentoServiceMock = new Mock<IEquipamentoService>();
            _controller = new EquipamentoController(_equipamentoServiceMock.Object);
        }

        [Fact]
        public async Task GetById_ReturnsExpectedEquipamento()
        {
            var mockEquipamento = new EquipamentoDTO { Id = 1, Nome = "Equipamento A" };

            _equipamentoServiceMock
                .Setup(service => service.ObterPorIdAsync(1))
                .ReturnsAsync(mockEquipamento);

            var result = await _controller.GetById(1);

            Assert.NotNull(result); 
            var okResult = Assert.IsType<OkObjectResult>(result.Result); 
            Assert.Equal(mockEquipamento, okResult.Value); 
        }

        [Fact]
        public async Task GetAll_ReturnsListOfEquipamentos()
        {
            var mockEquipamentos = new List<EquipamentoDTO>
    {
        new EquipamentoDTO { Id = 1, Nome = "Equipamento A" },
        new EquipamentoDTO { Id = 2, Nome = "Equipamento B" }
    };

            _equipamentoServiceMock
                .Setup(service => service.ObterTodosAsync())
                .ReturnsAsync(mockEquipamentos);

            var result = await _controller.GetAll();

            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockEquipamentos, okResult.Value);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction()
        {
            var novoEquipamento = new EquipamentoDTO { Nome = "Novo Equipamento" };
            _equipamentoServiceMock.Setup(service => service.AdicionarAsync(novoEquipamento)).ReturnsAsync(true);

            var result = await _controller.Create(novoEquipamento);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(novoEquipamento, createdResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            var equipamentoAtualizado = new EquipamentoDTO { Id = 1, Nome = "Equipamento Atualizado" };

            _equipamentoServiceMock
                .Setup(service => service.AtualizarAsync(1, equipamentoAtualizado))
                .ReturnsAsync(true);

            var result = await _controller.Update(1, equipamentoAtualizado);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenEquipamentoDoesNotExist()
        {
            var equipamentoAtualizado = new EquipamentoDTO { Id = 1, Nome = "Equipamento Atualizado" };

            _equipamentoServiceMock
                .Setup(service => service.AtualizarAsync(1, equipamentoAtualizado))
                .ReturnsAsync(false); 

            var result = await _controller.Update(1, equipamentoAtualizado);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeletionIsSuccessful()
        {
            _equipamentoServiceMock
                .Setup(service => service.RemoverAsync(1))
                .ReturnsAsync(true);

            var result = await _controller.Delete(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenEquipamentoDoesNotExist()
        {
            _equipamentoServiceMock
                .Setup(service => service.RemoverAsync(1))
                .ReturnsAsync(false); 

            var result = await _controller.Delete(1);

            Assert.IsType<NotFoundResult>(result);
        }

    }
}
