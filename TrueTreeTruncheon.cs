using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items
{
	public class TrueTreeTruncheon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Tree Truncheon");
			Tooltip.SetDefault("Rain powerful leaves down on your enemies, at no cost!\nRare Item");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 37;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 4.5f;
			item.value = 450000;
			item.rare = -11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.Leaf;
			item.shootSpeed = 16f;
			item.noMelee = true;
			item.mana = 0;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.Next(-2, 2);
			speedY = 27;
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TreeTruncheon"));
			recipe.AddIngredient(ItemID.BorealWood);
			recipe.AddIngredient(ItemID.Ebonwood);
			recipe.AddIngredient(ItemID.PalmWood);
			recipe.AddIngredient(ItemID.Pearlwood);
			recipe.AddIngredient(ItemID.RichMahogany);
			recipe.AddIngredient(ItemID.Wood);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TreeTruncheon"));
			recipe.AddIngredient(ItemID.BorealWood);
			recipe.AddIngredient(ItemID.PalmWood);
			recipe.AddIngredient(ItemID.Pearlwood);
			recipe.AddIngredient(ItemID.RichMahogany);
			recipe.AddIngredient(ItemID.Shadewood);
			recipe.AddIngredient(ItemID.Wood);
			recipe.AddIngredient(mod.ItemType("ElementamaxSludge"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}