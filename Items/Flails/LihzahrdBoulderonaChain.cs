using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Flails
{
	public class LihzahrdBoulderonaChain : ModItem
	{
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 11f;
			Item.damage = 140;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Flails.LihzahrdBoulderonaChain>();
			Item.shootSpeed = 13.5f;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BoulderonaChain>());
			recipe.AddIngredient(ItemID.LihzahrdBrick, 25);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}