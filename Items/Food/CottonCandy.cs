using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Food
{
	public class CottonCandy : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Minor improvements to all stats\n'Now this is FLUFFY!'");
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 24;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 2);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 999;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
            Item.buffTime = 43200;
		}
	}
}