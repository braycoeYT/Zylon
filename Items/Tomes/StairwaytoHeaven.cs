using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class StairwaytoHeaven : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 53;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 4, 60);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.StairwaytoHeavenProj>();
			Item.shootSpeed = 6f;
			Item.noMelee = true;
			Item.mana = 6;
			Item.stack = 1;
			Item.UseSound = SoundID.Item20;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int numberProjectiles = 2 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}