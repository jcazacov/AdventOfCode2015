namespace day03
{
    public class Coordinates
    {
        // Fields
        public int X;
        public int Y;

        // Methods
        public void Move(char instr)
        {
            if (instr == '^')
            {
                Y++;
            }
            if (instr == 'v')
            {
                Y--;
            }
            if (instr == '<')
            {
                X--;
            }
            if (instr == '>')
            {
                X++;
            }
        }

        // Constructor
        public Coordinates()
        {
            X = 0;
            Y = 0;
        }

        // Properties
        public string Key
        {
            get
            {
                return $"{X};{Y}";
            }
        }
    }
}