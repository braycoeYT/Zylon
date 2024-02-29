using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class DeterminationBreaker : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 65;
			Item.width = 44;
			Item.height = 42;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 11;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Vector2 loc = Main.MouseWorld - player.Center;
			if (Math.Abs(loc.Y) > Math.Abs(loc.X)) {
				if (loc.Y > 0) Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(0, Item.shootSpeed), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
				else Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(0, Item.shootSpeed*-1), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
            }
			else {
				if (loc.X > 0) Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(Item.shootSpeed, 0), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
				else Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(Item.shootSpeed*-1, 0), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
            }
            return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BookofSkulls);
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Texture2D glowMask = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/DeterminationBreaker_glow");

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
            {
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            }
            else
            {
                frame = texture.Frame();
            }

            Vector2 frameOrigin = frame.Size() / 2f;
            Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            spriteBatch.Draw(texture, drawPos, frame, Item.GetAlpha(lightColor), rotation, frameOrigin, scale, SpriteEffects.None, 0);

            for (float i = 0f; i < 1f; i += 0.2f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 2f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 4f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 6f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, drawPos + new Vector2(0f, 8f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(glowMask, drawPos, frame, Item.GetAlpha(Color.White), rotation, frameOrigin, scale, SpriteEffects.None, 0);

            return false;
        }
        float increase;
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Texture2D glowMask = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/DeterminationBreaker_glow");

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

            spriteBatch.Draw(texture, position, frame, Item.GetAlpha(Color.White), 0f, origin, scale, SpriteEffects.None, 0);

            for (float i = 0f; i < 1f; i += 0.2f)
            {
                float radians = (i + timer + (time / 3)) * MathHelper.TwoPi;

                spriteBatch.Draw(glowMask, position + new Vector2(0f, 2f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 4f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 6f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
                spriteBatch.Draw(glowMask, position + new Vector2(0f, 8f).RotatedBy(radians), frame, Item.GetAlpha(Color.White) * 0.085f, 0f, origin, scale, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(glowMask, position, frame, Item.GetAlpha(Color.White), 0f, origin, scale, SpriteEffects.None, 0);

            return false;
        }


    }
}