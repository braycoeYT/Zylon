using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class VinylDisc : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Vinyl Disc");
		}
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.scale = 0.5f;
			AIType = ProjectileID.Bullet;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (target.HasBuff(ModContent.BuffType<Buffs.Debuffs.Heartdaze>()))
			{
				target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Heartdaze>(), 20);
			}
			else if (Main.rand.NextBool(25))
			{
				SoundEngine.PlaySound(SoundID.Shatter, target.position);
				if (target.HasBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta2>()))
					target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Heartdaze>(), 120);
				else if (target.HasBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta1>()))
					target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta2>(), 3600);
				else
					target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta1>(), 3600);
				CombatText.NewText(target.getRect(), Color.Crimson, "!!!");
			}
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				if (target.HasBuff(ModContent.BuffType<Buffs.Debuffs.Heartdaze>()))
				{
					target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Heartdaze>(), 20);
				}
				else if (Main.rand.NextBool(25))
				{
					SoundEngine.PlaySound(SoundID.Shatter, target.position);
					if (target.HasBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta2>()))
						target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Heartdaze>(), 120);
					else if (target.HasBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta1>()))
						target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta2>(), 3600);
					else
						target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrokenKarta1>(), 3600);
					CombatText.NewText(target.getRect(), Color.Crimson, "!!!");
				}
			}
        }

        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
    }
}