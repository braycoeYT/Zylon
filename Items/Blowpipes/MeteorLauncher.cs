using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes //play cool sound when launch, double recharge time
{
	public class MeteorLauncher : ZylonBlowpipe
	{
		public MeteorLauncher() : base(145, 1.35f, new Color(125, 63, 0), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 31;
			Item.knockBack = 1.75f;
			Item.shootSpeed = 7.5f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 3, 12);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
        }
		public override bool AltFunctionUse(Player player) {
			return true;
		}
        public override void AltClickEvent(Player player) {
            maxReplace = !maxReplace;
			if (maxReplace) CombatText.NewText(player.getRect(), textColor, "Enabled");
			else CombatText.NewText(player.getRect(), textColor, "Disabled");
        }
        public override void ShootAction(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            if (maxReplace && reuseCounter <= 0) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.MeteorLauncherProj>(), tempDmg, tempKb, Main.myPlayer, summonNum);
				else Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
			summonNum = 0;
		}
        int summonNum;
		public override void ChargeEvent(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = (int)(4*charge/(maxCharge + p.blowpipeMaxInc));
			if (summonNum == 4 && charge < maxCharge + p.blowpipeMaxInc) summonNum = 3;
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 4);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}