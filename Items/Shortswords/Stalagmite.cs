using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Shortswords
{
	public class Stalagmite : ModItem
	{
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to switch between legacy and modern modes\nHitting enemies spawns granite sparks\nIn legacy mode, stats are buffed and more sparks are spawned");
        }
        public override void SetDefaults() {
			Item.damage = 27;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 2.8f;
			Item.value = Item.sellPrice(0, 0, 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.Stalagmite>();
			Item.shootSpeed = 4.9f;
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
					Item.shoot = 0;
					Item.damage = 41;
					Item.useTime = 18;
					Item.useAnimation = 18;
					Item.knockBack = 3.9f;
					Item.useStyle = ItemUseStyleID.Thrust;
					Item.noUseGraphic = false;
					Item.noMelee = false;
					Item.useTurn = true;
					CombatText.NewText(player.getRect(), Color.Navy, "LEGACY");
                }
                else {
                    Item.shoot = ProjectileType<Projectiles.Shortswords.Stalagmite>();
					Item.damage = 27;
					Item.useTime = 9;
					Item.useAnimation = 9;
					Item.knockBack = 2.8f;
					Item.useStyle = ItemUseStyleID.Rapier;
					Item.noUseGraphic = true;
					Item.noMelee = true;
					Item.useTurn = false;
					CombatText.NewText(player.getRect(), Color.Navy, "MODERN");
                }
				return false;
            }
			return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			for (int i = 0; i < 5; i++)
				Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-7, -4)), ProjectileType<Projectiles.Shortswords.GraniteSpark>(), Item.damage, Item.knockBack, Main.myPlayer);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			for (int i = 0; i < 5; i++)
				Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center, new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-7, -4)), ProjectileType<Projectiles.Shortswords.GraniteSpark>(), Item.damage, Item.knockBack, Main.myPlayer);
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldShortsword);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 9);
			recipe.AddIngredient(ItemID.GraniteBlock, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumShortsword);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 9);
			recipe.AddIngredient(ItemID.GraniteBlock, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}