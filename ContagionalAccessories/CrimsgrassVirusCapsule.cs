using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Zylon.Items.ContagionalAccessories
{
	public class CrimsgrassVirusCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'This isn't the actual plant, but a close cousin close to extinction'\n(Viruses inside: Crimsgrass Virus)\nIn the crimson biome, +35 Max Contagion Points");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 15624;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCrimson)
			{
				var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
				modPlayer.ContagionalResourceMax2 += 35;
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmptyVirusCapsule"));
			recipe.AddIngredient(ItemID.DirtBlock, 12);
			recipe.AddIngredient(ItemID.ViciousPowder, 10);
			recipe.AddIngredient(ItemID.Vertebrae, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}