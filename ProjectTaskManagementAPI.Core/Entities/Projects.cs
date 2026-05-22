namespace ProjectTaskManagementAPI.Core.Entities
{
    public class Projects
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public ICollection<Tasks>? Tasks { get; set; }
    }
}
