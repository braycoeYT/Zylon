using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneSpikehelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...\nDamage reduction is increased by 10%\nIncreases melee critical strike chance by 25%\nIncreases melee damage by 25%\nIncreases melee speed by 17%\nDefense is increased when health is low");
		} //Crit +4 - 5, Damage +6 - 10, Defense +15

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 500000;
			item.rare = 11;
			item.defense = 39;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "After taking damage, there is a 25% chance of your defense increasing by 40 for a bit";
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.gemstoneMelee = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.25f;
			player.meleeCrit += 25;
			player.meleeSpeed += 0.17f;
			player.endurance += 0.1f;
			if (player.statLife < player.statLifeMax2 / 3)
				player.statDefense += 15;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 15);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 12);
			recipe.AddIngredient(ItemID.Amethyst, 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}