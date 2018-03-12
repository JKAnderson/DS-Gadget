using System.Collections.Generic;

namespace DS_Gadget
{
    class DSInfusion
    {
        public string Name;
        public int Value;
        public int MaxUpgrade;

        private DSInfusion(string name, int value, int maxUpgrade)
        {
            Name = name;
            Value = value;
            MaxUpgrade = maxUpgrade;
        }

        public override string ToString()
        {
            return Name;
        }

        public static List<DSInfusion> All = new List<DSInfusion>()
        {
            new DSInfusion("Normal", 000, 15),
            new DSInfusion("Raw", 300, 5),
            new DSInfusion("Lightning", 200, 5),
            new DSInfusion("Crystal", 100, 5),
            new DSInfusion("Divine", 600, 10),
            new DSInfusion("Occult", 700, 5),
            new DSInfusion("Magic", 400, 10),
            new DSInfusion("Enchanted", 500, 5),
            new DSInfusion("Fire", 800, 10),
            new DSInfusion("Chaos", 900, 5),
        };
    }
}
