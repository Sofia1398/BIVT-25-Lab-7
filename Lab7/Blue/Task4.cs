namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores => _scores;

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    foreach (int score in _scores)
                    {
                        sum += score;
                    }
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0]; 
            }

            public void PlayMatch(int result)
            {
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print()
            {
                Console.WriteLine($"Team: {Name}, Total Score: {TotalScore}, Scores: [{string.Join(", ", Scores)}]");
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _count;

            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            public void Add(Team team)
            {
                if (_count < 12)
                {
                    _teams[_count] = team;
                    _count++;
                }
            }

            public void Add(Team[] teams)
            {
                foreach (Team team in teams)
                {
                    if (team.Name != null) 
                        Add(team);
                }
            }

            public void Sort()
            {
                for (int i = 0; i < _count - 1; i++)
                {
                    for (int j = 0; j < _count - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                group1.Sort();
                group2.Sort();

                int takeFromEach = Math.Min(6, size / 2);

                for (int i = 0; i < takeFromEach; i++)
                {
                    result.Add(group1.Teams[i]);
                    result.Add(group2.Teams[i]);
                }

                result.Sort(); 
                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Group: {Name}");
                for (int i = 0; i < _count; i++) 
                {
                    _teams[i].Print();
                }
            }
        }
        
    }
}
