using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class HollowKnife : ZylonBlowpipe
	{
		public HollowKnife() : base(400, 3f, new Color(195, 191, 73)) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 137;
			Item.knockBack = 4f;
			Item.shootSpeed = 13f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.rare = ModContent.RarityType<Magenta>();
			Item.value = Item.sellPrice(0, 15);
			Item.autoReuse = true;
		}
		int numShot;
        public override void ChargeEvent(Player player) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			numShot = (int)(charge*20f/maxCharge);
			if (numShot < 1) numShot = 1;
        }
        public override void ShootEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.HollowKnifeProj>(), tempDmg, tempKb, Main.myPlayer, numShot);
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
    }
}