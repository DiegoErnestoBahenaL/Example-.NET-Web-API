using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebGlobalProduct.Data.Entities
{
    public class TaskEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(150), Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }

        [Required]
        public WorkFlowStateEnum State { get; set; }


        public TaskEntity () { }

        public TaskEntity  (string name, string description, DateTimeOffset startDate, DateTimeOffset endDate, WorkFlowStateEnum state, long userId)
        {
            Name = name;
            UserId = userId;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            State = state;
        }
    }
}
