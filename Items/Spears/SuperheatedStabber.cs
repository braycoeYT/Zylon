using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Spears
{
	public class SuperheatedStabber : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Spears[Item.type] = true;
			// Tooltip.SetDefault("Heats up while using the spear\nThrow the spear out when it's hot enough with alternate fire\n'Breaks the laws of thermodynamics for fun.'");
		}
		public override void SetDefaults() {
			Item.damage = 41;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.shootSpeed = 3f;
			Item.knockBack = 6.1f;
			Item.width = 38;
			Item.height = 38;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 4, 50, 0);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Spears.SuperheatedStabber>();
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2)
            {
				Player ItemOwner = Main.player[Main.myPlayer];
				var SuperheatedPlayer = ItemOwner.GetModPlayer<Projectiles.Spears.SuperheatedStabberPlayer>();
				if (SuperheatedPlayer.Heat >= 200 || (SuperheatedPlayer.Overheat - 6) >= 5)
                {
					return player.ownedProjectileCounts[Item.shoot] < 1;
                }
				return false;
            } else
            {
				return player.ownedProjectileCounts[Item.shoot] < 1;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse == 2)
            {
				Player ItemOwner = Main.player[Main.myPlayer];
				var SuperheatedPlayer = ItemOwner.GetModPlayer<Projectiles.Spears.SuperheatedStabberPlayer>();

				Projectile.NewProjectile(source, position, (velocity * 4f) + new Vector2(0f, -0.75f), ProjectileType<Projectiles.Spears.SuperheatedStabberThrown>(), damage, knockback * 3f, player.whoAmI, SuperheatedPlayer.Heat, SuperheatedPlayer.Overheat);

				SuperheatedPlayer.Heat = 0;
				SuperheatedPlayer.Overheat = 0;
				SuperheatedPlayer.HeatCooldown = 0;

				return false;
            }
			return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		float increase;
		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Texture2D texture = TextureAssets.Item[Item.type].Value;
			Texture2D molten = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Spears/SuperheatedStabber_molten");
			Texture2D overheat = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Spears/SuperheatedStabber_overheat");

			Player ItemOwner = Main.player[Main.myPlayer];
			var SuperheatedPlayer = ItemOwner.GetModPlayer<Projectiles.Spears.SuperheatedStabberPlayer>();

			spriteBatch.Draw(texture, position, frame, Item.GetAlpha(Color.White), 0f, origin, scale, SpriteEffects.None, 0);

			if (SuperheatedPlayer.Overheat > 6)
            {
				float time = Main.GlobalTimeWrappedHourly;
				increase++;
				float timer = increase / 240f + time * 0.04f;

				time %= 4f;
				time /= 2f;

				if (time >= 1f)
				{
					time = 2f - time;
				}

				time = time * 0.5f + 0.5f;

				Color GlowColor = Item.GetAlpha(Color.White) * (((SuperheatedPlayer.Overheat - 6) / 15f) * 0.1f);

				for (float i = 0f; i < 1f; i += 0.2f)
				{
					float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

					spriteBatch.Draw(overheat, position + new Vector2(0f, 1f).RotatedBy(radians), frame, GlowColor, 0f, origin, scale, SpriteEffects.None, 0);
					spriteBatch.Draw(overheat, position + new Vector2(0f, 2f).RotatedBy(radians), frame, GlowColor, 0f, origin, scale, SpriteEffects.None, 0);
					spriteBatch.Draw(overheat, position + new Vector2(0f, 3f).RotatedBy(radians), frame, GlowColor, 0f, origin, scale, SpriteEffects.None, 0);
					spriteBatch.Draw(overheat, position + new Vector2(0f, 4f).RotatedBy(radians), frame, GlowColor, 0f, origin, scale, SpriteEffects.None, 0);
				}
			}

			spriteBatch.Draw(molten, position, frame, Item.GetAlpha(Color.White) * (SuperheatedPlayer.Heat / 200f), 0f, origin, scale, SpriteEffects.None, 0);

			if (SuperheatedPlayer.Overheat > 6)
			{
				spriteBatch.Draw(overheat, position, frame, Item.GetAlpha(Color.White) * ((SuperheatedPlayer.Overheat - 6) / 15f), 0f, origin, scale, SpriteEffects.None, 0);
			}

			return false;
		}
	}
}