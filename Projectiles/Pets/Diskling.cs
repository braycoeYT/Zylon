using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.Audio;

namespace Zylon.Projectiles.Pets
{
	public class Diskling : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            AIType = ProjectileID.ZephyrFish;
            Projectile.width = 20;
            Projectile.height = 20;
        }
        public override bool PreAI() {
            rot += MathHelper.ToRadians(4);
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            Projectile.frameCounter = 0;
            if (death) {
                Projectile.velocity *= 0.95f;
            }
            dist = Projectile.velocity.Length()/6f;
            if (dist > 1f) dist = 1f;
            return !death;
        }
        float rot;
        float dist = 0f;
        bool death;
        public override void AI() {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff<Buffs.Pets.Diskling>())
                Projectile.timeLeft = 2;
            else if (player.dead && !death) {
                Projectile.timeLeft = 90;
                death = true;
            }

            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) > 1900f) Projectile.Center = Main.player[Projectile.owner].Center;
        }
        public override void OnKill(int timeLeft) {
            SoundEngine.PlaySound(SoundID.NPCDeath14, Projectile.Center);
            if (death) {
                for (int i = 0; i < 8; i++) Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(Projectile.width/2f, Projectile.height/2f), new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-3, 5)), ModContent.GoreType<Gores.Projectiles.DisklingSpike>());
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center - new Vector2(Projectile.width/2f, Projectile.height/2f), new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 2)), ModContent.GoreType<Gores.Projectiles.DisklingMain>());
            }
        }
        public override bool PreDraw(ref Color lightColor) {
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D spikeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Pets/Diskling_Spike");
            Texture2D eyeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Pets/Diskling_Eye");
            if (death) {
                eyeTexture = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Pets/Diskling_EyeDeath");
            }
			//int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			//int spriteSheetOffset = frameHeight * Projectile.frame;
			Vector2 pos = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();
			Main.EntitySpriteDraw(spikeTexture, pos, null, lightColor*((255f-Projectile.alpha)/255f), rot, new Vector2(spikeTexture.Width / 2f, spikeTexture.Height / 2f), Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture, pos, null, lightColor*((255f-Projectile.alpha)/255f), 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(eyeTexture, pos + new Vector2(0, -6f*dist).RotatedBy(Projectile.velocity.ToRotation()+MathHelper.PiOver2), null, Color.White*((255f-Projectile.alpha)/255f), 0f, new Vector2(eyeTexture.Width / 2f, eyeTexture.Height / 2f), Projectile.scale, SpriteEffects.None, 0);
			return false;
		}
	}   
}