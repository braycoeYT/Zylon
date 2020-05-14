using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Magentite
{
	[AutoloadEquip(EquipType.Head)]
	public class MagentiteHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("-3% Mana Cost");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 5000;
			item.rare = 1;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<MagentiteBreastplate>() && legs.type == ItemType<MagentiteBoots>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "1 Defense\n-6% Mana Cost";
			player.statDefense += 1;
			player.manaCost -= 0.06f;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.manaCost -= 0.03f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MagentiteBar"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}