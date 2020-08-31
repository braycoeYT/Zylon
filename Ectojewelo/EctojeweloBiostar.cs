using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Ectojewelo
{
	public class EctojeweloBiostar : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Use this to increase max mana by 50\nOne time use\nFighters of the Calamity need not apply\nAwakeners of the Elements need not apply");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override bool CanUseItem(Player player)
		{
			Mod CalamityMod = ModLoader.GetMod("CalamityMod");
			if (CalamityMod == null)
			{
				Mod EA = ModLoader.GetMod("EA");
				if (EA == null)
				{
					return player.statManaMax == 200 && player.GetModPlayer<ZylonPlayer>().upgradeStars < 1;
				}
			}
			return false;
		}

		public override bool UseItem(Player player)
		{
			player.statManaMax2 += 50;
			player.statMana += 50;
			if (Main.myPlayer == player.whoAmI)
			{
				player.ManaEffect(50);
			}
			player.GetModPlayer<ZylonPlayer>().upgradeStars += 1;
			return true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 20);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(ItemID.ManaCrystal, 5);
			recipe.AddIngredient(mod.ItemType("XenicCore"));
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}