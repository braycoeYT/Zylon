using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts
{
	public class ZincOreDust : ModDust
	{
        public override void OnSpawn(Dust dust) {
            dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
            dust.rotation = Main.rand.NextFloat(6.28f);
        }
        public override bool Update(Dust dust) {
            dust.velocity += Vector2.UnitY.RotatedBy(0, Vector2.Zero) * dust.scale * 0.175f;
            dust.position += dust.velocity;
            dust.scale -= 0.015f;
            if (dust.scale < 0.1f)
                dust.active = false;
            return false;
        }
    }
}