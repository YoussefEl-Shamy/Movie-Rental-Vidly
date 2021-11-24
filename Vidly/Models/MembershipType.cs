using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte id { get; set; }
        public string name { get; set; }
        public short signUpFee { get; set; }
        public byte durationInMonths { get; set; }
        public byte discountRate { get; set; }


        public static readonly byte unknown = 0;
        public static readonly byte payAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte quarterly = 3;
        public static readonly byte annual = 4;
    }
}