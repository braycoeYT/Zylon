using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class GlazedLens : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Eye can see!'\nIncreases crit chance by 4\nCritical strikes spawn temporary eyes to rotate around the player, damaging enemies\nThe higher the player's crit chance, the faster the eyes move");
		}
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetCritChance(DamageClass.Generic) += 4;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.glazedLens = true;
		}
	}
}