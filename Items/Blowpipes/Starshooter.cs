using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class Starshooter : ZylonBlowpipe
	{
		public Starshooter() : base(145, 1.65f, new Color(127, 116, 194), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("Supercharges starshots based on charge if they are used as ammo");
=======
			// Tooltip.SetDefault("Supercharges starshots based on charge if they are used as ammo");
>>>>>>> ProjectClash
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 18;
			Item.knockBack = 0.25f;
			Item.shootSpeed = 8f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
        }
		int summonNum;
		public override void ChargeEvent(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = (int)(4*charge/(maxCharge + p.blowpipeMaxInc));
			if (summonNum == 4 && charge < maxCharge + p.blowpipeMaxInc) summonNum = 3;
        }
        public override void ShootAction(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            if (tempType == ModContent.ProjectileType<Projectiles.Ammo.Starshot>() && reuseCounter <= 0) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.Superstarshot_Y>(), tempDmg, tempKb, Main.myPlayer, summonNum);
			else Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -8);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}