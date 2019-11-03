using main.ViewModels;

namespace main.Views
{

    public partial class Issue01ListViewPage
    {
        ItemsViewModel viewModel;

        public Issue01ListViewPage()
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
    }
}