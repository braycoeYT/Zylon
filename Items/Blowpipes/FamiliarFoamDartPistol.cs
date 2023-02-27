using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class FamiliarFoamDartPistol : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'It's this or nothin', they said...'\nUses seeds as ammo");
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 33;
			Item.knockBack = 3.5f;
			Item.shootSpeed = 15f;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.value = Item.sellPrice(0, 3);
			Item.autoReuse = true;
			Item.rare = ItemRarityID.LightRed;
			Item.useStyle = ItemUseStyleID.Shoot;
		}
	}
}