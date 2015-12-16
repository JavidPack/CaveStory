using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
    class MachineGun : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Machine Gun";
            item.toolTip = "Cave Story weapon";

            item.useStyle = 6;
            // item.holdStyle
            //   item.useStyle = 100;
            item.useAnimation = 9;
            item.useTime = 8;
            item.autoReuse = true;
            item.width = 33;
            item.height = 15;
            item.shoot = mod.ProjectileType("MachineGunLv3Shot");
            item.useAmmo = 14;
            item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/MachineGunShoot");
            item.damage = 45;
            item.shootSpeed = 12f; //12
            item.noMelee = true;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.ranged = true;
            item.rare = 8;
            item.knockBack = 3f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (speedX - speedY > 0)
            {
                if (speedX + speedY > 0)
                {
                    speedX = item.shootSpeed;
                    speedY = (Main.rand.NextFloat() - .5f) * 1.4f;
                }
                else
                {
                    speedY = -item.shootSpeed;
                    speedX = (Main.rand.NextFloat() - .5f) * 1f;

                    if (player.gravDir == -1f)
                    {
                        player.velocity.Y += 3.5f;
                        if (player.velocity.Y < 0)
                            player.velocity.Y = 0;
                    }
                }
            }
            else
            {
                if (speedX + speedY > 0)
                {
                    speedY = item.shootSpeed;
                    speedX = (Main.rand.NextFloat() - .5f) * .8f;
                    //
                    if (player.gravDir == 1f)
                    {
                        player.velocity.Y -= 3.5f;
                        if (player.velocity.Y > 0)
                            player.velocity.Y = 0;
                    }
                }
                else
                {
                    speedX = -item.shootSpeed;
                    speedY = (Main.rand.NextFloat() - .5f) * .6f;
                }
            }
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
            int a = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, item.shoot, item.damage, item.knockBack, item.owner, 0f, 0f);
            Main.projectile[a].scale = 2;
            Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();



            int dust = Dust.NewDust(position, 0, 0, mod.DustType( "StarMuzzleFlash"));
            Main.dust[dust].scale = 2;
            Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);

            return false;
        }
        public override void UseStyle(Player player)
        {
            player.itemLocation.X = player.position.X + (float)player.width * 0.5f;// - (float)Main.itemTexture[item.type].Width * 0.5f;// - (float)(player.direction * 2);
            player.itemLocation.Y = player.MountedCenter.Y + player.gravDir * (float)Main.itemTexture[item.type].Height * 0.5f;

            float relativeX = (float)Main.mouseX + Main.screenPosition.X - player.Center.X;
            float relativeY = (float)Main.mouseY + Main.screenPosition.Y - player.Center.Y;
            if (player.gravDir == -1f)
            {
                relativeY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - player.Center.Y;
            }

            if (relativeX - relativeY > 0)
            {
                if (relativeX + relativeY > 0)
                {
                    player.itemRotation = 0;
                }
                else
                {

                    player.itemRotation = player.direction * -MathHelper.Pi / 2;
                    player.itemLocation.X += player.direction * 2;
                    player.itemLocation.Y -= 10;
                }
            }
            else
            {
                if (relativeX + relativeY > 0)
                {
                    player.itemRotation = player.direction * MathHelper.Pi / 2;
                    player.itemLocation.X += player.direction * 2;
					Main.rand.Next(0, 100);
                }
                else
                {
                    player.itemRotation = 0;
                }
            }
			player.itemLocation.X += player.direction * Main.rand.Next(0, 100);
		}

        public override bool UseItemFrame(Player player)
        {
            float num18 = player.itemRotation * (float)player.direction;
            player.bodyFrame.Y = player.bodyFrame.Height * 3;
            if ((double)num18 < -0.75)
            {
                player.bodyFrame.Y = player.bodyFrame.Height * 2;
                if (player.gravDir == -1f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 4;
                }
            }
            if ((double)num18 > 0.6)
            {
                player.bodyFrame.Y = player.bodyFrame.Height * 4;
                if (player.gravDir == -1f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 2;
                }
            }
            return true;
        }

        //public override bool UseItemFrame(Player player)
        //{
        ////    player.itemRotation = 0;

        //    //   Vector2 adjust = new Vector2(player.direction*10, 0);
        //    //  adjust.Y = -5;
        //    Vector2 relative = Main.MouseWorld - player.Center;
        //  //  float relativeX = (float)Main.mouseX + Main.screenPosition.X - player.Center.X;
        // //   float relativeY = (float)Main.mouseY + Main.screenPosition.Y - player.Center.Y;
        // //   if (player.gravDir == -1f)
        //   // {
        //        //    relativeY  = -(float)Main.mouseY + Main.screenPosition.Y - player.Center.Y;
        //        //   relativeY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - player.Center.Y;
        //        //   adjust.Y = 25;
        // //   }

        //    if (relative.X - relative.Y > 0)
        //    {
        //        if (relative.X + relative.Y > 0)
        //        {
        //            player.itemRotation = 0;
        //        }
        //        else
        //        {

        //            player.itemRotation = player.direction * -MathHelper.Pi / 2;
        //                   player.itemLocation.X += player.direction * 8;
        //        }
        //    }
        //    else
        //    {
        //        if (relative.X + relative.Y > 0)
        //        {
        //            player.itemRotation = player.direction * MathHelper.Pi / 2;
        //            //       player.itemLocation += adjust;
        //            player.itemLocation.X += player.direction * 8;
        //        }
        //        else
        //        {
        //            player.itemRotation = 0;
        //        }
        //    }

        //    return true;
        //}

        //public override void UseStyle(Player player)
        //{
        //    player.itemRotation = 0;
        //}
        //    float relativeX = (float)Main.mouseX + Main.screenPosition.X - player.Center.X;
        //    float relativeY = (float)Main.mouseY + Main.screenPosition.Y - player.Center.Y;
        //    if (player.gravDir == -1f)
        //    {
        //        relativeY = -(float)Main.mouseY + Main.screenPosition.Y - player.Center.Y;
        //        //    relativeY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - player.Center.Y;
        //    }

        //    if (relativeX - relativeY > 0)
        //    {
        //        if (relativeX + relativeY > 0)
        //        {
        //            player.itemRotation = 0;
        //        }
        //        else
        //        {

        //            player.itemRotation = player.direction * -MathHelper.Pi / 2;
        //        }
        //    }
        //    else
        //    {
        //        if (relativeX + relativeY > 0)
        //        {
        //            player.itemRotation = player.direction * MathHelper.Pi / 2;
        //        }
        //        else
        //        {
        //            player.itemRotation = 0;
        //        }
        //    }
        //}


        //public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale)
        //{
        //    rotation = 0;
        //    Vector2 value13 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);

        //   // spriteBatch.Draw(Main.itemTexture[item.type], value13, bnull, lightColor,0, );
        //    return false;
        //}

        //public override void HoldStyle(Player player)
        //{
        //    Vector2 value13 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);

        //    if (value13.X > value13.Y)
        //    {
        //        if (value13.X > 0)
        //        {
        //            value13.X = 1;
        //            value13.Y = 0;
        //        }
        //        else
        //        {
        //            value13.Y = -1;
        //            value13.X = 0;
        //        }
        //    }
        //    else
        //    {
        //        if (value13.X > 0)
        //        {
        //            value13.Y = 1;
        //            value13.X = 0;
        //        }
        //        else
        //        {
        //            value13.X = -1;
        //            value13.Y = 0;
        //        }
        //    }

        //    player.itemRotation = value13.ToRotation();
        //}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddCraftGroup(CraftGroup.GetVanillaGroup("IronBar"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
            //recipe.SetResult(Terraria.ID.ItemID.IchorBullet, 999);
            //recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock);
            //recipe.SetResult(mod, "MachineGunExp", 10);
            //recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
            //recipe.SetResult(Terraria.ID.ItemID.GravitationPotion, 10);
            //recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
            //recipe.SetResult(Terraria.ID.ItemID.TeleportationPotion, 10);
            //recipe.AddRecipe();
        }
    }
}
