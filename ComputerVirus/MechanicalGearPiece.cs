using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.ComputerVirus
{
	public class MechanicalGearPiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Gear Piece");
			Tooltip.SetDefault("It keeps on running...");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 10000;
			item.rare = 5;
			item.expert = true;
		}
	}
}