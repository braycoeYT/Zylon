using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Carnallite
{
	public class RedRose : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots roses that may confuse enemies");
		}
		public override void SetDefaults()  {
			item.damage = 85;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.7f;
			item.value = Item.sellPrice(0, 2, 75, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("SmallRose");
			item.shootSpeed = 8f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CarnalliteBar"), 12);
			recipe.AddIngredient(mod.ItemType("FloralUndergrowth"), 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}