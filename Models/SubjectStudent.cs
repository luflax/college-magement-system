//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace College_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubjectStudent
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public Nullable<int> Grade { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
