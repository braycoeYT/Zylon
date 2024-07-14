using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class SlimePendant : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 28;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 20);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.jumpSpeedBoost += 1.25f;
			player.maxFallSpeed += 3f;
			p.slimePendant = true;
		}
	}
}