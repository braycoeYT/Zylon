using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Boots
{
	public class NonstopBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nonstop Boots");
			Tooltip.SetDefault("Allows flight, super fast running, and extra mobility on ice\nProvides the ability to walk on water and lava\nGrants immunity to fire blocks and 7 seconds of immunity to lava\n10% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 420000;
			item.rare = 8;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accRunSpeed = 8f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.1f;
			player.iceSkate = true;
			
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += 420;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(ItemID.LavaWaders);
			recipe.AddIngredient(mod.ItemType("BraycoeSludge"), 15);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}