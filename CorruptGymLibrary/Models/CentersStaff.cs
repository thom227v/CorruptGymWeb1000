using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class CentersStaff
    {
        public string Address_Line { get; set; }
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public string Role_Name { get; set; }
        public int Security_Level { get; set; }
        public int Center_Access { get; set; }

        public bool Center_Access_Staff {
            get => ConvertBitToBool(Center_Access);
            set => Center_Access = ConvertBoolToBit(value);
        }

        bool ConvertBitToBool(int value)
        {
            return value == 1;
        }

        int ConvertBoolToBit(bool value)
        {
            return value ? 1 : 0;
        }
    }
}
