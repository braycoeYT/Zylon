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
			Tooltip.SetDefault("+5% movement speed\n+10% mining speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<DiscusBreastplate>() && legs.type == ItemType<DiscusLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You now glow in the dark\n+7% melee damage\n+10% movement speed";
			Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.2f, 0.4f, 0.6f);
			player.meleeDamage += 0.07f;
			player.maxRunSpeed += 0.1f;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.maxRunSpeed += 0.05f;
			player.pickSpeed -= 0.1f;
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