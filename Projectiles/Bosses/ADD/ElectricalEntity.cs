using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Zylon.NPCs;

namespace Zylon.Projectiles.Bosses.ADD
{
	public class ElectricalEntity : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electrical Entity");
			Main.projFrames[Projectile.type] = 4;
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
			Lighting.AddLight(Projectile.Center, 0.75f*(255-Projectile.alpha)/255, 0.75f*(255-Projectile.alpha)/255, 0.75f*(255-Projectile.alpha)/255);
            Player target = Main.player[Main.npc[ZylonGlobalNPC.diskiteBoss].target];
			Projectile.rotation += 0.05f;
			Projectile.alpha -= 17;
			if (Projectile.alpha < 1) Timer++;
			if (Timer % 60 == 0) {
				//finish later
            }
        }
        public override void PostAI() {
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}