using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebXBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Sun Speck"); //hole no ray
			Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = Main.rand.Next(90, 151);
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
        public override void AI() {
			NPC owner = Main.npc[ZylonGlobalNPC.adenebBoss];
			float hpLeft = (float)owner.life/(float)(owner.lifeMax);
			if (hpLeft <= 0.5f && Projectile.timeLeft > 90) Projectile.timeLeft = 90;
			
			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
            Projectile.rotation += 0.04f;
			Projectile.velocity *= 0.982f;
        }
        public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.Item29, Projectile.position);
        }
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		Vector2 speed;
        public override void OnKill(int timeLeft) {
			speed = Projectile.Center - Main.player[Main.npc[ZylonGlobalNPC.adenebBoss].target].Center;
			speed.Normalize();
			if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, speed*-10f, ModContent.ProjectileType<AdenebLaser>(), Projectile.damage, 0);
			if (Main.expertMode) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, speed.RotatedBy(MathHelper.ToRadians(20))*-10f, ModContent.ProjectileType<AdenebLaser>(), Projectile.damage, 0);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, speed.RotatedBy(MathHelper.ToRadians(-20))*-10f, ModContent.ProjectileType<AdenebLaser>(), Projectile.damage, 0);
            }
		}
    }   
}