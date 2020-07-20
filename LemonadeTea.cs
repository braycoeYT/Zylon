using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class LemonadeTea : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Combines two amazing drinks!\nGrants the player the Happy buff");
		}
		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 22;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
			item.value = 7500;
			item.rare = 3;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.maxStack = 9999;
			item.UseSound = SoundID.Item2;
			item.noUseGraphic = true;
			item.consumable = true;
			item.healLife = 105;
			item.healMana = 55;
			item.buffType = BuffID.Sunflower;
            item.buffTime = 1800;
			item.potion = true;
		}
	}
}