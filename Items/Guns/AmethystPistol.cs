using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class AmethystPistol : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.damage = 16;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 1.5f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 8.5f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (Main.rand.NextBool(4)) { //It took me at least an hour to figure out the dust spawning and apparently the issue was that I used the parameters instead of the direct values. I guess they were slightly different?
				SoundEngine.PlaySound(SoundID.Shatter.WithVolumeScale(0.5f).WithPitchOffset(1f), position);
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Guns.AmethystPistolProj>(), (int)(damage*1.25f), knockback, Main.myPlayer);
				for (int i = 0; i < 3; i++) {
					Dust dust = Dust.NewDustDirect(position, 1, 1, DustID.GemAmethyst);
					float rot = player.DirectionTo(Main.MouseWorld).ToRotation();
					dust.position = player.Center - new Vector2(2*player.direction, 44).RotatedBy(rot+MathHelper.PiOver2); //og 48
					dust.velocity = velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-10f, 10f)));
					dust.velocity.Normalize();
					dust.velocity *= 3f;
					dust.noGravity = true;
					dust.scale = Main.rand.NextFloat(0.75f, 1.5f);
				}
				return false;
			}
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Cerussite>(), 15);
			recipe.AddIngredient(ItemID.Amethyst, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}