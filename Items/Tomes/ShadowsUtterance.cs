using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class ShadowsUtterance : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 61;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 39;
			Item.useAnimation = 39;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(0, 4, 60);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.ShadowsUtteranceProj>();
			Item.shootSpeed = 32f;
			Item.noMelee = true;
			Item.mana = 15;
			Item.UseSound = SoundID.Item20;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.DarkronBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}