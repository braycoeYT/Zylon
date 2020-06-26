using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome
{
	[AutoloadEquip(EquipType.Head)]
	public class SymbiosisHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases max health by 20");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 50000;
			item.rare = 1;
			item.defense = 6;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<SymbiosisPlates>() && legs.type == ItemType<SymbiosisLeggings>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Max health is increased by 30";
			player.statLifeMax2 += 30;
		}
		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 20;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TwistedMembraneBar"), 15);
			recipe.AddIngredient(mod.ItemType("Cytoplasm"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}