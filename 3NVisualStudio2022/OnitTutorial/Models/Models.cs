using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnitTutorial.Models
{
    public class PizzaOrderModel
    {
        public int Id { get; set; }

        public string Base { get; set; } = string.Empty;

        public List<String> Toppings { get; set; } = [];

        public string Notes { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;



    }
}
