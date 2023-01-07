using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class SaberTooth : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Fresh from the maw of a slain canine'\nIncreases critical strike chance by 6\nCritical strikes deal 33% more damage");
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
			if (!p.st2check) {
				player.GetCritChance(DamageClass.Generic) += 6;
				p.critExtraDmg += 0.33f;
				p.st2check = true;
			}
		}
	}
}