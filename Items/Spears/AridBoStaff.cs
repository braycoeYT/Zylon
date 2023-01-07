using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class AridBoStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Spears[Item.type] = true;
			Tooltip.SetDefault("'From a primordial desert dynasty'\nCreates dust storms at will");
		}
		public override void SetDefaults() {
			Item.damage = 21;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.shootSpeed = 3f;
			Item.knockBack = 6.1f;
			Item.width = 38;
			Item.height = 38;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 1, 15, 0);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.AridBoStaff>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Amber, 6);
			recipe.AddIngredient(ItemID.DynastyWood, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}