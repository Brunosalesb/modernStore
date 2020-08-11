namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
