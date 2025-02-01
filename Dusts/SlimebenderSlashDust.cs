using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class SlimebenderSlashDust : ModDust
	{
        public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			//dust.color = new Color(22, 104, 108);
			dust.scale = 1f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			//dust.alpha = 100;
			dust.frame = new Rectangle(0, 0, 22, 22);
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			dust.rotation += MathHelper.ToRadians(dust.velocity.Length());
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.116f, 0.179f, 0.237f);
			dust.scale -= 0.02f;
			if (dust.scale < 0.25f) {
				dust.active = false;
			}
			return false;
		}
	}
}