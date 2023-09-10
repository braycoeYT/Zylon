using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class ChlorophyteBlowspitterDust : ModDust
	{
        public override void OnSpawn(Dust dust) {
            dust.frame = new Rectangle(0, 0, 8, 8);
            dust.noGravity = true;
        }
        public override bool Update(Dust dust) {
			dust.velocity = Vector2.Zero;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.25f, 0.21f, 0f);
			dust.scale -= 0.05f;
			if (dust.scale < 0.1f) {
				dust.active = false;
			}
			return false;
		}
    }
}