using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockAssessment3
{
    class Town
    {
        public List<Villager> Villagers { get; set; }

        public Town()
        {
            Villagers = new List<Villager>();
            Villagers.Add(new Farmer());

            for(int i =0; i < 3; i++)
            {
                Villagers.Add(new Slacker());
            }
        }

        public int Harvest()
        {
            int total = 0;
            foreach(Villager v in Villagers)
            {
                total += v.Farm();
            }
            return total;
        }

        public int CalcFoodConsumption()
        {
            int total = 0;
            foreach(Villager v in Villagers)
            {
                total += v.Hunger;
            }

            return total;
        }

        public bool SurviveTheWinter()
        {
            int hunger = CalcFoodConsumption();
            int food = Harvest();

            if(food>= hunger)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
