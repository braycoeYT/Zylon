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

namespace Zylon
{
	public class ProjectileHelpers
	{
		/// <summary>
		/// This shouldn't be used for every time you want to spawn a projectile, it is just made for easier use for those who don't want to bother with the more basic aspects of multiplayer integration
		/// <br/><br/>BasicNetType values mean...
		/// <br/>one is player projectile spawning, could be from accessories or other projectiles. Owner needs to be set to the right player for this to work. 
		/// <br/>two is NPC sources and projectiles.
		/// <br/><br/>If you want to do anything even slightly more complicated involving multiplayer, don't use this, code the conditions indicated on Projectile.NewProjectile and go from there.
		/// </summary>
		public static void NewNetProjectile(IEntitySource spawnSource, Vector2 position, Vector2 velocity, int Type, int Damage, float Knockback, int Owner = 255, float ai0 = 0, float ai1 = 0, int BasicNetType = 1)
        {
			switch(BasicNetType)
            {
				case 1:
					if (Main.myPlayer == Owner)
					Projectile.NewProjectile(spawnSource, position, velocity, Type, Damage, Knockback, Owner, ai0, ai1);
					break;

				case 2:
					if (Main.netMode != NetmodeID.MultiplayerClient)
						Projectile.NewProjectile(spawnSource, position, velocity, Type, Damage, Knockback, Owner, ai0, ai1);
					break;
			}
		}

		/// <summary>
		/// This shouldn't be used for every time you want to spawn a projectile, it is just made for easier use for those who don't want to bother with the more basic aspects of multiplayer integration
		/// <br/><br/>BasicNetType values mean...
		/// <br/>one is player projectile spawning, could be from accessories or other projectiles. Owner needs to be set to the right player for this to work. 
		/// <br/>two is NPC sources and projectiles.
		/// <br/><br/>If you want to do anything even slightly more complicated involving multiplayer, don't use this, code the conditions indicated on Projectile.NewProjectile and go from there.
		/// </summary>
		public static void NewNetProjectile(IEntitySource spawnSource, float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float Knockback, int Owner = 255, float ai0 = 0, float ai1 = 0, int BasicNetType = 1)
		{
			switch (BasicNetType)
			{
				case 1:
					if (Main.myPlayer == Owner)
						Projectile.NewProjectile(spawnSource, X, Y, SpeedX, SpeedY, Type, Damage, Knockback, Owner, ai0, ai1);
					break;

				case 2:
					if (Main.netMode != NetmodeID.MultiplayerClient)
						Projectile.NewProjectile(spawnSource, X, Y, SpeedX, SpeedY, Type, Damage, Knockback, Owner, ai0, ai1);
					break;
			}
		}
	}
}