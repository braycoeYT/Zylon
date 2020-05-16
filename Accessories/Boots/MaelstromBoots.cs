using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories.Boots
{
	public class MaelstromBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Maelstrom Boots");
			Tooltip.SetDefault("Allows flight, ultra fast running, and extra mobility on ice\nProvides the ability to walk on water and lava\nGrants immunity to fire blocks and 10 seconds of immunity to lava\nGrants the ability to swim and greatly extends underwater breathing\nProvides extreme light underwater and some light on land\n+1/2 seconds of wingtime\n12% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 540000;
			item.rare = 9;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accRunSpeed = 9.75f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.12f;
			player.iceSkate = true;
			
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += 600;
			
			player.arcticDivingGear = true;
			player.accFlipper = true;
			player.accDivingHelm = true;
			player.iceSkate = true;
			if (player.wet)
			{
				Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.4f, 1.6f, 1.8f);
			}
			else
			Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.2f, 0.8f, 0.9f);
		
			player.wingTimeMax += 30;
			
			player.maxRunSpeed += 0.25f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NonstopBoots"));
			recipe.AddIngredient(ItemID.ArcticDivingGear);
			recipe.AddIngredient(ItemID.ShinePotion, 5);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}