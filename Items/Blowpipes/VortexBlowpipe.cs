using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class VortexBlowpipe : ZylonBlowpipe
	{
		public VortexBlowpipe() : base(325, 3.25f, new Color(242, 170, 1)) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 101;
			Item.knockBack = 3f;
			Item.shootSpeed = 10f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.rare = ModContent.RarityType<RedModded>();
			Item.value = Item.sellPrice(0, 10);
			Item.autoReuse = true;
		}
		int summonNum;
		public override void ChargeEvent(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = (int)(5*charge/(maxCharge + p.blowpipeMaxInc));
			if (summonNum == 5 && charge < maxCharge + p.blowpipeMaxInc) summonNum = 4;
        }
        public override void ShootEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
			for (int i = 0; i < summonNum; i++) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, vel.RotatedByRandom(MathHelper.ToRadians(30))*tempSpd*Main.rand.NextFloat(0.7f, 0.9f), ModContent.ProjectileType<Projectiles.Blowpipes.VortexMiniRocket>(), tempDmg, tempKb, Main.myPlayer);
			}
            //if (charge >= (int)(maxCharge/3)) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), tempDmg, tempKb, player.whoAmI);
			//if (charge >= (int)(maxCharge/3*2)) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), tempDmg, tempKb, player.whoAmI);
			//if (charge >= maxCharge) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), tempDmg, tempKb, player.whoAmI);
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentVortex, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
    }
}