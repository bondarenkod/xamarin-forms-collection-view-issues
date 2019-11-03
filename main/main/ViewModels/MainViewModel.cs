using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using main.Views;
using Prism.Mvvm;
using Xamarin.Forms;

namespace main.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Page _mainPage;
        public ObservableCollection<Option> Options { get; private set; }
        public MainViewModel(Page mainPage)
        {
            _mainPage = mainPage;
            Title = "Main";
            Options = new ObservableCollection<Option>();
            LoadData();

        }

        private void NavigateTo<TPage>() where TPage : Page
        {
            Page page = (Page)Activator.CreateInstance(typeof(TPage));
            var _ = _mainPage.Navigation.PushAsync(page);
        }

        protected void LoadData()
        {
            var items = new Option[]
            {
                new Option("01. Header&Footer binding issue, collection view", NavigateTo<Issue01CollectionViewPage>),

                new Option("01. Header&Footer binding issue, list view", NavigateTo<Issue01ListViewPage>),

                new Option("02. Carousel ", () =>
                {

                }),

            };

            foreach (var option in items)
            {
                Options.Add(option);
            }
        }
        //public ICommand OpenWebCommand { get; }
    }

    public class Option : BindableBase
    {
        public Option(string name, Action onTap)
        {
            Name = name;
            OnTapCommand = new Command(onTap);
        }
        public string Name { get; private set; }
        public ICommand OnTapCommand { get; private set; }
    }
}