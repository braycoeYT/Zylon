using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class WaterleafSeed : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 7;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 12;
			Item.height = 10;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 0f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.WaterleafSeed>();
			Item.ammo = AmmoID.Dart;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.WaterleafSeeds);
			recipe.Register();
		}
	}
}