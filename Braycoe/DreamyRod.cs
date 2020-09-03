using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Braycoe
{
	public class DreamyRod : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Rain stars from above");
		}

		public override void SetDefaults() 
		{
			item.damage = 9;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 1;
			item.value = 40000;
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.FallingStar;
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.mana = 8;
			item.stack = 1;
			item.UseSound = SoundID.Item13;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 600;
			speedX = Main.rand.Next(-4, 4);
			speedY = 12;
			return true;
		}
	}
}