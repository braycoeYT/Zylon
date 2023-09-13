using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Tomes
{
	public class DarkPrognosticusVoid : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.timeLeft = 480;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.usesIDStaticNPCImmunity = true;
			Projectile.idStaticNPCHitCooldown = 15; 
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			if (Main.rand.NextBool(3) && target.type != NPCID.TargetDummy) {
				Main.player[Projectile.owner].statMana += 1;
				Main.player[Projectile.owner].ManaEffect(1);
            }
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(20, 41));
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				Main.player[Projectile.owner].statMana += 1;
				Main.player[Projectile.owner].ManaEffect(1);
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Timestop>(), Main.rand.Next(20, 41));
			}
        }
		Vector2 startPos;
		int Timer;
		bool init;
		float rot;
        public override void AI() {
			if (++Projectile.frameCounter >= 10) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
					Projectile.frame = 0;
			}
			Timer++;
            if (!init) {
				rot = Projectile.ai[0];
				init = true;
				startPos = Projectile.Center;
            }
			rot += 1f;
			Projectile.Center = startPos - new Vector2(0, (int)(Timer*1.25f)).RotatedBy(MathHelper.ToRadians(rot));
        }
    }   
}