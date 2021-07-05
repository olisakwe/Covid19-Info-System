using Covid19_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Info_System.Services
{
   public class ArticlesDataStore : IDataStore<ArticleModel>
    {
        readonly List<ArticleModel> Articles;

        public ArticlesDataStore()
        {
            Articles = new List<ArticleModel>()
            {
                new ArticleModel { Id = Guid.NewGuid().ToString(), Title = "First item", Author="Olisakwe IFeanyi", isActive=true, Date=DateTime.Now, Content="This is an item description." },
                new ArticleModel { Id = Guid.NewGuid().ToString(), Title = "Second item", Author="Hojn IFeanyi", isActive=true, Date=DateTime.Now, Content="This is an item description." },
                new ArticleModel { Id = Guid.NewGuid().ToString(), Title = "Third item", Author="Moji IFeanyi", isActive=true, Date=DateTime.Now, Content="This is an item description." },
                new ArticleModel { Id = Guid.NewGuid().ToString(), Title = "Fourt item", Author="Kate IFeanyi", isActive=true, Date=DateTime.Now, Content="This is an item description." },
                new ArticleModel { Id = Guid.NewGuid().ToString(), Title = "Five item", Author="Benson IFeanyi", isActive=true, Date=DateTime.Now, Content="This is an item description." },
                new ArticleModel { Id = Guid.NewGuid().ToString(), Title = "Six item", Author="Olisakwe IFeanyi", isActive=true, Date=DateTime.Now, Content="This is an item description." }
               
            };
        }

        public async Task<bool> AddItemAsync(ArticleModel item)
        {
            //Articles.Add(item);
             await    App.database.InsertAsync(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Articles.Where((ArticleModel arg) => arg.Id == id).FirstOrDefault();
            Articles.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ArticleModel> GetItemAsync(string id)
        {
            var article = await App.database.FindAsync<ArticleModel>(s => s.Id == id);
            return await Task.FromResult(article);
        }

        public async Task<IEnumerable<ArticleModel>> GetItemsAsync(bool forceRefresh = false)
        {
            var articles = await App.database.Table<ArticleModel>().ToListAsync();
            return await Task.FromResult(articles);
        }

        public async Task<bool> UpdateItemAsync(ArticleModel item)
        {
            var oldItem = await GetItemAsync(item.Id);
            await App.database.DeleteAsync(oldItem);
            await App.database.InsertAsync(item);
           // Articles.Remove(oldItem);
           
           // Articles.Add(item);

            return await Task.FromResult(true);
        }
    }
}
