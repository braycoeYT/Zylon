using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class GalacticSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galactic Soul");
			Tooltip.SetDefault("Gives the player 'Gemstone Casing' for 10 seconds");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults()
		{
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			item.width = 40;
			item.height = 40;
			item.maxStack = 9999;
			item.value = 0;
			item.rare = 1;
		}
		public override bool OnPickup(Player player)
		{
			player.AddBuff(mod.BuffType("GemstoneCasing"), 600);
			return false;
		}
	}
}