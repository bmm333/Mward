using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Mward.Views
{
    public partial class WardrobePage : ContentPage
    {
        private ObservableCollection<string> _wardrobeItems;

        public WardrobePage()
        {
            InitializeComponent();
            _wardrobeItems = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };
            WardrobeListView.ItemsSource = _wardrobeItems;
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            // Implement adding a new item to the wardrobe
            _wardrobeItems.Add("New Item");
        }
    }
}
