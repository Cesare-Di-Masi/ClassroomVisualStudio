using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public partial class MainWindowViewModel:ObservableObject
    {
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private bool isMale;

        public ObservableCollection<Animal> Animals;


    }
}
