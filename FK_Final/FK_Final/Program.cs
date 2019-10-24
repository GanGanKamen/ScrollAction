using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FK_CLI;

namespace FK_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            fk_Material.InitDefault();
            var window = new fk_AppWindow();
            window.CameraPos = new fk_Vector(0.0, 10.0, 50.0);
            window.CameraFocus = new fk_Vector(0.0, 0.0, 0.0);
            window.Size = new fk_Dimension(800, 600);
            window.BGColor = new fk_Color(0.6, 0.7, 0.8);

            

            var floor = new fk_Model();
            var floorshape = new fk_Block(130.0, 2.0, 10.0);
            floor.Shape = floorshape;
            floor.Material = fk_Material.Brown;
            window.Entry(floor);
            
            var player = new fk_Model();
            player.SmoothMode = true;
            player.BMode = fk_BoundaryMode.OBB;
            player.OBB = new fk_Vector(0.6, 2.6, 0.5);
            player.BDraw = true;
            window.Entry(player);

            var body = new fk_Model();
            var bodyShape = new fk_Prism(20, 0.5, 0.5, 2.0);
            body.Shape = bodyShape;
            body.Parent = player;
            body.Material = fk_Material.Gray2;
            window.Entry(body);

            var head = new fk_Model();
            var headShape = new fk_Sphere(10, 0.5);
            head.Shape = headShape;
            head.Material = fk_Material.White;
            head.GlMoveTo(0.0, 0.0, -2.5);
            head.Parent = body;
            window.Entry(head);

            
            var tube = new fk_Model[6];
            var tubeShape = new fk_Prism(20, 1.0, 1.0, 4.5);

            for (int a = 0; a < 4; a++)
            {
                tube[a] = new fk_Model();
                tube[a].Shape = tubeShape;
                tube[a].Material = fk_Material.Green;
                tube[a].GlVec(0.0, 1.0, 0.0);

                window.Entry(tube[a]);
            }

            var needle = new fk_Model[6];
            var needleShape = new fk_Cone(30, 0.5, 3.0);

            for(int b = 0; b < 6; b++)
            {
                needle[b] = new fk_Model();
                needle[b].Shape = needleShape;
                needle[b].Material = fk_Material.Red;
                needle[b].GlVec(0.0, 1.0, 0.0);
                needle[b].SmoothMode = true;
                needle[b].BMode = fk_BoundaryMode.OBB;
                needle[b].AdjustOBB();
                needle[b].BDraw = false;

                window.Entry(needle[b]);
            }

            var enemy = new fk_Model[9];
            var enemyShape = new fk_Sphere(10, 1.0);

            for (int i = 0; i < 9; i++)
            {
                enemy[i] = new fk_Model();
                enemy[i].Shape = enemyShape;
                enemy[i].Material = fk_Material.Pink;
                enemy[i].SmoothMode = true;
                enemy[i].BMode = fk_BoundaryMode.OBB;
                enemy[i].AdjustOBB();
                enemy[i].BDraw = false;

                window.Entry(enemy[i]);
            }

            var enemy0 = new fk_Model[3];
            for(int x = 0; x < 3; x++)
            {
                enemy0[x] = new fk_Model();
                enemy0[x].Shape = enemyShape;
                enemy0[x].Material = fk_Material.Purple;
                enemy0[x].SmoothMode = true;
                enemy0[x].BMode = fk_BoundaryMode.OBB;
                enemy0[x].AdjustOBB();
                enemy0[x].BDraw = false;

                window.Entry(enemy0[x]);
            }

            var enemy1 = new fk_Model[3];
            for(int y = 0; y < 3; y++)
            {
                enemy1[y] = new fk_Model();
                enemy1[y].Shape = enemyShape;
                enemy1[y].Material = fk_Material.Yellow;
                enemy1[y].SmoothMode = true;
                enemy1[y].BMode = fk_BoundaryMode.OBB;
                enemy1[y].AdjustOBB();
                enemy1[y].BDraw = false;

                window.Entry(enemy1[y]);

            }

            var velocity0 = new fk_Vector(-0.15, 0.2, 0.0);
            var velocity1 = new fk_Vector(-0.1, 0.3, 0.0);
            var velocity2 = new fk_Vector(-0.15, 0.2, 0.0);
            var velocity3 = new fk_Vector(-0.1, 0.3, 0.0);
            var velocity4 = new fk_Vector(-0.5, 0.2, 0.0);
            var velocity5 = new fk_Vector(-0.15, 0.3, 0.0);
            var velocity6 = new fk_Vector(-0.15, 0.3, 0.0);
            var velocity7 = new fk_Vector(-0.5, 0.3, 0.0);
            var velocity8 = new fk_Vector(-0.5, 0.3, 0.0);
            var velocity00 = new fk_Vector(0.25, 0.0, 0.0);
            var velocity10 = new fk_Vector(0.0, -0.3, 0.0);

            var camera = new fk_Model();
            window.CameraModel = camera;
            camera.GlMoveTo(-10.0, 6.0, 50.0);

            var sprite = new fk_SpriteModel();
            if (sprite.InitFont("rm1b.ttf") == false)
            {
                Console.WriteLine("Font Init Error");
            }
            window.Entry(sprite);
            
            var gate = new fk_Model();
            var gateshape = new fk_Block(1.5, 3.0, 0.0);
            gate.Shape = gateshape;
            gate.Material = fk_Material.Cream;
            window.Entry(gate);

            var goal = new fk_Model();
            goal.Shape = gateshape;
            goal.Material = fk_Material.Blue;
            window.Entry(goal);

            floor.GlMoveTo(25.0, -1.0, 0.0);
            goal.GlMoveTo(86.0, 1.5, 0.0);
            player.GlMoveTo(-20.0, 0.0, 0.0);
            body.GlVec(0.0, 1.0, 0.0);
            gate.GlMoveTo(-20.0, 1.5, 0.0);

            enemy[0].GlMoveTo(30, 0.5, 0.0);
            enemy[1].GlMoveTo(80, 0.5, 0.0);
            enemy[2].GlMoveTo(130, 0.5, 0.0);
            enemy[3].GlMoveTo(140, 0.5, 0.0);
            enemy[4].GlMoveTo(160, 0.5, 0.0);
            enemy[5].GlMoveTo(190, 0.5, 0.0);
            enemy[6].GlMoveTo(200, 0.5, 0.0);
            enemy[7].GlMoveTo(280, 0.5, 0.0);
            enemy[8].GlMoveTo(340, 0.5, 0.0);

            tube[0].GlMoveTo(20.0, 0.0, -2.0);
            tube[1].GlMoveTo(40.0, 0.0, -2.0);
            tube[2].GlMoveTo(60.0, 0.0, -2.0);
            tube[3].GlMoveTo(80.0, 0.0, -2.0);

            enemy0[0].GlMoveTo(-50, 0.5, 0.0);
            enemy0[1].GlMoveTo(-100, 0.5, 0.0);
            enemy0[2].GlMoveTo(-150, 0.5, 0.0);

            enemy1[0].GlMoveTo(45, 26.0, 0.0);
            enemy1[1].GlMoveTo(60, 26.0, 0.0);
            enemy1[2].GlMoveTo(70, 26.0, 0.0);

            needle[0].GlMoveTo(-10, 0.0, 0.0);
            needle[1].GlMoveTo(5, 0.0, 0.0);
            needle[2].GlMoveTo(25, 0.0, 0.0);
            needle[3].GlMoveTo(50, 0.0, 0.0);
            needle[4].GlMoveTo(70, 0.0, 0.0);
            needle[5].GlMoveTo(73, 0.0, 0.0);



            var velocity = new fk_Vector(0.0, 0.2, 0.0);

            var bgm = new GP_BGM("Shissou.ogg");
            bgm.Gain = 0.5;
            var se = new GP_SE(1);
            se.LoadData(0, "MIDTOM2.wav");

            window.Open();
            bgm.Start();
            se.Start();

            int life = 3;
            
            bool oldCrash0 = false;
            bool nowCrash0 = false;
            bool oldCrash1 = false;
            bool nowCrash1 = false;
            bool oldCrash2 = false;
            bool nowCrash2 = false;
            bool oldCrash3 = false;
            bool nowCrash3 = false;
            bool oldCrash4 = false;
            bool nowCrash4 = false;
            bool oldCrash5 = false;
            bool nowCrash5 = false;
            bool oldCrash6 = false;
            bool nowCrash6 = false;
            bool oldCrash7 = false;
            bool nowCrash7 = false;
            bool oldCrash8 = false;
            bool nowCrash8 = false;

            bool oldCrash00 = false;
            bool nowCrash00 = false;
            bool oldCrash01 = false;
            bool nowCrash01 = false;
            bool oldCrash02 = false;
            bool nowCrash02 = false;

            bool oldCrashN0 = false;
            bool nowCrashN0 = false;
            bool oldCrashN1 = false;
            bool nowCrashN1 = false;
            bool oldCrashN2 = false;
            bool nowCrashN2 = false;
            bool oldCrashN3 = false;
            bool nowCrashN3 = false;
            bool oldCrashN4 = false;
            bool nowCrashN4 = false;
            bool oldCrashN5 = false;
            bool nowCrashN5 = false;

            bool oldCrash11 = false;
            bool nowCrash11 = false;
            bool oldCrash12 = false;
            bool nowCrash12 = false;
            bool oldCrash10 = false;
            bool nowCrash10 = false;

            while (window.Update() == true)
            {
                string str = "残りライフ       " + life.ToString();
                sprite.DrawText(str, true);
                sprite.SetPositionLT(-400.0, 300.0);

                if (life == 0)
                {
                    player.GlMoveTo(-20.0, 0.0, 0.0);
                    camera.GlMoveTo(-10.0, 6.0, 50.0);
                    enemy[0].GlMoveTo(30, 0.5, 0.0);
                    enemy[1].GlMoveTo(80, 0.5, 0.0);
                    enemy[2].GlMoveTo(130, 0.5, 0.0);
                    enemy[3].GlMoveTo(140, 0.5, 0.0);
                    enemy[4].GlMoveTo(160, 0.5, 0.0);
                    enemy[5].GlMoveTo(190, 0.5, 0.0);
                    enemy[6].GlMoveTo(200, 0.5, 0.0);
                    enemy[7].GlMoveTo(280, 0.5, 0.0);
                    enemy[8].GlMoveTo(340, 0.5, 0.0);
                    enemy0[0].GlMoveTo(-50, 0.5, 0.0);
                    enemy0[1].GlMoveTo(-100, 0.5, 0.0);
                    enemy0[2].GlMoveTo(-150, 0.5, 0.0);
                    enemy1[0].GlMoveTo(45, 26.0, 0.0);
                    enemy1[1].GlMoveTo(60, 26.0, 0.0);
                    enemy1[2].GlMoveTo(70, 26.0, 0.0);
                    life += 2;
                }
               
                var pos = player.Position;
                if (pos.x < 86.0)
                {
                    if (-20.0 < pos.x)
                    {
                        if (pos.y > 0.0)
                        {
                            velocity.y -= 0.003;
                        }
                        else
                        {
                            velocity.y = 0.0;
                            if (window.GetKeyStatus(' ', fk_SwitchStatus.PRESS) == true)
                            {
                                velocity.y = 0.2;
                            }
                        }
                        if (window.GetSpecialKeyStatus(fk_SpecialKey.LEFT, fk_SwitchStatus.PRESS) == true)
                        {
                            player.LoTranslate(-0.07, 0.0, 0.0);
                            camera.LoTranslate(-0.07, 0.0, 0.0);
                        }
                        if (window.GetSpecialKeyStatus(fk_SpecialKey.RIGHT, fk_SwitchStatus.PRESS) == true)
                        {
                            player.LoTranslate(0.07, 0.0, 0.0);
                            camera.LoTranslate(0.07, 0.0, 0.0);
                        }
                    }
                    else if (-20.0 >= pos.x)
                    {
                        if (pos.y > 0.0)
                        {
                            velocity.y -= 0.003;
                        }
                        else
                        {
                            velocity.y = 0.0;
                            if (window.GetKeyStatus(' ', fk_SwitchStatus.PRESS) == true)
                            {
                                velocity.y = 0.2;
                            }
                            if (window.GetSpecialKeyStatus(fk_SpecialKey.RIGHT, fk_SwitchStatus.PRESS) == true)
                            {
                                player.LoTranslate(0.1, 0.0, 0.0);
                                camera.LoTranslate(0.1, 0.0, 0.0);
                            }
                        }
                    }
                    player.GlTranslate(velocity);
                }
                else
                {
                    player.GlMoveTo(86.0, 0.0, 0.0);
                }
               
                if (pos.x >= 40.0)
                {
                    enemy1[0].GlTranslate(velocity10);
                }
                        
                nowCrash10 = player.IsInter(enemy1[0]);
                if (nowCrash10 == true && oldCrash10 == false)
                {
                    life -= 1;
                }
                oldCrash10 = nowCrash10;

                if (pos.x >= 55.0)
                {
                    enemy1[1].GlTranslate(velocity10);
                }
                nowCrash11 = player.IsInter(enemy1[1]);
                if (nowCrash11 == true && oldCrash11 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash11 = nowCrash11;

                if (pos.x >= 65.0)
                {
                    enemy1[2].GlTranslate(velocity10);
                }
                nowCrash12 = player.IsInter(enemy1[2]);
                if (nowCrash12 == true && oldCrash12 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash12 = nowCrash12;



                var pos0 = enemy[0].Position;
               
                    if (pos0.y > 0.0)
                    {
                        velocity0.y -= 0.003;
                    }
                    else
                    {
                        velocity0.y = 0.3;

                    }


                    enemy[0].GlTranslate(velocity0);
                
                
                nowCrash0 = player.IsInter(enemy[0]);
                if (nowCrash0 == true && oldCrash0 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash0 = nowCrash0;
                
                    var pos1 = enemy[1].Position;
                if (pos1.y > 0.0)
                {
                    velocity1.y -= 0.003;
                }
                else
                {
                    velocity1.y = 0.3;

                }
                enemy[1].GlTranslate(velocity1);

                nowCrash1 = player.IsInter(enemy[1]);
                if (nowCrash1 == true && oldCrash1 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash1 = nowCrash1;

                var pos2 = enemy[2].Position;
                if (pos2.y > 0.0)
                {
                    velocity2.y -= 0.003;
                }
                else
                {
                    velocity2.y = 0.3;

                }
                enemy[2].GlTranslate(velocity2);

                nowCrash2 = player.IsInter(enemy[2]);
                if (nowCrash2 == true && oldCrash2 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash2 = nowCrash2;

                var pos3 = enemy[3].Position;
                if (pos3.y > 0.0)
                {
                    velocity3.y -= 0.003;
                }
                else
                {
                    velocity3.y = 0.3;

                }
                enemy[3].GlTranslate(velocity3);

                nowCrash3 = player.IsInter(enemy[3]);
                if (nowCrash3 == true && oldCrash3 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash3 = nowCrash3;

                var pos4 = enemy[4].Position;
                if (pos4.y > 0.0)
                {
                    velocity4.y -= 0.003;
                }
                else
                {
                    velocity4.y = 0.3;

                }
                enemy[4].GlTranslate(velocity4);

                nowCrash4 = player.IsInter(enemy[4]);
                if (nowCrash4 == true && oldCrash4 == false)
                {
                    life -= 1;
                }
                oldCrash4 = nowCrash4;

                var pos5 = enemy[5].Position;
                if (pos5.y > 0.0)
                {
                    velocity5.y -= 0.003;
                }
                else
                {
                    velocity5.y = 0.3;

                }
                enemy[5].GlTranslate(velocity5);

                nowCrash5 = player.IsInter(enemy[5]);
                if (nowCrash5 == true && oldCrash5 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash5 = nowCrash5;

                var pos6 = enemy[6].Position;
                if (pos6.y > 0.0)
                {
                    velocity6.y -= 0.003;
                }
                else
                {
                    velocity6.y = 0.3;

                }
                enemy[6].GlTranslate(velocity6);

                nowCrash6 = player.IsInter(enemy[6]);
                if (nowCrash6 == true && oldCrash6 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash6 = nowCrash6;

                var pos7 = enemy[7].Position;
                if (pos7.y > 0.0)
                {
                    velocity7.y -= 0.003;
                }
                else
                {
                    velocity7.y = 0.3;

                }
                enemy[7].GlTranslate(velocity7);

                nowCrash7 = player.IsInter(enemy[7]);
                if (nowCrash7 == true && oldCrash7 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash7 = nowCrash7;

                var pos8 = enemy[8].Position;
                if (pos8.y > 0.0)
                {
                    velocity8.y -= 0.003;
                }
                else
                {
                    velocity8.y = 0.3;

                }
                enemy[8].GlTranslate(velocity8);

                nowCrash8 = player.IsInter(enemy[8]);
                if (nowCrash8 == true && oldCrash8 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash8 = nowCrash8;

                var pos00 = enemy0[0].Position;
                enemy0[0].GlTranslate(velocity00);

                nowCrash00 = player.IsInter(enemy0[0]);
                if (nowCrash00 == true && oldCrash00 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash00 = nowCrash00;

                var pos01 = enemy0[1].Position;
                enemy0[1].GlTranslate(velocity00);

                nowCrash01 = player.IsInter(enemy0[1]);
                if (nowCrash01 == true && oldCrash01 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash01 = nowCrash01;

                var pos02 = enemy0[2].Position;
                enemy0[2].GlTranslate(velocity00);

                nowCrash02 = player.IsInter(enemy0[2]);
                if (nowCrash02 == true && oldCrash02 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrash02 = nowCrash02;

                nowCrashN0 = player.IsInter(needle[0]);
                if (nowCrashN0 == true && oldCrashN0 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrashN0 = nowCrashN0;

                nowCrashN1 = player.IsInter(needle[1]);
                if (nowCrashN1 == true && oldCrashN1 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrashN1 = nowCrashN1;

                nowCrashN2 = player.IsInter(needle[2]);
                if (nowCrashN2 == true && oldCrashN2 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrashN2 = nowCrashN2;

                nowCrashN3 = player.IsInter(needle[3]);
                if (nowCrashN3 == true && oldCrashN3 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrashN3 = nowCrashN3;

                nowCrashN4 = player.IsInter(needle[4]);
                if (nowCrashN4 == true && oldCrashN4 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrashN4 = nowCrashN4;

                nowCrashN5 = player.IsInter(needle[5]);
                if (nowCrashN5 == true && oldCrashN5 == false)
                {
                    se.StartSE(0);
                    life -= 1;
                }
                oldCrashN5 = nowCrashN5;
            }

            
            bgm.StopStatus = true;
            se.StopStatus = true;
        }
    }
}
    