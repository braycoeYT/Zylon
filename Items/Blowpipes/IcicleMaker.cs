using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class IcicleMaker : ZylonBlowpipe
	{
		public IcicleMaker() : base(50, 0.75f, new Color(0, 200, 255), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("At max charge, replaces ammo with a heap of mini icicles");
=======
			// Tooltip.SetDefault("At max charge, replaces ammo with a heap of mini icicles");
>>>>>>> ProjectClash
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 3;
			Item.knockBack = 0.1f;
			Item.shootSpeed = 6.75f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 5, 12);
			Item.autoReuse = true;
		}
        public override void MaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
			for (int i = 0; i < 5; i++) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedByRandom(0.45f), ModContent.ProjectileType<Projectiles.Blowpipes.IcicleMakerProj>(), (int)(Item.damage*0.75f), Item.knockBack*0.75f, Main.myPlayer);
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.EnchantedIceCube>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}