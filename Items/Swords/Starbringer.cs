using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
    public class Starbringer : ModItem
    {
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Rains stars on enemies after striking them");
			ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 26;
			Item.DamageType = DamageClass.Melee;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3.95f;
			Item.value = Item.sellPrice(0, 0, 89);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
            for (int i = 0; i < 3; i++) {
				Vector2 spawn = new Vector2(target.Center.X + Main.rand.Next(-320, 321), player.position.Y - 400);
				Vector2 target2 = spawn - target.Center;
				Projectile.NewProjectile(Item.GetSource_FromThis(), spawn, target2*-2f*(i+1), ModContent.ProjectileType<Projectiles.FallenStarFriendly>(), damage, knockBack, Main.myPlayer);
			}
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
            for (int i = 0; i < 3; i++) {
				Vector2 spawn = new Vector2(Main.MouseWorld.X + Main.rand.Next(-320, 321), player.position.Y - 400);
				Vector2 target2 = spawn - target.Center;
				Projectile.NewProjectile(Item.GetSource_FromThis(), spawn, target2*-2f*(i+1), ModContent.ProjectileType<Projectiles.FallenStarFriendly>(), damage, Item.knockBack, Main.myPlayer);
			}
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpeckledStardust>(), 15);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}