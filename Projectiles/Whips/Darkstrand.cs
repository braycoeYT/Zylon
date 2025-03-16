﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Whips
{
	public class Darkstrand : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.IsAWhip[Type] = true;
		}
		public override void SetDefaults() {
			Projectile.DefaultToWhip();

			Projectile.WhipSettings.Segments = 30; //20
			Projectile.WhipSettings.RangeMultiplier = 1f; //1f
		}
        public override void AI() {
            if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(headPos, Projectile.width, Projectile.height, ModContent.DustType<Dusts.DarkronDust>());
				dust.noGravity = false;
				dust.scale = 1f;
			}
        }
        private float Timer {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		private float ChargeTime {
			get => Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}
		bool hasHit;
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;

			if (!hasHit && target.type != NPCID.TargetDummy) {
				if (Main.myPlayer == Projectile.owner) for (int i = 0; i < 3; i++) {
					Vector2 pos = new Vector2(target.Center.X, Main.player[Projectile.owner].Center.Y - 600);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), pos + new Vector2(Main.rand.Next(-100, 101), 0), new Vector2(0, 9+3*i).RotatedByRandom(MathHelper.ToRadians(30f)), ModContent.ProjectileType<Darkstrand_Mini>(), (int)(Projectile.damage*0.5f), Projectile.knockBack/2f, Projectile.owner, i);
				}
				hasHit = true;
			}

			Projectile.damage = (int)(Projectile.damage * 0.7f);
		}
        private void DrawLine(List<Vector2> list)
        {
            Texture2D texture = TextureAssets.FishingLine.Value;
            Rectangle frame = texture.Frame();
            Vector2 origin = new Vector2(frame.Width / 2, 2);

            Vector2 pos = list[0];
            for (int i = 0; i < list.Count - 1; i++)
            {
                Vector2 element = list[i];
                Vector2 diff = list[i + 1] - element;

                float rotation = diff.ToRotation() - MathHelper.PiOver2;
                Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
                Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

                Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

                pos += diff;
            }
        }
		Vector2 headPos;
        public override bool PreDraw(ref Color lightColor) {
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);

			DrawLine(list);

			SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

			Main.instance.LoadProjectile(Type);
			Texture2D texture = TextureAssets.Projectile[Type].Value;

			Vector2 pos = list[0];

			for (int i = 0; i < list.Count - 1; i++) {
				Rectangle frame = new Rectangle(0, 0, 14, 26); //Handle size
				Vector2 origin = new Vector2(5, 8); //Player hand offset
				float scale = 1;

				if (i == list.Count - 2) {
					frame.Y = 76; //Distance from top of sprite to top of frame.
					frame.Height = 16; //Height of frame.

					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));

					headPos = pos;
				}
				else if (i > 16) {
					frame.Y = 60;
					frame.Height = 16;
				}
				else if (i > 8) {
					frame.Y = 44;
					frame.Height = 16;
				}
				else if (i > 0) {
					frame.Y = 28;
					frame.Height = 16;
				}

				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates());

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

				pos += diff;
			}
			return false;
		}
	}
}