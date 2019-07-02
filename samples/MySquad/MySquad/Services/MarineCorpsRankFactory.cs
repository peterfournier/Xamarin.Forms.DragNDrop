using MySquad.Models;

namespace MySquad.Services
{
    public static class MarineCorpsRankFactory
    {
        public static Private Private = new Private();
        public static PrivateFirstClass PrivateFirstClass = new PrivateFirstClass();
        public static LanceCorporal LanceCorporal = new LanceCorporal();
        public static Corporal Corporal = new Corporal();
        public static Sergeant Sergeant = new Sergeant();
        public static StaffSergeant StaffSergeant = new StaffSergeant();
        public static GunnerySergeant GunnerySergeant = new GunnerySergeant();
        public static MasterSergeant MasterSergeant = new MasterSergeant();
        public static FirstSergeant FirstSergeant = new FirstSergeant();
        public static MasterGunnerySergeant MasterGunnerySergeant = new MasterGunnerySergeant();
        public static SergeantMajor SergeantMajor = new SergeantMajor();
        public static SergeantMajorOfTheMarineCorps SergeantMajorOfTheMarineCorps = new SergeantMajorOfTheMarineCorps();
    }
}
