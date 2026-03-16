namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0; 
            }

            public void SetPlace(int place)
            {
                if (_place == 0 && place >= 1 && place <= 18)
                {
                    _place = place;
                }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {Name} {Surname}, Место: {Place}");
            }
        }

        public struct Team
        {
            private string _name;
            private List<Sportsman> _sportsmenList;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmenList.ToArray();

            public int TotalScore
            {
                get
                {
                    int[] scoreTable = { 0, 5, 4, 3, 2, 1 }; 
                    int total = 0;

                    foreach (var sportsman in _sportsmenList)
                    {
                        if (sportsman.Place >= 1 && sportsman.Place <= 5)
                        {
                            total += scoreTable[sportsman.Place];
                        }
                    }
                    return total;
                }
            }

            public int TopPlace
            {
                get
                {
                    int minPlace = int.MaxValue;
                    foreach (var sportsman in _sportsmenList)
                    {
                        if (sportsman.Place > 0 && sportsman.Place < minPlace)
                        {
                            minPlace = sportsman.Place;
                        }
                    }
                    return minPlace == int.MaxValue ? 0 : minPlace;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmenList = new List<Sportsman>();
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmenList.Count < 6)
                {
                    _sportsmenList.Add(sportsman);
                }
                else
                {
                    Console.WriteLine("Команда уже заполнена ");
                }
            }

            public void Add(IEnumerable<Sportsman> sportsmen)
            {
                foreach (var s in sportsmen)
                {
                    Add(s);
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;

                Array.Sort(teams, (a, b) =>
                {
                    int scoreComparison = b.TotalScore.CompareTo(a.TotalScore);
                    if (scoreComparison != 0)
                        return scoreComparison;

                    return a.TopPlace.CompareTo(b.TopPlace);
                });
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name}, Баллы: {TotalScore}, Лучшее место: {TopPlace}");
                foreach (var sportsman in _sportsmenList)
                {
                    sportsman.Print();
                }
                Console.WriteLine();
            }
        }

    }
}
