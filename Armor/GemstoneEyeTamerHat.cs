using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneEyeTamerHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...'\n+3 Minions\n+30% Minion Damage\n+2 Minion Knockback\n+4% Endurance\n+10 Max HP");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 18;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Night vision and a pet eyeball spring\n+3 Minions\n+24% Minion Damage\n+1 Minion Knockback";
			player.AddBuff(12, 60, false);
			player.AddBuff(65, 60, false);
			player.maxMinions += 3;
			player.minionDamage += 0.24f;
			player.minionKB += 1f;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 3;
			player.minionDamage += 0.3f;
			player.minionKB += 2f;
			player.endurance += 0.04f;
			player.statLifeMax2 += 10;
			
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 20);
			recipe.AddIngredient(ItemID.Amethyst, 5);
			recipe.AddIngredient(3381);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}