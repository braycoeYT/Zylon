using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class SearedStone : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() { //Add cool glow effect?
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 2);
			Item.rare = ItemRarityID.Green;
		}
	}
}