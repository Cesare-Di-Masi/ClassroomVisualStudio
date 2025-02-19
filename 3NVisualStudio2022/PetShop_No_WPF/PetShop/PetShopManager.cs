using PetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopLib
{
    public class PetShopManager
    {
        private List<Pet?> _petList;
        private List<Customer?> _customerList;
        private List<Order?> _orderList;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal petShop name");
                _name = value;
            }
        }

        public List<Pet> PetList
        {
            get { return _petList; }
        }

        public List<Customer> CustomerList
        {
            get { return _customerList; }
        }

        public List<Order> OrderList
        {
            get { return _orderList; }
        }

        //costruttore da qui in poi

        private PetShopManager(string shopName)
        {
            Name = shopName;
            _petList = null;
            _customerList = null;
            _orderList = null;
        }

        private PetShopManager(string shopName, List<Pet> petList) : this(shopName)
        {
            _petList = petList;
            _customerList = null;
            _orderList = null;
        }

        private PetShopManager(string shopName, List<Pet> petList, List<Customer> customerList) : this(shopName, petList)
        {
            _customerList = customerList;
            _orderList = null;
        }

        private PetShopManager(string shopName, List<Pet> petList, List<Customer> customerList, List<Order> orderlist) : this(shopName, petList, customerList)
        {
            _orderList = orderlist;

            for (int i = 0; i < orderlist.Count; i++)
            {
                for (int j = 0; j < orderlist[i].PetList.Count; j++)
                {
                    if (_petList.Contains(orderlist[i].PetList[j]) == false)
                    {
                        throw new Exception($"animal {j} in order {i} does not exist in the shop");
                    }
                }
            }
        }

        public int totAnimalsNumber()
        {
            return _petList.Count;
        }

        public int totSpeciesNumber(Species species)
        {
            int counter = 0;

            for (int i = 0; i < _petList.Count; i++)
            {
                if (_petList[i].Species == species)
                    counter++;
            }
            return counter;
        }

        public double totSales()
        {
            double tot = 0;

            for (int i = 0; i < _orderList.Count; i++)
            {
                tot += _orderList[i].TotPrice;
            }
            return tot;
        }

        public Customer CustomerWithTheMostPets()
        {
            int max = 0;
            int pos = 0;

            for (int i = 0; i < _customerList.Count; i++)
            {
                if (_customerList[i].BoughtPetList.Count > max)
                {
                    max = _customerList[i].BoughtPetList.Count;
                    pos = i;
                }
            }
            return _customerList[pos];
        }

        public void addAnimal(Pet newPet)
        {
            if (_petList.Contains(newPet) == true)
                throw new ArgumentException("this animal already exists");

            _petList.Add(newPet);
        }

        public void removeAnimal(Pet petToRemove)
        {
            if (_petList.Contains(petToRemove) == false)
                throw new ArgumentException("this animal does not exists");

            _petList.Remove(petToRemove);
        }

        public void addCustomer(Customer newCustomer)
        {
            if (_customerList.Contains(newCustomer) == true)
                throw new ArgumentException("this customer already exists");

            _customerList.Add(newCustomer);
        }

        public void removeCustomer(Customer customerToRemove)
        {
            if (_customerList.Contains(customerToRemove) == false)
                throw new ArgumentException("this customer does not exists");

            _customerList.Remove(customerToRemove);
        }

        public void addOrder(Order newOrder)
        {
            if (_orderList.Contains(newOrder) == true)
                throw new ArgumentException("this order already exists");

            _orderList.Add(newOrder);
        }

        public void removeOrder(Order orderToRemove)
        {
            if (_orderList.Contains(orderToRemove) == false)
                throw new ArgumentException("this order does not exists");
            _orderList.Remove(orderToRemove);
        }

        public List<Pet> searchAnimalBySpecies(Species species)
        {
            List<Pet> list = new List<Pet>();

            for (int i = 0; i < _petList.Count; i++)
            {
                if (_petList[i].Species == species)
                {
                    list.Add(_petList[i]);
                }
            }

            return list;
        }

        public List<Pet> searchAnimalByPrice(int price)
        {
            List<Pet> list = new List<Pet>();

            for (int i = 0; i < _petList.Count; i++)
            {
                if (price == _petList[i].Price)
                {
                    list.Add(_petList[i]);
                }
            }
            return list;
        }

        public List<Pet> searchAnimalByCustomer(Customer customer)
        {
            List<Pet> list = new List<Pet>();

            for (int i = 0; i < _petList.Count; i++)
            {
                if (_petList[i].Customer.Equals(customer))
                    list.Add(_petList[i]);
            }
            return list;
        }

        public List<Order> searchOrderByCustomer(Customer customer)
        {
            List<Order> list = new List<Order>();

            for (int i = 0; i < _orderList.Count; i++)
            {
                if (_orderList[i].Customer.Equals(customer))
                    list.Add(_orderList[i]);
            }

            return list;
        }
    }
}