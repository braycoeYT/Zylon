using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ADD
{
    public class ADD_Ankh : ModNPC
    {
        public override void SetStaticDefaults() {
            //DisplayName.SetDefault("Everlasting Ankh");
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
            NPC.value = 0;
            NPC.width = 132; //132
            NPC.height = 270; //270 //242
            NPC.damage = 41; //322
            NPC.defense = 16;
            NPC.lifeMax = 2400;
            NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.netAlways = true;
            NPC.alpha = 255;
            NPC.dontCountMe = true;
            NPC.dontTakeDamage = true;
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */ {
            NPC.lifeMax = 3200;
        }
        int Timer;
        int num;
        public override bool CanHitPlayer(Player target, ref int cooldownSlot) {
            return false;
        }
        /*public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            Texture2D texture = TextureAssets.Npc[NPC.type].Value;
            Vector2 drawOrigin = new Vector2(NPC.width * 0.5f, NPC.height * 0.5f + 17);
            Vector2 temp = NPC.Center-screenPos;
            Main.spriteBatch.Draw(texture, temp, NPC.frame, drawColor, NPC.rotation, drawOrigin, NPC.scale, SpriteEffects.None, 0);
            return false;
        }*/
        public override void AI() {
            Timer++;
            if (Timer < 3) return;
            NPC.alpha = 0;
            NPC main = Main.npc[ZylonGlobalNPC.diskiteBoss];
            if (main.whoAmI < 0 || !main.active) NPC.life = 0;
            NPC.Center = main.Center;// + new Vector2(0, 17).RotatedBy(main.rotation);
            NPC.rotation = main.rotation;
            NPC.velocity = main.velocity;
        }
    }
}