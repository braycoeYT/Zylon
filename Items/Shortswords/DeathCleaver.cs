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
        public override void SetDefaults() {
			Item.damage = 17;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 3.4f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
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
					Item.shoot = ProjectileID.None;
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
					Item.damage = 17;
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
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            if (target.life < 1)
				for (int i = 0; i < 12; i++)
					Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*30)), ProjectileType<Projectiles.Shortswords.ShadeOrb>(), Item.damage, Item.knockBack, Main.myPlayer);
        }
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
            if (target.statLife < 1)
				for (int i = 0; i < 12; i++)
					Projectile.NewProjectile(Item.GetSource_FromThis(), target.Center, new Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*30)), ProjectileType<Projectiles.Shortswords.ShadeOrb>(), Item.damage, Item.knockBack, Main.myPlayer);
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 12);
			recipe.AddIngredient(ItemType<Materials.ObeliskShard>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.InGraveyard);
			recipe.Register();
		}
	}
}