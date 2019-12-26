using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPITEA.Entities.ViewModel
{
   public class Users
    {
        public decimal Emp_ID { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public string Last_name { get; set; }
        public byte Age { get; set; }
        public String MaritalStatus { get; set; }
        public bool Marital_Status {
            get {
                return Marital_Status;
            }
            set
            {
                if (value)
                {
                    MaritalStatus = "Married";
                }
                else
                {
                    MaritalStatus = "Single";
                }
            }

 }
        public System.DateTime LastChangedAt { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }

    }
}
