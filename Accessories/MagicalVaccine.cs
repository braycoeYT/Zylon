using Terraria;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class MagicalVaccine : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Scares the heck outta those flat-earthers\nImmunity to feral bite");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 5000;
			item.rare = 2;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[148] = true;
		}
	}
}