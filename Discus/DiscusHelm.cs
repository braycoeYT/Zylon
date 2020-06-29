using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Discus
{
	[AutoloadEquip(EquipType.Head)]
	public class DiscusHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandgrain Electrohelm");
			Tooltip.SetDefault("Mining speed increased by 2%\nDamage increased by 2%\nMovement speed increased by 5%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 25000;
			item.rare = 1;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<DiscusBreastplate>() && legs.type == ItemType<DiscusLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immune to electricity\nTaking over 40 damage summons a temporary electric field to damage enemies";
			player.buffImmune[144] = true;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.electricField = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.allDamage += 0.02f;
			player.maxRunSpeed += 0.05f;
			player.pickSpeed -= 0.02f;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZylonianDesertCore"), 7);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}