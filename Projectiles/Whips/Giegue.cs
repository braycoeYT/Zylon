﻿﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Whips
{
	public class Giegue : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.IsAWhip[Type] = true;
		}
		public override void SetDefaults() {
			Projectile.DefaultToWhip();

			Projectile.WhipSettings.Segments = 24; //20
			Projectile.WhipSettings.RangeMultiplier = 0.75f; //1f
		}
		private float Timer {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		private float ChargeTime {
			get => Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
			Projectile.damage = (int)(Projectile.damage * 0.75f);
			if (Main.myPlayer == Projectile.owner) {
				if (target.type != NPCID.TargetDummy) {
					int rand = Main.rand.Next(3, 7);
					Main.player[Projectile.owner].statMana += rand;
					Main.player[Projectile.owner].ManaEffect(rand);
				}
			}
		}
		int atkTimer;
        public override void AI() {
            atkTimer++;
			if (atkTimer == 28 && Main.player[Projectile.owner].statMana >= 40) {
				Main.player[Projectile.owner].statMana -= 40;
				SoundEngine.PlaySound(SoundID.Item8, Projectile.Center);
				for (int i = 0; i < 12; i++) {
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), headPos, new Vector2(0, 6).RotatedBy(MathHelper.ToRadians(i*30)), ModContent.ProjectileType<GiegueBrainCyclone>(), (int)(Projectile.damage*0.6f), Projectile.knockBack*0.5f, Projectile.owner);
				}
			}
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
					frame.Y = 74; //Distance from top of sprite to top of frame.
					frame.Height = 18; //Height of frame.

					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));

					headPos = pos;
				}
				else if (i > 10) {
					frame.Y = 58;
					frame.Height = 16;
				}
				else if (i > 5) {
					frame.Y = 42;
					frame.Height = 16;
				}
				else if (i > 0) {
					frame.Y = 26;
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