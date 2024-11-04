using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace IASI.Equipamentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendacaoController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public RecomendacaoController(IWebHostEnvironment env)
        {
            _env = env;
            _mlContext = new MLContext();
        }

        private string GetDataPath()
        {
            return Path.Combine(_env.ContentRootPath, "Data", "equipment_maintenance_data.csv");
        }
        [HttpPost("treinar-modelo")]
        public IActionResult TreinarModelo()
        {
            try
            {
                var dataPath = GetDataPath();
                IDataView dataView = _mlContext.Data.LoadFromTextFile<EquipmentData>(dataPath, hasHeader: true, separatorChar: ',');

                var pipeline = _mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "MaintenanceNeeded")
                    .Append(_mlContext.Transforms.Categorical.OneHotEncoding("EquipmentType"))
                    .Append(_mlContext.Transforms.Concatenate("Features", "EquipmentAge", "LastMaintenance", "EquipmentType"))
                    .Append(_mlContext.Regression.Trainers.FastTree());

                _model = pipeline.Fit(dataView);

                // Salvar o modelo em disco
                var modelPath = Path.Combine(_env.ContentRootPath, "Data", "trainedModel.zip");
                _mlContext.Model.Save(_model, dataView.Schema, modelPath);

                return Ok("Modelo treinado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao treinar o modelo: {ex.Message}");
            }
        }

        [HttpPost("prever-manutencao")]
        public IActionResult PreverManutencao([FromBody] EquipmentData inputData)
        {
            try
            {
                if (_model == null)
                {
                    var modelPath = Path.Combine(_env.ContentRootPath, "Data", "trainedModel.zip");
                    if (!System.IO.File.Exists(modelPath))
                    {
                        return BadRequest("O modelo precisa ser treinado antes de fazer previsões.");
                    }
                    _model = _mlContext.Model.Load(modelPath, out _);
                }

                var predictionEngine = _mlContext.Model.CreatePredictionEngine<EquipmentData, MaintenancePrediction>(_model);
                var prediction = predictionEngine.Predict(inputData);

                return Ok(JsonConvert.SerializeObject(prediction));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao fazer a previsão: {ex.Message}");
            }
        }

        public class EquipmentData
        {
            [LoadColumn(0)]
            public float EquipmentAge { get; set; }

            [LoadColumn(1)]
            public float LastMaintenance { get; set; }

            [LoadColumn(2)]
            public string EquipmentType { get; set; }

            [LoadColumn(3)]
            public float MaintenanceNeeded { get; set; }
        }

        public class MaintenancePrediction
        {
            [ColumnName("Score")]
            public float MaintenanceProbability { get; set; }
        }
    }
}
