using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Zylon.Items.VoidDream
{
	public class NeozylsWrath : ModItem
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Neozyl's Wrath");
			Tooltip.SetDefault("Activates Void Dream Mode.\nWORKS IN EXPERT ONLY\nA few Zylonian enemies and all Zylonian bosses are buffed\nJungle Temple is banned until Plantera is defeated\nZylonian bosses drop new loot(slightly unfinished)\nSome Town NPCs, especially Braycoe, sell new loot at certain times\nSome boss drops are increased\nUSE WHILE A ZYLONIAN BOSS (AND SOME VANILLA BOSSES) IS ALIVE AND SUFFER!!");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 13;
			item.value = 0;
			item.rare = 1;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 4;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (Main.expertMode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public override bool UseItem(Player player)
		{
			if (NPC.AnyNPCs(mod.NPCType("Dirtball")))
			{
				player.statLife = -13;
				player.AddBuff(20, 475839, false);
				player.AddBuff(21, 475839, false);
				player.AddBuff(22, 475839, false);
				player.AddBuff(23, 475839, false);
				player.AddBuff(30, 475839, false);
				player.AddBuff(37, 475839, false);
				player.AddBuff(46, 475839, false);
				player.AddBuff(47, 475839, false);
				player.AddBuff(68, 475839, false);
				player.AddBuff(69, 475839, false);
				player.AddBuff(80, 475839, false);
				player.AddBuff(144, 475839, false);
				player.AddBuff(149, 475839, false);
				player.AddBuff(156, 475839, false);
				player.AddBuff(163, 475839, false);
				player.AddBuff(197, 475839, false);
			}
			if (NPC.AnyNPCs(mod.NPCType("AncientDesertDiscus")))
			{
				player.statLife = -13;
				player.AddBuff(20, 475839, false);
				player.AddBuff(21, 475839, false);
				player.AddBuff(22, 475839, false);
				player.AddBuff(23, 475839, false);
				player.AddBuff(30, 475839, false);
				player.AddBuff(37, 475839, false);
				player.AddBuff(46, 475839, false);
				player.AddBuff(47, 475839, false);
				player.AddBuff(68, 475839, false);
				player.AddBuff(69, 475839, false);
				player.AddBuff(80, 475839, false);
				player.AddBuff(144, 475839, false);
				player.AddBuff(149, 475839, false);
				player.AddBuff(156, 475839, false);
				player.AddBuff(163, 475839, false);
				player.AddBuff(197, 475839, false);
			}
			if (NPC.AnyNPCs(mod.NPCType("ComputerVirus")))
			{
				player.statLife = -13;
				player.AddBuff(20, 475839, false);
				player.AddBuff(21, 475839, false);
				player.AddBuff(22, 475839, false);
				player.AddBuff(23, 475839, false);
				player.AddBuff(30, 475839, false);
				player.AddBuff(37, 475839, false);
				player.AddBuff(46, 475839, false);
				player.AddBuff(47, 475839, false);
				player.AddBuff(68, 475839, false);
				player.AddBuff(69, 475839, false);
				player.AddBuff(80, 475839, false);
				player.AddBuff(144, 475839, false);
				player.AddBuff(149, 475839, false);
				player.AddBuff(156, 475839, false);
				player.AddBuff(163, 475839, false);
				player.AddBuff(197, 475839, false);
			}
			if (NPC.AnyNPCs(mod.NPCType("ComputerVirusPha2")))
			{
				player.statLife = -13;
				player.AddBuff(20, 475839, false);
				player.AddBuff(21, 475839, false);
				player.AddBuff(22, 475839, false);
				player.AddBuff(23, 475839, false);
				player.AddBuff(30, 475839, false);
				player.AddBuff(37, 475839, false);
				player.AddBuff(46, 475839, false);
				player.AddBuff(47, 475839, false);
				player.AddBuff(68, 475839, false);
				player.AddBuff(69, 475839, false);
				player.AddBuff(80, 475839, false);
				player.AddBuff(144, 475839, false);
				player.AddBuff(149, 475839, false);
				player.AddBuff(156, 475839, false);
				player.AddBuff(163, 475839, false);
				player.AddBuff(197, 475839, false);
			}
			if (NPC.AnyNPCs(mod.NPCType("ZylonianMineralExtractor")))
			{
				player.statLife = -13;
				player.AddBuff(20, 475839, false);
				player.AddBuff(21, 475839, false);
				player.AddBuff(22, 475839, false);
				player.AddBuff(23, 475839, false);
				player.AddBuff(30, 475839, false);
				player.AddBuff(37, 475839, false);
				player.AddBuff(46, 475839, false);
				player.AddBuff(47, 475839, false);
				player.AddBuff(68, 475839, false);
				player.AddBuff(69, 475839, false);
				player.AddBuff(80, 475839, false);
				player.AddBuff(144, 475839, false);
				player.AddBuff(149, 475839, false);
				player.AddBuff(156, 475839, false);
				player.AddBuff(163, 475839, false);
				player.AddBuff(197, 475839, false);
			}
			if (NPC.AnyNPCs(mod.NPCType("ZylonianMineralExtractorPha2")))
			{
				player.statLife = -13;
				player.AddBuff(20, 475839, false);
				player.AddBuff(21, 475839, false);
				player.AddBuff(22, 475839, false);
				player.AddBuff(23, 475839, false);
				player.AddBuff(30, 475839, false);
				player.AddBuff(37, 475839, false);
				player.AddBuff(46, 475839, false);
				player.AddBuff(47, 475839, false);
				player.AddBuff(68, 475839, false);
				player.AddBuff(69, 475839, false);
				player.AddBuff(80, 475839, false);
				player.AddBuff(144, 475839, false);
				player.AddBuff(149, 475839, false);
				player.AddBuff(156, 475839, false);
				player.AddBuff(163, 475839, false);
				player.AddBuff(197, 475839, false);
			}
			
			if (WorldEdit.voidDream == true)
			{
				WorldEdit.voidDream = false;
				Main.PlaySound(SoundID.Shatter, player.position, 0);
				return true;
			}
			else
			{
				WorldEdit.voidDream = true;
				Main.PlaySound(SoundID.Roar, player.position, 0);
				return true;
			}
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}