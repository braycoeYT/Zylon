using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class GloryPetals : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 25;
		}
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 18;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 0, 12);
			Item.rare = ItemRarityID.White;
		}
	}
}
