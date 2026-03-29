using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace Zylon.Projectiles.Pets
{
	public class Dirtboi : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Dirtboi");
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.aiStyle = -1;
            Projectile.width = 38;
            Projectile.height = 20;

            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            if (month == 12 && day > 14)
                Projectile.frame = 1;
            if ((month == 1 && day == 4) || (month == 9 && day == 28))
                Projectile.frame = 2;
            if (month == 4 && day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges)
                Projectile.frame = 3;
        }
        bool cry;
        int cryTimer;
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            if (cry) {
                Projectile.rotation = 0f;
                Projectile.timeLeft = 4;
                Projectile.velocity = new Vector2();
                cryTimer++;
                if (cryTimer % 10 == 0)
                    ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + Main.rand.Next(-15, 16), Projectile.Center.Y + 40, 0, 10, ModContent.ProjectileType<Bosses.Dirtball.DirtboiTears>(), 0, 0f, Projectile.owner);
                if (cryTimer > 100) Projectile.alpha += 15;
                if (cryTimer > 120) Projectile.active = false;
                if (!player.dead && cryTimer > 60) {
                    cryTimer = 0;
                    cry = false;
                    Projectile.alpha = 0;
                }
                return false;
            }
            player.zephyrfish = false;
            Projectile.frameCounter = 0;
            return true;
        }
        public override void AI() {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff<Buffs.Pets.DirtboiBuff>())
                Projectile.timeLeft = 4;
            else if (player.dead) cry = true;

            #region General behavior
			Vector2 idlePosition = player.Center + new Vector2(-60*player.direction, -80);
			
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}
			#endregion

            #region Movement

			float speed = 12f;
			float inertia = 30f;
			if (distanceToIdlePosition > 600f) {
				speed = 24f;
				inertia = 25f;
			}
            else if (distanceToIdlePosition <= 20f) {
                speed = 12f;
                inertia = 50f;
            }
            if (Main.hardMode && distanceToIdlePosition > 80f) speed *= 2; //Those darn wings.

			if (distanceToIdlePosition > 20f) {
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
			else if (Projectile.velocity == Vector2.Zero) {
				Projectile.velocity.X = -0.15f;
				Projectile.velocity.Y = -0.05f;
			}
            #endregion
        }
        public override void PostAI() {
            Dust dust = Dust.NewDustDirect(Projectile.position + new Vector2(0, 28), Projectile.width, 1, DustID.Dirt);
            //dust.position = Projectile.Center + new Vector2(Main.rand.Next(-Projectile.width/2, Projectile.width/2+1));
			dust.noGravity = false;
			dust.scale = Main.rand.NextFloat(0.5f, 1f);
            dust.velocity.Y = 3;
        }
    }   
}