using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class Earthbound : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 101;
			item.melee = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.2f;
			item.value = 900000;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("CrazyDirtStuff");
			item.shootSpeed = 14f;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 0);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenDirtballCopperShortsword"));
			recipe.AddIngredient(ItemID.DirtBlock, 150);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}