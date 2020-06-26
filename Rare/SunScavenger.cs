using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Rare
{
	public class SunScavenger : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Come here, my sun\nCrits burn the heck outta your enemies\nRare item");
		}

		public override void SetDefaults() 
		{
			item.damage = 16;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2.9f;
			item.value = 275000;
			item.rare = -11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit = 2;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (crit)
			{
				target.AddBuff(BuffID.OnFire, 120, false);
				target.AddBuff(BuffID.CursedInferno, 120, false);
				target.AddBuff(BuffID.ShadowFlame, 120, false);
				target.AddBuff(BuffID.Frostburn, 120, false);
			}
		}
	}
}