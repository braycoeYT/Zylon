using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Swords
{
	public class ExcalipoorProj1 : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 90;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.alpha = 255;
			Projectile.ignoreWater = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = (int)Projectile.ai[0];
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
			if (target.type != NPCID.TargetDummy && !target.SpawnedFromStatue) p.excalipoorPower += 1;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
				p.excalipoorPower += 1;
			}
        }
        public override void AI() {
			Projectile.localNPCHitCooldown = (int)Projectile.ai[0];
			Projectile.velocity *= 0.92f;

			//Determine which dust - this matches the tooltip, btw.
			float chance = Main.DiscoG/255f;

			int dustType = ModContent.DustType<Dusts.BlackDust>();
			if (Main.rand.NextFloat() < chance) dustType = ModContent.DustType<Dusts.WhiteDust>();

            for (int i = 0; i < 3; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}