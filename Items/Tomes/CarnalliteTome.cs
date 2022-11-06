using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Items.Tomes
{
	public class CarnalliteTome : ModItem
	{
		public int CurrentSelected = 1;
		

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots seeds that grow into buffing flowers\nRight click changes the seed thrown\nMaximum of two at a given time\n'I always knew flowers had powers!'");
		}
		public override void SetDefaults() {
			Item.width = 44;
			Item.height = 42;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.Carnallite.HealingSeed>();
			Item.shootSpeed = 9.6f;
			Item.noMelee = true;
			Item.mana = 56;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}


		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

        public override bool CanUseItem(Player player)
        {
			int OwnedProjectiles = 0;
			if (player.altFunctionUse == 2)
            {
				Item.UseSound = SoundID.DD2_MonkStaffSwing;
				Item.mana = 0;
				Item.useStyle = ItemUseStyleID.HiddenAnimation;
				Item.noUseGraphic = true;
				Item.useTime = 3;
				Item.useAnimation = 3;
				// The code right below this technically allows for slight animation canacels, but I value the viability over anything else.
				if (ModContent.GetInstance<CarnalliteUISystem>().VisualActive == false || (ModContent.GetInstance<CarnalliteUISystem>().TimeActive/17f) > 1)
                {
					return true;
				}
				return false;
            } else
            {
				Item.UseSound = SoundID.Item8;
				Item.mana = 56;
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.noUseGraphic = false;
				Item.useTime = 15;
				Item.useAnimation = 15;
				// For the love of christ i hate this code but I have no idea how to fix it.
				for (int i = 0; i < player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Tomes.Carnallite.DefenseSeed>()]; i++)
				{
					OwnedProjectiles++;
				}
				for (int i = 0; i < player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Tomes.Carnallite.ManaSeed>()]; i++)
				{
					OwnedProjectiles++;
				}
				for (int i = 0; i < player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Tomes.Carnallite.HealingSeed>()]; i++)
				{
					OwnedProjectiles++;
				}
				for (int i = 0; i < player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Tomes.Carnallite.DefenseFlower>()]; i++)
				{
					OwnedProjectiles++;
				}
				for (int i = 0; i < player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Tomes.Carnallite.ManaFlower>()]; i++)
				{
					OwnedProjectiles++;
				}
				for (int i = 0; i < player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Tomes.Carnallite.HealingFlower>()]; i++)
				{
					OwnedProjectiles++;
				}

				if (OwnedProjectiles >= 2)
                {
					return false;
                }
				

			}

			return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse == 2)
            {
				// The bread and butter of the swap weirdly goes here, since to my knowledge the Shoot functionality is run client side we don't have to worry too much about accidentally running this through other players.
				if (CurrentSelected < 3)
                {
					CurrentSelected++;
					ModContent.GetInstance<CarnalliteUISystem>().Fade = 1f;
					ModContent.GetInstance<CarnalliteUISystem>().VisualDisplay = CurrentSelected;
					ModContent.GetInstance<CarnalliteUISystem>().TimeActive = 0;
					ModContent.GetInstance<CarnalliteUISystem>().VisualActive = true;
				} else
                {
					CurrentSelected = 1;
					ModContent.GetInstance<CarnalliteUISystem>().Fade = 1f;
					ModContent.GetInstance<CarnalliteUISystem>().VisualDisplay = CurrentSelected;
					ModContent.GetInstance<CarnalliteUISystem>().TimeActive = 0;
					ModContent.GetInstance<CarnalliteUISystem>().VisualActive = true;
				}


				return false;
            }

			switch(CurrentSelected)
            {
				case 1:
					Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Tomes.Carnallite.HealingSeed>(), damage, knockback, player.whoAmI, 0f, 0f);
					return false;

				case 2:
					Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Tomes.Carnallite.ManaSeed>(), damage, knockback, player.whoAmI, 0f, 0f);
					return false;

				case 3:
					Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Tomes.Carnallite.DefenseSeed>(), damage, knockback, player.whoAmI, 0f, 0f);
					return false;
			}
			return false;
        }

        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}

	// Thanks I hate it
	public class CarnalliteUISystem : ModSystem
    {

		public bool VisualActive;
		public int TimeActive;
		public float Fade;
		public int VisualDisplay;
		public override void Load()
        {
        }

		public override void UpdateUI(GameTime gameTime)
		{
			if (VisualActive == true)
            {
				TimeActive++;
				if (TimeActive > 35)
				{
					Fade -= 0.1345f;
					if (Fade < 0f)
                    {
						Fade = 0f;
						VisualActive = false;
					}
				}
			} else
            {
				TimeActive = 0;
				Fade = 0f;
				VisualDisplay = 0;
            }
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			if (VisualActive == true)
			{
				int InterfaceIndex = layers.FindIndex((l) => l.Name == "Vanilla: Resource Bars");
				if (InterfaceIndex != -1)
					layers.Insert(InterfaceIndex, new LegacyGameInterfaceLayer("Zylon: Carnallite UI", DrawUI, InterfaceScaleType.Game));
			}
		}

		public bool DrawUI()
        {
			Player player = Main.LocalPlayer;
			if (VisualActive == false)
            {
				return true;
            }

			Texture2D UIBackround = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI");
			Texture2D UIFirst = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/MissingTextureDebug");
			Texture2D UISecond = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/MissingTextureDebug");
			Texture2D UIThird = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/MissingTextureDebug");


			switch (VisualDisplay)
			{
				case 1:
					UIFirst = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_defense");
					UISecond = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_healing");
					UIThird = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_mana");
					break;

				case 2:
					UIFirst = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_healing");
					UISecond = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_mana");
					UIThird = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_defense");
					break;

				case 3:
					UIFirst = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_mana");
					UISecond = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_defense");
					UIThird = (Texture2D)ModContent.Request<Texture2D>("Zylon/Items/Tomes/CarnalliteUI/CarnalliteTomeUI_healing");
					break;
			}



			Vector2 DrawOriginBackground = UIBackround.Size() * 0.5f;
			Vector2 DrawOriginUITop = UIFirst.Size() * 0.5f;
			Color color = Color.White * Fade;
			Vector2 DrawPos = player.Center - Main.screenPosition;

			float progress = (TimeActive / 20f);

			float OpacityLerp = MathHelper.SmoothStep(0.75f, 0.5f, progress);
			float LOpacityLerp = MathHelper.SmoothStep(1f, 0.85f, progress);
			float OpacityLerpOpposite = MathHelper.SmoothStep(0.5f, 0.75f, progress);
			float LOpacityLerpOpposite = MathHelper.SmoothStep(0.85f, 1f, progress);
			float ScaleLerp = MathHelper.SmoothStep(0.7f, 1.2f, progress);
			float ScaleLerpOpposite = MathHelper.SmoothStep(1.2f, 0.7f, progress);

			float VectorLerpIncrease = MathHelper.SmoothStep(0f, 40f, progress);
			float ExtremeOpacityLerp = MathHelper.SmoothStep(1f, 0f, (progress * 1.5f));
			float ExtremeOpacityLerpOpposite = MathHelper.SmoothStep(0f, 1f, (progress * 1.5f));

			Main.spriteBatch.Draw(UIBackround, DrawPos + new Vector2(0f + VectorLerpIncrease, -player.height + -12), null, color * OpacityLerp, 0f, DrawOriginBackground, ScaleLerpOpposite, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(UIFirst, DrawPos + new Vector2(0f + VectorLerpIncrease, -player.height + -12), null, color * LOpacityLerp, 0f, DrawOriginUITop, ScaleLerpOpposite, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(UIBackround, DrawPos + new Vector2(-40f + VectorLerpIncrease, -player.height + -12), null, color * OpacityLerpOpposite, 0f, DrawOriginBackground, ScaleLerp, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(UISecond, DrawPos + new Vector2(-40f + VectorLerpIncrease, -player.height + -12), null, color * LOpacityLerpOpposite, 0f, DrawOriginUITop, ScaleLerp, SpriteEffects.None, 0f);

			Main.spriteBatch.Draw(UIBackround, DrawPos + new Vector2(40f + VectorLerpIncrease, -player.height + -12), null, color * 0.5f * ExtremeOpacityLerp, 0f, DrawOriginBackground, 0.7f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(UIThird, DrawPos + new Vector2(40f + VectorLerpIncrease, -player.height + -12), null, color * 0.85f * ExtremeOpacityLerp, 0f, DrawOriginUITop, 0.7f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(UIBackround, DrawPos + new Vector2(-80f + VectorLerpIncrease, -player.height + -12), null, color * 0.5f * ExtremeOpacityLerpOpposite, 0f, DrawOriginBackground, 0.7f, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(UIThird, DrawPos + new Vector2(-80f + VectorLerpIncrease, -player.height + -12), null, color * 0.85f * ExtremeOpacityLerpOpposite, 0f, DrawOriginUITop, 0.7f, SpriteEffects.None, 0f);

			return true;
        }

	}
}