using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class Slimewhipper : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("5 summon tag damage\nYour summons will focus struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = 17;
			Item.knockBack = 2.5f;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<Projectiles.Whips.Slimewhipper>();
			Item.shootSpeed = 4;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.UseSound = SoundID.Item152;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
		}
		public override bool MeleePrefix() {
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.SlimyCore>(), 5);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}