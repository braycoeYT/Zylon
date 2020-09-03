using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Books
{
	public class FatalError : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("[c/01A1FF:CoRrUpTeD dAtA!]\nShoots several random glitched text");
		}
		public override void SetDefaults() {
			item.value = 200000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 29;
			item.useTime = 29;
			item.damage = 101;
			item.width = 12;
			item.height = 24;
			item.knockBack = 3f;
			item.shoot = mod.ProjectileType("FatalErrorLetter1");
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.LightRed;
			item.mana = 11;
			item.UseSound = SoundID.Item116;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++)
			{
				int letterChoose = Main.rand.Next(6);
				if (letterChoose == 0)
					type = mod.ProjectileType("FatalErrorLetter1");
				else if (letterChoose == 1)
					type = mod.ProjectileType("FatalErrorLetter3");
				else if (letterChoose == 2)
					type = mod.ProjectileType("FatalErrorLetterA");
				else if (letterChoose == 3)
					type = mod.ProjectileType("FatalErrorLetterB");
				else if (letterChoose == 4)
					type = mod.ProjectileType("FatalErrorLetterHappy");
				else if (letterChoose == 5)
					type = mod.ProjectileType("FatalErrorLetterZ");
				Vector2 perturbedSpeed = new Vector2(speedX + Main.rand.NextFloat(-1, 2), speedY + Main.rand.NextFloat(-1, 2)).RotatedByRandom(MathHelper.ToRadians(10));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}