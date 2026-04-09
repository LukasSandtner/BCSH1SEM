using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace FinanceSandtner.Services
{
    public class DatabaseService : IDisposable
    {
        private readonly LiteDatabase _db;
        private static DatabaseService? _instance;

        public static DatabaseService Instance => _instance ??= new DatabaseService();

        public ILiteCollection<Models.FamilyMember> Members =>
            _db.GetCollection<Models.FamilyMember>("members");

        public ILiteCollection<Models.Category> Category =>
            _db.GetCollection<Models.Category>("category");

        public ILiteCollection<Models.Transaction> Transaction =>
            _db.GetCollection<Models.Transaction>("transaction");

        private DatabaseService()
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FinanceSandtner",
                "finance.db"
            );
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
            _db = new LiteDatabase(dbPath);
        }

        public void Dispose() => _db.Dispose();
    }
}
