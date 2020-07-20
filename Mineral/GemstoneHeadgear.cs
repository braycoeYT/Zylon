using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...\nDamage reduction is increased by 5%\nIncreases magic critical strike chance by 15%\nIncreases magic damage by 22%\nMax mana increased by 40 and mana cost is decreased by 18%\nDefense is increased when health is low");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 500000;
			item.rare = 11;
			item.defense = 19;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Hurting enemies can summon mana crystals that leech extra mana for you";
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.gemstoneManaBullet = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.22f;
			player.magicCrit += 15;
			player.manaCost -= 0.18f;
			player.statManaMax2 += 40;
			player.endurance += 0.05f;
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