using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class SaberTooth : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.LightRed;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!p.CHECK_SaberTooth) {
				player.GetCritChance(DamageClass.Generic) += 6;
				p.critExtraDmg += 0.33f;
				p.CHECK_SaberTooth = true;
			}
		}
	}
}