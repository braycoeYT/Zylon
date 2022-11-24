using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Misc
{
	public class SturgeonsKnife : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sturgeon's Knife");
			Tooltip.SetDefault("After hitting an enemy or six tile collisions, dissipates and releases two aqua bubbles");
        }
        public override void SetDefaults() {
            Item.width = 14;
            Item.height = 40;
            Item.damage = 21;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 26;
            Item.useTime = 26;
            Item.knockBack = 4f;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 3);
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileType<Projectiles.Misc.SturgeonsKnife>();
            Item.shootSpeed = 13.5f;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemType<SurgeonsKnife>());
            recipe.AddIngredient(ItemID.Swordfish);
			recipe.AddIngredient(ItemID.SharkFin, 3);
            recipe.AddIngredient(ItemID.Goldfish);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}