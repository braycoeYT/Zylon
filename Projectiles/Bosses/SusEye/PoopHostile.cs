using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Bosses.SusEye
{
	public class PoopHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Poop");
        }
		public override void SetDefaults() {
			AIType = ProjectileID.Bullet;
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 300;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}
        public override void OnSpawn(IEntitySource source) {
            if (Main.rand.NextBool(4)) SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Projectiles/ZylonLoreBasically"));
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
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
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
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/SusEye/PoopHostile");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), new Color(255, 255, 255, 255-Projectile.alpha), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}