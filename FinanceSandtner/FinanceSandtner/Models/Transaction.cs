using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace FinanceSandtner.Models
{
    public class Transaction
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.NewObjectId();
        public required ObjectId FamilyMemberId { get; set; }
        public required ObjectId CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Today;
        public string TypeOfTansaction { get; set; } = string.Empty;

        [BsonIgnore]
        public FamilyMember? Member { get; set; }
        [BsonIgnore]
        public Category? Cat { get; set; }
    }
}
