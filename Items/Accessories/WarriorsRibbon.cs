using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class WarriorsRibbon : ModItem
	{
		public override void SetDefaults() {
			Item.width = 12;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetCritChance(DamageClass.Generic) += (int)(15-15*((float)player.statLife/(float)player.statLifeMax2));
			p.critExtraDmg += 0.25f-0.25f*((float)player.statLife/(float)player.statLifeMax2);
		}
	}
}