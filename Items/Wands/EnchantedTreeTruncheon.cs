using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class EnchantedTreeTruncheon : ModItem
	{
        public override void SetStaticDefaults() {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 127;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 37;
			Item.useAnimation = 37;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6.5f;
			Item.value = Item.sellPrice(0, 4, 92);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.EnchantedTreeTruncheonProj>();
			Item.shootSpeed = 25f;
			Item.mana = 10;
			Item.noMelee = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (Main.rand.NextFloat() < .25f) type = ModContent.ProjectileType<Projectiles.Wands.EnchantedTreeTruncheonLeaf>();
			/*if (Main.rand.NextBool()) { //Scrapped this bc it was too messy with 3 projs
				if (Main.rand.NextFloat() < .6f) type = ModContent.ProjectileType<Projectiles.Wands.EnchantedTreeTruncheonAcorn>();
				else type = ModContent.ProjectileType<Projectiles.Wands.EnchantedTreeTruncheonLeaf>();
			}*/
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (type == ModContent.ProjectileType<Projectiles.Wands.EnchantedTreeTruncheonLeaf>()) {
				float numberProjectiles = 5;
				float rotation = MathHelper.ToRadians(15);
				position += Vector2.Normalize(velocity) * 16f;

				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = (velocity*0.72f).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
					Projectile.NewProjectile(source, position, perturbedSpeed, type, (int)(damage*0.75f), knockback/2, player.whoAmI);
				}
				return false;
            }
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<TreeTruncheon>());
			recipe.AddIngredient(ModContent.ItemType<CarnalliteWand>());
			recipe.AddIngredient(ItemID.Pearlwood, 17);
			recipe.AddIngredient(ItemID.AshWood, 21);
			recipe.AddIngredient(ItemID.SpookyWood, 31);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
    }
}