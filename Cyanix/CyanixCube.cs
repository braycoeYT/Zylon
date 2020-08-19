using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cyanix
{
	public class CyanixCube : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Highly illegal.\nReduces the cooldown of cyanix pills by 25%");
		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.accessory = true;
			item.value = 25000;
			item.rare = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.cyanixShort = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}