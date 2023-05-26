using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Swords
{
	public class Mudslinger : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Every third swing fires an accelerating dirt glob that heats up over time\nAs it heats up, its power steadily increases\nThe glob explodes into molten mud after being left alive for long enough\nHeating speed will change depending on the player's biome");
		}
		public override void SetDefaults() {
			Item.damage = 38;
			Item.DamageType = DamageClass.Melee;
			Item.width = 58;
			Item.height = 58;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.8f;
			Item.value = Item.sellPrice(0, 5, 27);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.MudslingerProj>();
			Item.shootSpeed = 4f;
		}
		int x;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            x++;
			if (x%3==0) SoundEngine.PlaySound(SoundID.Item70, position);
			return x%3==0;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MuddyGreatsword>());
			recipe.AddIngredient(ItemID.MudBlock, 100);
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 8);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}