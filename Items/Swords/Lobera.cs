using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Items.Swords
{
	public class Lobera : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee;
			Item.width = 34;
			Item.height = 60;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 0, 60);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.LoberaWave>();
			Item.shootSpeed = 4.5f;
		}
        public override void UpdateInventory(Player player) {
            float hp = (float)player.statLife/(float)player.statLifeMax2;
			Item.damage = 70 - (int)(20*hp);
			Item.knockBack = 9f - 3.5f*hp;
			Item.useTime = 20 + (int)(14*hp);
			Item.useAnimation = 20 + (int)(14*hp);
        }
        int shootCount;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootCount++;
			float hp = (float)player.statLife/(float)player.statLifeMax2;
			if (hp <= 0.25f) {
				SoundEngine.PlaySound(SoundID.Item71, position);
				Projectile.NewProjectile(source, position, velocity*1.5f, ModContent.ProjectileType<Projectiles.Swords.LoberaHyperwave>(), (int)(damage * 0.75f), knockback * 0.5f, player.whoAmI);
            }
			else if (shootCount % 3 == 0) {
				SoundEngine.PlaySound(SoundID.Item71, position);
				Projectile.NewProjectile(source, position, velocity, type, (int)(damage * 0.75f), knockback * 0.5f, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyMythrilBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.WolfPelt>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}