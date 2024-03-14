using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Ammo
{
	public class ObsidianDart : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 99;
		}
		public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 10;
			Item.height = 10;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2.25f;
			Item.value = 0;
			Item.rare = ItemRarityID.White;
			Item.shoot = ProjectileType<Projectiles.Ammo.ObsidianDart>();
			//Item.shootSpeed = 3f;
			Item.ammo = AmmoID.Dart;
			Item.crit = 8;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.Obsidian);
			recipe.Register();
		}
	}
}