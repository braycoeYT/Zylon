using Terraria.ModLoader;
using System;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zylon.Dusts
{
	public class ExperimentalSyringeDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			//dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
			dust.scale = 1f;
			dust.noGravity = true;
			dust.velocity = Vector2.Zero;
			dust.alpha = 0;
			dust.rotation = Main.rand.NextFloat(6.28f);
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.04f;
			if (dust.scale < 0.1f) {
				dust.active = false;
			}
			return false;
		}
        /*public override bool PreDraw(Dust dust) {
			Main.spriteBatch.Draw(Texture2D.Value, Main.screenPosition, dust.frame, Color.White, dust.rotation, new Vector2(4f, 4f), dust.scale, SpriteEffects.None, 0f);
			return false;
		}*/
    }
}