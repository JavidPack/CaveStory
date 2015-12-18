using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Mounts
{
    //ported from my tAPI mod because I'm lazy
    public class CurlyBrace : ModMountData
    {
        public override void SetDefaults()
        {
            // Dust on Spawn?
            mountData.spawnDust = 56;
            // Buff Applied while in use
			//ErrorLogger.Log("~~" + mountData.buff);
          //  mountData.buff = mod.BuffType("CurlyBraceBuff");//130;
			//ErrorLogger.Log("~~" + mountData.buff);
          //  ErrorLogger.Log("SetDefaults mod.buffType: " + mod.BuffType("CurlyBraceBuff"));
          // mod.BuffType("CurlyBraceBuff");
            // Pixels above ground of mount image while in use?
            // mountData.heightBoost raises the player's hitbox, so if this is left to zero, no raise will happen
            mountData.heightBoost = 0;
            //??
            // I think this enables mount flight, but it should be the wings or any other fight accessory that apply flight, not the mount
            mountData.flightTimeMax = 0;
            //??
            // Might want to make sure the player takes fall damage, because if the player doesn't have wings, he/she will take FD when he/she falls from a high heigh.
            mountData.fallDamage = 0.5f;
            //??
            mountData.runSpeed = 4f;
            mountData.dashSpeed = 4f;
            mountData.acceleration = 0.18f;
            mountData.jumpHeight = 12;
            mountData.jumpSpeed = 8.25f;
            mountData.constantJump = true;
            mountData.totalFrames = 3;
            mountData.blockExtraJumps = false;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 0;
            }
            //    array[1] += 2;
            //   array[3] -= 2;
            // Player offset off ground for each frame. Bounce on saddle.
            mountData.playerYOffsets = array;
            // Mount x offset
            mountData.xOffset = -20;
            mountData.bodyFrame = 3;
            mountData.yOffset = -15;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 1;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 0;
            mountData.idleFrameDelay = 0;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;
            //mountData.abilityChargeMax = 100;
            //mountData.abilityDuration = 10;
            //mountData.abilityCooldown = 20;

            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.backTexture.Width;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }
        //public override bool CustomBodyFrame()
        //{
        //    ErrorLogger.Log("CustomBodyFrame");
        //    // Leave player as is.
        //    return true;
        //}
        public override bool UpdateFrame(Player mountedPlayer, int state, Vector2 velocity)
        {
            float relativeX = (float)Main.mouseX + Main.screenPosition.X - mountedPlayer.Center.X;
            float relativeY = (float)Main.mouseY + Main.screenPosition.Y - mountedPlayer.Center.Y;
            if (mountedPlayer.gravDir == -1f)
            {
                relativeY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - mountedPlayer.Center.Y;
            }


            if (relativeX - relativeY > 0)
            {
                if (relativeX + relativeY > 0)
                {
                    mountedPlayer.mount._frame = 0;
                    mountData.xOffset = -20;
                    mountData.yOffset = -15;
                }
                else
                {
                    if (mountedPlayer.velocity.Y == 0f)
                    {
                        mountedPlayer.mount._frame = 1;
                        mountData.xOffset = 0;
                        mountData.yOffset = -30;
                    }
                    else
                    {
                        mountedPlayer.mount._frame = 2;
                        mountData.xOffset = 0;
                        mountData.yOffset = 20;

                    }
                }
            }
            else
            {
                if (relativeX + relativeY > 0)
                {
                    mountedPlayer.mount._frame = 1;
                    mountData.xOffset = 0;
                    mountData.yOffset = -30;
                }
                else
                {
                    mountedPlayer.mount._frame = 0;
                    mountData.xOffset = -20;
                    mountData.yOffset = -15;
                }
            }
            return false;
        }



        bool used = false;
        public override void UpdateEffects(Player mountedPlayer)
        {
            //        ErrorLogger.Log("UpdateEffects");
            if (/*mountedPlayer.mount.AbilityReady && */mountedPlayer.whoAmI == Main.myPlayer)
            {
                if (mountedPlayer.releaseUseItem)
                {
                    used = false;
                }

                //if(mountedPlayer.jump == 0)
                //    mountedPlayer.mount.

                //mountedPlayer.mount._abilityCharging = false;
                //mountedPlayer.mount._abilityCooldown = this.mountData.abilityCooldown;
                //mountedPlayer.mount._abilityDuration = this.mountData.abilityDuration;
                //mountedPlayer.mount.AbilityReady
                //Mount._abilityCharging = false;
                //Mount._abilityCooldown = Mount._data.abilityCooldown;
                //Mount._abilityDuration = Mount._data.abilityDuration;

                //ErrorLogger.Log("channel " + mountedPlayer.channel);
                if (mountedPlayer.controlUseItem && !used)
                {
                    used = true;
                    Vector2 center = mountedPlayer.Center;
                    //  bool horizontal = false;

                    float relativeX = (float)Main.mouseX + Main.screenPosition.X - mountedPlayer.Center.X;
                    float relativeY = (float)Main.mouseY + Main.screenPosition.Y - mountedPlayer.Center.Y;
                    if (mountedPlayer.gravDir == -1f)
                    {
                        relativeY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - mountedPlayer.Center.Y;
                    }


                    int dir = 0;
                    if (relativeX - relativeY > 0)
                    {
                        if (relativeX + relativeY > 0)
                        {
                            dir = 0;
                            relativeX = 12;
                            relativeY = 0;
                        }
                        else
                        {
                            dir = 3;
                            relativeY = -12;
                            relativeX = 0;
                            if (mountedPlayer.velocity.Y == 0f)
                            {
                                relativeY = -relativeY;
                            }
                        }
                    }
                    else
                    {
                        if (relativeX + relativeY > 0)
                        {
                            dir = 1;
                            relativeY = 12;
                            relativeX = 0;

                            //    position.X += player.direction * 10f * item.scale;
                        }
                        else
                        {
                            dir = 2;
                            relativeX = -12;
                            relativeY = 0;
                        }
                    }
                    center.X += mountData.xOffset;
                    center.Y += mountData.xOffset;

                    relativeX = -relativeX;
                    relativeY = -relativeY;

                    //   position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
                    // I don't see where the knockback(KB) is at, because the mount does too much KB
                    int a = Projectile.NewProjectile(center.X, center.Y, relativeX, relativeY, mod.ProjectileType("NemesisLv3Shot"), 100, 100, Main.myPlayer, 0f, 0f);
                    Main.projectile[a].scale = 2;
                    Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();
                    Main.projectile[a].frame = dir * 2;
                }
            }



        }
    }
}


//     Vector2 vector = center;
//     bool flag = false;
//     float num = 1500f;
//     for (int i = 0; i < 200; i++)
//     {
//         NPC nPC = Main.npc[i];
//         if (nPC.CanBeChasedBy(this, false))
//         {
//             float num2 = Vector2.Distance(nPC.Center, vector);
//             if (((Vector2.Distance(vector, vector) > num2 && num2 < num) || !flag) && Collision.CanHitLine(center, 0, 0, nPC.position, nPC.width, nPC.height))
//             {
//                 num = num2;
//                 vector = nPC.Center;
//                 flag = true;
//             }
//         }
//     }
//     bool flag2 = flag;
//     float num3 = Math.Abs((vector - center).ToRotation());
//     if (mountedPlayer.direction == 1 && (double)num3 > 1.0471975949079879)
//     {
//         flag2 = false;
//     }
//     else if (mountedPlayer.direction == -1 && (double)num3 < 2.0943951461045853)
//     {
//         flag2 = false;
//     }
//     else if (!Collision.CanHitLine(center, 0, 0, vector, 0, 0))
//     {
//         flag2 = false;
//     }
//     if (!flag2)
//     {
////         this._abilityCharging = false;
// //        this.ResetHeadPosition();
//         return;
//     }
//     //    if (this._abilityCooldown == 0 && mountedPlayer.whoAmI == Main.myPlayer)
//    {
//this.AimAbility(mountedPlayer, vector);
//this.StopAbilityCharge();
//this.UseAbility(mountedPlayer, vector, false);
//return;
//    }
//    this.AimAbility(mountedPlayer, vector);
// this._abilityCharging = true;
