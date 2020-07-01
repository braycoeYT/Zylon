using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Rare
{
	public class TreeTruncheon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tree Truncheon");
			Tooltip.SetDefault("Rain leaves down on your enemies, at no cost!\nRare Item");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 5;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 5;
			item.knockBack = 4.5f;
			item.value = 68000;
			item.rare = -11;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = 206;
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
	}
}