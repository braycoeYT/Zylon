using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class OvergrownHilt : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Only at 0.1% of its true power'");
		}
		public override void SetDefaults() {
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 0.8f;
			Item.value = 1;
			Item.rare = ItemRarityID.Gray;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, 0);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
	}
}