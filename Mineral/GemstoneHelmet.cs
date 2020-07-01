using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...\n25% increased Ranged Damage\n15% increased Ranged Crit\nMax life increased by 15\n3% increased damage reduction\n20% chance not to consume ammo\nDefense is increased when health is low");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 25;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Every tenth attack shoots a crystal that leeches life\nIncreased ranged damage and crit by 5%";
			player.rangedDamage += 0.05f;
			player.rangedCrit += 5;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.gemstoneHealBullet = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.25f;
			player.rangedCrit += 15;
			player.statLifeMax2 += 15;
			player.endurance += 0.03f;
			player.ammoCost80 = true;
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