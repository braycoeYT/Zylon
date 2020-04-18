using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...\n+55 Max Mana\n+30 Max HP\n+17% Magic Crit\n+30% Magic Damage\n+5% endurance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 23;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "A leaf crystal defends you\n+15 Mana\n+30 Max HP\n+11% Magic Damage\n+9% Magic Crit";
			player.AddBuff(60, 60, false);
			player.statManaMax2 += 15;
			player.statLifeMax2 += 30;
			player.magicDamage += 0.11f;
			player.magicCrit += 9;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 55;
			player.statLifeMax2 += 30;
			player.magicDamage += 0.30f;
			player.magicCrit += 17;
			player.endurance += 0.05f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 20);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}