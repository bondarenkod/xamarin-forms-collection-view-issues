using System;
using Xamarin.Forms;
using main.ViewModels;

namespace main.Views
{
    public partial class Issue01CollectionViewPage : ContentPage
    {
        ItemsViewModel viewModel;

        public Issue01CollectionViewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                var _ = viewModel.ExecuteLoadItemsCommand();
            }
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            this.CollectionView.Header = viewModel.Header;
            this.CollectionView.Footer = viewModel.Footer;
        }
    }
}