using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinanceSandtner.Models
{
    public class FamilyMember
    {
        public ObjectId Id { get; set; } = ObjectId.NewObjectId();
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public override string ToString() => $"{Name} {Surname} ({Role})";


    }
}
