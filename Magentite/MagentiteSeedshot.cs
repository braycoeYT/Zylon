using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Magentite
{
	public class MagentiteSeedshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magentite Seedshot");
			Tooltip.SetDefault("For use with blowpipes");
        }
		public override void SetDefaults()
		{
			item.damage = 3; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = 5; //0
			item.rare = 0;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.MagentiteSeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
			item.crit = 4; //0
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seed, 150);
			recipe.AddIngredient(mod.ItemType("MagentiteBar"));
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}