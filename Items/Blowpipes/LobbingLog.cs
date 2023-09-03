using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class LobbingLog : ZylonBlowpipe
	{
		public LobbingLog() : base(100, 1f, new Color(125, 63, 0), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("At max charge, shoots a faster piercing splinter\nRight click to disable and enable this effect");
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 4;
			Item.knockBack = 0.5f;
			Item.shootSpeed = 5.5f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 0, 20);
			Item.rare = ItemRarityID.White;
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
		public override void MaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
			if (maxReplace) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd*1.5f, ModContent.ProjectileType<Projectiles.Blowpipes.LobbingLogSplinter>(), tempDmg, tempKb, Main.myPlayer);
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(4, -8);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
    }
}