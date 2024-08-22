using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Controllers.Models.View
{
    public class TaskViewModel
    { 
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WorkFlowStateEnum State { get; set; }

        public TaskViewModel() { }

        public TaskViewModel(TaskEntity task)
        {
            Id = task.Id;
            UserId = task.UserId;
            Name = task.Name;
            Description = task.Description;
            StartDate = task.StartDate;
            EndDate = task.EndDate;
            State = task.State;
     
        }

        public static List<TaskViewModel> FromList(List<TaskEntity> tasks)
        {
            var viewModelList = new List<TaskViewModel>();

            foreach (var task in tasks)
            {
                viewModelList.Add(new TaskViewModel(task));
            }

            return viewModelList;
        }
    }
}
