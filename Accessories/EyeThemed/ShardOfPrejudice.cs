using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories.EyeThemed
{
	public class ShardOfPrejudice : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shard of Prejudice");
			Tooltip.SetDefault("Using a javelance will launch a bleeding javelance which rains blood");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 42;
			item.accessory = true;
			item.value = 21000;
			item.rare = ItemRarityID.LightPurple;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.redJavelance = true;
		}
	}
}