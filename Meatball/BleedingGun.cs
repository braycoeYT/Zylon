using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Meatball
{
	public class BleedingGun : ModItem
	{
		public override void SetStaticDefaults()  {
			DisplayName.SetDefault("Bleeding Gun");
			Tooltip.SetDefault("10% chance to not consume ammo");
		}
		public override void SetDefaults() {
			item.value = 500;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 19;
			item.useTime = 19;
			item.damage = 13;
			item.width = 60;
			item.height = 36;
			item.knockBack = 1.5f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .1f)
            return false;
			return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MeatShard"), 20);
			recipe.AddIngredient(mod.ItemType("PlainNoodle"));
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}