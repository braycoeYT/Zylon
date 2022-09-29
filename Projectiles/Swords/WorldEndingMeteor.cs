using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Swords
{
	public class WorldEndingMeteor : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("World-Ending Meteor");
		}
		public override void SetDefaults() {
			Projectile.width = 148;
			Projectile.height = 148;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 270;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			AIType = ProjectileID.Bullet;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 2;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (target.HasBuff(ModContent.BuffType<Buffs.SevereBleeding>()))
			{
				target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 20);
			}
			else if (Main.rand.NextBool(15))
			{
				SoundEngine.PlaySound(SoundID.Shatter, target.position);
				if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta2>()))
					target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 120);
				else if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta1>()))
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta2>(), 3600);
				else
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta1>(), 3600);
				CombatText.NewText(target.getRect(), Color.Crimson, "!!!");
			}
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (target.HasBuff(ModContent.BuffType<Buffs.SevereBleeding>()))
			{
				target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 20);
			}
			else if (Main.rand.NextBool(15))
			{
				SoundEngine.PlaySound(SoundID.Shatter, target.position);
				if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta2>()))
					target.AddBuff(ModContent.BuffType<Buffs.SevereBleeding>(), 120);
				else if (target.HasBuff(ModContent.BuffType<Buffs.BrokenKarta1>()))
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta2>(), 3600);
				else
					target.AddBuff(ModContent.BuffType<Buffs.BrokenKarta1>(), 3600);
				CombatText.NewText(target.getRect(), Color.Crimson, "!!!");
			}
		}
	}
}