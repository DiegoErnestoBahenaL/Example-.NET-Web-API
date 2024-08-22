using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Controllers.Models.CreateUpdate
{
    public class TaskModel
    {
        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(150), Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter)), Required]
        public WorkFlowStateEnum State { get; set; }

        public long? UserId {get; set;}

        public TaskModel() { }
    }
}
