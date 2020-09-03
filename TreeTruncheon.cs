using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class TreeTruncheon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tree Truncheon");
			Tooltip.SetDefault("Rain leaves down on your enemies, at no cost!");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 4.5f;
			item.value = 68000;
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.Leaf;
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.mana = 0;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.Next(-3, 3);
			speedY = 10;
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 100);
			recipe.AddIngredient(ItemID.Acorn, 50);
			recipe.AddIngredient(ItemID.LivingWoodWand);
			recipe.AddIngredient(ItemID.LeafWand);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}