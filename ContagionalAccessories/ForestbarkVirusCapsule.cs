using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.ContagionalAccessories
{
	public class ForestbarkVirusCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Contains a parasitic tree disease that cannot survive any extreme conditions'\n(Viruses inside: Forestbark Virus)\n+1 Contagional Knockback");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 8124;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalKnockback += 1;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmptyVirusCapsule"));
			recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(mod.ItemType("RainShard"), 10);
			recipe.AddIngredient(ItemID.Acorn, 8);
			recipe.AddIngredient(mod.ItemType("WoodenVirus"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}