using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DS_Gadget
{
    class DSSex : IComparable<DSSex>
    {
        private static Regex SexEntryRx = new Regex(@"^(?<id>\d+) (?<name>.+)$");

        public short ID { get; }
        public string Name { get; }

        public DSSex(byte id, string name)
        {
            ID = id;
            Name = name;
        }

        public int CompareTo(DSSex other) => Name.CompareTo(other.Name);

        public override string ToString() => Name;

        public static IReadOnlyList<DSSex> All { get; }

        static DSSex()
        {
            var all = new List<DSSex>();
            foreach (string line in Regex.Split(Properties.Resources.Sexes, "[\r\n]+"))
            {
                Match match = SexEntryRx.Match(line);
                byte id = byte.Parse(match.Groups["id"].Value);
                string name = match.Groups["name"].Value;
                all.Add(new DSSex(id, name));
            }
            all.Sort();
            All = all;
        }
    }
}
