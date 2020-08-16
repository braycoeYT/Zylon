using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Crate
{
	public class Celldigger : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 9;
			item.melee = true;
			item.width = 28;
			item.height = 28;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 1;
			item.knockBack = 1.1f;
			item.value = 75000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
	}
}