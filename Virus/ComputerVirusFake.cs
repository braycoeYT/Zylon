using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles.Virus
{
	public class ComputerVirusFake : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Computer Virus");
        }
		public override void SetDefaults()
		{
			projectile.width = 29;
			projectile.height = 29;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 300;
			projectile.penetrate = -1;
			aiType = -1;
			if (Main.expertMode)
				projectile.damage = 51;
			else
				projectile.damage = 83;
		}
		public override void AI()
		{
			projectile.velocity.X = 0;
			projectile.velocity.Y = 0;
			if (!NPC.AnyNPCs(NPCType<NPCs.Bosses.ComputerVirus>()))
				projectile.timeLeft = 0;
			else
				projectile.timeLeft = 300;
		}
	}   
}