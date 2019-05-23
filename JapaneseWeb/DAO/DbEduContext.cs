using System.Data.Entity;
using JapaneseWeb.Models;

namespace JapaneseWeb.DAO
{
    public class DbEduContext : DbContext
    {        
        public DbSet<Level> Levels { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Grammar> Grammars { get; set; }
        public DbSet<Detailgrammar> Detailgrammars { get; set; }

        public DbSet<Topicvocabulary> Topicvocabularies { get; set; }
        public DbSet<Vocabulary> Vocabularies { get; set; }
        
        public DbSet<Detailvocabulary> Detailvocabularies { get; set; }

        public DbEduContext() : base("name = DekiruNihongoConnectionString")
        {

        }

        
    }
}