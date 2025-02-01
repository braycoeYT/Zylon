using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;
using Terraria.Audio;
using Zylon.Projectiles.Whips;

namespace Zylon.Projectiles.Swords
{
	public class SlimebenderSlash : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 60;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 8;
			Projectile.extraUpdates = 4;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(2, 4) * 60, false);
			ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
            p.slimebenderDamage += hit.Damage;
			while (p.slimebenderDamage > 2500) {
				p.slimebenderDamage -= 2500;
				p.slimebenderCore++;
				if (p.slimebenderCore > 13) p.slimebenderCore = 13;
				if (Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<SlimebenderCore>()] < 1 && Main.myPlayer == Projectile.owner)
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Main.player[Projectile.owner].Center, Vector2.Zero, ModContent.ProjectileType<SlimebenderCore>(), 0, 0f, Projectile.owner);
			}
			Projectile.damage = (int)(Projectile.damage*0.7f);
			if (Projectile.damage < 1) Projectile.damage = 1;
			//Main.NewText(p.slimebenderCore + ", " + p.slimebenderDamage); //TESTING
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo info) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(2, 4) * 60, false);
		}
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers) {
            if (target.HasBuff(BuffID.Slimed)) modifiers.Defense.Flat -= 20;
        }
        public override void OnSpawn(IEntitySource source) {
            SoundEngine.PlaySound(SoundID.Item21.WithVolumeScale(1.25f), Projectile.position);
        }
        float randRot = Main.rand.NextFloat(-0.5f, 0.5f); //Curve offset - can't make it too long or hits will miss cursor
		public override void AI() {
			if (Projectile.timeLeft > 30) Projectile.scale = 1.5f*(1f-(Projectile.timeLeft-30)/30f);
			else Projectile.scale = 1.5f*Projectile.timeLeft/30f;

			if (Projectile.scale < 0.1f) Projectile.scale = 0.1f; //Looks weird if too small

			Projectile.rotation = Projectile.scale; //Absolutely genius solution for there being no oldScale

			float power = Projectile.scale*3f;
			Lighting.AddLight(Projectile.Center, new Vector3(0.116f*power, 0.179f*power, 0.237f*power));

			Projectile.velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(randRot));
		}
        public override void PostAI() {
            if (Main.rand.NextBool() && Projectile.scale > 0.75f) {
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.SlimebenderSlashDust>());
				dust.noGravity = true;
				dust.scale = 0.5f;
				float rotRand = Main.rand.NextFloat(60f, 120f);
				float dir = 1f;
				if (Main.rand.NextBool()) dir = -1f;
				dust.velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians(rotRand*dir))*0.75f;
			}
        }
        public override bool PreDraw(ref Color lightColor) {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Color color = new (152, 228, 248);

            for (int k = 0; k < Projectile.oldPos.Length; k++) {
                Vector2 drawPosEffect = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color colorAfterEffect = color * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 0.75f;
                float AfterAffectScale = ((Projectile.scale - k / (float)Projectile.oldPos.Length / 3) * (k / 8f)) + Projectile.scale;
                Main.spriteBatch.Draw(projectileTexture, drawPosEffect, null, colorAfterEffect, Projectile.oldRot[k], drawOrigin, Projectile.oldRot[k], SpriteEffects.None, 0);
            }
            Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
	}   
}