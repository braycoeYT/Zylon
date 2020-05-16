using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Accessories
{
	public class DarkstarVeil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkstar Veil");
			Tooltip.SetDefault("Causes stars and giant darkstars to fall and increases length of invincibility after taking damage");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 1000000;
			item.rare = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.starCloak = true;
			player.longInvince = true;
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();
			p.darkstarFall = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarVeil);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}