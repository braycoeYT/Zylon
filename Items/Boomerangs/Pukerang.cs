using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Pukerang : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Inflicts cursed inferno on struck enemies\nShoots cursed flames at nearby enemies");
		}
		public override void SetDefaults() {
			Item.damage = 78;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.8f;
			Item.value = Item.sellPrice(0, 3, 56);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Pukerang>();
			Item.shootSpeed = 12f;
			Item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Barfarang>());
			recipe.AddIngredient(ItemID.CursedFlame, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.AdamantiteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Barfarang>());
			recipe.AddIngredient(ItemID.CursedFlame, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.TitaniumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}