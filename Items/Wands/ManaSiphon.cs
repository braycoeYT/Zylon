using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class ManaSiphon : ModItem
	{
        public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Leeches mana from struck enemies");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 4;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.ManaSiphonBolt>();
			Item.shootSpeed = 11f;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.InGraveyard);
			recipe.Register();
		}
	}
}