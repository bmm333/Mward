using Microsoft.Maui.Controls;

namespace Mward.Views
{
    public partial class StylistPage : ContentPage
    {
        public StylistPage()
        {
            InitializeComponent();
        }

        private async void OnGetSuggestionClicked(object sender, EventArgs e)
        {
            // Implement AI logic to get outfit suggestion
            SuggestionLabel.Text = "Try wearing your blue jeans with a white shirt!";
        }
    }
}
