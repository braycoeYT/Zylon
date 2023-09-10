using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Zylon.Systems.Camera;

namespace Zylon.Projectiles.Boomerangs
{
	public abstract class BoomerangProj : ModProjectile
	{
		private bool Setup;
		private bool ThrowAllowed;
		private bool SetupThrow;

		private bool ReachedTipOfArc;

		private int initialDirection;
		private Vector2 StoredVelocity = Vector2.Zero;

		private int channelTime;
		public int ChannelMax;

		private int ThrowAnimation;
		public int ThrowAnimationMax;

		public float BoomerangRotationSpeed;

		public float ArcSpread;
		public float ArcLength;
		public int ArcTime;
		public int ArcFrames;

		private int FlashTime;
		private const int FlashTimeMax = 20;
		private bool Flashed;

		public int MaxPredictionDots;
		private float DotProgress;

		public int BonusDamage;

		public float ScreenshakeOnHit;
		public float ScreenshakeDistance;

		public float ArcCenter;

		public BoomerangProj(int ChannelMax_Input, int ThrowAnimationMax_Input, int BonusDamage_Input, float ArcSpread_Input, float ArcLength_Input, int ArcFrames_Input, float BoomerangRotationSpeed_Input = 0.2f, int MaxPredictionDots_Input = 95, float ScreenshakeOnHit_Input = 5f, float ScreenshakeDistance_Input = 425f, float ArcCenter_Input = 0.8f)
		{
			ChannelMax = ChannelMax_Input;
			ThrowAnimationMax = ThrowAnimationMax_Input;
			BonusDamage = BonusDamage_Input;
			ArcSpread = ArcSpread_Input;
			ArcLength = ArcLength_Input;
			ArcFrames = ArcFrames_Input;
			BoomerangRotationSpeed = BoomerangRotationSpeed_Input;
			MaxPredictionDots = MaxPredictionDots_Input;
			ScreenshakeOnHit = ScreenshakeOnHit_Input;
			ScreenshakeDistance = ScreenshakeDistance_Input;
			ArcCenter = ArcCenter_Input;
		}

		public override void SetDefaults()
		{
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 5;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 6;
			Projectile.netImportant = true;
			Projectile.tileCollide = false;
			BoomerangDefaultsSafe();
		}

		public override void AI()
		{
			BoomerangAISafe();
			Projectile.oldPos[0] = Projectile.position;
			for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
			{
				Projectile.oldPos[i] = Projectile.oldPos[i - 1];
			}
			Projectile.oldRot[0] = Projectile.rotation;
			for (int j = Projectile.oldRot.Length - 1; j > 0; j--)
			{
				Projectile.oldRot[j] = Projectile.oldRot[j - 1];
			}
			Player ProjectileOwner = Main.player[Projectile.owner];
			if (!Setup)
			{
				initialDirection = ProjectileOwner.direction;
				SetupThrow = false;
				Setup = true;
			}
			if (ProjectileOwner.channel)
			{
				ChannelBehaviour(ProjectileOwner);
				return;
			}
			if (!ThrowAllowed)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					CameraController.ReturnCamera(10);
				}
				return;
			}
			if (ThrowAnimation > 0)
			{
				ThrowBoomerang(ProjectileOwner);
				return;
			}
			ThrownAI(ProjectileOwner);
		}

		public void ThrownAI(Player player)
		{
			Projectile.timeLeft = 2;
			if (!SetupThrow && Projectile.owner == Main.myPlayer)
			{
				Projectile.velocity = Vector2.Normalize(Main.MouseWorld - Projectile.Center);
				Projectile.netUpdate = true;
			}
			SetupThrow = true;
			Projectile.rotation += BoomerangRotationSpeed;
			float ArcRatio = (float)ArcTime / (float)ArcFrames;
			if (ArcRatio > 0.5f)
			{
				float FakeArcRatio = (ArcRatio - 0.5f) * 2f;
				Projectile.Center = new Vector2(MathHelper.SmoothStep(ArcLength, 0f, FakeArcRatio), 0f).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2)) + player.Center;
				Projectile.Center += new Vector2(MathExtras.TensionStep(0f, 0f, FakeArcRatio, (1f - ArcCenter), -ArcSpread), 0f).RotatedBy((double)(Projectile.velocity.ToRotation() + 1.57079637f * (float)initialDirection), default(Vector2));
				if (!ReachedTipOfArc)
				{
					ReachedTipOfArc = true;
					BoomerangPeakArc();
				}
			}
			else
			{
				float FakeArcRatio2 = ArcRatio * 2f;
				Projectile.Center = new Vector2(MathHelper.SmoothStep(0f, ArcLength, FakeArcRatio2), 0f).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2)) + player.Center;
				Projectile.Center += new Vector2(MathExtras.TensionStep(0f, 0f, FakeArcRatio2, ArcCenter, ArcSpread), 0f).RotatedBy((double)(Projectile.velocity.ToRotation() + 1.57079637f * (float)initialDirection), default(Vector2));
			}
			ArcTime++;
			if (ArcTime > ArcFrames)
			{
				Projectile.Kill();
			}
		}

		public void ThrowBoomerang(Player player)
		{
			Projectile.timeLeft = 2;
			float AnimationRatio = (float)ThrowAnimation / (float)ThrowAnimationMax;
			if (Projectile.owner == Main.myPlayer)
			{
				CameraController.ReturnCamera(10);
			}
			if (StoredVelocity == Vector2.Zero)
			{
				StoredVelocity = Projectile.velocity;
			}
			Projectile.velocity = Vector2.Normalize(Vector2.SmoothStep(StoredVelocity.RotatedBy((double)(-1.8f * (float)initialDirection), default(Vector2)), StoredVelocity, AnimationRatio));
			Projectile.velocity *= 15f;
			Projectile.Center = player.RotatedRelativePoint(player.MountedCenter, true, true) + new Vector2((float)Projectile.width * 0.2f, 0f).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.direction = initialDirection;
			Projectile.spriteDirection = Projectile.direction;
			float AdditionalArmRotation = -1.13f;
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += 3.14159274f;
				AdditionalArmRotation = -AdditionalArmRotation;
			}
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation + AdditionalArmRotation);
			player.SetCompositeArmBack(true, Player.CompositeArmStretchAmount.Full, MathHelper.SmoothStep(0f, -2.12f, AnimationRatio) * (float)initialDirection);
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (Projectile.velocity * (float)Projectile.direction).ToRotation();
			ThrowAnimation--;
		}

		public void ChannelBehaviour(Player player)
		{
			Projectile.timeLeft = 2;
			if (channelTime < ChannelMax)
			{
				channelTime++;
			}
			float ChannelRatio = (float)channelTime / (float)ChannelMax;
			if (ChannelRatio > 0.45f)
			{
				ThrowAnimation = (int)MathHelper.SmoothStep(0f, (float)ThrowAnimationMax, ChannelRatio);
				ThrowAllowed = true;
			}
			Projectile.Center = player.RotatedRelativePoint(player.MountedCenter, true, true) + new Vector2((float)Projectile.width * 0.2f, 0f).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.direction = initialDirection;
			Projectile.spriteDirection = Projectile.direction;
			float AdditionalArmRotation = -1.13f;
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += 3.14159274f;
				AdditionalArmRotation = -AdditionalArmRotation;
			}
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation + AdditionalArmRotation);
			player.SetCompositeArmBack(true, Player.CompositeArmStretchAmount.Full, MathHelper.SmoothStep(0f, -2.12f, ChannelRatio) * (float)initialDirection);
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (Projectile.velocity * (float)Projectile.direction).ToRotation();
			if (Projectile.owner == Main.myPlayer)
			{
				float CameraDistance = 100f;
				if ((Main.MouseWorld + CameraController.PanLocation).Distance(Main.LocalPlayer.Center + CameraController.PanLocation) < CameraDistance * 3f)
				{
					CameraDistance = (Main.MouseWorld + CameraController.PanLocation).Distance(Main.LocalPlayer.Center + CameraController.PanLocation) / 3f;
				}
				CameraController.ManualPanFunction(Main.LocalPlayer.Center, Main.LocalPlayer.Center + new Vector2(CameraDistance, 0f).RotatedBy((double)Vector2.Normalize(Main.MouseWorld - Main.LocalPlayer.Center).ToRotation(), default(Vector2)), ChannelRatio);
				SetAim(MathHelper.SmoothStep(0.15f, 0.085f, ChannelRatio), ChannelRatio, player);
			}
		}

		public void SetAim(float speed, float ChannelRatio, Player player)
		{
			Vector2 aim = Vector2.Normalize(Main.MouseWorld - player.RotatedRelativePoint(player.MountedCenter, true, true));
			if (aim.HasNaNs())
			{
				aim = -Vector2.UnitY;
			}
			aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(Projectile.velocity.RotatedBy((double)MathHelper.SmoothStep(0f, -2.3f * (float)Projectile.direction, ChannelRatio), default(Vector2))), aim, speed));
			aim *= 15f;
			if (aim.RotatedBy((double)MathHelper.SmoothStep(0f, 2.3f * (float)Projectile.direction, ChannelRatio), default(Vector2)) != Projectile.velocity)
			{
				Projectile.netUpdate = true;
			}
			Projectile.velocity = aim;
			Projectile.velocity = Projectile.velocity.RotatedBy((double)MathHelper.SmoothStep(0f, 2.3f * (float)Projectile.direction, ChannelRatio), default(Vector2));
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
			Texture2D predictionMarker = (Texture2D)ModContent.Request<Texture2D>("Zylon/Projectiles/Boomerangs/BoomerangShow");
			SpriteEffects effects = 0;
			Vector2 drawOrigin = new Vector2((float)projectileTexture.Width * 0.5f, (float)Projectile.height * 0.5f);
			Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
			Color color = Projectile.GetAlpha(lightColor);
			Player ProjectileOwner = Main.player[Projectile.owner];
			if (Projectile.spriteDirection == -1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			if (SetupThrow)
			{
				for (int i = 0; i < Projectile.oldPos.Length; i++)
				{
					Vector2 drawPosEffect = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
					Color colorAfterEffect = color * ((float)(Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length) * 0.5f;
					Main.spriteBatch.Draw(projectileTexture, drawPosEffect, new Rectangle?(new Rectangle(0, 0, projectileTexture.Width, projectileTexture.Height / 2)), colorAfterEffect, Projectile.oldRot[i], drawOrigin, Projectile.scale, effects, 0f);
				}
			}
			Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, 0, projectileTexture.Width, projectileTexture.Height / 2)), color, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0f);
			if (ProjectileOwner.channel)
			{
				if (channelTime == ChannelMax)
				{
					if (!Flashed)
					{
						FlashTime = 20;
						Flashed = true;
					}
					Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, projectileTexture.Height / 2, projectileTexture.Width, projectileTexture.Height / 2)), Projectile.GetAlpha(Color.White) * MathHelper.SmoothStep(0f, 0.7f, (float)FlashTime / 20f), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0f);
					Main.spriteBatch.Draw(projectileTexture, drawPos, new Rectangle?(new Rectangle(0, projectileTexture.Height / 2, projectileTexture.Width, projectileTexture.Height / 2)), Projectile.GetAlpha(Color.White) * MathHelper.SmoothStep(0f, 0.3f, (float)FlashTime / 20f), Projectile.rotation, drawOrigin, Projectile.scale + MathHelper.SmoothStep(0f, 0.3f, (float)FlashTime / 20f), effects, 0f);
					FlashTime--;
				}
				if (Projectile.owner == Main.myPlayer && Flashed)
				{
					DotProgress += 0.5f;
					if (DotProgress > (float)MaxPredictionDots)
					{
						DotProgress = 0f;
					}
					Vector2 PredictionVelocity = Vector2.Normalize(Main.MouseWorld - Projectile.Center);
					for (int predictionAmount = 0; predictionAmount < MaxPredictionDots; predictionAmount++)
					{
						if ((float)predictionAmount >= DotProgress - 5f && (float)predictionAmount <= DotProgress + 5f)
						{
							float opacityMultiplier = 0.9f;
							if ((float)predictionAmount > DotProgress)
							{
								opacityMultiplier = 1f - ((float)predictionAmount - DotProgress) / 5f;
							}
							if ((float)predictionAmount < DotProgress)
							{
								opacityMultiplier = 1f - (DotProgress - (float)predictionAmount) / 5f;
							}
							Vector2 drawLocation = Vector2.Zero;
							float ArcPredictionRatio = (float)predictionAmount * 0.5f / (float)ArcFrames;
							if (ArcPredictionRatio > 0.5f)
							{
								float FakeArcRatio = (ArcPredictionRatio - 0.5f) * 2f;
								drawLocation = new Vector2(MathHelper.SmoothStep(ArcLength, 0f, FakeArcRatio), 0f).RotatedBy((double)PredictionVelocity.ToRotation(), default(Vector2)) + Projectile.Center;
								drawLocation += new Vector2(MathExtras.TensionStep(0f, 0f, FakeArcRatio, (1f - ArcCenter), -ArcSpread), 0f).RotatedBy((double)(PredictionVelocity.ToRotation() + 1.57079637f * (float)initialDirection), default(Vector2));
							}
							else
							{
								float FakeArcRatio2 = ArcPredictionRatio * 2f;
								drawLocation = new Vector2(MathHelper.SmoothStep(0f, ArcLength, FakeArcRatio2), 0f).RotatedBy((double)PredictionVelocity.ToRotation(), default(Vector2)) + Projectile.Center;
								drawLocation += new Vector2(MathExtras.TensionStep(0f, 0f, FakeArcRatio2, ArcCenter, ArcSpread), 0f).RotatedBy((double)(PredictionVelocity.ToRotation() + 1.57079637f * (float)initialDirection), default(Vector2));
							}
							if (ArcPredictionRatio <= 1f)
							{
								drawLocation = drawLocation - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
								Main.spriteBatch.Draw(predictionMarker, drawLocation, null, Color.White * 0.6f * opacityMultiplier * MathHelper.SmoothStep(1f, 0f, (float)FlashTime / 20f), 0f, drawOrigin, 0.7f, effects, 0f);
							}
						}
					}
				}
			}
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			if (SetupThrow)
			{
				return null;
			}
			return new bool?(false);
		}

		public override bool CanHitPvp(Player target)
		{
			return SetupThrow;
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			modifiers.SourceDamage += ((float)BonusDamage * ((float)channelTime / (float)ChannelMax)) * 0.01f;
			if (channelTime == ChannelMax)
			{
				modifiers.SetCrit();
			}
			base.ModifyHitNPC(target, ref modifiers);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Projectile.owner == Main.myPlayer)
			{
				CameraController.ScreenshakePoints(ScreenshakeOnHit, ScreenshakeDistance, target.Center, Main.LocalPlayer.Center, 1f);
			}
			OnHitNPCSafe(target, damageDone, hit.Knockback, hit.Crit);
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (info.PvP)
            {
				if (Projectile.owner == Main.myPlayer)
				{
					CameraController.ScreenshakePoints(ScreenshakeOnHit, ScreenshakeDistance, target.Center, Main.LocalPlayer.Center, 1f);
				}
				OnHitPvpSafe(target, info.Damage, false);
			}
        }

        public virtual void OnHitNPCSafe(NPC target, int damage, float knockback, bool crit)
		{
		}

		public virtual void OnHitPvpSafe(Player target, int damage, bool crit)
		{
		}


		public virtual void BoomerangDefaultsSafe()
		{
		}

		public virtual void BoomerangAISafe()
		{
		}

		public virtual void BoomerangPeakArc()
		{
		}
	}
}
