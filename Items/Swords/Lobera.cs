using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Items.Swords
{
	public class Lobera : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 61;
			Item.DamageType = DamageClass.Melee;
			Item.width = 58;
			Item.height = 58;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3.8f;
			Item.value = Item.sellPrice(0, 0, 60);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.SparklyGelFriendly>();
			Item.shootSpeed = 8f;
		}
		int shootCount;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			int numberProjectiles = 5;
			if (shootCount % 3 == 0) {
				SoundEngine.PlaySound(SoundID.Splash, position);
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = new Vector2(velocity.X * Main.rand.NextFloat(0.9f, 1.1f), velocity.Y * Main.rand.NextFloat(0.9f, 1.1f)).RotatedByRandom(MathHelper.ToRadians(10));
					Projectile.NewProjectile(source, position, perturbedSpeed, type, (int)(damage * 0.5f), knockback * 0.5f, player.whoAmI);
				}
			}
			return false;
		}
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
            target.AddBuff(320, Main.rand.Next(3, 6) * 60, false);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(320, Main.rand.Next(3, 6) * 60, false);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Slimecutter>());
			recipe.AddIngredient(ItemID.GelBalloon, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}