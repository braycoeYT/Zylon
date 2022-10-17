using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Stone
{
	public class StoneShortsword : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to switch between legacy and modern modes\nIn legacy mode, stats are buffed");
        }
		public override void SetDefaults() {
			Item.damage = 7;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 4f;
			Item.value = 150;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.StoneShortsword>();
			Item.shootSpeed = 4.3f;
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
					Item.shoot = ProjectileID.None;
					Item.damage = 10;
					Item.useTime = 21;
					Item.useAnimation = 21;
					Item.knockBack = 5f;
					Item.useStyle = ItemUseStyleID.Thrust;
					Item.noUseGraphic = false;
					Item.noMelee = false;
					Item.useTurn = true;
					CombatText.NewText(player.getRect(), Color.Gray, "LEGACY");
                }
                else {
                    Item.shoot = ProjectileType<Projectiles.Shortswords.StoneShortsword>();
					Item.damage = 7;
					Item.useTime = 12;
					Item.useAnimation = 12;
					Item.knockBack = 4f;
					Item.useStyle = ItemUseStyleID.Rapier;
					Item.noUseGraphic = true;
					Item.noMelee = true;
					Item.useTurn = false;
					CombatText.NewText(player.getRect(), Color.Gray, "MODERN");
                }
				return false;
            }
			return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddIngredient(ItemID.Gel, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}