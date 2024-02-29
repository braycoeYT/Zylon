using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class NeedleSpitter : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 9;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 0, 80);
			Item.rare = ItemRarityID.White;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.NeedleSpitterProj>();
			Item.shootSpeed = 9f;
			Item.noMelee = true;
			Item.mana = 11;
			Item.UseSound = SoundID.Item20;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int numberProjectiles = 5;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = (velocity*Main.rand.NextFloat(0.8f, 1.2f)).RotatedByRandom(MathHelper.ToRadians(25));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Cactus, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}