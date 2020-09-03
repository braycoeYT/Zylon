using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Cave
{
	public class Flintbow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Turns normal arrows into stalagmites that can confuse enemies");
		}
		public override void SetDefaults() 
		{
			item.value = 50000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.damage = 9;
			item.width = 12;
			item.height = 24;
			item.knockBack = 3.6f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 44f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Blue;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = mod.ProjectileType("StalagmiteProj");
			}
			return true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.MarbleBlock, 10);
			recipe.AddIngredient(ItemID.GraniteBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}