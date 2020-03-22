using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Zylon.Items.ContagionalAccessories
{
	public class EbonwormVirusCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'This virus, apart from predators, is the devourer's greatest killer'\n(Viruses inside: Ebonworm Virus)\nIn the corruption biome, +5 All Crit");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 23734;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCorrupt)
			{
				var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
				modPlayer.ContagionalCrit += 5;
				player.meleeCrit += 5;
				player.rangedCrit += 5;
				player.magicCrit += 5;
				player.thrownCrit += 5;
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmptyVirusCapsule"));
			recipe.AddIngredient(ItemID.WormTooth, 8);
			recipe.AddIngredient(ItemID.VilePowder, 5);
			recipe.AddIngredient(ItemID.RottenChunk, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}