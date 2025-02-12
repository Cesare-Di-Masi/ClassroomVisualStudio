using PetShopLib;

namespace PetShop
{
    public class Pet
    {

        private string _name;
        private Species _species;
        private int _age;
        private double _price;
        private PetState _petState = PetState.Purchasable;
        private DateTime _birthday;
        private Customer? _customer = null;

        public string Name
        {

            get
            {
                return _name;
            }
            set
            {
                if(String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal pet name");
                _name = value;
            }

        }

        public Species Species
        {
            get { return _species; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
        }

        public int Age
        {
            get 
            {
                return DateTime.Today.Year - Birthday.Year;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("illegal pet price");
                _price = value;
            }
        }

        public Customer? Customer
        {
            get
            {
                return _customer;
            }
        }

        public PetState PetState
        {
            get { return _petState; }
        }

        public Pet(string name, Species species, DateTime birthday, double price )
        {
            Name = name;
            _species = species;
            _birthday = birthday;
            Price = price;
        }

        public Pet(string name, Species species, DateTime birthday, double price, Customer customer):this(name,species,birthday,price)
        {
            _customer = customer;
            _petState = PetState.Sold;
        }

        public void BuyPet( Customer customer)
        {
            if (_petState != PetState.Purchasable)
                throw new ArgumentException($"cannot buy the pet in this state {_petState}");
            _petState = PetState.Sold;
            _customer = customer;
        }

        public void PetDies()
        {
            _petState = PetState.Decesead;
        }

        public override bool Equals(object? obj)
        {
            
            if(!(obj is Pet)|| obj ==null) return false;

            Pet other = obj as Pet;

            if (other.Name == Name && other.Species == Species && other.Birthday == Birthday && other.Price == Price && other.Customer.Equals(Customer))
                return true;
            return false;

        }


    }
}
