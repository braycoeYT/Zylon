using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
    public class StoneBow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Converts ammo to stone arrows");
		}
		public override void SetDefaults() {
			Item.damage = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 32;
			Item.useTime = 15;
			Item.useAnimation = 30;
			Item.reuseDelay = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.2f;
			Item.value = 150;
			Item.rare = ItemRarityID.White;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.StoneBall>();
			Item.shootSpeed = 12.7f;
			Item.useAmmo = AmmoID.Arrow;
			Item.consumeAmmoOnLastShotOnly = true;
			Item.noMelee = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Bows.StoneArrow>(), (int)(damage * 0.85f), knockback, player.whoAmI);
            return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 7);
			recipe.AddIngredient(ItemID.Gel, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}