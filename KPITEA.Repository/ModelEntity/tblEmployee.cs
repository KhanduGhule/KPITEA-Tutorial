//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KPITEA.Repository.ModelEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmployee()
        {
            this.tblUserCredentials = new HashSet<tblUserCredential>();
        }
    
        public decimal Emp_ID { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public string Last_name { get; set; }
        public byte Age { get; set; }
        public bool Marital_Status { get; set; }
        public System.DateTime LastChangedAt { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
    
        public virtual tblEmployee tblEmployee1 { get; set; }
        public virtual tblEmployee tblEmployee2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserCredential> tblUserCredentials { get; set; }
    }
}
