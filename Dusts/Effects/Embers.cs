using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts.Effects
{
	public class SuperheatedEmber : ModDust
	{

		public override string Texture => "Zylon/Assets/Bloom/Glow120_120";
		public override void OnSpawn(Dust dust)
		{
			dust.frame = new Rectangle(0, 0, 120, 120);
			dust.rotation = Main.rand.NextFloat(6.28f);
			dust.noGravity = true;
			dust.scale = Main.rand.NextFloat(0.02f, 0.06f);
		}
		public override Color? GetAlpha(Dust dust, Color lightColor)
		{
			Color color;
			if (dust.alpha % 120 <= 60)
			{
				color = Color.Lerp(new Color(255, 110, 37), new Color(250, 18, 67), ((dust.alpha % 60) / 60f));
			}
			else
			{
				color = Color.Lerp(new Color(250, 18, 67), new Color(255, 110, 37), (((dust.alpha - 60) % 60) / 60f));
			}

			return color * ((255f - dust.alpha) / 255f);
		}
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;

			dust.alpha += (int)MathHelper.Lerp(4, 1, dust.alpha / 255f);

			dust.velocity.X *= MathHelper.Lerp(0.98f, 0.75f, dust.alpha / 175f);
			dust.velocity.X += Main.rand.NextFloat(-0.3f, 0.3f);
			dust.velocity.Y *= MathHelper.Lerp(1f, 0.87f, dust.alpha / 175f);
			dust.velocity.Y -= MathHelper.Lerp(0.02f, 0.12f, dust.alpha / 175f);

			if (dust.alpha >= 255)
				dust.active = false;

			return false;
		}
	}
}