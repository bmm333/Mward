using Microsoft.Maui.Controls;
using Mward.Models;
using Mward.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mward.Views
{
    public partial class AnalyticsPage : ContentPage
    {
        private readonly MongoDBService _mongoDBService;
        private ObservableCollection<KeyValuePair<string, string>> _analyticsData;

        public AnalyticsPage()
        {
            InitializeComponent();
            _mongoDBService = new MongoDBService();
            LoadAnalyticsData();
        }

        private async void LoadAnalyticsData()
        {
            var items = await _mongoDBService.GetWardrobeItemsAsync();
            var itemCounts = items.GroupBy(i => i.Name)
                                  .Select(g => new KeyValuePair<string, string>(g.Key, $"Count: {g.Count()}"))
                                  .ToList();
            _analyticsData = new ObservableCollection<KeyValuePair<string, string>>(itemCounts);
            AnalyticsListView.ItemsSource = _analyticsData;
        }
    }
}
