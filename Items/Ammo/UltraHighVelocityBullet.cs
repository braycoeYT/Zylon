using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class UltraHighVelocityBullet : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 31;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 16;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 0, 0, 4);
			Item.rare = ItemRarityID.Purple;
			Item.shoot = ProjectileType<Projectiles.Guns.UltraHighVelocityBullet>();
			Item.ammo = AmmoID.Bullet;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(300);
			recipe.AddIngredient(ItemID.HighVelocityBullet, 300);
			recipe.AddIngredient(ItemType<Materials.NeutronFragment>());
			recipe.Register();
		}
	}
}