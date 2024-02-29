using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Materials
{
	public class SpectralFairyDust : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(0, 0, 1, 50);
			Item.rare = ItemRarityID.Green;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.IceTorch);
				dust.noGravity = true;
				dust.scale = 0.75f;
			}
		}
	}
}