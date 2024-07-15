using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Zylon.NPCs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Bosses.SaburRex
{
	public class SaburRexMartianSaucerWarning : ModProjectile
	{
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults() {
			Projectile.width = 42;
			Projectile.height = 48;
			Projectile.aiStyle = -1;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.timeLeft = 31;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
			Projectile.extraUpdates = 30;
		}
        public override void AI() {
			NPC owner = Main.npc[ZylonGlobalNPC.saburBoss];
			if (owner.life < 2 || !owner.active) Projectile.Kill();
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (Main.netMode != NetmodeID.MultiplayerClient) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SaburRexMartianSaucerWarning2>(), Projectile.damage, 0f, -1, Projectile.rotation, Projectile.ai[1]);
		}
		public override void OnSpawn(IEntitySource source) {
			SoundEngine.PlaySound(SoundID.Item93, Projectile.position);
			Projectile.position += Projectile.velocity*1.3f;
        }
    }   
}