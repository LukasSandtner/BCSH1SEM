using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;   

namespace FinanceSandtner.Models
{
    public class Category
    {
        public ObjectId Id { get; set; } = ObjectId.NewObjectId();
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Color { get; set; } = "#4CAF50";
        public override string ToString() => $"{Name} ({Type})";
    }
}
