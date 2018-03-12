using System;
using System.Text.RegularExpressions;

namespace DS_Gadget
{
    class DSItem : IComparable<DSItem>
    {
        private static Regex itemEntryRx = new Regex(@"^(?<id>\S+) (?<limit>\S+) (?<infusable>\S+) (?<upgrade>\S+) (?<name>.+)$");

        private bool mystery;

        public string Name;
        public int ID;
        public int StackLimit;
        public bool Infusable;
        public int MaxUpgrade;

        public DSItem(string config, bool showID)
        {
            Match itemEntry = itemEntryRx.Match(config);
            ID = Convert.ToInt32(itemEntry.Groups["id"].Value);
            StackLimit = Convert.ToInt32(itemEntry.Groups["limit"].Value);
            Infusable = Convert.ToBoolean(itemEntry.Groups["infusable"].Value);
            MaxUpgrade = Convert.ToInt32(itemEntry.Groups["upgrade"].Value);
            mystery = showID;
            if (showID)
                Name = ID.ToString() + ": " + itemEntry.Groups["name"].Value;
            else
                Name = itemEntry.Groups["name"].Value;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(DSItem other)
        {
            if (mystery)
                return ID.CompareTo(other.ID);
            else
                return Name.CompareTo(other.Name);
        }
    }
}
