using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTutorial.Models;


namespace XamarinTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {

        public CoffeeEquipmentPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var coffee = ((MenuItem)sender).BindingContext as Coffee;
            if (coffee == null)
                return;

            await DisplayAlert("Coffee Favorited", coffee.Name, "Ok");
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var coffee = ((MenuItem)sender).BindingContext as Coffee;
            if (coffee == null)
                return;

            if (await DisplayAlert("Delete", $"Delete \"{coffee.Name}\"?", "Yes", "No"))
            {
                int roaster_list = (coffee.Roaster == "Blue Bottle" ? 0 : 1);

                

                int lim = ((ObservableRangeCollection<Grouping<string, Coffee>>)CoffeeLists.ItemsSource)[roaster_list].Count;

                for (int i = 0; i < lim; i++)
                {
                    if (((ObservableRangeCollection<Grouping<string, Coffee>>)CoffeeLists.ItemsSource)[roaster_list].ElementAt(i).Name == coffee.Name)
                    {
                            ((ObservableRangeCollection<Grouping<string, Coffee>>)CoffeeLists.ItemsSource)[roaster_list].RemoveAt(i);
                            i = lim;
                    }
                }

            }
                
        }
    }
}