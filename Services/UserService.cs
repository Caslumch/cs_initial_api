using MongoDB.Driver;
using email_api.Models;

namespace email_api.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("YourDatabaseName"); // Substitua pelo nome do seu banco de dados
            _users = database.GetCollection<User>("Users"); // Nome da coleção
        }

        public async Task CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _users.Find(user => true).ToListAsync();
        }
    }
}