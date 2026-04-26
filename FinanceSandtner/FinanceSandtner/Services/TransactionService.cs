using System;
using System.Collections.Generic;
using System.Linq;
using FinanceSandtner.Models;
using LiteDB;

namespace FinanceSandtner.Services
{
    public class TransactionService
    {
        private readonly DatabaseService _db = DatabaseService.Instance;

        public void Add(Transaction transaction) => _db.Transaction.Insert(transaction);
        public void Alter(Transaction transaction) => _db.Transaction.Update(transaction);
        public void Delete(ObjectId id) => _db.Transaction.Delete(id);

        public List<Transaction> AllTransaction()
        {
            var transactions = _db.Transaction.FindAll().ToList();
            var members = _db.Members.FindAll().ToDictionary(c => c.Id);
            var categories = _db.Category.FindAll().ToDictionary(k => k.Id);

            foreach (var t in transactions)
            {
                members.TryGetValue(t.FamilyMemberId, out var member);
                categories.TryGetValue(t.CategoryId, out var cat);
                t.Member = member;
                t.Cat = cat;
            }
            return transactions;
        }
        public decimal SumRemaining()
        {
            return _db.Transaction.FindAll().Sum(t =>
                t.TypeOfTansaction == "Příjem" ? t.Amount : -t.Amount);
        }
    }
}
