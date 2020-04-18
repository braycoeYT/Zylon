using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstonePlaguehead : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...\n+21% Contagional Damage\n+5% Contagional Crit\n+3 Contagional Regen Amount\n+300 Contagion Points\n+5% endurance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 29;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Reveals the locations of enemies\n+3 Contagional Regen Amount\n+12% Contagional Damage\n+7% Contagional Crit\n+300 Contagion Points";
			player.AddBuff(17, 60, false);
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalRegenAmount += 3;
			modPlayer.ContagionalDamageMult += 0.12f;
			modPlayer.ContagionalCrit += 7;
			modPlayer.ContagionalResourceMax2 += 300;
		}
		
		public override void UpdateEquip(Player player)
		{
			var modPlayer = Items.Contagional.ContagionalPlayer.ModPlayer(player);
			modPlayer.ContagionalDamageMult += 0.21f;
			modPlayer.ContagionalCrit += 5;
			modPlayer.ContagionalResourceMax2 += 300;
			player.endurance += 5;
			modPlayer.ContagionalRegenAmount += 3;
			
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