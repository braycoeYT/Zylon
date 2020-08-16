using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Braycoe
{
	public class DeliciousGelatin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Quite squishy as well");
		}
		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 22;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.value = 400;
			item.rare = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.maxStack = 9999;
			item.UseSound = SoundID.Item2;
			item.noUseGraphic = true;
			item.consumable = true;
			item.buffType = BuffID.Slimed;
            item.buffTime = 10 * 3600;
		}
		public override void OnConsumeItem(Player player)
		{
			player.AddBuff(BuffID.WellFed, 10 * 3600, false);
		}
	}
}