using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Mineral
{
	public class ZMEBG : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ZME Background");
        }
		public override void SetDefaults()
		{
			projectile.width = 1000;
			projectile.height = 600;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 99999;
			projectile.ignoreWater = true;
			projectile.damage = 0;
			projectile.tileCollide = false;
			projectile.owner = (int)Player.FindClosest(projectile.position, projectile.width, projectile.height);
			projectile.alpha = 200;
			projectile.scale = 2f;
			projectile.light = 1f;
		}
		public override void AI()
		{
			projectile.position.X = Main.player[projectile.owner].Center.X - 500;
			projectile.position.Y = Main.player[projectile.owner].Center.Y + 600;
			if (NPC.AnyNPCs(NPCType<NPCs.Bosses.ZylonianMineralExtractor>()))
				projectile.timeLeft = 9999;
			else
				projectile.timeLeft = 0;
		}
	}   
}