using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class SpearofJustice : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Spear of Justice"); //Pretty obvious reference :P
			// Tooltip.SetDefault("'The true power of SPEAR'\nDealing 750 damage summons spear clones to attack enemies");
		}
		public override void SetDefaults() {
			Item.damage = 61;
			Item.useStyle = ItemUseStyleID.Thrust;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.shootSpeed = 3.5f;
			Item.knockBack = 5.75f;
			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(0, 9, 7);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.SpearofJustice>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SharkFin, 2);
			recipe.AddIngredient(ItemID.FallenStar, 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}