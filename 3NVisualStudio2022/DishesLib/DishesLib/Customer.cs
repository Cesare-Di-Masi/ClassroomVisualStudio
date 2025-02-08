using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DishesLib
{
    public class Customer
    {
        private string _name;
        private Dish[] _favDishes;

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("illegal restaurant name");

                _name = value;
            }
        }

        public Dish[] FavDishes
        {
            get
            {
                return _favDishes;
            }
        }

        public Customer(string name) 
        {
            Name = name;
            _favDishes = new Dish[10];
        }

        public Customer(string name, Dish[] favDishes) : this(name)
        {
            for (int i = 0; i < favDishes.Length - 1; i++)
            {
                if (favDishes[i].CompareTo(favDishes[i + 1]) == 0 || favDishes[i].Name == favDishes[i + 1].Name)
                    throw new ArgumentException("cannot have same dish");
            }
            _favDishes = favDishes;
        }

        public void modifyFavDish(int dishPos, Dish newDish)
        {
            if (dishPos < 1 || dishPos > _favDishes.Length)
                throw new ArgumentOutOfRangeException("illegal position of dish");

            for (int i = 0; i < _favDishes.Length; i++)
            {
                if (_favDishes[i].CompareTo(newDish) == 0 || _favDishes[i].Name == newDish.Name)
                    throw new ArgumentException("cannot have same dish");
            }

            _favDishes[dishPos - 1] = newDish;

        }

        public int[] lowestPriceForEveryCourseFavDishes()
        {

            int[] priceList = new int[5];

            for (int i = 0; i < _favDishes.Length; i++)
            {
                TypeOfCourse currCourse = _favDishes[i].Course;
                int currPrice = _favDishes[i].Price;

                if (currCourse == TypeOfCourse.Appetizer)
                {
                    if (priceList[0] > currPrice)
                        priceList[0] = currPrice;

                }
                else if (currCourse == TypeOfCourse.FirstCourse)
                {
                    if (priceList[1] > currPrice)
                        priceList[1] = currPrice;
                }
                else if (currCourse == TypeOfCourse.SecondCourse)
                {
                    if (priceList[2] > currPrice)
                        priceList[2] = currPrice;
                }
                else if (currCourse == TypeOfCourse.Countour)
                {
                    if (priceList[3] > currPrice)
                        priceList[3] = currPrice;
                }
                else if (currCourse == TypeOfCourse.Dessert)
                {
                    if (priceList[4] > currPrice)
                        priceList[4] = currPrice;
                }

            }

            return priceList;

        }

        public Dish favDishWithLongestName()
        {

            Dish longestNameDish = _favDishes[0];

            for (int i = 1; i < _favDishes.Length; i++)
            {

                if (String.Compare(longestNameDish.Name, _favDishes[i].Name) == 1)
                {
                    longestNameDish = _favDishes[i];
                }

            }

            return longestNameDish;

        }

        public Dish[] dishesOfARestaurant(string restaurantName)
        {
            if (String.IsNullOrEmpty(restaurantName))
                throw new ArgumentNullException("illegal requested restaurant name");

            Dish[] dishList = new Dish[_favDishes.Length];

            int counter = 0;

            for(int i=0; i<_favDishes.Length; i++)
            {

                if (_favDishes[i].Name == restaurantName)
                {
                    dishList[counter] = _favDishes[i];
                    counter++;
                }

            }

            return dishList;

        }



    }
}
