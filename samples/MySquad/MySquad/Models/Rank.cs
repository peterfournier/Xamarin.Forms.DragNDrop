using System;

namespace MySquad.Models
{
    public enum Grade
    {
        E1,
        E2,
        E3,
        E4,
        E5,
        E6,
        E7,
        E8,
        E9,
        W1,
        W2,
        W3,
        W4,
        O1,
        O2,
        O3,
        O4,
        O5,
        O6,
        O7,
        O8,
        O9,
        O10
    }

    public abstract class Rank
    {
        public abstract Grade Grade { get; }
        public abstract string Description { get; }
        public abstract string Abbreviation { get; }

    }

    public abstract class MarineCorpsRank : Rank
    {
        // Used for binding...
        public string ShortDescription => this.ToString();
        // ...

        // other rank business logic here

        // ...
        public override string ToString()
        {
            return $"{Grade} - {Abbreviation}";
        }
    }

    public abstract class EnlistedMarineCorpsRank : MarineCorpsRank
    {
        public EnlistedMarineCorpsRank()
        {
            if (!Grade.ToString().StartsWith("E"))
                throw new Exception("Invalid Enlisted grade");
        }
    }

    public sealed class Private : MarineCorpsRank
    {
        public override Grade Grade => Grade.E1;

        public override string Description => "Private";

        public override string Abbreviation => "Pvt";
    }

    public sealed class PrivateFirstClass : MarineCorpsRank
    {
        public override Grade Grade => Grade.E2;

        public override string Description => "Private First Class";

        public override string Abbreviation => "PFC";
    }

    public sealed class LanceCorporal : MarineCorpsRank
    {
        public override Grade Grade => Grade.E3;

        public override string Description => "Lance Corporal";

        public override string Abbreviation => "LcCpl";
    }

    public sealed class Corporal : MarineCorpsRank
    {
        public override Grade Grade => Grade.E4;

        public override string Description => "Corporal";

        public override string Abbreviation => "Cpl";
    }

    public sealed class Sergeant : MarineCorpsRank
    {
        public override Grade Grade => Grade.E5;

        public override string Description => "Sergeant";

        public override string Abbreviation => "Sgt";
    }

    public sealed class StaffSergeant : MarineCorpsRank
    {
        public override Grade Grade => Grade.E6;

        public override string Description => "Staff Sergeant";

        public override string Abbreviation => "SSgt";
    }

    public sealed class GunnerySergeant : MarineCorpsRank
    {
        public override Grade Grade => Grade.E7;

        public override string Description => "Gunnery Sergeant";

        public override string Abbreviation => "GySgt";
    }

    public sealed class MasterSergeant : MarineCorpsRank
    {
        public override Grade Grade => Grade.E8;

        public override string Description => "Master Sergeant";

        public override string Abbreviation => "GySgt";
    }

    public sealed class FirstSergeant : MarineCorpsRank
    {
        public override Grade Grade => Grade.E8;

        public override string Description => "First Sergeant";

        public override string Abbreviation => "1Sgt";
    }

    public sealed class MasterGunnerySergeant : MarineCorpsRank
    {
        public override Grade Grade => Grade.E9;

        public override string Description => "Master Gunnery Sergeant";

        public override string Abbreviation => "MGySgt";
    }

    public sealed class SergeantMajor : MarineCorpsRank
    {
        public override Grade Grade => Grade.E9;

        public override string Description => "Sergeant Major";

        public override string Abbreviation => "SgtMaj";
    }

    public sealed class SergeantMajorOfTheMarineCorps : MarineCorpsRank
    {
        public override Grade Grade => Grade.E9;

        public override string Description => "Sergeant Major of the Marine Corps";

        public override string Abbreviation => "SgtMajMC";
    }
}
