using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Zylon.NPCs;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ElectricalEntity : ModProjectile
	{
        public override void SetStaticDefaults() { //SCRAPPED ATTACK
			DisplayName.SetDefault("Electrical Entity");
			Main.projFrames[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 300;
			Projectile.alpha = 255;
		}
		int Timer = 1;
        public override void AI() {
			Timer++;
			Player target = Main.player[Main.npc[ZylonGlobalNPC.diskiteBoss].target];
			if (Timer == 1) Projectile.position.X = target.position.X;
			Projectile.position.Y = target.Center.Y - 320;

			if (Timer % 5 == 0)
				Projectile.frameCounter++;
			if (Projectile.frameCounter > 1)
				Projectile.frameCounter = 0;
			Projectile.frame = Projectile.frameCounter * 72;

			if (Timer % 5 == 0)
				if (Projectile.Center.X < target.Center.X) Projectile.velocity.X += 1;
				else Projectile.velocity.X -= 1;
				if (Projectile.velocity.X > 16)
					Projectile.velocity.X = 16;
				if (Projectile.velocity.X < -16)
					Projectile.velocity.X = -16;

			Lighting.AddLight(Projectile.Center, 0.75f*(255-Projectile.alpha)/255, 0.75f*(255-Projectile.alpha)/255, 0.75f*(255-Projectile.alpha)/255);
			Projectile.rotation += 0.05f;
			Projectile.alpha -= 17;
			if (Timer % 60 == 0) {
				ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 8), ModContent.ProjectileType<ADDZap>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, BasicNetType: 2);
            }
        }
        public override void PostAI() {
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}