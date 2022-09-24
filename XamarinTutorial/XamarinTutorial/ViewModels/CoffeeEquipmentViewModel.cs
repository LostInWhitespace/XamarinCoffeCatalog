using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Linq;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using MvvmHelpers;
using XamarinTutorial.Models;
using Xamarin.Forms;

namespace XamarinTutorial.ViewModels
{
    public class CoffeeEquipmentViewModel : BaseViewModel
    {

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";

            Coffee = new ObservableRangeCollection<Coffee>();

            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();
            var image = "https://media.istockphoto.com/photos/roasted-coffee-beans-in-a-burlap-sack-picture-id1058410944";

        

            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Sip of Sunshine", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Potent Potable", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Radical Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Kickin' Kona", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "The 2nd Best Part of Waking Up", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Nectar of the Colombian Bean Fields", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "I Can't Believe It's Not Caffeinated", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Morning Glory", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Soothing Lavender Blend", Image = image });


            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Sumeria Kiambu Handege", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Michigan Cherry Medium Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Spanish Dark Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Deep Blue Blend", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "House Roast", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Death Cup", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Arabian Light Roast Blend", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Starry Night Dark Roast", Image = image });

            


            CoffeeGroups.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(cof => cof.Roaster == "Blue Bottle")));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Yes Plz", Coffee.Where(cof => cof.Roaster == "Yes Plz")));

            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);


        }

        
        public ObservableRangeCollection<Coffee> Coffee { get; set; }

        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Coffee> FavoriteCommand { get; }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }

        async Task Favorite(Coffee coffee)
        {
            if(coffee == null)
            {
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Favorite", $"Favorited \"{coffee.Name}\"", "Ok");


        }




    }
}
