using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Projectiles.Pets
{
	public class MiniDiskling : ModProjectile
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mini Diskling");
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            AIType = ProjectileID.ZephyrFish;
            Projectile.width = 20;
            Projectile.height = 20;
        }
        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            Projectile.frameCounter = 0;
            return true;
        }
        bool init;
        public override void AI() {
            Player player = Main.player[Projectile.owner];
            if (!init && Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<MiniDiskling_SpikeRing>()] < 1) {
                ProjectileHelpers.NewNetProjectile(Projectile.GetSource_FromAI(), Projectile.Center, new Vector2(), ModContent.ProjectileType<MiniDiskling_SpikeRing>(), Projectile.damage, Projectile.knockBack, Projectile.owner, Projectile.whoAmI);
                init = true;
            }
            if (!player.dead && player.HasBuff<Buffs.Pets.MiniDiskling>())
                Projectile.timeLeft = 2;
        }
	}   
}