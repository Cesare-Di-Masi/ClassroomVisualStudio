using PetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopLib
{
    public class Order : IComparable<Order>
    {
        private Customer _customer;
        private List<Pet> _petList;
        private DateTime _dateOfCreationOfTheOrder;

        public Customer Customer
        {
            get { return _customer; }
        }

        public List<Pet> PetList
        {
            get { return _petList; }
        }

        public DateTime DateOfCreationOfTheOrder
        {
            get { return _dateOfCreationOfTheOrder; }
        }

        public double TotPrice
        {
            get
            {
                double tot = 0;

                for (int i = 0; i < _petList.Count; i++)
                {
                    tot += _petList[i].Price;
                }
                return tot;
            }
        }

        public Order(Customer customer, List<Pet> petList, DateTime dateOfCreationOfTheOrder)
        {
            for (int i = 0; i < petList.Count; i++)
            {
                if (petList[i].PetState == PetState.Sold)
                    throw new ArgumentException("an animal as been already sold");
                else
                    petList[i].BuyPet(customer);
            }

            customer.addListOfPets(petList);

            _customer = customer;
            _petList = petList;
            _dateOfCreationOfTheOrder = dateOfCreationOfTheOrder;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Order)) return false;

            Order other = (Order)obj;

            bool eq = true;

            for (int i = 0; i < _petList.Count; i++)
            {
                if (!(other.PetList[i].Equals(PetList[i])))
                    eq = false;
            }

            if (other.Customer.Equals(Customer) && eq == true && other.TotPrice == TotPrice) return true;
            return false;
        }

        public int CompareTo(Order? other)
        {
            if (other == null) return 1;

            Order order = other as Order;

            return DateOfCreationOfTheOrder.CompareTo(order.DateOfCreationOfTheOrder);
        }
    }
}