namespace Sadco.FamilyDoctor.MedicalChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_CONTROLS",
                c => new
                    {
                        F_ID = c.Int(nullable: false, identity: true),
                        F_NAME = c.String(maxLength: 100, unicode: false),
                        F_IMAGE = c.String(maxLength: 50, unicode: false),
                        F_REQUIRED = c.Boolean(nullable: false),
                        F_EDITING = c.Boolean(nullable: false),
                        F_VISIBLE = c.Boolean(nullable: false),
                        F_HELP = c.String(maxLength: 500, unicode: false),
                        F_SYMMETRICAL = c.Boolean(nullable: false),
                        F_SYMMETRYPARAMLEFT = c.String(maxLength: 50, unicode: false),
                        F_SYMMETRYPARAMRIGHT = c.String(maxLength: 50, unicode: false),
                        F_COMMENT = c.String(maxLength: 1000, unicode: false),
                        F_GROUP_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.F_ID)
                .ForeignKey("dbo.T_GROUPS_CONTROL", t => t.F_GROUP_ID, cascadeDelete: true)
                .Index(t => t.F_GROUP_ID);
            
            CreateTable(
                "dbo.T_GROUPS_CONTROL",
                c => new
                    {
                        F_ID = c.Int(nullable: false, identity: true),
                        F_NAME = c.String(maxLength: 100, unicode: false),
                        F_PARENT_ID = c.Int(),
                    })
                .PrimaryKey(t => t.F_ID)
                .ForeignKey("dbo.T_GROUPS_CONTROL", t => t.F_PARENT_ID)
                .Index(t => t.F_PARENT_ID);
            
            CreateTable(
                "dbo.T_CONTROLS_COMBOBOX",
                c => new
                    {
                        F_ID = c.Int(nullable: false, identity: true),
                        F_TEXT = c.String(maxLength: 8000, unicode: false),
                        F_CONTROL_ID = c.Int(nullable: false),
                        p_BaseControl_p_ID = c.Int(),
                    })
                .PrimaryKey(t => t.F_ID)
                .ForeignKey("dbo.T_CONTROLS", t => t.p_BaseControl_p_ID)
                .Index(t => t.p_BaseControl_p_ID);
            
            CreateTable(
                "dbo.T_CONTROLS_TEXT",
                c => new
                    {
                        F_ID = c.Int(nullable: false, identity: true),
                        F_TEXT = c.String(maxLength: 8000, unicode: false),
                        F_CONTROL_ID = c.Int(nullable: false),
                        p_BaseControl_p_ID = c.Int(),
                    })
                .PrimaryKey(t => t.F_ID)
                .ForeignKey("dbo.T_CONTROLS", t => t.p_BaseControl_p_ID)
                .Index(t => t.p_BaseControl_p_ID);
            
            CreateTable(
                "dbo.T_GROUPS_TEMPLATES",
                c => new
                    {
                        F_ID = c.Int(nullable: false, identity: true),
                        F_NAME = c.String(maxLength: 100, unicode: false),
                        F_PARENT_ID = c.Int(),
                    })
                .PrimaryKey(t => t.F_ID)
                .ForeignKey("dbo.T_GROUPS_TEMPLATES", t => t.F_PARENT_ID)
                .Index(t => t.F_PARENT_ID);
            
            CreateTable(
                "dbo.T_TEMPLATES",
                c => new
                    {
                        F_ID = c.Int(nullable: false, identity: true),
                        F_GROUP_ID = c.Int(nullable: false),
                        F_NAME = c.String(maxLength: 100, unicode: false),
                        F_DESC = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.F_ID)
                .ForeignKey("dbo.T_GROUPS_TEMPLATES", t => t.F_GROUP_ID, cascadeDelete: true)
                .Index(t => t.F_GROUP_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_TEMPLATES", "F_GROUP_ID", "dbo.T_GROUPS_TEMPLATES");
            DropForeignKey("dbo.T_GROUPS_TEMPLATES", "F_PARENT_ID", "dbo.T_GROUPS_TEMPLATES");
            DropForeignKey("dbo.T_CONTROLS_TEXT", "p_BaseControl_p_ID", "dbo.T_CONTROLS");
            DropForeignKey("dbo.T_CONTROLS_COMBOBOX", "p_BaseControl_p_ID", "dbo.T_CONTROLS");
            DropForeignKey("dbo.T_CONTROLS", "F_GROUP_ID", "dbo.T_GROUPS_CONTROL");
            DropForeignKey("dbo.T_GROUPS_CONTROL", "F_PARENT_ID", "dbo.T_GROUPS_CONTROL");
            DropIndex("dbo.T_TEMPLATES", new[] { "F_GROUP_ID" });
            DropIndex("dbo.T_GROUPS_TEMPLATES", new[] { "F_PARENT_ID" });
            DropIndex("dbo.T_CONTROLS_TEXT", new[] { "p_BaseControl_p_ID" });
            DropIndex("dbo.T_CONTROLS_COMBOBOX", new[] { "p_BaseControl_p_ID" });
            DropIndex("dbo.T_GROUPS_CONTROL", new[] { "F_PARENT_ID" });
            DropIndex("dbo.T_CONTROLS", new[] { "F_GROUP_ID" });
            DropTable("dbo.T_TEMPLATES");
            DropTable("dbo.T_GROUPS_TEMPLATES");
            DropTable("dbo.T_CONTROLS_TEXT");
            DropTable("dbo.T_CONTROLS_COMBOBOX");
            DropTable("dbo.T_GROUPS_CONTROL");
            DropTable("dbo.T_CONTROLS");
        }
    }
}