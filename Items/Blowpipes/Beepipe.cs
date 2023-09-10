using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Zylon.Items.Blowpipes
{
	public class Beepipe : ZylonBlowpipe
	{
		public Beepipe() : base(160, 1.6f, new Color(255, 200, 0), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("At max charge, replaces ammo with a horde of bees");
=======
			// Tooltip.SetDefault("At max charge, replaces ammo with a horde of bees");
>>>>>>> ProjectClash
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 30;
			Item.knockBack = 1f;
			Item.shootSpeed = 8.25f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = true;
		}
        public override void MaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            //for (int i = 0; i < Main.rand.Next(3, 7); i++)
			Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ProjectileID.BeeArrow, tempDmg, tempKb, player.whoAmI);
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
    }
}