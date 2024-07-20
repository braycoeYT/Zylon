using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Zylon.NPCs;
using System.Collections.Generic;

namespace Zylon.Projectiles.Bosses.Adeneb
{
	public class AdenebSunShieldSplit : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
		public override void SetDefaults() {
			Projectile.width = 128;
			Projectile.height = 128;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.timeLeft = 9999;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			if (Main.getGoodWorld) ihatescale = 2f;
            else ihatescale = 1.5f;
			Projectile.hide = true;
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info) {
            target.AddBuff(BuffID.OnFire, Main.rand.Next(6, 9) * 60);
        }
		int Timer;
        float dist;
        float rot;
        float ihatescale;
		NPC owner;
        public override bool PreAI() {
            owner = Main.npc[ZylonGlobalNPC.adenebBoss];
            if (owner.ai[0] == 3f) {
                Projectile.timeLeft = 2;
                ihatescale *= 0.99f;
                ihatescale -= 0.01f;
                Projectile.rotation += MathHelper.ToRadians(5);

                if (ihatescale < 0.01f) Projectile.Kill();
            }
            if (!owner.active) Projectile.Kill();
            return owner.ai[0] != 3f;
        }
        public override void AI() {
            Timer++;
			//owner = Main.npc[ZylonGlobalNPC.adenebBoss];

            if (Timer < 300) {
                if (Timer <= 60) {
                    //ihatescale -= 0.008333f;
                }
                /*else {
                    if (Main.getGoodWorld) ihatescale = 1.5f;
                    else ihatescale = 1f;
                }*/
                dist += 3.5f;
                if (dist > 210) dist = 210;
            }
            else {
                ihatescale -= 0.008333f;
                //ihatescale += 0.0075f;
                //if (Main.getGoodWorld) ihatescale += 0.0025f;
                dist -= 3.5f;
                if (Timer == 360) {
                    if (Projectile.ai[0] == 0) Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShield>(), Projectile.damage, 0f, -1, 1f);
                    Projectile.Kill();
                }
            }
            rot += 3f;
            //if (Timer > 60) rot += 3f;
            //else rot += 3f*((float)Timer/60);
            if (owner.life == 1 && Timer != 360)  {
                if (Main.netMode != NetmodeID.MultiplayerClient && Projectile.ai[0] == 0) Projectile.NewProjectile(Projectile.GetSource_FromThis(), owner.Center, Vector2.Zero, ModContent.ProjectileType<AdenebSunShield>(), Projectile.damage, 0f);
                Projectile.Kill();
            }
			if (!(owner.life < 1 || !owner.active)) Projectile.timeLeft = 2; //Active check
			//Pos fix
            int quick = 1;
            if (Projectile.ai[0] == 0) quick = -1;
            Projectile.Center = owner.Center - new Vector2(dist*quick, 0).RotatedBy(MathHelper.ToRadians(rot));
			Projectile.rotation += MathHelper.ToRadians(5);

        }
		public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D overlay = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Bosses/Adeneb/AdenebSunShieldSplit");

            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = Color.White;

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.3f;
                Main.spriteBatch.Draw(overlay, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, ihatescale, SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, ihatescale, SpriteEffects.None, 0f);

            return false;
        }
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
            behindNPCs.Add(index);
        }
    }   
}