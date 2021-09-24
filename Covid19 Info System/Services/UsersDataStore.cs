using Covid19_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Info_System.Services
{
     class UsersDataStore: IDataStore<UserModel>
    {
        readonly List<UserModel> Users;
        public UsersDataStore()
        {
            //delte
            
        }

        public async Task<bool> AddItemAsync(UserModel item)
        {
            await App.database.InsertAsync(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Users.Where((UserModel arg) => arg.Id == id).FirstOrDefault();
            Users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<UserModel> GetItemAsync(string id)
        {
            var user = await App.database.FindAsync<UserModel>(s => s.Id == id);

            return await Task.FromResult(user);
        }
        public async Task<IEnumerable<UserModel>> GetItemsAsync(bool forceRefresh = false)
        {
            var users = await App.database.Table<UserModel>().ToListAsync();
            return await Task.FromResult(users);
        }

        public async Task<bool> UpdateItemAsync(UserModel item)
        {
            var oldItem = Users.Where((UserModel arg) => arg.Id == item.Id).FirstOrDefault();
            Users.Remove(oldItem);
            Users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<UserModel> CheckUserExist(string email, string password)
        {
            //var users = await App.database.Table<UserModel>().ToListAsync();
            var user= await App.database.FindAsync<UserModel>(c => c.Email == email && c.Password ==password);

            return await Task.FromResult(user);
        }
    }
}
