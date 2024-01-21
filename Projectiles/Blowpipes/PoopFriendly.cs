using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Projectiles.Blowpipes
{
	public class PoopFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Poop");
        }
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 9999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            target.AddBuff(BuffID.Poisoned, 69);
			target.AddBuff(BuffID.OnFire, 69);
			target.AddBuff(BuffID.Frostburn, 69);
			target.AddBuff(BuffID.Venom, 69);
			target.AddBuff(BuffID.Daybreak, 69);
			target.AddBuff(BuffID.CursedInferno, 69);
			target.AddBuff(BuffID.Ichor, 69);
			target.AddBuff(BuffID.ShadowFlame, 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Shroomed>(), 69);
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>(), 69);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				target.AddBuff(BuffID.Poisoned, 69);
				target.AddBuff(BuffID.OnFire, 69);
				target.AddBuff(BuffID.Frostburn, 69);
				target.AddBuff(BuffID.Venom, 69);
				target.AddBuff(BuffID.Daybreak, 69);
				target.AddBuff(BuffID.CursedInferno, 69);
				target.AddBuff(BuffID.Ichor, 69);
				target.AddBuff(BuffID.ShadowFlame, 69);
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), 69);
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Shroomed>(), 69);
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.LoberaSoulslash>(), 69);
			}
        }
		public override void OnSpawn(IEntitySource source) {
            if (Main.rand.NextBool(4)) SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Projectiles/ZylonLoreBasically"));
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}