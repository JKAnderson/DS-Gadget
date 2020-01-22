using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DS_Gadget
{
    class DSPhysique : IComparable<DSPhysique>
    {
        private static Regex PhysiqueEntryRx = new Regex(@"^(?<id>\d+) (?<name>.+)$");

        public byte ID { get; }
        public string Name { get; }

        public DSPhysique(byte id, string name)
        {
            ID = id;
            Name = name;
        }

        public int CompareTo(DSPhysique other) => Name.CompareTo(other.Name);

        public override string ToString() => Name;

        public static IReadOnlyList<DSPhysique> All { get; }

        static DSPhysique()
        {
            var all = new List<DSPhysique>();
            foreach (string line in Regex.Split(Properties.Resources.Physiques, "[\r\n]+"))
            {
                Match match = PhysiqueEntryRx.Match(line);
                byte id = byte.Parse(match.Groups["id"].Value);
                string name = match.Groups["name"].Value;
                all.Add(new DSPhysique(id, name));
            }
            all.Sort();
            All = all;
        }
    }
}
