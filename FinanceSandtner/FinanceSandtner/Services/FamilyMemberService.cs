using System.Collections.Generic;
using System.Linq;
using LiteDB;
using FinanceSandtner.Models;

namespace FinanceSandtner.Services
{
    public class FamilyMemberService
    {
        private readonly DatabaseService _db = DatabaseService.Instance;

        public void Add(FamilyMember member) => _db.Members.Insert(member);

        public List<FamilyMember> GetAll() => _db.Members.FindAll().ToList();

        public void Update(FamilyMember member) => _db.Members.Update(member);

        public void Delete(ObjectId id) => _db.Members.Delete(id);
    }
}