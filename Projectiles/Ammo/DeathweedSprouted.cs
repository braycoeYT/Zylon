using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Projectiles.Ammo
{
	public class DeathweedSprouted : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Deathweed");
        }
		public override void SetDefaults() {
			Projectile.width = 12; //16
			Projectile.height = 16; //36
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 3;
			Projectile.rotation = 0;
		}
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
			if (target.life < target.lifeMax/2) modifiers.SourceDamage += 3;
			if (target.life < target.lifeMax/4) modifiers.SourceDamage += 2;
			if (target.life < target.lifeMax/8) modifiers.SourceDamage += 2;
			if (target.life < target.lifeMax/16) modifiers.SourceDamage += 1;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (p.bigOlBouquet && Main.rand.NextFloat() < .13f) Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
			Projectile.damage /= 2;
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            if (modifiers.PvP)
            {
				if (target.statLife < target.statLifeMax2 / 2) modifiers.SourceDamage += 3;
				if (target.statLife < target.statLifeMax2 / 4) modifiers.SourceDamage += 2;
				if (target.statLife < target.statLifeMax2 / 8) modifiers.SourceDamage += 2;
				if (target.statLife < target.statLifeMax2 / 16) modifiers.SourceDamage += 1;
				ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
				if (p.bigOlBouquet && Main.rand.NextFloat() < .13f) Main.player[Projectile.owner].Heal(Main.rand.Next(1, 3));
				Projectile.damage /= 2;
			}
        }
    }   
}