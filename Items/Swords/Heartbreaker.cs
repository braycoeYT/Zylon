using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Heartbreaker : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("The Heartbreaker");
			// Tooltip.SetDefault("'Don't go breaking my heart'\nAll true melee attacks leech life\nShoots life crystals");
		}
		public override void SetDefaults() {
			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
			Item.width = 56;
			Item.height = 56;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.8f;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.HeartbreakerProj>();
			Item.shootSpeed = 12f;
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.type != NPCID.TargetDummy) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			player.statLife += 1;
			player.HealEffect(1, true);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBroadsword);
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddRecipeGroup("Zylon:AnyGem", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LeadBroadsword);
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddRecipeGroup("Zylon:AnyGem", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ZincBroadsword>());
			recipe.AddIngredient(ItemID.LifeCrystal, 3);
			recipe.AddRecipeGroup("Zylon:AnyGem", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}