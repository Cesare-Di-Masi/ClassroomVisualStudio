namespace DishesLib
{
    public class Dish:IComparable<Dish>
    {
        private string _name, _restaurant;
        private int _price;
        private TypeOfCourse _course;

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if(String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("illegal dish name");

                _name = value;
            }
        }

        public string Restaurant
        {

            get
            {
                return _restaurant;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("illegal restaurant name");

                _restaurant = value;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }
            private set
            {
                if(value < 1)
                    throw new ArgumentOutOfRangeException("illegal dish price");
                _price = value;
            }
        }

        public TypeOfCourse Course
        {
            get
            {
                return _course;
            }
            private set
            { 
                _course = value;
            }
        }


        public Dish(string name, string restaurant, int price, TypeOfCourse course) 
        {
            Name = name;
            Restaurant = restaurant;
            Price = price;
            Course = course;
        }


        public int CompareTo(Dish? other)
        {
            if (other == null || (!(other is Dish)))
                throw new ArgumentException("not comparable object");

            if(Course > other.Course)
            {
                return 1;
            }
            else if(Course == other.Course)
            {

                if(String.Compare(Name,other.Name) == -1)
                {
                    return 1;
                }
                else if(String.Compare(Name, other.Name) == 0)
                {
                    if (Price == other.Price)
                    {
                        return 0;
                    }
                    else if (Price > other.Price)
                    {
                        return -1;
                    }
                }

            }

            return 1;

        }


        public override string ToString()
        {
            return $"Property of:{Restaurant} Name:{Name} Course:{Course} Price (not taxed):{Price}";
        }

    }
}
