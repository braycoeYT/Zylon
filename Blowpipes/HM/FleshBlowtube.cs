using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blowpipes.HM
{
	public class FleshBlowtube : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Uses seed shots as ammo\nShoots 2-4 seedshots at a time\nWhile in your inventory, the following enemies will drop Flesh Seedshots:\nDemon, Fire Imp, Lava Slime");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 22; //9
			item.knockBack = 2.2f; //3.5
			item.shootSpeed = 13f; //11
			item.useTime = 43; //45
			item.useAnimation = 43; //45
			item.rare = ItemRarityID.LightRed;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(9));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -3);
		}
	}
}