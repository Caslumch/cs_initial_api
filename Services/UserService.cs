using MongoDB.Driver;
using email_api.Models;

namespace email_api.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("baseEmailCode"); // Substitua pelo nome do seu banco de dados
            _users = database.GetCollection<User>("Users"); // Nome da coleção
        }


        // aqui ele cria o usuario no banco
        public async Task CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }


        //aqui ele busca all users  no banco
        public async Task<List<User>> GetUsersAsync()
        {
            return await _users.Find(user => true).ToListAsync();
        }


        // aqui ele faz um get do usuario na tabela pelo id 
        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }


        //Ele valida se tem algum email igual, se tiver ele retorna
        public async Task<bool> EmailExistsAsync(string email)
        {
            var user = await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
            return user != null;
        }

        public async Task UpdateUserAsync(string id, User updatedUser)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            var update = Builders<User>.Update
                .Set(u => u.Name, updatedUser.Name)
                .Set(u => u.Email, updatedUser.Email)
                .Set(u => u.Telefone, updatedUser.Telefone);

            await _users.UpdateOneAsync(filter, update);
        }
    }
}