using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts.CarnalliteTome
{
	public class ManaFlowerBuffDust : ModDust
	{
        public override void OnSpawn(Dust dust) {
            dust.frame = new Rectangle(0, 0, 16, 16);
            dust.noGravity = true;
        }
        public override bool Update(Dust dust) {
            dust.position += new Vector2(dust.velocity.X, -0.8f);
            dust.scale -= 0.0174f;
            if (dust.scale < 0.1f)
                dust.active = false;

            dust.velocity.X *= 0.99f;

            return false;
        }
    }
}