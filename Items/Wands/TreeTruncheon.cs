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
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.width = 42;
			Item.height = 46;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 0.1f;
			Item.value = Item.sellPrice(0, 2, 34);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.WandofKindlingProj>();
			Item.shootSpeed = 9f;
			Item.mana = 4;
			Item.noMelee = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.hexNecklace) {
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, 1f);
				return false;
            }
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddIngredient(ItemID.BorealWood, 17);
			recipe.AddIngredient(ItemID.RichMahogany, 21);
			recipe.AddIngredient(ItemID.AshWood, 18);
			//recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 30);
			recipe.AddTile(TileID.LivingLoom);
			recipe.Register();
		}
    }
}