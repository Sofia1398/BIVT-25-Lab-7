namespace Lab7.Blue
{
    public class Task3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes; 

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes => (int[])_penaltyTimes.Clone();
            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    foreach (int mark in _penaltyTimes)
                    {
                        sum += mark;
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    foreach (int mark in _penaltyTimes)
                    {

                        if (mark == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0]; 
            }

            public void PlayMatch(int time)
            {
                if (time == 0 || time == 2 || time == 5 || time == 10)
                {
                    Array.Resize(ref _penaltyTimes, _penaltyTimes.Length + 1);
                    _penaltyTimes[_penaltyTimes.Length - 1] = time;
                }
            }

            
            public static void Sort(Participant[] array)
            {
                var sorted = array.OrderBy(p => p.TotalTime).ToArray();

                Array.Copy(sorted, array, array.Length);
            }

            public void Print()
            {
                Console.WriteLine($"Игрок: {Name} {Surname}");
                Console.WriteLine($"Общее штрафное время: {TotalTime} минут");
                Console.WriteLine($"Штрафы по матчам:");
                foreach (var time in _penaltyTimes)
                {
                    if (time != 0) Console.Write($"{time} ");
                }
            }
        }

    }
}
