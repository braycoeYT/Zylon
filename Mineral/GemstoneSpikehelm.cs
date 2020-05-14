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
			Tooltip.SetDefault("Shiny and smooth...\n25% increased melee damage\n15% increased melee crit\n10% increased melee speed\n3% increased damage reduction\nMax life increased by 20\nDefense is increased when health is low");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 37;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Releases several gemstone spikes when you take damage, which can venom and frostburn enemies\nIncreased melee damage and crit by 5%";
			player.meleeDamage += 0.05f;
			player.meleeCrit += 5;
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();
			p.gemstoneSpikes = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.25f;
			player.meleeCrit += 15;
			player.meleeSpeed += 0.1f;
			player.statLifeMax2 += 20;
			player.endurance += 0.03f;
			if (player.statLife < player.statLifeMax2 / 3)
				player.statDefense += 12;
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