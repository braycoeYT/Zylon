using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class BloodyBaller : ZylonBlowpipe
	{
		public BloodyBaller() : base(130, 1.25f, new Color(200, 0, 0)) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 15;
			Item.knockBack = 1.25f;
			Item.shootSpeed = 7.25f;
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
			summonNum *= 2;
        }
        public override void ShootEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            for (int x = 0; x < summonNum; x++) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Blowpipes.BloodBall>(), tempDmg/2, 0.5f, player.whoAmI, x, summonNum);
			summonNum = 0;
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -4); //og 4, -6
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}