using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class TreeWhacker : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("'Only hurts a little!'");
        }
        public override void SetDefaults() {
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1.8f;
			Item.value = Item.buyPrice(0, 3);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.axe = 1;
			Item.useTurn = true;
		}
	}
}