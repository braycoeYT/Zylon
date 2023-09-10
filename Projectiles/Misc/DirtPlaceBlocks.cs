using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Projectiles.Misc
{
	public class DirtPlaceBlocks : ModProjectile
	{
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Dirt Ball");
        }
        public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 9999;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Generic;
		}
        public override bool PreKill(int timeLeft) {
			int num832;
			int num833 = (int)(Projectile.position.X + (float)(Projectile.width / 2)) / 16;
						int num834 = (int)(Projectile.position.Y + (float)(Projectile.width / 2)) / 16;
						int num835 = 0;
						int num836 = 2;
						if (Main.tile[num833, num834].IsHalfBlock && Projectile.velocity.Y > 0f && Math.Abs(Projectile.velocity.Y) > Math.Abs(Projectile.velocity.X))
						{
							num834--;
						}
						if (!Main.tile[num833, num834].HasUnactuatedTile && num835 >= 0)
						{
							bool flag5 = false;
							if (num834 > Main.maxTilesY - 2 || (Main.tile[num833, num834].HasTile && !Main.tile[num833, num834].HasUnactuatedTile) || (!(Main.tile[num833, num834+1].HasTile || Main.tile[num833, num834-1].HasTile || Main.tile[num833-1, num834].HasTile || Main.tile[num833+1, num834].HasTile)))//Main.tile[num833, num834 + 1] != null || !Main.tile[num833, num834 + 1].HasUnactuatedTile) //I hope I don't need this (I definitely screwed this up 100%, prepare for pain) --> //&& Main.tile[num833, num834 + 1].BlockType == Terraria.ID.BlockType.)
							{
								flag5 = true;
							}
							if (!flag5)
							{
								WorldGen.PlaceTile(num833, num834, num835, false, true, -1, 0);
							}
							if (!flag5 && Main.tile[num833, num834].HasUnactuatedTile && (int)Main.tile[num833, num834].BlockType == num835)
							{
								if (Main.tile[num833, num834 + 1].IsHalfBlock || Main.tile[num833, num834 + 1].Slope != 0)
								{
									WorldGen.SlopeTile(num833, num834 + 1, 0);
									if (Main.netMode == NetmodeID.Server)
									{
										NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 14, (float)num833, (float)(num834 + 1), 0f, 0, 0, 0);
									}
								}
								if (Main.netMode != NetmodeID.SinglePlayer)
								{
									NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, (float)num833, (float)num834, (float)num835, 0, 0, 0);
								}
							}
							else if (num836 > 0)
							{
								num832 = Item.NewItem(Projectile.GetSource_FromAI(), (int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height, num836, 1, false, 0, false, false);
							}
						}
						else if (num836 > 0)
						{
							num832 = Item.NewItem(Projectile.GetSource_FromAI(), (int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height, num836, 1, false, 0, false, false);
						}
            return true;
        }
        public override void Kill(int timeLeft) {
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
	}   
}