using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MockAssessment3
{
    public class MockAssessment3Test
    {
        [Theory]
        [InlineData("farmer")]
        [InlineData("slacker")]
        public void Test1_Farmer_4pts(string s)
        {
            Villager v;
            if (s == "farmer")
            {
                v = new Farmer();
            }
            else
            {
                v = new Slacker();
            }
                
            Assert.NotNull(v);
            int actual = v.Farm();
            int hungerActual = v.Hunger;
            if (s == "farmer")
            {
                Assert.Equal(2, actual);
                Assert.Equal(1, hungerActual);
            }
            else
            {
                Assert.Equal(0, actual);
                Assert.Equal(3, hungerActual);
            }
        }

        [Fact]
        public void Test2_TownHasVillagers_1pt()
        {
            Town t = new Town();

            int actual = t.Villagers.Count;
            int expected = 4;

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Test3_TownHasRightVillagers_1pt()
        {
            Town t = new Town();
            List<Villager> vills = t.Villagers;

            int actual = vills[0].Farm();
            int expected = 2;
            //This is a farmer
            Assert.Equal(expected, actual);

            for(int i = 1; i<vills.Count; i++)
            {
                //These are slackers
                Villager v = vills[i];
                Assert.Equal(0, v.Farm());
            }
        }

        [Fact]
        public void Test4_TestHarvest_1pt()
        {
            Town t = new Town();
            List<Villager> vills = new List<Villager>();

            for(int i = 0; i < 2; i++)
            {
                vills.Add(new Slacker());
                vills.Add(new Farmer());
            }

            t.Villagers = vills;

            int actual = t.Harvest();
            int expected = 4;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test4_TestCalcFoodConsumption_1pt()
        {
            Town t = new Town();
            List<Villager> vills = new List<Villager>();

            for (int i = 0; i < 2; i++)
            {
                vills.Add(new Slacker());
                vills.Add(new Farmer());
            }

            t.Villagers = vills;

            int actual = t.CalcFoodConsumption();
            int expected = 8;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test6_TestSurviveTheWinterFail_1pt()
        {
            Town t = new Town();

            bool actual = t.SurviveTheWinter();

            Assert.False(actual);
        }

        [Fact]
        public void Test7_TestSurviveTheWinterPass_1pt()
        {
            Town t = new Town();
            List<Villager> vills = new List<Villager>();

            for (int i = 0; i < 2; i++)
            {
                vills.Add(new Farmer());
            }

            t.Villagers = vills;

            bool actual = t.SurviveTheWinter();

            Assert.True(actual);
        }
    }
}
