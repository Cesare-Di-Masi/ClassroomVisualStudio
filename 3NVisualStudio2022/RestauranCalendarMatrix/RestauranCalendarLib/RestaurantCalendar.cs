namespace RestauranCalendarLib
{
    public class RestaurantCalendar
    {
        List<List<double?>>_calendarRestaurant;
        List<string> _resPosition;
        List<string> _bestRestaurant = new List<string>(7);

        public List<List<double?>> CalendarRestaurant
        {
            get { return _calendarRestaurant; }
        }

        public List<string> ResPosition
        { 
            get { return _resPosition; } 
        }


        public RestaurantCalendar(List<string> restaurants)
        {
            if(restaurants.Count < 0)
            {
                throw new ArgumentOutOfRangeException("Number of restaurant must be greater than 0");
            }

            _calendarRestaurant = new List<List<double?>>(restaurants.Count);
            _resPosition = restaurants;

            for(int i = 0; i < restaurants.Count;i++)
            {
                _calendarRestaurant[i].Capacity = 7;
            }

        }

        public RestaurantCalendar()
        {
            _calendarRestaurant = new List<List<double?>>(0);
            _resPosition = new List<string>(0);
        }

        public void addRestaurant(string restaurant)
        {
            if (restaurant == null)
                throw new ArgumentNullException("illegal restaurant name");

            _resPosition.Add(restaurant);

            _calendarRestaurant.Add(new List<double?>(7));


        }

        public void addRevenue(string restaurant,DaysOfTheWeek day,double? revenue)
        {
            if(restaurant == null || _resPosition.Contains(restaurant) == false)
                throw new ArgumentNullException("ileggal restaurant name");

            if (revenue < 1)
                throw new ArgumentOutOfRangeException("illegal revenue to add");

            _calendarRestaurant[_resPosition.IndexOf(restaurant)][(int)day] = revenue;

        }

        public double? getRevenue(string restaurant, DaysOfTheWeek day)
        {
            if (restaurant == null || _resPosition.Contains(restaurant) == false)
                throw new ArgumentNullException("ileggal restaurant name");

            return _calendarRestaurant[_resPosition.IndexOf(restaurant)][(int)day];
        }

        public double? getWeeklyAverage(string restaurant)
        {
            if (restaurant == null || _resPosition.Contains(restaurant) == false)
                throw new ArgumentNullException("illegal restaurant name");

            int resIndex = _resPosition.IndexOf(restaurant);

            double? sum = 0;
            int counter = 0;
            for(int i = 0; i < 7; i++)
            {
                if (_calendarRestaurant[resIndex][i] != null)
                {
                    sum += _calendarRestaurant[resIndex][i];
                    counter++;
                }
            }
            if(counter == 0)
            {
                return null;
            }
            else
            return sum / counter;
        }

        public List<string> daysWithMaxRevenue()
        {
            List<string> maxRevenue = new List<string>(7);

            int max = 0;
            int current = 0;

            for (int i = 0; i < 7; i++)
            {
                max = 0;
                current = 0;

                for(int j = 0; j < _calendarRestaurant.Count; j++)
                {
                    if(_calendarRestaurant[j][i] != null)
                    {
                        if(_calendarRestaurant[j][i] > max)
                        {
                            max = (int)_calendarRestaurant[j][i];
                            current = j;
                        }
                    }
                }
                maxRevenue.Add(_resPosition[current]);
                
            }

            return maxRevenue;

        }

        public double? totalWeeklyRevenueOfARestaurant(string restaurant)
        {
            double? tot = 0;
            int resIndex = _resPosition.IndexOf(restaurant);

            for(int i = 0; i < 7; i++)
            {
                if(_calendarRestaurant[resIndex][i] != null)
                {
                    tot += _calendarRestaurant[resIndex][i];
                }
            }
            if(tot == 0)
            {
                return 0;
            }
            else
            return tot;
        }

        public int closedDaysOfARestaurant(string restaurant)
        {
            int closed = 0;
            int resIndex = _resPosition.IndexOf(restaurant);

            for (int i = 0; i < 7; i++)
            {
                if (_calendarRestaurant[resIndex][i] == null)
                {
                    closed++;
                }
            }
            return closed;
        }
        
        public void bestRestaurants()
        {
            int max = 0;
            int current = 0;
            int currDay = 0;

            for(int i=0; i<7; i++)
            {
                max = 0;
                current = 0;
                currDay = 0;

                for(int j = 0; j < _resPosition.Count; j++)
                {
                    if(_calendarRestaurant[i][j] != null)
                    {
                        if(_calendarRestaurant[j][i] > max)
                        {
                            max = (int)_calendarRestaurant[j][i];
                            current = i;
                        }
                    }
                }
                _bestRestaurant[currDay] = _resPosition[current];
                currDay++;
            }


          
        }

        public int bestDaysOfARestaurant(string restaurant)
        {
            if(restaurant == null || _resPosition.Contains(restaurant) == false)
            {
                throw new ArgumentNullException("illegal restaurant name");
            }

            int counter = 0;

            if(_bestRestaurant.Contains(restaurant) == false)
            {
                return 0;
            }
            else
            {
                for(int i = 0; i < 7; i++)
                {
                    if(_bestRestaurant[i] == restaurant)
                    {
                        counter++;
                    }
                }
                return counter;
            }

        }



    }
}
