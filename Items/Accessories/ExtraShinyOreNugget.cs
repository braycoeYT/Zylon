using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class ExtraShinyOreNugget : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'I love miners!'\nEmits a faint glow from within your pack");
		}
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 36;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.Green;
		}
        public override void UpdateInventory(Player player) {
            Lighting.AddLight(player.Center, 0.25f, 0.25f, 0f);
        }
        public override void Update(ref float gravity, ref float maxFallSpeed) {
            Lighting.AddLight(Item.Center, 0.25f, 0.25f, 0f);
        }
    }
}