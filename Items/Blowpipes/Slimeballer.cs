using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class Slimeballer : ZylonBlowpipe
	{
		public Slimeballer() : base(115, 1.2f, new Color(0, 125, 255)) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Converts ammo to a giant slimeball\nThe slimeball's size and pierce depends on the charge");
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 10;
			Item.knockBack = 0.5f;
			Item.shootSpeed = 6f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
		}
		float summonNum;
		public override void ChargeEvent(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = 4f*charge/maxCharge;
        }
        public override void ShootAction(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            int aaaa = Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.Slimeball>(), tempDmg, tempKb, player.whoAmI, summonNum);
			Main.projectile[aaaa].ai[0] = summonNum/1.5f;
			Main.projectile[aaaa].Center += new Vector2(0, -5*summonNum);
			summonNum = 0f;
			//Main.projectile[aaaa].penetrate = (int)(1+summonNum);
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 5);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
    }
}