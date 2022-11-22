using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class VenomousPills : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Take a pill a day to build up a resistance!'\nGrants immunity to acid venom");
		}
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Pink;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.buffImmune[BuffID.Venom] = true;
        }
	}
}