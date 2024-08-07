﻿﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Whips
{
	public class EmeraldWhip : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.IsAWhip[Type] = true;
		}
		public override void SetDefaults() {
			Projectile.DefaultToWhip();

			Projectile.WhipSettings.Segments = 20; //20
			Projectile.WhipSettings.RangeMultiplier = 0.7f; //1f
		}

		private float Timer {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		private float ChargeTime {
			get => Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}
        public override void AI() {
            Lighting.AddLight(Projectile.Center, 0.2f, 0.6f, 0.4f);
        }
		bool canInc = true;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
			Projectile.damage = (int)(Projectile.damage * 0.6f);

			if (target.type != NPCID.TargetDummy && canInc) {
				canInc = false;
				ZylonPlayer p = Main.player[Projectile.owner].GetModPlayer<ZylonPlayer>();
				p.emeraldWhipNum += 120; //+2 seconds
				if (p.emeraldWhipNum > 600) p.emeraldWhipNum = 600; //10 seconds max
				
				if (Main.player[Projectile.owner].ownedProjectileCounts[ModContent.ProjectileType<EmeraldWhipProj>()] < 1 && Main.myPlayer == Projectile.owner)
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Main.player[Projectile.owner].Center, Vector2.Zero, ModContent.ProjectileType<EmeraldWhipProj>(), 25, 4f, Projectile.owner);
			}
		}
		private void DrawLine(List<Vector2> list) {
			Texture2D texture = TextureAssets.FishingLine.Value;
			Rectangle frame = texture.Frame();
			Vector2 origin = new Vector2(frame.Width / 2, 2);

			Vector2 pos = list[0];
			for (int i = 0; i < list.Count - 1; i++) {
				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
				Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

				pos += diff;
			}
		}

		public override bool PreDraw(ref Color lightColor) {
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);

			DrawLine(list);

			SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

			Main.instance.LoadProjectile(Type);
			Texture2D texture = TextureAssets.Projectile[Type].Value;

			Vector2 pos = list[0];

			for (int i = 0; i < list.Count - 1; i++) {
				Rectangle frame = new Rectangle(0, 0, 10, 26); //Handle size
				Vector2 origin = new Vector2(5, 8); //Player hand offset
				float scale = 1;

				if (i == list.Count - 2) { //Whip Head
					frame.Y = 80; //Distance from top of sprite to top of frame.
					frame.Height = 22; //Height of frame.

					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
				}
				else if (i > 10) {
					frame.Y = 62;
					frame.Height = 18;
				}
				else if (i > 5) {
					frame.Y = 44;
					frame.Height = 18;
				}
				else if (i > 0) {
					frame.Y = 26;
					frame.Height = 18;
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