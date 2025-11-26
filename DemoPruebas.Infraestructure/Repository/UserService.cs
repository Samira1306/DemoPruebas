namespace DemoPruebas.Infraestructure.Repository
{
    public class UserService(AppDbContext appDbContext) : IUserService
    {
        private readonly AppDbContext _context = appDbContext;

        public void CreateUser(Users users)
        {
            _context.Users.AddAsync(users);
            _context.SaveChanges();
        }
    }
}
