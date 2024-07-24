using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;
using ReLogic.Content;
using Terraria.DataStructures;

namespace Zylon.Projectiles.Flails
{
	public class Sporophyte : ModProjectile
	{
		private const string ChainTexturePath = "Zylon/Projectiles/Flails/SporophyteChain";
		
		private enum AIState
		{
			Spinning,
			LaunchingForward,
			Retracting,
			UnusedState,
			ForcedRetracting,
			Ricochet,
			Dropping
		}

		private AIState CurrentAIState {
			get => (AIState)Projectile.ai[0];
			set => Projectile.ai[0] = (float)value;
		}
		public ref float StateTimer => ref Projectile.ai[1];
		public ref float CollisionCounter => ref Projectile.localAI[0];
		public ref float SpinningStateTimer => ref Projectile.localAI[1];

		public override void SetStaticDefaults() {
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}
		public override void SetDefaults() {
			Projectile.netImportant = true;
			Projectile.width = 24;
			Projectile.height = 24;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 20 == 0) {
				//SoundEngine.PlaySound(SoundID.Grass);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, -5).RotatedByRandom(1f), ModContent.ProjectileType<StingerPassive>(), (int)(Projectile.damage * 0.5f), (int)(Projectile.knockBack / 3), Main.myPlayer);
			}

			Player player = Main.player[Projectile.owner];
			if (!player.active || player.dead || player.noItems || player.CCed || Vector2.Distance(Projectile.Center, player.Center) > 900f) {
				Projectile.Kill();
				return;
			}
			if (Main.myPlayer == Projectile.owner && Main.mapFullscreen) {
				Projectile.Kill();
				return;
			}

			Vector2 mountedCenter = player.MountedCenter;
			bool doFastThrowDust = false;
			bool shouldOwnerHitCheck = false;
			int launchTimeLimit = 20;  // How much time the Projectile can go before retracting (speed and shootTimer will set the flail's range)
			float launchSpeed = 19f; // How fast the Projectile can move
			float maxLaunchLength = 1000f; // How far the Projectile's chain can stretch before being forced to retract when in launched state
			float retractAcceleration = 2.7f; // How quickly the Projectile will accelerate back towards the player while retracting
			float maxRetractSpeed = 11f; // The max speed the Projectile will have while retracting
			float forcedRetractAcceleration = 9f; // How quickly the Projectile will accelerate back towards the player while being forced to retract
			float maxForcedRetractSpeed = 18f; // The max speed the Projectile will have while being forced to retract
			float unusedRetractAcceleration = 2.1f;
			float unusedMaxRetractSpeed = 18f;
			int unusedChainLength = 60;
			int defaultHitCooldown = 10; // How often your flail hits when resting on the ground, or retracting
			int spinHitCooldown = 20; // How often your flail hits when spinning
			int movingHitCooldown = 10; // How often your flail hits when moving
			int ricochetTimeLimit = launchTimeLimit + 5;

			// Scaling these speeds and accelerations by the players meleeSpeed make the weapon more responsive if the player boosts their meleeSpeed
			float meleeSpeed = player.GetAttackSpeed(DamageClass.Melee);
			float meleeSpeedMultiplier = 1f / meleeSpeed;
			launchSpeed *= meleeSpeedMultiplier;
			unusedRetractAcceleration *= meleeSpeedMultiplier;
			unusedMaxRetractSpeed *= meleeSpeedMultiplier;
			retractAcceleration *= meleeSpeedMultiplier;
			maxRetractSpeed *= meleeSpeedMultiplier;
			forcedRetractAcceleration *= meleeSpeedMultiplier;
			maxForcedRetractSpeed *= meleeSpeedMultiplier;
			float launchRange = launchSpeed * launchTimeLimit;
			float maxDroppedRange = launchRange + 160f;
			Projectile.localNPCHitCooldown = defaultHitCooldown;

			switch (CurrentAIState) {
				case AIState.Spinning: {
						shouldOwnerHitCheck = true;
						if (Projectile.owner == Main.myPlayer) {
							Vector2 unitVectorTowardsMouse = mountedCenter.DirectionTo(Main.MouseWorld).SafeNormalize(Vector2.UnitX * player.direction);
							player.ChangeDir((unitVectorTowardsMouse.X > 0f) ? 1 : (-1));
							if (!player.channel)
							{
								CurrentAIState = AIState.LaunchingForward;
								StateTimer = 0f;
								Projectile.velocity = unitVectorTowardsMouse * launchSpeed + player.velocity;
								Projectile.Center = mountedCenter;
								Projectile.netUpdate = true;
								Projectile.ResetLocalNPCHitImmunity();
								Projectile.localNPCHitCooldown = movingHitCooldown;
								break;
							}
						}
						SpinningStateTimer += 1f;
						Vector2 offsetFromPlayer = new Vector2(player.direction).RotatedBy((float)Math.PI * 10f * (SpinningStateTimer / 60f) * player.direction);

						offsetFromPlayer.Y *= 0.8f;
						if (offsetFromPlayer.Y * player.gravDir > 0f) {
							offsetFromPlayer.Y *= 0.5f;
						}
						Projectile.Center = mountedCenter + offsetFromPlayer * 30f;
						Projectile.velocity = Vector2.Zero;
						Projectile.localNPCHitCooldown = spinHitCooldown;
						break;
					}
				case AIState.LaunchingForward: {
						doFastThrowDust = true;
						bool shouldSwitchToRetracting = StateTimer++ >= launchTimeLimit;
						shouldSwitchToRetracting |= Projectile.Distance(mountedCenter) >= maxLaunchLength;
						if (player.controlUseItem)
						{
							CurrentAIState = AIState.Dropping;
							StateTimer = 0f;
							Projectile.netUpdate = true;
							Projectile.velocity *= 0.2f;
							float rand = MathHelper.ToRadians(Main.rand.NextFloat(24f));
							if (Main.myPlayer == Projectile.owner) for (int x = 0; x < 15; x++) {
								Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 3).RotatedBy(MathHelper.ToRadians(x*24)+rand), ModContent.ProjectileType<TheArchangelProj>(), Projectile.damage/4, Projectile.knockBack/2, Projectile.owner);
                            }
							break;
						}
						if (shouldSwitchToRetracting)
						{
							CurrentAIState = AIState.Retracting;
							StateTimer = 0f;
							Projectile.netUpdate = true;
							Projectile.velocity *= 0.3f;
							float rand = MathHelper.ToRadians(Main.rand.NextFloat(24f));
							if (Main.myPlayer == Projectile.owner) for (int x = 0; x < 15; x++) {
								Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 3).RotatedBy(MathHelper.ToRadians(x*24)+rand), ModContent.ProjectileType<TheArchangelProj>(), Projectile.damage/4, Projectile.knockBack/2, Projectile.owner);
                            }
						}
						player.ChangeDir((player.Center.X < Projectile.Center.X) ? 1 : (-1));
						Projectile.localNPCHitCooldown = movingHitCooldown;
						break;
					}
				case AIState.Retracting: {
						Vector2 unitVectorTowardsPlayer = Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero);
						if (Projectile.Distance(mountedCenter) <= maxRetractSpeed) {
							Projectile.Kill();
							return;
						}
						if (player.controlUseItem)
						{
							CurrentAIState = AIState.Dropping;
							StateTimer = 0f;
							Projectile.netUpdate = true;
							Projectile.velocity *= 0.2f;
						}
						else {
							Projectile.velocity *= 0.98f;
							Projectile.velocity = Projectile.velocity.MoveTowards(unitVectorTowardsPlayer * maxRetractSpeed, retractAcceleration);
							player.ChangeDir((player.Center.X < Projectile.Center.X) ? 1 : (-1));
						}
						break;
					}
				case AIState.UnusedState:
					{
						if (!player.controlUseItem) {
							CurrentAIState = AIState.ForcedRetracting;
							StateTimer = 0f;
							Projectile.netUpdate = true;
							break;
						}
						float currentChainLength = Projectile.Distance(mountedCenter);
						Projectile.tileCollide = StateTimer == 1f;
						bool flag3 = currentChainLength <= launchRange;
						if (flag3 != Projectile.tileCollide) {
							Projectile.tileCollide = flag3;
							StateTimer = Projectile.tileCollide ? 1 : 0;
							Projectile.netUpdate = true;
						}
						if (currentChainLength > unusedChainLength) {

							if (currentChainLength >= launchRange) {
								Projectile.velocity *= 0.5f;
								Projectile.velocity = Projectile.velocity.MoveTowards(Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero) * unusedMaxRetractSpeed, unusedMaxRetractSpeed);
							}
							Projectile.velocity *= 0.98f;
							Projectile.velocity = Projectile.velocity.MoveTowards(Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero) * unusedMaxRetractSpeed, unusedRetractAcceleration);
						}
						else {
							if (Projectile.velocity.Length() < 6f) {
								Projectile.velocity.X *= 0.96f;
								Projectile.velocity.Y += 0.2f;
							}
							if (player.velocity.X == 0f) {
								Projectile.velocity.X *= 0.96f;
							}
						}
						player.ChangeDir((player.Center.X < Projectile.Center.X) ? 1 : (-1));
						break;
					}
				case AIState.ForcedRetracting:
					{
						Projectile.tileCollide = false;
						Vector2 unitVectorTowardsPlayer = Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero);
						if (Projectile.Distance(mountedCenter) <= maxForcedRetractSpeed) {
							Projectile.Kill();
							return;
						}
						Projectile.velocity *= 0.98f;
						Projectile.velocity = Projectile.velocity.MoveTowards(unitVectorTowardsPlayer * maxForcedRetractSpeed, forcedRetractAcceleration);
						Vector2 target = Projectile.Center + Projectile.velocity;
						Vector2 value = mountedCenter.DirectionFrom(target).SafeNormalize(Vector2.Zero);
						if (Vector2.Dot(unitVectorTowardsPlayer, value) < 0f) {
							Projectile.Kill();
							return;
						}
						player.ChangeDir((player.Center.X < Projectile.Center.X) ? 1 : (-1));
						break;
					}
				case AIState.Ricochet:
					if (StateTimer++ >= ricochetTimeLimit) {
						CurrentAIState = AIState.Dropping;
						StateTimer = 0f;
						Projectile.netUpdate = true;
					}
					else {
						Projectile.localNPCHitCooldown = movingHitCooldown;
						Projectile.velocity.Y += 0.6f;
						Projectile.velocity.X *= 0.95f;
						player.ChangeDir((player.Center.X < Projectile.Center.X) ? 1 : (-1));
					}
					break;
				case AIState.Dropping:
					if (!player.controlUseItem || Projectile.Distance(mountedCenter) > maxDroppedRange) {
						CurrentAIState = AIState.ForcedRetracting;
						StateTimer = 0f;
						Projectile.netUpdate = true;
					}
					else {
						Projectile.velocity.Y += 0.8f;
						Projectile.velocity.X *= 0.95f;
						player.ChangeDir((player.Center.X < Projectile.Center.X) ? 1 : (-1));
					}
					break;
			}
			Projectile.direction = (Projectile.velocity.X > 0f) ? 1 : -1;
			Projectile.spriteDirection = Projectile.direction;
			Projectile.ownerHitCheck = shouldOwnerHitCheck;

			bool freeRotation = CurrentAIState == AIState.Ricochet || CurrentAIState == AIState.Dropping;
			if (freeRotation) {
				if (Projectile.velocity.Length() > 1f)
					Projectile.rotation = Projectile.velocity.ToRotation() + Projectile.velocity.X * 0.1f;
				else
					Projectile.rotation += Projectile.velocity.X * 0.1f;
			}
			else {
				Vector2 vectorTowardsPlayer = Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero);
				Projectile.rotation = vectorTowardsPlayer.ToRotation() + MathHelper.PiOver2;
			}

			Projectile.timeLeft = 2;
			player.heldProj = Projectile.whoAmI;
			player.SetDummyItemTime(2);
			player.itemRotation = Projectile.DirectionFrom(mountedCenter).ToRotation();
			if (Projectile.Center.X < mountedCenter.X) {
				player.itemRotation += (float)Math.PI;
			}
			player.itemRotation = MathHelper.WrapAngle(player.itemRotation);

			int dustRate = 15;
			if (doFastThrowDust)
				dustRate = 1;

			if (Main.rand.NextBool(dustRate))
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Stone);
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			int defaultLocalNPCHitCooldown = 10;
			int impactIntensity = 0;
			Vector2 velocity = Projectile.velocity;
			float bounceFactor = 0.2f;
			if (CurrentAIState == AIState.LaunchingForward || CurrentAIState == AIState.Ricochet)
				bounceFactor = 0.4f;

			if (CurrentAIState == AIState.Dropping)
				bounceFactor = 0f;

			if (oldVelocity.X != Projectile.velocity.X) {
				if (Math.Abs(oldVelocity.X) > 4f)
					impactIntensity = 1;

				Projectile.velocity.X = (0f - oldVelocity.X) * bounceFactor;
				CollisionCounter += 1f;
			}

			if (oldVelocity.Y != Projectile.velocity.Y) {
				if (Math.Abs(oldVelocity.Y) > 4f)
					impactIntensity = 1;

				Projectile.velocity.Y = (0f - oldVelocity.Y) * bounceFactor;
				CollisionCounter += 1f;
			}

			if (CurrentAIState == AIState.LaunchingForward) {
				CurrentAIState = AIState.Ricochet;
				Projectile.localNPCHitCooldown = defaultLocalNPCHitCooldown;
				Projectile.netUpdate = true;
				Point scanAreaStart = Projectile.TopLeft.ToTileCoordinates();
				Point scanAreaEnd = Projectile.BottomRight.ToTileCoordinates();
				impactIntensity = 2;
				Projectile.CreateImpactExplosion(2, Projectile.Center, ref scanAreaStart, ref scanAreaEnd, Projectile.width, out bool causedShockwaves);
				Projectile.CreateImpactExplosion2_FlailTileCollision(Projectile.Center, causedShockwaves, velocity);
				Projectile.position -= velocity;
			}

			if (impactIntensity > 0) {
				Projectile.netUpdate = true;
				for (int i = 0; i < impactIntensity; i++) {
					Collision.HitTiles(Projectile.position, velocity, Projectile.width, Projectile.height);
				}

				SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			}

			if (CurrentAIState != AIState.UnusedState && CurrentAIState != AIState.Spinning && CurrentAIState != AIState.Ricochet && CurrentAIState != AIState.Dropping && CollisionCounter >= 10f) {
				CurrentAIState = AIState.ForcedRetracting;
				Projectile.netUpdate = true;
			}
			return false;
		}

		public override bool? CanDamage() {
			if (CurrentAIState == AIState.Spinning && SpinningStateTimer <= 12f)
				return false;
			return base.CanDamage();
		}
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) {
			if (CurrentAIState == AIState.Spinning) {
				Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
				Vector2 shortestVectorFromPlayerToTarget = targetHitbox.ClosestPointInRect(mountedCenter) - mountedCenter;
				shortestVectorFromPlayerToTarget.Y /= 0.8f;
				float hitRadius = 55f;
				return shortestVectorFromPlayerToTarget.Length() <= hitRadius;
			}
			return base.Colliding(projHitbox, targetHitbox);
		}
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			modifiers.HitDirectionOverride = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);

			if (CurrentAIState == AIState.Spinning)
				modifiers.Knockback *= 0.25f;
			if (CurrentAIState == AIState.Dropping)
				modifiers.Knockback *= 0.5f;

			if (CurrentAIState == AIState.Spinning)
				modifiers.SourceDamage *= 1.2f;

			if (CurrentAIState == AIState.LaunchingForward || CurrentAIState == AIState.Retracting)
				modifiers.SourceDamage *= 2f;
		}
		public override bool PreDraw(ref Color lightColor) {
			Vector2 playerArmPosition = Main.GetPlayerArmPosition(Projectile);

			playerArmPosition.Y -= Main.player[Projectile.owner].gfxOffY;

			Asset<Texture2D> chainTexture = ModContent.Request<Texture2D>(ChainTexturePath);
			
			Rectangle? chainSourceRectangle = null;
			float chainHeightAdjustment = 0f;

			Vector2 chainOrigin = chainSourceRectangle.HasValue ? (chainSourceRectangle.Value.Size() / 2f) : (chainTexture.Size() / 2f);
			Vector2 chainDrawPosition = Projectile.Center;
			Vector2 vectorFromProjectileToPlayerArms = playerArmPosition.MoveTowards(chainDrawPosition, 4f) - chainDrawPosition;
			Vector2 unitVectorFromProjectileToPlayerArms = vectorFromProjectileToPlayerArms.SafeNormalize(Vector2.Zero);
			float chainSegmentLength = (chainSourceRectangle.HasValue ? chainSourceRectangle.Value.Height : chainTexture.Height()) + chainHeightAdjustment;
			if (chainSegmentLength == 0)
				chainSegmentLength = 10;
			float chainRotation = unitVectorFromProjectileToPlayerArms.ToRotation() + MathHelper.PiOver2;
			int chainCount = 0;
			float chainLengthRemainingToDraw = vectorFromProjectileToPlayerArms.Length() + chainSegmentLength / 2f;

			while (chainLengthRemainingToDraw > 0f) {
				Color chainDrawColor = Lighting.GetColor((int)chainDrawPosition.X / 16, (int)(chainDrawPosition.Y / 16f));

				var chainTextureToDraw = chainTexture;
				Main.spriteBatch.Draw(chainTextureToDraw.Value, chainDrawPosition - Main.screenPosition, chainSourceRectangle, chainDrawColor, chainRotation, chainOrigin, 1f, SpriteEffects.None, 0f);
				chainDrawPosition += unitVectorFromProjectileToPlayerArms * chainSegmentLength;
				chainCount++;
				chainLengthRemainingToDraw -= chainSegmentLength;
			}
			if (CurrentAIState == AIState.LaunchingForward)
			{
				Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
				Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
				SpriteEffects spriteEffects = SpriteEffects.None;
				if (Projectile.spriteDirection == -1)
					spriteEffects = SpriteEffects.FlipHorizontally;
				for (int k = 0; k < Projectile.oldPos.Length && k < StateTimer; k++) {
					Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
					Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
					Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - k / (float)Projectile.oldPos.Length / 3, spriteEffects, 0f);
				}
			}
			return true;
		}
	}
}