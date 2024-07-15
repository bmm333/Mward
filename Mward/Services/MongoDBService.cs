using MongoDB.Driver;
using Mward.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mward.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<UserProfile> _userProfiles;
        private readonly IMongoCollection<WardrobeItem> _wardrobeItems;

        public MongoDBService()
        {
            var client = new MongoClient("your_mongodb_connection_string");
            var database = client.GetDatabase("MwardDatabase");
            _userProfiles = database.GetCollection<UserProfile>("UserProfiles");
            _wardrobeItems = database.GetCollection<WardrobeItem>("WardrobeItems");
        }

        public async Task<UserProfile> GetUserProfileAsync()
        {
            return await _userProfiles.Find(profile => true).FirstOrDefaultAsync();
        }

        public async Task SaveUserProfileAsync(UserProfile profile)
        {
            var existingProfile = await _userProfiles.Find(p => p.Id == profile.Id).FirstOrDefaultAsync();
            if (existingProfile == null)
            {
                await _userProfiles.InsertOneAsync(profile);
            }
            else
            {
                await _userProfiles.ReplaceOneAsync(p => p.Id == profile.Id, profile);
            }
        }

        public async Task<List<WardrobeItem>> GetWardrobeItemsAsync()
        {
            return await _wardrobeItems.Find(item => true).ToListAsync();
        }

        public async Task SaveWardrobeItemAsync(WardrobeItem item)
        {
            var existingItem = await _wardrobeItems.Find(i => i.Id == item.Id).FirstOrDefaultAsync();
            if (existingItem == null)
            {
                await _wardrobeItems.InsertOneAsync(item);
            }
            else
            {
                await _wardrobeItems.ReplaceOneAsync(i => i.Id == item.Id, item);
            }
        }
    }
}
