using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.ContagionalAccessories
{
	public class DesertMachineRotVirusCapsule : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'The main reason the Ancient Desert Discus had grown weak...'\n(Viruses inside: Desert Machine Rot)\nIn the desert, +100% max run speed");
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
			if (player.ZoneDesert)
			player.maxRunSpeed += 3f;
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