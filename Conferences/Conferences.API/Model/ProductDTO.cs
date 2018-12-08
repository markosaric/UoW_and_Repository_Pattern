using System;
using AutoMapper.Configuration.Conventions;
using Newtonsoft.Json;

namespace Conferences.API.Model
{
    public class ProductDTO
    {
        [JsonProperty("id")]
        public virtual int? ProductID { get; set; }
        [JsonProperty("name")]
        public string ProductName { get; set; }
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        [JsonProperty("description")]
        public string ProductDescription { get; set; }
    }

    public class ProductModel : ProductDTO
    {
        [JsonIgnore]
        public override int? ProductID { get; set; }
    }
}
