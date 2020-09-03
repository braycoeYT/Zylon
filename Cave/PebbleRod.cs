using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Cave
{
	public class PebbleRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pebble Rod");
			Tooltip.SetDefault("Rains pebbles which can confuse enemies");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.magic = true;
			item.width = 62;
			item.height = 60;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 5.1f;
			item.value = 50000;
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Pebble");
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.mana = 7;
			item.stack = 1;
			item.UseSound = SoundID.Item8;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.Next(-2, 2);
			speedY = 15;
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