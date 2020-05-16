using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Empress
{
	public class EmpressChalice : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Chalice of the Empress");
			Tooltip.SetDefault("You really shouldn't drink this...\nSummons Empress Slime");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 9999;
			item.value = 500000;
			item.rare = 7;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("EmpressSlime"));
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.EmpressSlime>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 5);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 6);
			recipe.AddIngredient(ItemID.Gel, 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}