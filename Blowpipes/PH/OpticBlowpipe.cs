using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Blowpipes.PH
{
	public class OpticBlowpipe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Optic Blowpipe");
			Tooltip.SetDefault("Uses seed shots as ammo\nWhile in your inventory, the following enemies will drop Seeds:\nDemon Eye");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 19; //9
			item.knockBack = 4.5f; //3.5
			item.shootSpeed = 16f; //11
			item.useTime = 52; //45
			item.useAnimation = 52; //45
			item.rare = ItemRarityID.Blue;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, 3);
		}
	}
}