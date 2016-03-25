using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VladkosNotebook
{
    class VladkosNotebook
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] columns = line.Split('|');
                string color = columns[0];

                Player player = players.FirstOrDefault(p => p.Color == color);

                if (player == null)
                {
                    player = new Player(color);
                    players.Add(player);
                }

                string playersInfo = columns[1];

                switch (playersInfo)
                {
                    case "win":
                    case "loss":
                        if (playersInfo == "win")
                        {
                            player.Wins++;
                        }
                        else
                        {
                            player.Losses++;
                        }
                        string oponent = columns[2];
                        player.Oponents.Add(oponent);
                        break;

                    case "name":
                        string name = columns[2];
                        player.Name = name;
                        break;

                    case "age":
                        uint age = uint.Parse(columns[2]);
                        player.Age = age;
                        break;
                }

                line = Console.ReadLine();
            }
            IOrderedEnumerable<Player> orderedPlayers = players.OrderBy(p=>p.Color);
            Console.WriteLine(players.All(p => p.Name == null || p.Age == null) ? "No data recovered." : string.Join("", orderedPlayers));
        }

        
    }

    class Player
    {
        public Player(string color)
        {
            this.Color = color;
            this.Oponents = new List<string>();
        }

        public string Color { get; private set; }

        public List<string> Oponents { get; set; }

        public string Name { get; set; }

        public uint? Age { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        private double CalculateRank()
        {
            double rank = (double)(this.Wins + 1) / (this.Losses + 1);
            return rank;
        }

        private List<string> SortOponents()
        {
            this.Oponents.Sort(StringComparer.Ordinal);
            return this.Oponents;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            if (this.Name != null && this.Age != null)
            {
                output.AppendLine(String.Format("Color: {0}", this.Color));
                output.AppendLine(String.Format("-age: {0}", this.Age));
                output.AppendLine(String.Format("-name: {0}", this.Name));
                output.AppendLine(String.Format("-opponents: {0}", this.Oponents.Count > 0 ? string.Join(", ", this.SortOponents()) : "(empty)"));
                output.AppendLine(String.Format("-rank: {0:F}", this.CalculateRank()));
            }

            return output.ToString();
        }
    }
}
