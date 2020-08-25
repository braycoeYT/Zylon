using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Xenic
{
	public class TimeDistortingBattery : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Attracts Xenic Acidpumpers, causing one to enter the atmosphere nearby...\nOnly usable in space");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 20;
			item.value = 250000;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override bool CanUseItem(Player player)
		{
			if(player.ZoneSkyHeight && !NPC.AnyNPCs(mod.NPCType("XenicAcidpumper")))
				return !NPC.AnyNPCs(mod.NPCType("XenicAcidpumperGood"));
			return false;
		}
		
		public override bool UseItem(Player player)
		{
			int spawnRan = Main.rand.Next(0, 4);
			if (spawnRan == 0)
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-700, -301), (int)player.position.Y + Main.rand.Next(-300, 301), mod.NPCType("XenicAcidpumperGood"));
			else if (spawnRan == 1)
			NPC.NewNPC((int)player.position.X + Main.rand.Next(300, 701), (int)player.position.Y + Main.rand.Next(-300, 301), mod.NPCType("XenicAcidpumperGood"));
			else if (spawnRan == 2)
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-600, 601), (int)player.position.Y + Main.rand.Next(100, 301), mod.NPCType("XenicAcidpumperGood"));
			else
			NPC.NewNPC((int)player.position.X + Main.rand.Next(-600, 601), (int)player.position.Y + Main.rand.Next(-300, -101), mod.NPCType("XenicAcidpumperGood"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 5);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 3);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"));
			recipe.AddIngredient(mod.ItemType("InfectedOnyx"));
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}