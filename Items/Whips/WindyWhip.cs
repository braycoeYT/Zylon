using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Whips
{
	public class WindyWhip : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Blows wind gusts on use\n4 summon tag damage\nYour summons will focus struck enemies");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = 11;
			Item.knockBack = 2.5f;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<Projectiles.Whips.WindyWhip>();
			Item.shootSpeed = 4;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.UseSound = SoundID.Item152;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
		}
		public override bool MeleePrefix() {
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SunplateBlock, 10);
			recipe.AddIngredient(ItemID.Feather, 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.WindEssence>(), 20);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 5);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();
		}
	}
}