using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class UnholySpitter : ZylonBlowpipe
	{
		public UnholySpitter() : base(135, 1.1f, new Color(125, 0, 255)) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 16;
			Item.knockBack = 1.5f;
			Item.shootSpeed = 8f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 40, 5);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
		}
		int summonNum;
		public override void ChargeEvent(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = (int)(3*charge/(maxCharge + p.blowpipeMaxInc));
			if (summonNum == 3 && charge < maxCharge + p.blowpipeMaxInc) summonNum = 2;
        }
        public override void ShootEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            for (int x = 0; x < summonNum; x++) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center + new Vector2(Main.rand.Next(64, 129), 0).RotatedByRandom(MathHelper.TwoPi), Vector2.Zero, ModContent.ProjectileType<Projectiles.Blowpipes.UnholyEnergy>(), tempDmg/3, 2f, player.whoAmI);
			summonNum = 0;
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}