using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using main.Models;
using main.Views;

namespace main.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _header;
        private Item _footer;
        public ObservableCollection<Item> Items { get; set; }

        public Item Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        public Item Footer
        {
            get => _footer;
            set => SetProperty(ref _footer, value);
        }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);

                items = items.Take(2);

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

            NewHeader();
            NewFooter();

            var _ = Task.Run(async () =>
            {
                var stop = 42;
                while (stop > 0)
                {
                    await Task.Delay(1000);
                    Device.BeginInvokeOnMainThread(NewHeader);
                    Device.BeginInvokeOnMainThread(NewFooter);
                    --stop;
                }
            });
        }

        private void NewHeader()
        {
            this.Header = new Item() { Id = DateTimeOffset.Now.ToString("G") };
        }

        private void NewFooter()
        {
            this.Footer = new Item() { Id = DateTimeOffset.Now.ToString("G") };
        }
    }
}