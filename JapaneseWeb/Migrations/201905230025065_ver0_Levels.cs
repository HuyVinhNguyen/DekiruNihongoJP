namespace JapaneseWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver0_Levels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detailgrammars",
                c => new
                    {
                        GrammarId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        Description = c.String(),
                        Document_Iddocument = c.Int(),
                        Grammar_Idgrammar = c.Int(),
                    })
                .PrimaryKey(t => new { t.GrammarId, t.DocumentId })
                .ForeignKey("dbo.Documents", t => t.Document_Iddocument)
                .ForeignKey("dbo.Grammars", t => t.Grammar_Idgrammar)
                .Index(t => t.Document_Iddocument)
                .Index(t => t.Grammar_Idgrammar);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Iddocument = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Iddocument);
            
            CreateTable(
                "dbo.Detailvocabularies",
                c => new
                    {
                        GrammarId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        Description = c.String(),
                        Document_Iddocument = c.Int(),
                        Vocabulary_levelId = c.Int(),
                        Vocabulary_topicId = c.Int(),
                    })
                .PrimaryKey(t => new { t.GrammarId, t.DocumentId })
                .ForeignKey("dbo.Documents", t => t.Document_Iddocument)
                .ForeignKey("dbo.Vocabularies", t => new { t.Vocabulary_levelId, t.Vocabulary_topicId })
                .Index(t => t.Document_Iddocument)
                .Index(t => new { t.Vocabulary_levelId, t.Vocabulary_topicId });
            
            CreateTable(
                "dbo.Vocabularies",
                c => new
                    {
                        levelId = c.Int(nullable: false),
                        topicId = c.Int(nullable: false),
                        Kanji = c.String(nullable: false, maxLength: 50),
                        Hiragana = c.String(nullable: false, maxLength: 50),
                        Katakana = c.String(nullable: false, maxLength: 50),
                        Meaning = c.String(nullable: false, maxLength: 70),
                        Level_Idlevel = c.Int(),
                        Topicvocabulary_Idtopic = c.Int(),
                    })
                .PrimaryKey(t => new { t.levelId, t.topicId })
                .ForeignKey("dbo.Levels", t => t.Level_Idlevel)
                .ForeignKey("dbo.Topicvocabularies", t => t.Topicvocabulary_Idtopic)
                .Index(t => t.Level_Idlevel)
                .Index(t => t.Topicvocabulary_Idtopic);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Idlevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idlevel);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Idtest = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Detail = c.String(maxLength: 500),
                        levelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idtest)
                .ForeignKey("dbo.Levels", t => t.levelId, cascadeDelete: true)
                .Index(t => t.levelId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Idquestion = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Option1 = c.String(nullable: false, maxLength: 100),
                        Option2 = c.String(nullable: false, maxLength: 100),
                        Option3 = c.String(nullable: false, maxLength: 100),
                        Option4 = c.String(nullable: false, maxLength: 100),
                        Answer = c.String(nullable: false, maxLength: 100),
                        testId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idquestion)
                .ForeignKey("dbo.Tests", t => t.testId, cascadeDelete: true)
                .Index(t => t.testId);
            
            CreateTable(
                "dbo.Topicvocabularies",
                c => new
                    {
                        Idtopic = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Idtopic);
            
            CreateTable(
                "dbo.Grammars",
                c => new
                    {
                        Idgrammar = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Formula = c.String(nullable: false, maxLength: 50),
                        Example = c.String(nullable: false, maxLength: 100),
                        levelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idgrammar)
                .ForeignKey("dbo.Levels", t => t.levelId, cascadeDelete: true)
                .Index(t => t.levelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grammars", "levelId", "dbo.Levels");
            DropForeignKey("dbo.Detailgrammars", "Grammar_Idgrammar", "dbo.Grammars");
            DropForeignKey("dbo.Vocabularies", "Topicvocabulary_Idtopic", "dbo.Topicvocabularies");
            DropForeignKey("dbo.Vocabularies", "Level_Idlevel", "dbo.Levels");
            DropForeignKey("dbo.Questions", "testId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "levelId", "dbo.Levels");
            DropForeignKey("dbo.Detailvocabularies", new[] { "Vocabulary_levelId", "Vocabulary_topicId" }, "dbo.Vocabularies");
            DropForeignKey("dbo.Detailvocabularies", "Document_Iddocument", "dbo.Documents");
            DropForeignKey("dbo.Detailgrammars", "Document_Iddocument", "dbo.Documents");
            DropIndex("dbo.Grammars", new[] { "levelId" });
            DropIndex("dbo.Questions", new[] { "testId" });
            DropIndex("dbo.Tests", new[] { "levelId" });
            DropIndex("dbo.Vocabularies", new[] { "Topicvocabulary_Idtopic" });
            DropIndex("dbo.Vocabularies", new[] { "Level_Idlevel" });
            DropIndex("dbo.Detailvocabularies", new[] { "Vocabulary_levelId", "Vocabulary_topicId" });
            DropIndex("dbo.Detailvocabularies", new[] { "Document_Iddocument" });
            DropIndex("dbo.Detailgrammars", new[] { "Grammar_Idgrammar" });
            DropIndex("dbo.Detailgrammars", new[] { "Document_Iddocument" });
            DropTable("dbo.Grammars");
            DropTable("dbo.Topicvocabularies");
            DropTable("dbo.Questions");
            DropTable("dbo.Tests");
            DropTable("dbo.Levels");
            DropTable("dbo.Vocabularies");
            DropTable("dbo.Detailvocabularies");
            DropTable("dbo.Documents");
            DropTable("dbo.Detailgrammars");
        }
    }
}
