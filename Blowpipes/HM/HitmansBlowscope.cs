using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blowpipes.HM
{
	public class HitmansBlowscope : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hitman's Blowscope");
			Tooltip.SetDefault("Uses seed shots as ammo\nThat's not a mini blowpipe on top, but a scope\nInsanely accurate\nWhile in your inventory, the following enemies will drop Seeds:\nMechanical Slime");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 63; //9
			item.knockBack = 4.1f; //3.5
			item.shootSpeed = 28f; //11
			item.useTime = 49; //45
			item.useAnimation = 49; //45
			item.rare = ItemRarityID.Pink;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -6);
		}
	}
}