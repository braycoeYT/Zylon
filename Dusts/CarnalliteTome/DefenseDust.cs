using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts.CarnalliteTome
{
	public class DefenseDust : ModDust
	{
        public override void OnSpawn(Dust dust) {
            dust.frame = new Rectangle(0, Main.rand.Next(3) * 8, 8, 8);
            dust.rotation = Main.rand.NextFloat(6.28f);
            dust.noGravity = true;
        }
        public override bool Update(Dust dust) {
            dust.position += dust.velocity;
            dust.scale -= 0.0174f;
            if (dust.scale < 0.1f)
                dust.active = false;

            dust.velocity *= 0.96f;

            return false;
        }
    }
}