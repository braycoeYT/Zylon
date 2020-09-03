using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneEyeTamerHat : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shiny and smooth...\nDamage reduction is increased by 2.5%\nIncreases summon damage by 62%\nIncreases minion knockback by 60%\nIncreases max amount of minions by 5\nDefense is increased when health is low");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.defense = 9;
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
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons an indecisive Ubercabochon to fight for you";
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.gemstoneSummon = true;
			player.AddBuff(mod.BuffType("Ubercabochon"), 2);
		}
		
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.62f;
			player.minionKB += 0.6f;
			player.maxMinions += 5;
			player.endurance += 0.025f;
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