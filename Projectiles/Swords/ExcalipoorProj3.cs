using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Zylon.Projectiles.Swords
{
	public class ExcalipoorProj3 : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 90;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = (int)Projectile.ai[0];
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
			if (target.type != NPCID.TargetDummy && !target.SpawnedFromStatue) p.excalipoorPower += 1;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            if (info.PvP) {
				ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
				p.excalipoorPower += 1;
			}
        }
		float chance;
        public override void AI() {
			Projectile.localNPCHitCooldown = (int)Projectile.ai[0];
			Projectile.velocity *= 0.93f;
			Projectile.rotation += 0.08f*Projectile.velocity.Length() + 0.1f;

			//Determine which dust - this matches the tooltip, btw.
			chance = Main.DiscoG/255f;

			int dustType = ModContent.DustType<Dusts.BlackDust>();
			if (Main.rand.NextFloat() < chance) dustType = ModContent.DustType<Dusts.WhiteDust>();

            for (int i = 0; i < 2; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
        }
        public override void OnKill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);

			int dustType = ModContent.DustType<Dusts.BlackDust>();
			if (Main.rand.NextFloat() < chance) dustType = ModContent.DustType<Dusts.WhiteDust>();
			for (int i = 0; i < 8; i++) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}

			//MORE PROJECTILES MWHAHAHAHA
			float rand = Main.rand.NextFloat(72);
			if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 5; i++) {
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 9).RotatedBy(MathHelper.ToRadians(rand+i*72)), ModContent.ProjectileType<ExcalipoorProj2>(), Projectile.damage, Projectile.knockBack/2, Projectile.owner, Projectile.ai[0]);
			}
		}
		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D altTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Swords/ExcalipoorProj3_Light");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

			Vector2 drawOrigin = new Vector2(texture.Width / 2f, frameHeight / 2f);

			Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*((float)(255-Projectile.alpha)/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			Main.EntitySpriteDraw(altTexture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), Color.White*chance*((float)(255-Projectile.alpha)/255f), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0);
			return false;
		}
	}   
}