using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class SurgeonsKnife : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Surgeon's Knife");
			Tooltip.SetDefault("'110% surgery approved, though too dirty to be approved for culinary use'\nBounces four times before dissipating");
        }
        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 42;
            Item.damage = 17;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.knockBack = 3.1f;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 2);
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileType<Projectiles.Misc.SurgeonsKnife>();
            Item.shootSpeed = 12f;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ThrowingKnife, 300);
            recipe.AddIngredient(ItemType<Materials.BloodDroplet>(), 20);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}