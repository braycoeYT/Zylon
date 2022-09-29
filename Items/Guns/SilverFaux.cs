using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class SilverFaux : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Silver Faux");
			Tooltip.SetDefault("'The only things burning now are your fingers'\nWhile in your inventory as you shoot, the gun's use speed will rapidly increase... if you can keep up, that is");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 5, 50, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.damage = 39;
			Item.width = 42;
			Item.height = 30;
			Item.knockBack = 2.5f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 14f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Pink;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		int charge;
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
			Item.autoReuse = false;
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Item.autoReuse = false;
			Item.autoReuse = false;
			if (type == ProjectileID.Bullet) {
				type = 14;
			}
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Item.autoReuse = false;
			charge += 28;
            return true;
        }
        public override void UpdateInventory(Player player) {
			Item.autoReuse = false;
			charge -= 1;
			if (charge < 0)
				charge = 0;
			if (charge > 400)
				charge = 400;
			Item.shootSpeed = 10f + (charge/40);
			Item.useAnimation = (15 - (charge/40));
			Item.useTime = (15 - (charge/40));
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PhoenixBlaster);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddRecipeGroup("Zylon:AnyGem", 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}