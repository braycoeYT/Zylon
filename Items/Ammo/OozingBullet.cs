using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class OozingBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("On death, leaves a lasting ooze cloud");
        }
		public override void SetDefaults() {
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 32;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 0.25f;
			Item.value = Item.sellPrice(0, 0, 0, 3);
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ProjectileType<Projectiles.Ammo.OozingBullet>();
			Item.ammo = AmmoID.Bullet;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(75);
			recipe.AddIngredient(ItemID.MusketBall, 75);
			recipe.AddIngredient(ItemType<Materials.Oozeberry>());
			recipe.Register();
		}
	}
}