using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...'\n+27% Ranged Damage\n+16% Ranged Crit\n+6% endurance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 34;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "A 3.5% Chance of only taking one damage\n+10 Defense\n+35 Max HP\n+15% Ranged Damage\n+9% Ranged Crit";
			player.statDefense += 10;
			player.statLifeMax2 += 35;
			player.rangedDamage += 0.15f;
			player.rangedCrit += 9;
			if (Main.rand.NextFloat() < .035f)
			{
				player.endurance += 100;
			}
			else
			{
				player.endurance += 0;
			}
		}
		
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.27f;
			player.rangedCrit += 16;
			player.endurance += 0.06f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 20);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddIngredient(2757);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}