using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Empress
{
	[AutoloadEquip(EquipType.Head)]
	public class EmpressHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases your max amount of minions\nIncreases minion damage by 11%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 600000;
			item.rare = ItemRarityID.Lime;
			item.defense = 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<EmpressBreastplate>() && legs.type == ItemType<EmpressLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases minion damage by 27%";
			player.minionDamage += 0.27f;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.11f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmpressShard"), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}