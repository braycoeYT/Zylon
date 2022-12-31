using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class CryoWand : ModItem
	{
        public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a chunk of ice that splits into several shards on impact");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 0, 5, 12);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.CryoWandProj>();
			Item.shootSpeed = 9f;
			Item.mana = 8;
		}
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.EnchantedIceCube>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}