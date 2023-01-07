using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Food
{
	public class GalacticBrownie : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Medium improvements to all stats\n'The rainbow bits, oh, the rainbow bits...'");
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 24;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.Lime;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 999;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed2;
            Item.buffTime = 28800;
		}
	}
}