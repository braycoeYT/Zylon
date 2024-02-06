using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Food
{
	public class ChocolateMacaron : ModItem
	{
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 26;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.value = Item.sellPrice(0, 0, 4);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
			Item.maxStack = 999;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
            Item.buffTime = 32400;
		}
	}
}