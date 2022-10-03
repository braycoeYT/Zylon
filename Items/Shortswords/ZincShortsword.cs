using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Shortswords
{
	public class ZincShortsword : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to switch between legacy and modern modes\nIn legacy mode, stats are buffed");
        }
		public override void SetDefaults() {
			Item.damage = 9;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 2.9f;
			Item.value = Item.sellPrice(0, 0, 5);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.ZincShortsword>();
			Item.shootSpeed = 4.6f;
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
					Item.damage = 13;
					Item.useTime = 13;
					Item.useAnimation = 13;
					Item.knockBack = 3.9f;
					Item.useStyle = ItemUseStyleID.Thrust;
					Item.noUseGraphic = false;
					Item.noMelee = false;
					Item.useTurn = true;
					CombatText.NewText(player.getRect(), Color.DarkCyan, "LEGACY");
                }
                else {
                    Item.shoot = ProjectileType<Projectiles.Shortswords.ZincShortsword>();
					Item.damage = 9;
					Item.useTime = 5;
					Item.useAnimation = 5;
					Item.knockBack = 2.9f;
					Item.useStyle = ItemUseStyleID.Rapier;
					Item.noUseGraphic = true;
					Item.noMelee = true;
					Item.useTurn = false;
					CombatText.NewText(player.getRect(), Color.DarkCyan, "MODERN");
                }
				return false;
            }
			return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Bars.ZincBar>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}