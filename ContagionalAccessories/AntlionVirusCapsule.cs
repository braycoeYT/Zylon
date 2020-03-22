using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.ContagionalAccessories
{
	public class AntlionVirusCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Contains a antlion disease that can spread to terrarians'\n(Viruses inside: Mad Antlion Disease)\n+3 Contagional Crit");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 10921;
			item.rare = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalCrit += 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmptyVirusCapsule"));
			recipe.AddIngredient(ItemID.SandBlock, 12);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 4);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}