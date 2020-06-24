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
			Tooltip.SetDefault("Shiny and smooth...\n60 increased max mana\n25% increased magic damage\n17% increased magic crit\n3% increased damage reduction\nDefense is increased when health is low");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Hurting enemies summons mana crystals that leech extra mana for you\nIncreased magic damage and crit by 5%";
			player.magicDamage += 0.05f;
			player.magicCrit += 5;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.gemstoneManaBullet = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.25f;
			player.magicCrit += 15;
			player.manaCost -= 0.1f;
			player.statManaMax2 += 60;
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