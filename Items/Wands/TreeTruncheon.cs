using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class TreeTruncheon : ModItem
	{
        public override void SetStaticDefaults() {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 17;
			Item.DamageType = DamageClass.Magic;
			Item.width = 36;
			Item.height = 36;
			Item.useTime = 31;
			Item.useAnimation = 31;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.3f;
			Item.value = Item.sellPrice(0, 0, 46);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.TreeTruncheonProj>();
			Item.shootSpeed = 16f;
			Item.mana = 8;
			Item.noMelee = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (Main.rand.NextBool(5)) type = ModContent.ProjectileType<Projectiles.Wands.TreeTruncheonAcorn>();
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddIngredient(ItemID.BorealWood, 17);
			recipe.AddIngredient(ItemID.RichMahogany, 21);
			recipe.AddIngredient(ItemID.PalmWood, 15);
			recipe.AddIngredient(ModContent.ItemType<Materials.LivingBranch>(), 10);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
    }
}