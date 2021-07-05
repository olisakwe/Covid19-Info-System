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
            Users = new List<UserModel>()
            {
                new UserModel { Id = Guid.NewGuid().ToString(), Name="Olisakwe IFeanyi", IsActive=true, Date=DateTime.Now, Email="Olisak@dd.com",IsAdmin=false, Phone="0903349595",Password="0000" },
                new UserModel { Id = Guid.NewGuid().ToString(), Name="Olisakwe Johnson", IsActive=true, Date=DateTime.Now, Email="Johnson@dd.com",IsAdmin=false, Phone="070464634",Password="1111" },
                new UserModel { Id = Guid.NewGuid().ToString(), Name="Abe IFeanyi", IsActive=true, Date=DateTime.Now, Email="Abe@dd.com",IsAdmin=false, Phone="0812345677",Password="2222" },
                new UserModel { Id = Guid.NewGuid().ToString(), Name="Fake IFeanyi", IsActive=false, Date=DateTime.Now, Email="Fake@dd.com",IsAdmin=false, Phone="08054645",Password="3333" },
                new UserModel { Id = Guid.NewGuid().ToString(), Name="Sir Joe IFeanyi", IsActive=true, Date=DateTime.Now, Email="Joe@dd.com",IsAdmin=false, Phone="0005667",Password="4444" },

            };
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
