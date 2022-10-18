using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class SparklySlimewhipper : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Releases bouncy sparkly gel on use\n8 summon tag damage\nYour summons will focus struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = 59;
			Item.knockBack = 2.75f;
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ModContent.ProjectileType<Projectiles.Whips.SparklySlimewhipper>();
			Item.shootSpeed = 5f;
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
			recipe.AddIngredient(ModContent.ItemType<Slimewhipper>());
			recipe.AddIngredient(ItemID.GelBalloon, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}