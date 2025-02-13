using PetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PetShopLib
{
    public class Customer
    {
        private List<Pet> _boughtPets;
        private string _name, _surname;
        private MailAddress _mailaddress;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal customer name");
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("illegal customer surname");
                _surname = value;
            }
        }

        public MailAddress MailAddress
        {
            get
            {
                return _mailaddress;
            }
        }

        public List<Pet> BoughtPetList
        {
            get
            {
                return _boughtPets;
            }
        }

        public Customer(string name, string surname, MailAddress mailAddress)
        {
            Name = name;
            Surname = surname;
            _mailaddress = mailAddress;
        }

        public void addPet(Pet pet)
        {
            _boughtPets.Add(pet);
        }

        public void addListOfPets(List<Pet> listOfPets)
        {
            for (int i = 0; i < listOfPets.Count; i++)
            {
                addPet(listOfPets[i]);
            }
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Customer) || obj == null) return false;

            Customer other = (Customer)obj;

            if (other.Name == _name && other.Surname == _surname && other.MailAddress.Equals(_mailaddress)) return true;
            return false;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} mail: {MailAddress.ToString()}";
        }
    }
}