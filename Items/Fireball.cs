using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
    class Fireball : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fireball";
            item.toolTip = "Cave Story weapon, level up by collecting Fireball Exps";

            item.useStyle = 6;
            item.useAnimation = 9;
            item.useTime = 8;
        //    item.autoReuse = true;
            item.width = 33;
            item.height = 15;
            item.shoot = mod.ProjectileType("FireballLv3Shot");
            item.useAmmo = 14;
            item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/FireballSound");
            //  ErrorLogger.Log("~" + item.shoot);
            item.damage = 45;
            item.shootSpeed = 4f; //12
            item.noMelee = true;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.ranged = true;
            item.rare = 8;
            item.knockBack = 3f;
        }

        public override bool CanUseItem(Player player)
        {
            int level = CurrentLevel(player);
            if (level == 1 && player.ownedProjectileCounts[mod.ProjectileType("FireballLv1Shot")] < 2)
                return true;
            if (level == 2 && player.ownedProjectileCounts[mod.ProjectileType("FireballLv2Shot")] < 3)
                return true;
            if (level == 3 && player.ownedProjectileCounts[mod.ProjectileType("FireballLv3Shot")] < 4)
                return true;


            return false;
        }

        // Shoot: aim up: small in facing + player velocity
        // Down: player velovity
        // left right: large
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //ErrorLogger.Log("levels ");
            int level = CurrentLevel(player);
            //ErrorLogger.Log("level " + level);


            if (level == 1)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("FireballLv1Shot")] < 2)
                {
                    // if Right or up
                    if (speedX - speedY > 0)
                    {
                        //Right
                        if (speedX + speedY > 0)
                        {
                            speedX = item.shootSpeed + player.velocity.X;
                            speedY = -item.shootSpeed / 2;
                        }
                        //up
                        else
                        {
                            speedY = -item.shootSpeed;
                            if (player.direction == 1)
                            {
                                speedX = player.velocity.X + item.shootSpeed / 4;
                            }
                            else
                            {
                                speedX = player.velocity.X - item.shootSpeed / 4;
                            }
                        }
                    }
                    // Left or down
                    else
                    {
                        //down
                        if (speedX + speedY > 0)
                        {
                            position.Y += 1 * 40f * item.scale;
                            position.X += player.direction * 10f * item.scale;
                            speedY = item.shootSpeed;
                            speedX = player.velocity.X;
                        }
                        // Left
                        else
                        {
                            speedX = -item.shootSpeed + player.velocity.X;
                            speedY = -item.shootSpeed / 2;
                        }
                    }
                    //  position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
                    int a = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FireballLv1Shot"), item.damage, item.knockBack, item.owner, 0f, 0f);
                    Main.projectile[a].scale = 2;
                    Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();



                    int dust = Dust.NewDust(position, 0, 0, mod.DustType( "StarMuzzleFlash"));
                    Main.dust[dust].scale = 2;
                    Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);
                }
            }
            else if (level == 2)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("FireballLv2Shot")] < 3)
                {
                    // if Right or up
                    if (speedX - speedY > 0)
                    {
                        //Right
                        if (speedX + speedY > 0)
                        {
                            speedX = item.shootSpeed + player.velocity.X;
                            speedY = -item.shootSpeed / 2;
                        }
                        //up
                        else
                        {
                            speedY = -item.shootSpeed;
                            if (player.direction == 1)
                            {
                                speedX = player.velocity.X + item.shootSpeed / 4;
                            }
                            else
                            {
                                speedX = player.velocity.X - item.shootSpeed / 4;
                            }
                        }
                    }
                    // Left or down
                    else
                    {
                        //down
                        if (speedX + speedY > 0)
                        {
                            position.Y += 1 * 40f * item.scale;
                            position.X += player.direction * 10f * item.scale;
                            speedY = item.shootSpeed;
                            speedX = speedX = player.velocity.X;
                        }
                        // Left
                        else
                        {
                            speedX = -item.shootSpeed + player.velocity.X;
                            speedY = -item.shootSpeed / 2;
                        }
                    }
                    //  position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
                    int a = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FireballLv2Shot"), item.damage, item.knockBack, item.owner, 0f, 0f);
                    Main.projectile[a].scale = 2;
                    Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();



                    int dust = Dust.NewDust(position, 0, 0, mod.DustType( "StarMuzzleFlash"));
                    Main.dust[dust].scale = 2;
                    Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);
                }
            }
            else
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("FireballLv3Shot")] < 4)
                {
                    // if Right or up
                    if (speedX - speedY > 0)
                    {
                        //Right
                        if (speedX + speedY > 0)
                        {
                            position.X += 1 * 40f * item.scale;
                            position.Y -= 10f * item.scale;
                            speedX = item.shootSpeed + player.velocity.X;
                            speedY = -item.shootSpeed / 2;
                        }
                        //up
                        else
                        {
                            position.Y -= 1 * 40f * item.scale;
                            position.X += player.direction * 10f * item.scale;
                            speedY = -item.shootSpeed;
                            if (player.direction == 1)
                            {
                                speedX = player.velocity.X + item.shootSpeed / 4;
                            }
                            else
                            {
                                speedX = player.velocity.X - item.shootSpeed / 4;
                            }
                        }
                    }
                    // Left or down
                    else
                    {
                        //down
                        if (speedX + speedY > 0)
                        {
                            position.Y += 1 * 40f * item.scale;
                            position.X += player.direction * 10f * item.scale;
                            speedY = item.shootSpeed;
                            speedX = player.velocity.X;
                        }
                        // Left
                        else
                        {
                            position.X -= 1 * 40f * item.scale;
                            position.Y -= 10f * item.scale;
                            speedX = -item.shootSpeed + player.velocity.X;
                            speedY = -item.shootSpeed / 2;
                        }
                    }
                    //  position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
                    int a = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FireballLv3Shot"), item.damage, item.knockBack, item.owner, 0f, 0f);
                    Main.projectile[a].scale = 2;
                    Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();



                    int dust = Dust.NewDust(position, 0, 0, mod.DustType( "StarMuzzleFlash"));
                    Main.dust[dust].scale = 2;
                    Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);
                }
            }

            return false;
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
                    player.itemLocation.X += player.direction * 6;
                    player.itemLocation.Y -= 10;
                }
            }
            else
            {
                if (relativeX + relativeY > 0)
                {
                    player.itemRotation = player.direction * MathHelper.Pi / 2;
                    player.itemLocation.X += player.direction * 6;
                }
                else
                {
                    player.itemRotation = 0;
                }
            }
        }

        //public override bool UseItemFrame(Player player)
        //{
        //    Vector2 relative = Main.MouseWorld - player.Center;
        //    if (relative.X - relative.Y > 0)
        //    {
        //        if (relative.X + relative.Y > 0)
        //        {
        //            player.itemRotation = 0;
        //        }
        //        else
        //        {

        //            player.itemRotation = player.direction * -MathHelper.Pi / 2;
        //            player.itemLocation.X += player.direction * 8;
        //        }
        //    }
        //    else
        //    {
        //        if (relative.X + relative.Y > 0)
        //        {
        //            player.itemRotation = player.direction * MathHelper.Pi / 2;
        //            player.itemLocation.X += player.direction * 8;
        //        }
        //        else
        //        {
        //            player.itemRotation = 0;
        //        }
        //    }

        //    return true;
        //}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddCraftGroup(CraftGroup.GetVanillaGroup("IronBar"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock);
            //recipe.SetResult(mod, "FireballExp", 10);
            //recipe.AddRecipe();
        }

        private int CurrentLevel(Player player)
        {
            int num = 0;
            if (player.HasItem(mod.ItemType("FireballExp")))
            {
                for (int i = 0; i < player.inventory.GetLength(0); i++)
                {
                    if (player.inventory[i].type == mod.ItemType("FireballExp"))
                    {
                        num += 1 * player.inventory[i].stack;
                    }
                }
            }
            if (num >= 40)
            {
                return 3;
            }
            else if (num >= 20)
            {
                return 2;
            }
            else
                return 1;
        }
    }
}
