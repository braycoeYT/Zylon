using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class EnchantedIceCube : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 0, 12);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item2;
			Item.noUseGraphic = true;
			Item.consumable = true;
			Item.buffType = BuffID.WellFed;
            Item.buffTime = 5400;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.noMelee = true;
		}
	}
}