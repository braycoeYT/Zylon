using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class LihzahrdLance : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lihzahrd Lance");
		}
		public override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1.3f;
			Projectile.alpha = 0;
			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.hostile = false;
		}
		public float MovementFactor {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 5 == 0 && MovementFactor > 3f) {
				SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
				Projectile.NewProjectile(new EntitySource_TileBreak((int)Projectile.position.X, (int)Projectile.position.Y), Projectile.Center, Projectile.velocity.RotatedBy(Main.rand.NextFloat(-10, 11) * (Math.PI / 180)) * 4f, ModContent.ProjectileType<LihzahrdBeam>(), Projectile.damage, 1f, Main.myPlayer);
			}
			Player projOwner = Main.player[Projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			Projectile.direction = projOwner.direction;
			projOwner.heldProj = Projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
			Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);
			// As long as the player isn't frozen, the spear can move
			if (!projOwner.frozen) {
				if (MovementFactor == 0f)
				{
					MovementFactor = 1.2f; //3
					Projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 1.1f; //2.4
				}
				else // Otherwise, increase the movement factor
				{
					MovementFactor += 1f; //2.1
				}
			}
			Projectile.position += Projectile.velocity * MovementFactor;
			if (projOwner.itemAnimation == 0) {
				Projectile.Kill();
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (Projectile.spriteDirection == -1) {
				Projectile.rotation -= MathHelper.ToRadians(90f);
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Lihzahrd);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}