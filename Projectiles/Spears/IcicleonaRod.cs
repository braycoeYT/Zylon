using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Spears
{
	public class IcicleonaRod : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Icicle on a Rod");
			//Main.projFrames[Projectile.type] = 2;
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
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 7)*60);
        }
        public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Frostburn, Main.rand.Next(3, 7)*60);
        }
		public float MovementFactor {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		bool change;
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
					MovementFactor = 2f;
					Projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					MovementFactor -= 1.6f;
					if (!change) {
						//Projectile.frame = 1;
						Vector2 speed = Projectile.velocity;
						speed.Normalize();
						if (Main.myPlayer == Projectile.owner) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center+(speed*50f), speed*9f, ModContent.ProjectileType<IcicleonaRodBreak>(), (int)(Projectile.damage*0.5f), Projectile.knockBack*0.33f, Projectile.owner);
						change = true;
					}
				}
				else // Otherwise, increase the movement factor
				{
					MovementFactor += 1.4f;
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
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceGolem);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}