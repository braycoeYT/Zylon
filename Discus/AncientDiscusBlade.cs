using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Discus
{
	public class AncientDiscusBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightningbringer");
			Tooltip.SetDefault("It was struck seven times by Radias\nFrostburns enemies on critical strikes");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.melee = true;
			item.width = 55;
			item.height = 55;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.3f;
			item.value = 25000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (crit)
				target.AddBuff(BuffID.Frostburn, 240, false);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DriedEssence"), 3);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}