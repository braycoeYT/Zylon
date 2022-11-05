using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Shortswords
{
	public class DeathCleaver : ModItem
	{
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to switch between legacy and modern modes\nSlain enemies explode into eight shade orbs\nIn legacy mode, stats are buffed and twelve orbs are released");
        }
        public override void SetDefaults() {
			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 3.4f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.Shortswords.DeathCleaver>();
			Item.shootSpeed = 5.1f;
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
					Item.damage = 31;
					Item.useTime = 19;
					Item.useAnimation = 19;
					Item.knockBack = 4.6f;
					Item.useStyle = ItemUseStyleID.Thrust;
					Item.noUseGraphic = false;
					Item.noMelee = false;
					Item.useTurn = true;
					CombatText.NewText(player.getRect(), Color.Black, "LEGACY");
                }
                else {
                    Item.shoot = ProjectileType<Projectiles.Shortswords.DeathCleaver>();
					Item.damage = 21;
					Item.useTime = 8;
					Item.useAnimation = 8;
					Item.knockBack = 3.4f;
					Item.useStyle = ItemUseStyleID.Rapier;
					Item.noUseGraphic = true;
					Item.noMelee = true;
					Item.useTurn = false;
					CombatText.NewText(player.getRect(), Color.Black, "MODERN");
                }
				return false;
            }
			return true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
            if (target.life < 1)
				for (int i = 0; i < 12; i++)
					Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*30)), ProjectileType<Projectiles.Shortswords.ShadeOrb>(), Item.damage, Item.knockBack, Main.myPlayer);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
            if (target.statLife < 1)
				for (int i = 0; i < 12; i++)
					Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*30)), ProjectileType<Projectiles.Shortswords.ShadeOrb>(), Item.damage, Item.knockBack, Main.myPlayer);
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 12);
			recipe.AddIngredient(ItemType<Materials.ObeliskShard>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Recipe.Condition.InGraveyardBiome);
			recipe.Register();
		}
	}
}