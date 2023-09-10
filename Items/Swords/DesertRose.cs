using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
    public class DesertRose : ModItem
    {
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Desert Rose");
			// Tooltip.SetDefault("Rains desert sigils down from the sky");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 33;
			Item.height = 33;
			Item.useTime = 50;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.8f;
			Item.value = Item.sellPrice(0, 3, 28);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.DesertSigil>();
			Item.shootSpeed = 15f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            //SoundEngine.PlaySound(SoundID.Item29, position); //ANNOYING!!!
			int amount = 2 + Main.rand.Next(3);
            float speed = velocity.Length();
			Vector2 position2 = new Vector2(Main.MouseWorld.X, position.Y - 600);
			Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, position.Y - 600), new Vector2(0, speed), type, (int)(damage * 0.5f), (int)(knockback * 0.25f), player.whoAmI);
			for (int i = 0; i < amount; i++) {
				/*for (int j = 0; j < amount / 2; j++) {
					Dust.NewDust(new Vector2(position2.X - 2.5f, position2.Y), 5, 2, ModContent.DustType<Dusts.DesertRoseDust>());
				}*/
				Vector2 perturbedSpeed = new Vector2(Main.rand.NextFloat(-1f, 1f), speed);
				Projectile.NewProjectile(source, new Vector2(Main.MouseWorld.X, position.Y - 600), perturbedSpeed, type, (int)(damage * 0.5f), (int)(knockback * 0.25f), player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 9);
			recipe.AddIngredient(ItemID.PinkPricklyPear);
			recipe.AddIngredient(ItemID.HardenedSand, 25);
			recipe.AddIngredient(ItemID.FossilOre, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}