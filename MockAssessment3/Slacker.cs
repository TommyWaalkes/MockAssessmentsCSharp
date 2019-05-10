namespace MockAssessment3
{
    class Slacker : Villager
    {
        public Slacker()
        {
            Hunger = 3; 
        }
        public override int Farm()
        {
            return 0;
        }
    }
}