namespace SuperheroCreator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndmigrationwithkeyadded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Heroes");
            AddColumn("dbo.Heroes", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Heroes", "Name", c => c.String());
            AddPrimaryKey("dbo.Heroes", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Heroes");
            AlterColumn("dbo.Heroes", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Heroes", "ID");
            AddPrimaryKey("dbo.Heroes", "Name");
        }
    }
}
