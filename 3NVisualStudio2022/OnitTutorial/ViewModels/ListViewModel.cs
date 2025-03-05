using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OnitTutorial.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnitTutorial
{
    public partial class ListViewModel: ObservableObject
    {
        public ObservableCollection<PizzaOrderModel> OrdersList { get; set; } = [];

        public ListViewModel() { }

        //questo metodo verrà gestito come un comando
        [RelayCommand]
        public void OnAppearing()
        {
            if (OrdersList.Count == 0)
            {
                OrdersList.Add(new PizzaOrderModel
                {
                    Id = 1,
                    Base = "al sole",
                    Toppings = ["sole","altro sole","ulteriore sole"],
                    Notes = "per il nostro signore sole - Soleil",
                    Quantity = 5
                });
                OrdersList.Add(new PizzaOrderModel
                {
                    Id = 2,
                    Base = "margherita",
                    Toppings=["pomodoro,mozzarella"],
                    Notes ="pizza molto triste"
                });
                OrdersList.Add(new PizzaOrderModel
                {
                    Id =3,
                    Base = "rossa",
                    Toppings=["salame piccante","olio piccante","peperoncino piccante","salciccia piccane"],
                    Notes="Molto piccante, doppio salamino e salciccia"
                });
            }
        }

    }
}
