using System.Collections.Generic;

namespace DS_Gadget
{
    class DSInfusion
    {
        public string Name;
        public int Value;
        public int MaxUpgrade;
        public bool Restricted;

        private DSInfusion(string name, int value, int maxUpgrade, bool restricted)
        {
            Name = name;
            Value = value;
            MaxUpgrade = maxUpgrade;
            Restricted = restricted;
        }

        public override string ToString()
        {
            return Name;
        }

        public static List<DSInfusion> All = new List<DSInfusion>()
        {
            new DSInfusion("Normal", 000, 15, false),
            new DSInfusion("Chaos", 900, 5, true),
            new DSInfusion("Crystal", 100, 5, false),
            new DSInfusion("Divine", 600, 10, false),
            new DSInfusion("Enchanted", 500, 5, true),
            new DSInfusion("Fire", 800, 10, false),
            new DSInfusion("Lightning", 200, 5, false),
            new DSInfusion("Magic", 400, 10, false),
            new DSInfusion("Occult", 700, 5, true),
            new DSInfusion("Raw", 300, 5, true),
        };
    }
}
