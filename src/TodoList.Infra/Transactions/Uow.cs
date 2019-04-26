using TodoList.Infra.Contexts;

namespace TodoList.Infra.Transactions
{
    public class Uow : IUow
    {
        TodoListDataContext _context;

        public Uow(TodoListDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback() { }
    }
}
