using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Zylon.Dusts.Effects
{
	public class SuperheatedSmoke : ModDust
	{

		public override string Texture => "Zylon/Dusts/Effects/Smoke";
		public override void OnSpawn(Dust dust)
		{
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 36, 34, 36);
			dust.rotation = Main.rand.NextFloat(6.28f);
			dust.noGravity = true;
			dust.scale = Main.rand.NextFloat(0.7f, 1.4f);
		}
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
			Color color = new Color(35, 25, 48);
			if (dust.alpha < 120)
				color = Color.Lerp(new Color(211, 53, 133), new Color(35, 25, 48), dust.alpha / 120f);

			return color * ((255f - dust.alpha) / 255f);
        }
        public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;

			if (dust.alpha <= 120)
            {
				dust.alpha += (int)MathHelper.Lerp(4, 2, dust.alpha / 120f);
			} else
            {
				dust.alpha += 2;
            }

			dust.scale += MathHelper.Lerp(0.003f, 0.008f, dust.alpha / 255f);
			dust.velocity *= MathHelper.Lerp(0.98f, 0.75f, dust.alpha / 175f);
			dust.rotation += MathHelper.Lerp(0.01f, 0.001f, dust.alpha / 175f) * (dust.dustIndex % 2 == 0 ? -1 : 1);

			if (dust.alpha >= 255)
				dust.active = false;

			return false;
		}
	}
	public class SuperheatedSmokeFastFade : ModDust
	{

		public override string Texture => "Zylon/Dusts/Effects/Smoke";
		public override void OnSpawn(Dust dust)
		{
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 36, 34, 36);
			dust.rotation = Main.rand.NextFloat(6.28f);
			dust.noGravity = true;
			dust.scale = Main.rand.NextFloat(0.4f, 0.8f);
		}
		public override Color? GetAlpha(Dust dust, Color lightColor)
		{
			Color color = new Color(35, 25, 48);
			if (dust.alpha < 120)
				color = Color.Lerp(new Color(211, 53, 133), new Color(35, 25, 48), dust.alpha / 120f);

			return color * ((255f - dust.alpha) / 255f);
		}
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;

			if (dust.alpha <= 120)
			{
				dust.alpha += (int)MathHelper.Lerp(8, 4, dust.alpha / 120f);
			}
			else
			{
				dust.alpha += 4;
			}

			dust.scale += MathHelper.Lerp(0.003f, 0.008f, dust.alpha / 255f);
			dust.velocity *= MathHelper.Lerp(0.98f, 0.75f, dust.alpha / 175f);
			dust.rotation += MathHelper.Lerp(0.01f, 0.001f, dust.alpha / 175f) * (dust.dustIndex % 2 == 0 ? -1 : 1);

			if (dust.alpha >= 255)
				dust.active = false;

			return false;
		}
	}

	public class SuperheatedSmokeSlowFade : ModDust
	{

		public override string Texture => "Zylon/Dusts/Effects/Smoke";
		public override void OnSpawn(Dust dust)
		{
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 36, 34, 36);
			dust.rotation = Main.rand.NextFloat(6.28f);
			dust.noGravity = true;
			dust.scale = Main.rand.NextFloat(1f, 1.6f);
			dust.alpha = 20;
		}
		public override Color? GetAlpha(Dust dust, Color lightColor)
		{
			Color color = new Color(35, 25, 48);
			if (dust.alpha < 120)
				color = Color.Lerp(new Color(211, 53, 133), new Color(35, 25, 48), dust.alpha / 120f);

			return color * ((255f - dust.alpha) / 255f);
		}
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;

			dust.alpha += (int)MathHelper.Lerp(4, 1, dust.alpha / 255f);

			dust.scale += MathHelper.Lerp(0.003f, 0.008f, dust.alpha / 255f);
			dust.velocity *= MathHelper.Lerp(0.98f, 0.75f, dust.alpha / 175f);
			dust.rotation += MathHelper.Lerp(0.01f, 0.001f, dust.alpha / 175f) * (dust.dustIndex % 2 == 0 ? -1 : 1);

			if (dust.alpha >= 255)
				dust.active = false;

			return false;
		}
	}
}