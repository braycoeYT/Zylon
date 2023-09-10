using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Guns
{
	public class DiskanSecurityHandgun : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Every third shot is converted to an electric bolt that deals extra damage");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.damage = 18;
			Item.width = 26;
			Item.height = 24;
			Item.knockBack = 2f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Green;
		}
		int shootNum;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootNum++;
			if (shootNum % 3 == 0) {
				SoundEngine.PlaySound(SoundID.Item96, position);
				Projectile.NewProjectile(source, position, velocity*1.3f, ModContent.ProjectileType<Projectiles.ElectricBoltPassive>(), (int)(damage*1.5f), knockback, Main.myPlayer, 1f);
			}
			return shootNum % 3 != 0;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<OvergrownHandgunFragment>());
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 14);
			recipe.AddIngredient(ItemID.Obsidian, 12);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 8);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}