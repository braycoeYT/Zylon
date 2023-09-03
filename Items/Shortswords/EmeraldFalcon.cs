using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Shortswords
{
	public class EmeraldFalcon : ModItem
	{
        public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Better than the diamond sword!'\nRight click to switch between legacy and modern modes\nFires an emerald wave on every fifth stab\nIn legacy mode, emerald waves chase enemies");
        }
        public override void SetDefaults() {
			Item.damage = 30;
			Item.DamageType = DamageClass.Melee;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 4f;
			Item.value = Item.sellPrice(0, 1, 25);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.EmeraldFalcon>();
			Item.shootSpeed = 6f;
		}
		bool legacy;
		public override bool AltFunctionUse(Player player) {
			return true;
		}
        public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2) {
				legacy = !legacy;
				SoundEngine.PlaySound(SoundID.MaxMana, player.position);
				if (legacy) {
					Item.shoot = ProjectileType<Projectiles.Shortswords.EmeraldWaveChase>();
					Item.damage = 44;
					Item.useTime = 21;
					Item.useAnimation = 21;
					Item.knockBack = 5.2f;
					Item.useStyle = ItemUseStyleID.Thrust;
					Item.noUseGraphic = false;
					Item.noMelee = false;
					Item.useTurn = true;
					CombatText.NewText(player.getRect(), Color.Green, "LEGACY");
                }
                else {
                    Item.shoot = ProjectileType<Projectiles.Shortswords.EmeraldFalcon>();
					Item.damage = 30;
					Item.useTime = 9;
					Item.useAnimation = 9;
					Item.knockBack = 4f;
					Item.useStyle = ItemUseStyleID.Rapier;
					Item.noUseGraphic = true;
					Item.noMelee = true;
					Item.useTurn = false;
					CombatText.NewText(player.getRect(), Color.Green, "MODERN");
                }
				return false;
            }
			return true;
        }
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (legacy && shootCount % 5 == 0) Projectile.NewProjectile(source, position, new Vector2(12*player.direction, 0), type, damage/2, knockback/2, Main.myPlayer);
			if (!legacy) Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, 0f, shootCount);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Emerald, 15);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 10);
			recipe.AddIngredient(ItemType<Materials.RustedTech>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}