using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cyanix
{
	[AutoloadEquip(EquipType.Head)]
	public class CyanixHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+4% Melee Speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 5000;
			item.rare = 1;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<CyanixBreastplate>() && legs.type == ItemType<CyanixLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "3 Defense\nCyanix Boost Length is longer";
			player.statDefense += 3;
			
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();

			p.CyanixLong = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.04f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CyanixBar"), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}