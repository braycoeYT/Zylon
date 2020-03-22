using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Zylon.Items.ContagionalAccessories
{
	public class BorealCoronavirusCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'This coronavirus temporarily lives in boreal wood, but chilly RNA is its true home'\n(Viruses inside: Boreal Coronavirus)\nIn the snow biome, +1 Defense and +2 Contagional Crit");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 11853;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneSnow)
			{
				var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
				modPlayer.ContagionalCrit += 2;
				player.statDefense += 1;
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmptyVirusCapsule"));
			recipe.AddIngredient(ItemID.BorealWood, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 7);
			recipe.AddIngredient(ItemID.IceBlock, 3);
			recipe.AddIngredient(mod.ItemType("FrostBite"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}