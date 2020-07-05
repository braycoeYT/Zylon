using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cyanix
{
	public class DealersStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dealer's Stone");
			Tooltip.SetDefault("If they see this in your bag, play it cool... say its a family heirloom or something.\nReduces the cooldown of cyanix pills and healing potions by 25%");
		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.accessory = true;
			item.value = 125000;
			item.rare = 4;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.cyanixShort = true;
			player.pStone = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PhilosophersStone);
			recipe.AddIngredient(mod.ItemType("CyanixCube"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}