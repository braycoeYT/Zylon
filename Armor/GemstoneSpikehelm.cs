using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneSpikehelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...\n+14% Melee Damage\n+13% Melee Crit\n+50 Max HP\n+8% endurance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 41;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Effects of thorn potion\n+7 Defense\n+75 Max HP\n+10% Melee Damage\n+11% Melee Crit";
			player.AddBuff(14, 60, false);
			player.statDefense += 7;
			player.statLifeMax2 += 75;
			player.meleeDamage += 0.10f;
			player.meleeCrit += 11;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.14f;
			player.meleeCrit += 13;
			player.statLifeMax2 += 50;
			player.endurance += 0.08f;
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