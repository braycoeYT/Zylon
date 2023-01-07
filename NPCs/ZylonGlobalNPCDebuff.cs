using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class ZylonGlobalNPCDebuff : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool heartdaze;
		public bool shroomed;
		public bool deadlyToxins;
		public bool elemDegen;
		public bool timestop;
		public bool brainFreeze;
		public bool loberaSlash;
		public bool zombieRot;
		public bool flashPandemic;
		public override void ResetEffects(NPC npc) {
			heartdaze = false;
			shroomed = false;
			deadlyToxins = false;
			elemDegen = false;
			timestop = false;
			brainFreeze = false;
			loberaSlash = false;
			zombieRot = false;
			flashPandemic = false;
			base.ResetEffects(npc);
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (heartdaze) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 20;
				if (!npc.boss)
					npc.lifeRegen -= 40;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (shroomed) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 4;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (deadlyToxins) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 20;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (elemDegen) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 48;
				if (damage < 2) {
					damage = 2;
				}
			}
			if (zombieRot) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 10;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (flashPandemic) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 100;
				if (damage < 2) {
					damage = 2;
				}
			}
			base.UpdateLifeRegen(npc, ref damage);
		}
		int Timer;
		bool safe = true;
        Color safeColor;
		bool setup;
		bool safeGrav;
		float stayRot;
		int stayDir;
		Vector2 stay;
		Color tColor;
		bool checkColor;
        public override void PostAI(NPC npc) { //Tome man gonna kill me for this if statement army
			checkColor = !npc.boss && npc.type != NPCID.GolemHead;
			Timer++;
            if (safe) {
                safeColor = npc.color;
                safe = false;
				safeGrav = npc.noGravity;
            }
			tColor = safeColor;
			if (brainFreeze) {
				tColor = Color.LightSkyBlue;
				if (checkColor) {
					npc.velocity *= 0.93f;
				}
            }
			if (shroomed) {
				tColor = Color.DarkBlue;
            }
			if (zombieRot) {
				tColor = Color.ForestGreen;
				for (int i = 0; i < Main.maxNPCs; i++) {
					if (Vector2.Distance(npc.Center, Main.npc[i].Center) < 60 && !Main.npc[i].friendly && Main.npc[i].active && !Main.npc[i].HasBuff<Buffs.Debuffs.ZombieRot>() && Main.rand.NextFloat() < .03f)
						Main.npc[i].AddBuff(BuffType<Buffs.Debuffs.ZombieRot>(), 180);
                }
            }
			if (deadlyToxins) {
				tColor = Color.Purple;
            }
			if (loberaSlash) {
				tColor = Color.LightGoldenrodYellow;
            }
			if (flashPandemic) {
				tColor = Color.LimeGreen;
				for (int i = 0; i < Main.maxNPCs; i++) {
					if (Vector2.Distance(npc.Center, Main.npc[i].Center) < 60 && !Main.npc[i].friendly && Main.npc[i].active && !Main.npc[i].HasBuff<Buffs.Debuffs.FlashPandemic>() && Main.rand.NextFloat() < .05f)
						Main.npc[i].AddBuff(BuffType<Buffs.Debuffs.FlashPandemic>(), 60);
                }
            }
			if (heartdaze) {
				tColor = Color.Red;
            }
			if (elemDegen) {
				tColor = Color.LawnGreen;
				if (Timer % 90 < 45) tColor = Color.Orange;
            }
			if (timestop) {
				tColor = Color.SlateGray;
				if (checkColor) {
					npc.velocity = Vector2.Zero;
					if (!setup) {
				        stay = npc.position;
						stayRot = npc.rotation;
						stayDir = npc.spriteDirection;
				        setup = true;
					}
					npc.position = stay;
					npc.rotation = stayRot;
					npc.spriteDirection = stayDir;
					npc.noGravity = true;
				}
			}
			else {
				setup = false;
				npc.noGravity = safeGrav;
            }
			if (checkColor) {
                npc.color = tColor;
			}
			base.PostAI(npc);
        }
		/*private void ColorStuff(NPC npc, Color color) {
			if (!npc.boss && npc.type != NPCID.GolemHead) {
				npc.color = color;
			}
			canNormal = false;
        }*/
    }
}