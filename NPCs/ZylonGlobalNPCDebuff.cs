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
		public override void ResetEffects(NPC npc) {
			heartdaze = false;
			shroomed = false;
			deadlyToxins = false;
			elemDegen = false;
			timestop = false;
			brainFreeze = false;
			loberaSlash = false;
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
				if (damage < 1) {
					damage = 1;
				}
			}
			base.UpdateLifeRegen(npc, ref damage);
		}
		int Timer;
		bool safe = true;
        Color safeColor;
		bool setup;
		bool safeGrav;
		bool canNormal;
		float stayRot;
		int stayDir;
		Vector2 stay;
        public override void PostAI(NPC npc) { //Tome man gonna kill me for this if statement army
			Timer++;
			canNormal = true;
            if (safe) {
                safeColor = npc.color;
                safe = false;
				safeGrav = npc.noGravity;
            }
			if (brainFreeze) {
				if (!npc.boss && npc.type != NPCID.GolemHead) {
					npc.color = Color.LightSkyBlue;
					npc.velocity *= 0.93f;
				}
				canNormal = false;
            }
			if (shroomed) {
				if (!npc.boss && npc.type != NPCID.GolemHead) {
					npc.color = Color.DarkBlue;
				}
				canNormal = false;
            }
			if (deadlyToxins) {
				if (!npc.boss && npc.type != NPCID.GolemHead) {
					npc.color = Color.Purple;
				}
				canNormal = false;
            }
			if (loberaSlash) {
				if (!npc.boss && npc.type != NPCID.GolemHead) {
					npc.color = Color.LightGoldenrodYellow;
				}
				canNormal = false;
            }
			if (heartdaze) {
				if (!npc.boss && npc.type != NPCID.GolemHead) {
					npc.color = Color.Red;
				}
				canNormal = false;
            }
			if (elemDegen) {
				if (!npc.boss && npc.type != NPCID.GolemHead) {
					if (Timer % 90 < 45) npc.color = Color.Orange;
					else npc.color = Color.LawnGreen;
				}
				canNormal = false;
            }
			if (timestop) {
				if (!npc.boss && npc.type != NPCID.GolemHead) {
					npc.color = Color.SlateGray;
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
				canNormal = false;
			}
			else {
				setup = false;
				npc.noGravity = safeGrav;
            }
			if (canNormal) {
                npc.color = safeColor;
			}
			base.PostAI(npc);
        }
    }
}