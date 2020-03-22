using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Zylon.Items.ContagionalAccessories
{
	public class CoralClingerVirusCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'A virus that mainly lives on coral but only uses it to gain access to other sea creatures'\n(Viruses inside: Coral Clinger Virus)\nIn the beach biome, +35 Contagion Points");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 14271;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneBeach)
			{
				var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
				modPlayer.ContagionalResourceMax2 += 35;
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmptyVirusCapsule"));
			recipe.AddIngredient(ItemID.SandBlock, 17);
			recipe.AddIngredient(ItemID.Coral, 5);
			recipe.AddIngredient(ItemID.Seashell, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}