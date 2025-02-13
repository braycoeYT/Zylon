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
            AIType = ProjectileID.ZephyrFish;
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
                    ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + Main.rand.Next(-15, 16), Projectile.Center.Y + 20, 0, 10, ModContent.ProjectileType<Bosses.Dirtball.DirtboiTears>(), 0, 0f, Projectile.owner);
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

            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) > 1900f) Projectile.Center = Main.player[Projectile.owner].Center;
        }
    }   
}