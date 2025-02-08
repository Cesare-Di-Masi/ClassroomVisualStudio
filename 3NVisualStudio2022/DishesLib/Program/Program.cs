using DishesLib;
class Program
{
    static void Main(string[] args)
    {

        Dish[] ristoranteRomaDishes =
            {
                new Dish("Spaghetti Carbonara", "Ristorante Roma", 15, TypeOfCourse.FirstCourse),
                new Dish("Margherita Pizza", "Ristorante Roma", 12, TypeOfCourse.FirstCourse),
                new Dish("Tiramisu", "Ristorante Roma", 8, TypeOfCourse.Dessert),
                new Dish("Bruschetta", "Ristorante Roma", 6, TypeOfCourse.Appetizer),
                new Dish("Fettuccine Alfredo", "Ristorante Roma", 16, TypeOfCourse.FirstCourse),
                new Dish("Ravioli al Tartufo", "Ristorante Roma", 18, TypeOfCourse.FirstCourse),
                new Dish("Panna Cotta", "Ristorante Roma", 9, TypeOfCourse.Dessert)
        };

        Dish[] tokyoSushiDishes =
        {
                new Dish("Sushi Roll", "TokyoSushi", 18, TypeOfCourse.SecondCourse),
                new Dish("Miso Soup", "TokyoSushi", 5, TypeOfCourse.Appetizer),
                new Dish("Tempura", "TokyoSushi", 14, TypeOfCourse.SecondCourse),
                new Dish("Matcha Ice Cream", "TokyoSushi", 7, TypeOfCourse.Dessert),
                new Dish("Salmon Sashimi", "TokyoSushi", 20, TypeOfCourse.Appetizer),
                new Dish("Nigiri", "TokyoSushi", 22, TypeOfCourse.SecondCourse)
        };

        Dish[] americanGraffitiDishes =
        {
                new Dish("Burger Deluxe", "American Grill", 13, TypeOfCourse.MainCourse),
                new Dish("Buffalo Wings", "American Grill", 10, TypeOfCourse.Appetizer),
                new Dish("Caesar Salad", "American Grill", 9, TypeOfCourse.Countour),
                new Dish("Cheesecake", "American Grill", 8, TypeOfCourse.Dessert),
                new Dish("BBQ Ribs", "American Grill", 20, TypeOfCourse.MainCourse),
                new Dish("Hot Dog Classic", "American Grill", 7, TypeOfCourse.MainCourse),
                new Dish("Churros", "American Grill", 6, TypeOfCourse.Dessert)
        };

        Dish?[] errorList = new Dish?[1] { null };

        Restaurant Restaurant1 = new Restaurant("ristorante Roma", ristoranteRomaDishes);

        Restaurant Restaurant2 = new Restaurant("TokyoSushi", tokyoSushiDishes);

        Restaurant Restaurant3 = new Restaurant("American Graffiti", americanGraffitiDishes);

        Restaurant Restaurant = new Restaurant("error",errorList);

        Customer customer;

        bool error = false;

        string name;



        do
        {

            error = false;

            try
            {

                Console.WriteLine("write your name please");
                name = Console.ReadLine();

                customer = new Customer(name);

            }
            catch (Exception ex)
            {
                Console.WriteLine("something went wrong, retry");
                error = true;
            }

        } while (error);


        int chosenRestaurant=0;

        do
        {
            error = false;

            try
            {
                Console.WriteLine("Which Restaurant would you prefer to visit?");
                Console.WriteLine($"{Restaurant1.Name}=1");
                Console.WriteLine($"{Restaurant2.Name}=2");
                Console.WriteLine($"{Restaurant3.Name}=3");

                chosenRestaurant = int.Parse(Console.ReadLine())-1;


                switch (chosenRestaurant)
                {
                    case 0: Restaurant = Restaurant1; break;
                    case 1: Restaurant = Restaurant2; break;
                    case 2: Restaurant = Restaurant3; break;
                    default: throw new Exception("something went wrong, retry"); break;
                }

            }
            catch (Exception ex)
            {
                error = true;
            }
        } while (error);

        do
        {

            error =false;

            try
            {

                Console.WriteLine("would you like to see the list of dishes? (yes/no)");

                string answer = Console.ReadLine();
                int counter = 0;

                if (answer == "yes")
                {
                    for (int i = 0; i < Restaurant.Dishes.Length; i++)
                    {
                        Console.WriteLine($"{counter}: {Restaurant.Dishes[i].ToString}");
                        Console.WriteLine("\n");
                    }
                }
                else if (answer != "no")
                {
                    throw new Exception("something went wrong, retry");
                }


            }
            catch (Exception ex)
            {
                error = true;
            }

        } while (error);


    }
}