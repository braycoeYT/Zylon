using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Boomerangs
{
	public class Solaris_Stick : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.aiStyle = -1;
			Projectile.friendly = false;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 90;
			Projectile.scale = 0.75f;
			Projectile.tileCollide = false;
		}
		bool ad;
		NPC main = Main.npc[Main.maxNPCs];
		Player main2 = Main.player[Main.maxPlayers];
		Vector2 safe;
		public override void AI() {
			if (!ad) {
				if (Projectile.ai[2] == 0f) main = Main.npc[(int)Projectile.ai[0]];
				else main2 = Main.player[(int)Projectile.ai[0]];
				Projectile.rotation = Projectile.ai[1];
				if (Projectile.ai[2] == 0f) safe = main.Center - Projectile.Center;
				else safe = main2.Center - Projectile.Center;
				ad = true;
            }
			if (Projectile.ai[2] == 0f) Projectile.Center = main.Center - safe;
			else Projectile.Center = main2.Center - safe;
			if (Projectile.ai[2] == 0f && !main.active) Projectile.Kill();
			if (Projectile.ai[2] == 1f && !main2.active) Projectile.Kill();
		}
		public override void PostAI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch);
				dust.noGravity = true;
				dust.scale = 1f;
			}
        }
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
        public override void OnKill(int timeLeft) {
			float rand = Main.rand.NextFloat(0f, 45f);
			//int heal = Main.rand.Next(8);
            if (Main.myPlayer == Projectile.owner) for (int x = 0; x < 8; x++) {
				int proj = ModContent.ProjectileType<Solaris_FlameofHope>();
				//if (x == heal) proj = ModContent.ProjectileType<Solaris_FlameofHopeHeal>();
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, proj, Projectile.damage/3, Projectile.knockBack/3, Main.myPlayer, x*45+rand);
			}
		}
    }   
}