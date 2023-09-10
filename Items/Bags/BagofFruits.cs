using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bags
{
	public class BagofFruits : ModItem
	{
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			DisplayName.SetDefault("Bag of Fruits");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
=======
			// DisplayName.SetDefault("Bag of Fruits");
			// Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
>>>>>>> ProjectClash
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 15;
		}
		public override void SetDefaults() {
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 26;
			Item.height = 36;
			Item.rare = ItemRarityID.Green;
		}
		public override bool CanRightClick() {
			return true;
		}
		public override void ModifyItemLoot(ItemLoot itemLoot) {
			itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.Apple, ItemID.Apricot, ItemID.Grapefruit, ItemID.Lemon, ItemID.Peach, ItemID.Cherry, ItemID.Plum, ItemID.BlackCurrant, ItemID.Elderberry, ItemID.BloodOrange, ItemID.Rambutan, ItemID.Mango, ItemID.Pineapple, ItemID.Banana, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Starfruit));
			itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.Apple, ItemID.Apricot, ItemID.Grapefruit, ItemID.Lemon, ItemID.Peach, ItemID.Cherry, ItemID.Plum, ItemID.BlackCurrant, ItemID.Elderberry, ItemID.BloodOrange, ItemID.Rambutan, ItemID.Mango, ItemID.Pineapple, ItemID.Banana, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Starfruit));
			itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.Apple, ItemID.Apricot, ItemID.Grapefruit, ItemID.Lemon, ItemID.Peach, ItemID.Cherry, ItemID.Plum, ItemID.BlackCurrant, ItemID.Elderberry, ItemID.BloodOrange, ItemID.Rambutan, ItemID.Mango, ItemID.Pineapple, ItemID.Banana, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Starfruit));
			itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.Apple, ItemID.Apricot, ItemID.Grapefruit, ItemID.Lemon, ItemID.Peach, ItemID.Cherry, ItemID.Plum, ItemID.BlackCurrant, ItemID.Elderberry, ItemID.BloodOrange, ItemID.Rambutan, ItemID.Mango, ItemID.Pineapple, ItemID.Banana, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Starfruit));
			itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, ItemID.Apple, ItemID.Apricot, ItemID.Grapefruit, ItemID.Lemon, ItemID.Peach, ItemID.Cherry, ItemID.Plum, ItemID.BlackCurrant, ItemID.Elderberry, ItemID.BloodOrange, ItemID.Rambutan, ItemID.Mango, ItemID.Pineapple, ItemID.Banana, ItemID.Coconut, ItemID.Dragonfruit, ItemID.Starfruit));
		}
	}
}