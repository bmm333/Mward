using Microsoft.Maui.Controls;
using Mward.Models;
using Mward.Services;
using System;
using System.Collections.ObjectModel;

namespace Mward.Views
{
    public partial class WardrobePage : ContentPage
    {
        private readonly MongoDBService _mongoDBService;
        private ObservableCollection<WardrobeItem> _wardrobeItems;

        public WardrobePage()
        {
            InitializeComponent();
            _mongoDBService = new MongoDBService();
            LoadWardrobeItems();
        }

        private async void LoadWardrobeItems()
        {
            var items = await _mongoDBService.GetWardrobeItemsAsync();
            _wardrobeItems = new ObservableCollection<WardrobeItem>(items);
            WardrobeListView.ItemsSource = _wardrobeItems;
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            var newItem = new WardrobeItem
            {
                Name = "New Item",
                Description = "Description"
            };
            await _mongoDBService.SaveWardrobeItemAsync(newItem);
            _wardrobeItems.Add(newItem);
        }
    }
}
