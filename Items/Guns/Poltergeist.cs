using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class Poltergeist : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 9, 87);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 31;
			Item.useTime = 31;
			Item.damage = 127;
			Item.width = 66;
			Item.height = 34;
			Item.knockBack = 1.25f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 11f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Yellow;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			for (int i = 0; i < 4; i++) {
				Vector2 temp = position + new Vector2(Main.rand.NextFloat(-48, 48), Main.rand.NextFloat(-48, 48));
				Vector2 temp2 = temp.DirectionTo(Main.MouseWorld);

				Projectile.NewProjectile(source, temp, temp2, ModContent.ProjectileType<Projectiles.Guns.PoltergeistProj>(), damage/3, knockback*0.5f, Main.myPlayer, i*15);
			}
			for (int i = 0; i < 8; i++) {
				Dust dust = Dust.NewDustDirect(position, 1, 1, DustID.DungeonSpirit);
				float rot = player.DirectionTo(Main.MouseWorld).ToRotation();
				dust.position = player.Center - new Vector2(2*player.direction, 62).RotatedBy(rot+MathHelper.PiOver2);
				dust.velocity = velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-10f, 10f)));
				dust.velocity.Normalize();
				dust.velocity *= Main.rand.NextFloat(3f, 11f);
				dust.noGravity = true;
				dust.scale = Main.rand.NextFloat(1.5f, 3f);
			}
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.AddIngredient(ItemID.SpectreBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}