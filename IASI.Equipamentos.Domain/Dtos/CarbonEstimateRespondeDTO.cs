using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace IASI.Equipamentos.Domain.Dtos
{
    public class CarbonEstimateResponse
    {
        public DataResponse Data { get; set; }
    }

    public class DataResponse
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public CarbonAttributes Attributes { get; set; }
    }

    public class CarbonAttributes
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("electricity_unit")]
        public string ElectricityUnit { get; set; }

        [JsonProperty("electricity_value")]
        public decimal ElectricityValue { get; set; }

        [JsonProperty("estimated_at")]
        public DateTime EstimatedAt { get; set; }

        [JsonProperty("carbon_g")]
        public int CarbonG { get; set; }

        [JsonProperty("carbon_lb")]
        public decimal CarbonLb { get; set; }

        [JsonProperty("carbon_kg")]
        public decimal CarbonKg { get; set; }

        [JsonProperty("carbon_mt")]
        public decimal CarbonMt { get; set; }
    }


}