using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class EyeoftheSandstorm : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye of the Sandstorm");
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if (target.type != NPCID.TargetDummy) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(Main.rand.Next(-128, 129), Main.rand.Next(-128, 129)), new Vector2(), ModContent.ProjectileType<DesertSpiritFlameFriendly>(), (int)(Projectile.damage * 0.75f), Projectile.knockBack / 2, Main.myPlayer);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(Main.rand.Next(-128, 129), Main.rand.Next(-128, 129)), new Vector2(), ModContent.ProjectileType<DesertSpiritFlameFriendly>(), (int)(Projectile.damage * 0.75f), Projectile.knockBack / 2, Main.myPlayer);
        }
        public float MovementFactor {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		public override void AI() {
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
					MovementFactor = 3f; //3
					Projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 2.4f; //2.4
				}
				else // Otherwise, increase the movement factor
				{
					MovementFactor += 2.1f; //2.1
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
		/*public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.t_Lihzahrd);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}*/
	}
}