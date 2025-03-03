using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class SoulofByte : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 80);
			Item.rare = ItemRarityID.Pink;
		}
	}
}