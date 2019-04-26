namespace TodoList.Domain.Commands.Inputs.User
{
    public class UpdateUserInput
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
