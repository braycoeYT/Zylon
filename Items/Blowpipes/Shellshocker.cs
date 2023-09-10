using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class Shellshocker : ZylonBlowpipe
	{
		public Shellshocker() : base(125, 1.2f, new Color(255, 255, 155), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("At max charge, replaces ammo a shell that shocks enemies");
=======
			// Tooltip.SetDefault("At max charge, replaces ammo a shell that shocks enemies");
>>>>>>> ProjectClash
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 11;
			Item.knockBack = 0.5f;
			Item.shootSpeed = 8.125f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 80);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
		}
        public override void MaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
			Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.ShellshockerProj>(), tempDmg, tempKb, player.whoAmI);
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		/*public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Seashell, 15);
			recipe.AddIngredient(ItemID.Coral, 6);
			recipe.AddIngredient(ItemID.Starfish, 6);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}*/
    }
}