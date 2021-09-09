namespace day06
{
    public class Instruction
    {
        public string Order = "";
        public int X1 = 0;
        public int Y1 = 0;
        public int X2 = 0;
        public int Y2 = 0;

        public void Apply(ref bool[,] lights, int y, int x)
        {
            if (Order == "turn off")
            {
                lights[y , x] = false;
            }
            if (Order == "turn on")
            {
                lights[y , x] = true;
            }
            if (Order == "toggle")
            {
                lights[y , x] = ! lights[y , x];
            }
        }
        
        public void ApplyInt(ref int[,] lights, int y, int x)
        {
            if (Order == "turn off")
            {
                if (lights[y, x] > 0)
                {
                    lights[y , x]--;
                }
            }
            if (Order == "turn on")
            {
                lights[y , x]++;
            }
            if (Order == "toggle")
            {
                lights[y , x] += 2;
            }
        }
    }
}