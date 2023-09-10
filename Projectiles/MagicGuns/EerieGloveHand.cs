using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.MagicGuns
{
	public class EerieGloveHand : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Eerie Glove");
			Main.projFrames[Projectile.type] = 4;
		}
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.aiStyle = 19;
			Projectile.penetrate = -1;
			Projectile.scale = 1.3f;
			Projectile.alpha = 0;
			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 1;
		}
		public float MovementFactor {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		float oldRotation;
		public override void AI() {
			Player projOwner = Main.player[Projectile.owner];
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			oldRotation = Projectile.rotation;
			Projectile.direction = projOwner.direction;
			projOwner.heldProj = Projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			Projectile.position.X = ownerMountedCenter.X - (float)(Projectile.width / 2);
			Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2);
			if (!projOwner.frozen) {
				if (MovementFactor == 0f)
				{
					MovementFactor = 1f; //65
					Projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 0f; //2.4
				}
				else // Otherwise, increase the movement factor
				{
					MovementFactor += 0f; //2.1
				}
			}
			Projectile.frame = Projectile.direction + 1;
			if (Projectile.frame == 0)
				MovementFactor = 0.5f;
			else
				MovementFactor = 1f;
			Projectile.position += Projectile.velocity * MovementFactor;
			if (Projectile.frame == 0)
				Projectile.position += Projectile.velocity.RotatedBy(MathHelper.ToRadians(90));
			if (projOwner.itemAnimation == 0) {
				Projectile.Kill();
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
			if (Projectile.spriteDirection == -1) {
				Projectile.rotation -= MathHelper.ToRadians(90f);
			}
			Projectile.rotation += MathHelper.ToRadians(235f); //45
			//Projectile.spriteDirection = Projectile.direction;
		}
	}
}