using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ectojewelo
{
	public class ResetStats : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Reset Stats");
			Tooltip.SetDefault("Not for usage of the public, its for testing");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = 6500000;
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override bool UseItem(Player player)
		{
			player.GetModPlayer<ZylonPlayer>().upgradeHearts = 0;
			player.GetModPlayer<ZylonPlayer>().upgradeStars = 0;
			return true;
		}
	}
}