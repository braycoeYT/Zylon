using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Head)]
	public class GemstoneEyeTamerHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shiny and smooth...\n25% increased minion damage\nMinion knockback increased by 1.5\nMax minions increased by 3\nMax life increased by 5\nDamage reduction is increased by 3%\nDefense is increased when health is low");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 11;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<GemstoneChestplate>() && legs.type == ItemType<GemstoneLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "On death, explode into an insane amount of high damage projectiles\nYou run a lot faster after taking damage\nMax minions increased by 1\nMinion damage increased by 5%";
			player.maxMinions += 1;
			player.minionDamage += 0.05f;
			PlayerEdit p = player.GetModPlayer<PlayerEdit>();
			p.gemstoneKill = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.25f;
			player.minionKB += 1.5f;
			player.maxMinions += 3;
			player.statLifeMax2 += 5;
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