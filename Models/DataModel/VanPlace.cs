using System;

namespace BusFor.Models.DataModel
{
    public class VanPlace:IEquatable<VanPlace>
    {
        public int Van { get; set; }
        public int Place { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            VanPlace objAsPart = obj as VanPlace;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return Van;
        }
        public bool Equals(VanPlace other)
        {
            if (other == null) return false;
            return (this.Van == other.Van && this.Place == other.Place ? true : false);
        }
    }
}
