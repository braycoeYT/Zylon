using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Microbiome.Crate
{
	public class Celldigger : ModItem
	{
		public override void SetDefaults()  {
			item.damage = 9;
			item.melee = true;
			item.width = 28;
			item.height = 28;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1.1f;
			item.value = 75000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
	}
}