using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shiny and smooth...\nDamage reduction is increased by 7.5%\nIncreases ranged critical strike chance by 26%\nIncreases ranged damage by 32%\n25% chance not to consume ammo\nDefense is increased when health is low");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.defense = 29;
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
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Every fifth ranged attack shoots a crystal that leeches life";
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.gemstoneRanged = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.32f;
			player.rangedCrit += 26;
			player.endurance += 0.075f;
			player.ammoCost75 = true;
			if (player.statLife < player.statLifeMax2 / 3)
				player.statDefense += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 15);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 12);
			recipe.AddIngredient(ItemID.Amethyst, 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}