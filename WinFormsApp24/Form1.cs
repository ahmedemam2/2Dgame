using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp24
{
    public partial class Form1 : Form
    {
        public class Hero
        {
            public int X, Y, speed;
            public Bitmap heroimg;
        }
        public class images
        {
            public int ch, X, Y, xDirr, W = 10;
            public Bitmap all;
        }
        public class villains
        {
            public int X, Y;
            public Bitmap evil;
        }
        Rectangle Rsrc;
        Rectangle Rdest;
        Bitmap off;
        Bitmap img;
        public Graphics gf;
        public Random R1;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            
            tt.Tick += Tt_Tick;
            tt.Start();
        }
        Timer tt = new Timer();
        List<Hero> heroes = new List<Hero>();
        List<images> imgs = new List<images>();
        List<images> imgs2 = new List<images>();
        List<images> run = new List<images>();
        List<images> attack = new List<images>();
        List<images> attack2 = new List<images>();
        List<images> bullets = new List<images>();
        List<images> bulletsL = new List<images>();
        List<images> ladders = new List<images>();
        List<images> road1 = new List<images>();
        List<images> road2 = new List<images>();
        List<images> Boss = new List<images>();
        List<images> Gurreillas = new List<images>();
        List<images> Zombies = new List<images>();
        List<images> Zombies2 = new List<images>();
        List<images> Monsterpic = new List<images>();
        List<images> Bossbuls = new List<images>();
        List<images> Dead = new List<images>();
        List<images> jump = new List<images>();
        List<images> jumpL = new List<images>();
        Bitmap gg = new Bitmap("GG.jpg");
        public int mod = 600, zx2 = 1000, flag = 0, check = 0, where, ct = 0, ii = 0, HH, iiL = 0, ctIdle = 0, iidle = 0, iidle2 = 0, ctatt = 1, iatt = 0, dir, ibullet = 0,
            flagk = 0, attct = 0, iup = 0, ctcl = 0, ihh = 0, ctG = 0, chi = 12, w = 10, chch, die = 0, die2 = 0, bbmove = 0, bbmove2 = 0, ctover = 0,
            ctover2 = 0, jumpy, jumpi = 0, ctjump = 0, flagj = 0, cw = 0, Gct = 0, ctgover = 0;
        public Boolean isclimb = false, isDead, isDead1, hDead = false, GameOver = false, isjump = false, Gdead = false, Gdead2 = false;


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            flag = 0;
            if (heroes[0].Y < road1[0].Y + 100 && heroes[0].Y > road2[0].Y)
            {
                isDead = true;


            }
            if (heroes[0].Y < road2[0].Y + 40)
            {

                isDead1 = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*cheat*/
            if (e.KeyCode == Keys.D2)
            {
                heroes[0].Y -= 100;
            }
            if (e.KeyCode == Keys.D3)
            {
                heroes[0].Y += 100;
            }
            if (e.KeyCode == Keys.D1)
            {
                for (int wa = 0; wa < Zombies2.Count; wa++)
                {
                    Zombies2.RemoveAt(wa);
                }
                for (int wa = 0; wa < Zombies.Count; wa++)
                {
                    Zombies.RemoveAt(wa);
                }
            }
            if (heroes[0].Y < road1[0].Y && heroes[0].Y > road2[0].Y)
            {
                isDead = true;

            }
            if (heroes[0].Y < road2[0].Y + 40)
            {

                isDead1 = true;
            }
            flag = 1;
            if (e.KeyCode == Keys.D5)
            {
                if (isjump == false)
                {
                    heroes[0].heroimg = jump[jumpi].all;
                    jumpy = heroes[0].Y;
                    isjump = true;
                    jumpi++;
                }
            }
            if (e.KeyCode == Keys.Space && isclimb == false)
            {

                if (check == 1)
                {
                    dir = 1;
                    iatt = 0;
                }
                if (check == 2)
                {
                    dir = 2;
                    iatt = 6;
                    chch = 2;
                }
                check = 10;
            }
            if (e.KeyCode == Keys.Down)
            {
                int n = 5, w, h;
                if (heroes[0].X < ladders[0].all.Width + ladders[0].X - 155 && heroes[0].X > ladders[0].X + 80 && heroes[0].Y <= ladders[0].Y + 150
                    || heroes[0].X >= ladders[1].all.Width && heroes[0].X < ladders[1].all.Width + ladders[1].X && heroes[0].Y >= ladders[1].Y+ladders[1].all.Height)//condition if 2nd floor or fist floor
                {

                    images pnn = new images();
                    if (iup == 0)
                    {
                        pnn.all = new Bitmap("Climb0.bmp");
                        pnn.ch = 0;
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }

                    if (iup == 1)
                    {
                        pnn.all = new Bitmap("Climb1.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 2)
                    {
                        pnn.all = new Bitmap("Climb2.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 3)
                    {
                        pnn.all = new Bitmap("Climb3.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 4)
                    {
                        pnn.all = new Bitmap("Climb4.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 5)
                    {
                        pnn.all = new Bitmap("Climb5.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 6)
                    {
                        pnn.all = new Bitmap("Climb6.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 7)
                    {
                        pnn.all = new Bitmap("Climb7.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 8)
                    {
                        pnn.all = new Bitmap("Climb8.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                        iup = 0;
                    }
                    iup++;
                    heroes[0].Y += 5;
                }
            }
            if (e.KeyCode == Keys.Up)
            {

                if (heroes[0].X < ladders[0].all.Width + ladders[0].X - 155 && heroes[0].X > ladders[0].X + 80 && heroes[0].Y <= ladders[0].Y + 150 &&
                    ladders[0].all.Height + 60 <= heroes[0].Y || heroes[0].X >= ladders[1].X && heroes[0].X-10 < ladders[1].X+ladders[1].all.Width
                    &&heroes[0].Y <=ladders[1].Y+ladders[1].all.Height&&heroes[0].Y>60)
                {

                    isclimb = true;

                    check = 5;/*e2fel el shooting hena*/
                    int n = 5, w, h;
                    images pnn = new images();
                    if (iup == 0)
                    {
                        pnn.all = new Bitmap("Climb0.bmp");
                        pnn.ch = 0;
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 1)
                    {
                        pnn.all = new Bitmap("Climb1.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 2)
                    {
                        pnn.all = new Bitmap("Climb2.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 3)
                    {
                        pnn.all = new Bitmap("Climb3.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 4)
                    {
                        pnn.all = new Bitmap("Climb4.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 5)
                    {
                        pnn.all = new Bitmap("Climb5.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 6)
                    {
                        pnn.all = new Bitmap("Climb6.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 7)
                    {
                        pnn.all = new Bitmap("Climb7.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                    }
                    if (iup == 8)
                    {
                        pnn.all = new Bitmap("Climb8.bmp");
                        w = pnn.all.Width / n;
                        h = pnn.all.Height / n;
                        pnn.all = new Bitmap(pnn.all, new Size(w, h));
                        pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                        heroes[0].heroimg = pnn.all;
                        iup = 0;

                    }
                    iup++;
                    heroes[0].Y -= 5;


                }
                else
                {
                    isclimb = false;
                }
            }
            if (e.KeyCode == Keys.Right && isclimb == false)
            {
                ctcl = 0;
                flagj = 1;
                dir = check;
                check = 1;
                int n = 5, w, h;
                images pnn = new images();
                if (ii == 0)
                {
                    pnn.all = new Bitmap("run0.bmp");
                    pnn.ch = 0;
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    heroes[0].heroimg = pnn.all;
                }
                if (ii == 1)
                {
                    pnn.all = new Bitmap("run1.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    heroes[0].heroimg = pnn.all;
                }
                if (ii == 2)
                {
                    pnn.all = new Bitmap("run2.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    heroes[0].heroimg = pnn.all;
                }
                if (ii == 3)
                {
                    pnn.all = new Bitmap("run3.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                if (ii == 4)
                {
                    pnn.all = new Bitmap("run4.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                if (ii == 5)
                {
                    pnn.all = new Bitmap("run5.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                if (ii == 6)
                {
                    pnn.all = new Bitmap("run6.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                heroes[0].X += 10;
                ii++;
                if (ii > 6)
                {
                    ii = 0;
                }
            }
            if (e.KeyCode == Keys.Left && isclimb == false)
            {
                ctcl = 0;
                flagj = 2;
                dir = check;
                check = 2;
                int n = 5, w, h;
                images pnn = new images();
                if (iiL == 0)
                {
                    pnn.all = new Bitmap("runopp0.bmp");
                    pnn.ch = 0;
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    heroes[0].heroimg = pnn.all;
                }
                if (iiL == 1)
                {
                    pnn.all = new Bitmap("runopp1.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    heroes[0].heroimg = pnn.all;
                }
                if (iiL == 2)
                {
                    pnn.all = new Bitmap("runopp2.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    heroes[0].heroimg = pnn.all;
                }
                if (iiL == 3)
                {
                    pnn.all = new Bitmap("runopp3.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                if (iiL == 4)
                {
                    pnn.all = new Bitmap("runopp4.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                if (iiL == 5)
                {
                    pnn.all = new Bitmap("runopp5.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                if (iiL == 6)
                {
                    pnn.all = new Bitmap("runopp6.bmp");
                    w = pnn.all.Width / n;
                    h = pnn.all.Height / n;
                    pnn.all = new Bitmap(pnn.all, new Size(w, h));
                    pnn.all.MakeTransparent(pnn.all.GetPixel(0, 0));
                    run.Add(pnn);
                    heroes[0].heroimg = pnn.all;
                }
                heroes[0].X -= 10;
                iiL++;
                if (iiL > 6)
                {
                    iiL = 0;
                }
            }

        }
        private void Tt_Tick(object sender, EventArgs e)
        {
            if(Gdead2==true)
            {
                ctgover++;
                if(ctgover==2)
                Gdead = true;
            }
            if (Rdest.X > img.Width - 100)
            {
                Rdest.X = 0;
                Rdest.Y += 300;
            }
            else
            //game over
            {
                //game
                //over
                Rdest.X += 30;
            }

            if (isjump == true)
            {
                if (flagj == 1)
                {
                    if (ctjump < 4)
                    {
                        heroes[0].Y -= 40;
                        heroes[0].X += 25;
                        heroes[0].heroimg = jump[jumpi].all;
                        jumpi++;
                        ctjump++;
                    }
                    if (ctjump >= 4 && ctjump < 8)
                    {
                        heroes[0].Y += 40;
                        heroes[0].X += 25;
                        heroes[0].heroimg = jump[jumpi].all;
                        jumpi++;
                        ctjump++;
                    }
                    if (ctjump == 7)
                    {
                        heroes[0].Y += 40;
                        heroes[0].X += 25;
                        heroes[0].heroimg = jump[jumpi].all;
                    }
                }
                if (flagj == 2)
                {
                    if (ctjump < 4)
                    {
                        heroes[0].Y -= 40;
                        heroes[0].X -= 25;
                        heroes[0].heroimg = jumpL[jumpi].all;
                        jumpi++;
                        ctjump++;
                    }
                    if (ctjump >= 4 && ctjump < 8)
                    {
                        heroes[0].Y += 40;
                        heroes[0].X -= 25;
                        heroes[0].heroimg = jumpL[jumpi].all;
                        jumpi++;
                        ctjump++;
                    }
                    if (ctjump == 7)
                    {
                        heroes[0].Y += 40;
                        heroes[0].X -= 25;
                        heroes[0].heroimg = jumpL[jumpi].all;
                    }
                }
                if (jumpi == 8 || jumpi == 17)
                {
                    ctjump = 0;
                    jumpi = 0;
                    isjump = false;
                }
                if (heroes[0].Y != jumpy)
                {

                }
            }
            if (ctover == 1)
            {
                ctover2++;
                if (ctover2 == 3)
                {
                    GameOver = true;
                }
            }
            if (ctG != 3 && ctG != 4)
            {
                MoveG();
            }
            if (ctG == 3)
            {
                Boss[0].all = new Bitmap("Dead.Bmp");
                Gdead2 = true;
            }
            if (ctG == 4)
            {
                Boss[0].all = new Bitmap("Dead02.Bmp");
                Gdead2 = true;
            }
            if (check == 10)
            {

                if (dir == 1)
                {
                    heroes[0].heroimg = attack[iatt].all;
                    iatt++;
                }
                if (dir == 2)
                {
                    heroes[0].heroimg = attack2[iatt].all;
                    iatt++;
                }

                if (iatt == 6 || iatt == 13)
                {

                    if (dir == 1)
                    {
                        check = 1;
                        int n = 4, w, h;
                        images pnn6 = new images();
                        pnn6.all = new Bitmap("Kunai0.bmp");
                        pnn6.X = heroes[0].X + 60; 
                        pnn6.Y = heroes[0].Y + 50;
                        pnn6.xDirr = dir;
                        h = pnn6.all.Height / n;
                        w = pnn6.all.Width / n;
                        pnn6.all = new Bitmap(pnn6.all, new Size(w, h));
                        pnn6.all.MakeTransparent(pnn6.all.GetPixel(0, 0));
                        bullets.Add(pnn6);

                        flagk = 10;
                        flag = 0;
                        iatt = 0;
                    }
                    if (dir == 2)
                    {
                        check = 2;
                        int n = 4, w, h;
                        images pnn6 = new images();
                        pnn6.all = new Bitmap("Kunai1.bmp");
                        pnn6.X = heroes[0].X - 60;
                        pnn6.Y = heroes[0].Y + 50;
                        pnn6.xDirr = dir;
                        h = pnn6.all.Height / n;
                        w = pnn6.
                            all.Width / n;
                        pnn6.all = new Bitmap(pnn6.all, new Size(w, h));
                        pnn6.all.MakeTransparent(pnn6.all.GetPixel(0, 0));
                        bulletsL.Add(pnn6);
                        flagk = 10;
                        flag = 0;
                        iatt = 0;
                    }
                }

            }
            if (flagk == 10)
            {
                MoveBullet();
            }
            if (flag == 0 && isjump == false)
            {
                ctIdle++;
                if (ctIdle == 2)
                {
                    isIdle();
                    ctIdle = 0;

                }
            }
            else
            {

            }
            MoveBossbul();
            MoveZombies();
            isCollisionF1();

            DrawDubb(CreateGraphics());
        }
        void bulletcollision()
        {

            for (int ww = 0; ww < Bossbuls.Count; ww++)
            {
                if (isDead == true)
                {

                    if (heroes[0].X > Bossbuls[ww].X && heroes[0].X < Bossbuls[ww].X + Bossbuls[ww].all.Width)
                    {
                        if (heroes[0].Y < Bossbuls[ww].Y && heroes[0].Y + heroes[0].heroimg.Height > Bossbuls[ww].Y)
                        {
                            heroes.RemoveAt(0);
                            GameOver = true;
                            hDead = true;
                            ctover = 1;
                            break;
                        }
                    }
                    if (isDead1 == true)
                    {
                        if (heroes[0].X > Bossbuls[ww].X && heroes[0].X < Bossbuls[ww].X + Bossbuls[ww].all.Width)
                        {
                            if (heroes[0].Y < Bossbuls[ww].Y && heroes[0].Y + heroes[0].heroimg.Height > Bossbuls[ww].Y)
                            {
                                heroes.RemoveAt(0);
                                GameOver = true;
                                hDead = true;
                                ctover = 1;
                                break;
                            }
                        }
                    }
                }
            }
        }
        void isCollisionF1()
        {
            for (int ww = 0; ww < Zombies2.Count; ww++)
            {
                if (Zombies2[ww].X < heroes[0].X + heroes[0].heroimg.Width - 70)
                {
                    if (hDead == false)
                    {
                        heroes.RemoveAt(0);
                        GameOver = true;
                        hDead = true;
                        ctover = 1;
                    }
                }
            }
            for (int ww = 0; ww < Zombies.Count; ww++)
            {
                if (hDead == false && Zombies[ww].X + Zombies[ww].all.Width > heroes[0].X + 30 &&
                    Zombies[ww].X + Zombies[ww].all.Width < heroes[0].X + heroes[0].heroimg.Width &&
                    Zombies[ww].Y +10 > heroes[0].Y && Zombies[ww].Y-10 < heroes[0].Y + heroes[0].heroimg.Height)
                {
                    heroes.RemoveAt(0);
                    GameOver = true;
                    hDead = true;
                    ctover = 1;
                    break;
                }
            }

        }
        void MoveBossbul() 
        {
            
            for(int ww=0;ww<Bossbuls.Count;ww++)
            {
                if(Bossbuls[ww].X>ladders[1].X+30&&Bossbuls[ww].Y<road2[0].Y+100)
                {
                    Bossbuls[ww].X -= 10;
                    bulletcollision();
                }
                if(Bossbuls[ww].X<ladders[1].X+45&&Bossbuls[ww].Y<road1[0].Y-38&&Bossbuls[ww].Y>road2[0].Y-100)
                {
                    Bossbuls[ww].Y += 10;
                    bulletcollision();
                }
                if(Bossbuls[ww].X>ladders[1].X-10&&Bossbuls[ww].Y>road1[0].Y-75&&Bossbuls[ww].Y>road2[0].Y&&Bossbuls[ww].X<ClientSize.Width)
                {
                    Bossbuls[ww].X += 10;
                   bulletcollision();
                }
            }
        }
        
        Bitmap FlipImage(Bitmap i)
        {
            Bitmap temp = i;
            temp.RotateFlip(RotateFlipType.Rotate180FlipY);
            return temp;
        }

        void MoveZombies()
        {
           
            for(int ww=0;ww<Zombies.Count;ww++)
            {
                if (Zombies[ww].X + Zombies[ww].all.Width > heroes[0].X +30 &&
                    Zombies[ww].X + Zombies[ww].all.Width < heroes[0].X + heroes[0].heroimg.Width &&
                    Zombies[ww].Y+10>heroes[0].Y&&Zombies[ww].Y-10<heroes[0].Y+heroes[0].heroimg.Height 
                    )
                {
                    heroes.RemoveAt(0);
                    GameOver = true;
                    hDead = true;
                    ctover = 1;
                    break;
                }
                if(Zombies[ww].X>=ClientSize.Width-100)
                { 
                    Zombies[ww].W *= -1;
                }
                else if(Zombies[ww].X <= 20)
                {
                    Zombies[ww].W *= -1;
                }
                Zombies[ww].X += Zombies[ww].W;
            }
        }
        void MoveG()
        {
                if (ctG == 1)
                {
                    Boss[0].all = new Bitmap("1.Bmp");

                }
                if (ctG == 2)
                {
                    Boss[0].all = new Bitmap("2.Bmp");
                    ctG = 0;
                }
                ctcl++;
                if (ctcl > 45)
                {
                    images pns = new images();
                    pns.all = new Bitmap("7.bmp");
                    pns.X = Boss[0].X + 20;
                    pns.Y = Boss[0].Y;
                    pns.all.MakeTransparent(pns.all.GetPixel(0, 0));
                    Bossbuls.Add(pns);
                    ctcl = 0;
                    MoveBossbul();
                }
                ctG++;
                Boss[0].X += chi;
                /*if(Boss[0].X)*/
                if (Boss[0].X > ClientSize.Width - 90)
                    chi *= -1;
                if (Boss[0].X < 15)
                    chi *= -1;
        }
        void MoveBullet()
        { 

            //1 y 
            for (int dd = 0; dd < bullets.Count; dd++)
            {

                if (bullets[dd].xDirr == 1)
                {
                    bullets[dd].X += 40;
                    if (bullets[dd].X >= Boss[0].X && bullets[dd].X <= Boss[0].X + Boss[0].all.Width
                        && isDead1==true)
                    { 
                            ctG = 3;
                            Gct++;
                        bullets.RemoveAt(dd);
                        break;
                    }
                    for(int cc=0;cc<Zombies2.Count;cc++)
                    {
                        if (bullets[dd].X+bullets[dd].all.Width > Zombies2[cc].X+45&&bullets[dd].X+bullets[dd].all.Width<Zombies2[cc].X+Zombies[cc].all.Width)
                        {
                            die = 2;
                            bullets.RemoveAt(dd);
                            Zombies2.RemoveAt(cc);
                            break;
                        }
                    }
                    for(int ii=0;ii<Zombies.Count;ii++)
                    {
                        if(isDead==true&&bullets[dd].X+bullets[dd].all.Width>Zombies[ii].X&& bullets[dd].X + bullets[dd].all.Width < Zombies[ii].X+ Zombies[ii].all.Width+20)
                        {
                            die = 2;
                            Zombies.RemoveAt(ii);
                            bullets.RemoveAt(dd);
                            break;
                        }
                    }
                    if(die==2)
                    {
                        die = 0;
                        break;
                    }
                    if(bullets[dd].X > heroes[0].X + 800)
                    {
                        bullets.RemoveAt(dd);
                        break;
                    }    

                }
            }
            for (int ddw = 0; ddw < bulletsL.Count; ddw++)
            {
                if (bulletsL[ddw].xDirr == 2)
                {
                    bulletsL[ddw].X -= 40;
                    if (isDead1==true&&bulletsL[ddw].X<Boss[0].X+Boss[0].all.Width&&bulletsL[ddw].X>Boss[0].X)
                    {
                        Gct++;
                        ctG = 4;
                       bulletsL.RemoveAt(ddw);
                        break;
                    }
                    for(int ii=0;ii<Zombies.Count;ii++)
                    {
                        if(isDead==true&&bulletsL[ddw].X+bulletsL[ddw].all.Width<Zombies[ii].X+Zombies[ii].all.Width&&
                            bulletsL[ddw].X+bulletsL[ddw].all.Width>Zombies[ii].X)
                        {
                            die2 = 2;
                            Zombies.RemoveAt(ii);
                            bulletsL.RemoveAt(ddw);
                            break;
                        }
                    }
                    if(die2==2)
                    {
                        break;
                        die2 = 0;
                    }
                    if (bulletsL[ddw].X < heroes[0].X - 800)
                    {
                        bulletsL.RemoveAt(ddw);
                        break;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            flag = 0;
            CreateIdle();
            CreateJump();
            CreateJumpL();
            CreateHero();
            CreateWorld();
            CreateAttack();
            if (heroes[0].Y < road1[0].Y + 100 && heroes[0].Y > road2[0].Y)
            {
                isDead = true;
           

            }
            if (heroes[0].Y < road2[0].Y + 40)
            {

                isDead1 = true;
            }
            img = new Bitmap("gameover.bmp");
            Rsrc = new Rectangle(0, 0, img.Width, img.Height);
            Rdest = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
        }
        void CreateJump()
        {
            int n = 5, w, h;
            images pnn4 = new images();
            pnn4.all = new Bitmap("jump0.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("jump1.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jump2.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jump3.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jump4.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jump5.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jump6.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jump7.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jump8.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jump.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("jumpopp0.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("jumpopp1.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jumpopp2.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jumpopp3.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jumpopp4.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jumpopp5.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jumpopp6.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jumpopp7.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Jumpopp8.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            jumpL.Add(pnn4);
        }
        void CreateJumpL()
        {

        }
        void CreateWorld()
        {
            int n = 2, w, h, hh = 50;
           
            n = 5;
            int rX = 0, rY = 450;
            images pnn23 = new images();
           
            for (int iw = 0; iw < 45; iw++)
            {
                pnn23 = new images();
                pnn23.all = new Bitmap("surface0.bmp");
                pnn23.X = rX;
                pnn23.Y = rY;
                w = pnn23.all.Width / n;
                h = pnn23.all.Height / n;
                pnn23.all = new Bitmap(pnn23.all, new Size(w, h));
                pnn23.all.MakeTransparent(pnn23.all.GetPixel(0, 0));
                road1.Add(pnn23);
                rX += 30;
            }
            rX = 0;
            rY -= 300;
            for (int iw = 0; iw < 45; iw++)
            {
                pnn23 = new images();
                pnn23.all = new Bitmap("surface0.bmp");
                pnn23.X = rX;
                pnn23.Y = rY;
                w = pnn23.all.Width / n;
                h = pnn23.all.Height / n;
                pnn23.all = new Bitmap(pnn23.all, new Size(w, h));
                pnn23.all.MakeTransparent(pnn23.all.GetPixel(0, 0));
                road2.Add(pnn23);
                rX += 30;
            }
            images pnnn = new images();
            pnnn.X = 50;
            pnnn.Y = road2[1].Y - road2[0].all.Height-11;
            pnnn.all = new Bitmap("1.bmp");
            Boss.Add(pnnn);
            w = 0; n = 4; h = 0; int zx = 50;
            images pn1 = new images();
            for (int ww = 0; ww < 5; ww++)
            {
                pn1 = new images();
                if (ww == 0)
                {
                    pn1.all = new Bitmap("Wraith0.bmp");
                }
                if (ww == 1 || ww == 3)
                {

                    pn1.all = new Bitmap("Wraith01.bmp");
                }
                if (ww == 2 || ww == 4)
                {
                    pn1.all = new Bitmap("Wraith02.bmp");
                }
                pn1.X = zx;
                pn1.Y = road1[0].Y - road1[0].all.Height - 55;
                w = pn1.all.Width / n;
                h = pn1.all.Height / n;
                pn1.all = new Bitmap(pn1.all, new Size(w, h));
                pn1.all.MakeTransparent(pn1.all.GetPixel(0, 0));
                Zombies.Add(pn1);
                zx += 100;
            }
            zx = ClientSize.Width - 300; n = 4;
            images pn2 = new images();
            for (int ww = 0; ww < 3; ww++)
            {
                pn2 = new images();
                if (ww == 0)
                {
                    pn2.all = new Bitmap("Wraithopp0.bmp");
                }
                if (ww == 1)
                {

                    pn2.all = new Bitmap("Wraithopp01.bmp");
                }
                if (ww == 2)
                {
                    pn2.all = new Bitmap("Wraithopp02.bmp");
                }
                pn2.X = zx2;
                pn2.Y = heroes[0].Y;
                w = pn2.all.Width / n;
                h = pn2.all.Height / n;
                pn2.all = new Bitmap(pn2.all, new Size(w, h));
                pn2.all.MakeTransparent(pn2.all.GetPixel(0, 0));
                Zombies2.Add(pn2);
                zx2 -= 100;
            }
            rX += 30;
            images pnn33 = new images();
            pnn33.all = new Bitmap("1.bmp");
            pnn33.all.MakeTransparent(pnn33.all.GetPixel(0, 0));
            Gurreillas.Add(pnn33);
            pnn33 = new images();
            pnn33.all = new Bitmap("2.bmp");
            pnn33.all.MakeTransparent(pnn33.all.GetPixel(0, 0));
            Gurreillas.Add(pnn33);
            pnn33 = new images();
            pnn33.all = new Bitmap("3.bmp");
            pnn33.all.MakeTransparent(pnn33.all.GetPixel(0, 0));
            Gurreillas.Add(pnn33);
            pnn33 = new images();
            pnn33.all = 
                new Bitmap("4.bmp");
            pnn33.all.MakeTransparent(pnn33.all.GetPixel(0, 0));
            Gurreillas.Add(pnn33);
            n = 2; hh = 50;
            images pnn22 = new images();
            pnn22.all = new Bitmap("ladder.bmp");
            pnn22.X = 1100;
            pnn22.Y = ClientSize.Height - 250;
            w = pnn22.all.Width / n + 120;
            h = pnn22.all.Height;
            pnn22.all = new Bitmap(pnn22.all, new Size(w, h));
            pnn22.all.MakeTransparent(pnn22.all.GetPixel(0, 0));
            ladders.Add(pnn22);
            pnn22 = new images();
            pnn22.all = new Bitmap("ladder.bmp");
            pnn22.X = 0;
            pnn22.Y = road1[0].Y-ladders[0].all.Height+30;
            w = pnn22.all.Width / n + 120;
            h = pnn22.all.Height;
            pnn22.all = new Bitmap(pnn22.all, new Size(w, h));
            pnn22.all.MakeTransparent(pnn22.all.GetPixel(0, 0));
            ladders.Add(pnn22);
        }
        void CreateHero()
        {
            Hero pnn2 = new Hero();
            pnn2.X = 50;
            pnn2.Y = this.ClientSize.Height-100;
            pnn2.heroimg = imgs[0].all;
            heroes.Add(pnn2);
            
        }
        void CreateAttack()
        {
            int n = 5, w, h;
            images pnn4 = new images();
            pnn4.all = new Bitmap("Throw0.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throw1.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throw2.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throw3.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throw4.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throw5.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throw6.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack.Add(pnn4);
            pnn4 = new images();    
            pnn4.all = new Bitmap("Throwopp0.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack2.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throwopp1.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack2.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throwopp2.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack2.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throwopp3.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack2.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throwopp4.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack2.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throwopp5.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack2.Add(pnn4);
            pnn4 = new images();
            pnn4.all = new Bitmap("Throwopp6.bmp");
            pnn4.ch = 0;
            w = pnn4.all.Width / n;
            h = pnn4.all.Height / n;
            pnn4.all = new Bitmap(pnn4.all, new Size(w, h));
            pnn4.all.MakeTransparent(pnn4.all.GetPixel(0, 0));
            attack2.Add(pnn4);
            n = 5;
            images pnn3 = new images();
            pnn3.all = new Bitmap("Dead0.bmp");
            pnn3.ch = 0;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            Dead.Add(pnn3);
            pnn3 = new images();
            pnn3.all = new Bitmap("Dead1.bmp");
            pnn3.ch = 1;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            Dead.Add(pnn3);
            pnn3 = new images();
            pnn3.all = new Bitmap("Dead2.bmp");
            pnn3.ch = 2;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            Dead.Add(pnn3);
            pnn3 = new images();
            pnn3.all = new Bitmap("Dead3.bmp");
            pnn3.ch = 3;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            Dead.Add(pnn3);
            images pnn5 = new images();
            pnn5.all = new Bitmap("Dead_4.bmp");
            pnn5.ch = 4;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            Dead.Add(pnn5);
            pnn5 = new images();
            pnn5.all = new Bitmap("Dead5.bmp");
            pnn5.ch = 5;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            Dead.Add(pnn5);
            pnn5 = new images();
            pnn5.all = new Bitmap("Dead6.bmp");
            pnn5.ch = 6;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            Dead.Add(pnn5);
            pnn5 = new images();
            pnn5.all = new Bitmap("Dead7.bmp");
            pnn5.ch = 7;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            Dead.Add(pnn5);
            pnn5 = new images();
            pnn5.all = new Bitmap("Dead8.bmp");
            pnn5.ch = 7;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            Dead.Add(pnn5);
        }
        void CreateIdle()
        {
            int n = 5, w, h;
            images pnn3 = new images();
            pnn3.all = new Bitmap("idle0.bmp");
            pnn3.ch = 0;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            imgs.Add(pnn3);
            pnn3 = new images();
            pnn3.all = new Bitmap("Idle1.bmp");
            pnn3.ch = 1;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            imgs.Add(pnn3);
            pnn3 = new images();
            pnn3.all = new Bitmap("Idle2.bmp");
            pnn3.ch = 2;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            imgs.Add(pnn3);
            pnn3 = new images();
            pnn3.all = new Bitmap("Idle3.bmp");
            pnn3.ch = 3;
            w = pnn3.all.Width / n;
            h = pnn3.all.Height / n;
            pnn3.all = new Bitmap(pnn3.all, new Size(w, h));
            pnn3.all.MakeTransparent(pnn3.all.GetPixel(0, 0));
            imgs.Add(pnn3);
            images pnn5 = new images();
            pnn5.all = new Bitmap("idleopp0.bmp");
            pnn5.ch = 4;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            imgs2.Add(pnn5);
            pnn5 = new images();
            pnn5.all = new Bitmap("Idleopp1.bmp");
            pnn5.ch = 5;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            imgs2.Add(pnn5);
            pnn5 = new images();
            pnn5.all = new Bitmap("idleopp2.bmp");
            pnn5.ch = 6;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            imgs2.Add(pnn5);
            pnn5 = new images();
            pnn5.all = new Bitmap("Idleopp3.bmp");
            pnn5.ch = 7;
            w = pnn5.all.Width / n;
            h = pnn5.all.Height / n;
            pnn5.all = new Bitmap(pnn5.all, new Size(w, h));
            pnn5.all.MakeTransparent(pnn5.all.GetPixel(0, 0));
            imgs2.Add(pnn5);
        }
        private void Form1_Paint(object sender,PaintEventArgs e)
        {

            DrawScene(e.Graphics);
        }
        
        void isIdle()
        {
            if (check == 1)
            {
                heroes[0].heroimg = imgs[iidle].all;
                iidle++;
                if (iidle > 3)
                {
                    iidle = 0;
                }
            }
            if(check==2)
            {
                heroes[0].heroimg = imgs2[iidle2].all;
                iidle2++;
                if (iidle2 > 3)
                {
                    iidle2 = 0;
                }
            }
        }
        
        void DrawScene(Graphics gf)
        {
            if (GameOver == false)
            {
                gf.Clear(Color.Black);
                gf.DrawImage(ladders[0].all, ladders[0].X, ladders[0].Y - 240);
                for (int kk = 0; kk < bullets.Count; kk++)
                {
                    gf.DrawImage(bullets[kk].all, bullets[kk].X, bullets[kk].Y);
                }
                for (int kkw = 0; kkw < bulletsL.Count; kkw++)
                {
                    gf.DrawImage(bulletsL[kkw].all, bulletsL[kkw].X, bulletsL[kkw].Y);
                }
                for (int kk = 0; kk < ladders.Count; kk++)
                {
                    gf.DrawImage(ladders[kk].all, ladders[kk].X, ladders[kk].Y);
                }
                for (int kk = 0; kk < road1.Count; kk++)
                {
                    gf.DrawImage(road1[kk].all, road1[kk].X, road1[kk].Y);
                }
                for (int kk = 0; kk < road1.Count; kk++)
                {
                    gf.DrawImage(road2[kk].all, road2[kk].X, road2[kk].Y);
                }
                for (int k = 0; k < heroes.Count - 1; k++)
                {
                    gf.DrawImage(heroes[k].heroimg, heroes[k].X, heroes[k].Y);
                }
                for (int kk = 0; kk < Boss.Count - 1; kk++)
                {
                    Boss[kk].all.MakeTransparent(Boss[kk].all.GetPixel(0, 0));
                    gf.DrawImage(Boss[kk].all, Boss[kk].X, Boss[kk].Y);
                }
                for (int k = 0; k < Zombies2.Count; k++)
                {
                    gf.DrawImage(Zombies2[k].all, Zombies2[k].X, Zombies2[k].Y);
                }
                for(int k=0;k<10;k++)
                {
                    gf.DrawImage(road1[0].all, road1[0].X + mod, road1[0].Y);
                    
                mod += 50;
                }
                for (int kk = 0; kk < Zombies.Count; kk++)
                {
                    if (Zombies[kk].W > 0)
                    {
                        gf.DrawImage(Zombies[kk].all, Zombies[kk].X, Zombies[kk].Y);
                    }
                    else
                    {

                        gf.DrawImage(FlipImage(Zombies[kk].all), Zombies[kk].X, Zombies[kk].Y);
                        FlipImage(Zombies[kk].all);
                    }

                }


                for (int kk = 0; kk < Bossbuls.Count; kk++)
                {
                    try
                    {

                        gf.DrawImage(Bossbuls[kk].all, Bossbuls[kk].X, Bossbuls[kk].Y);

                    }
                    catch
                    {
                        MessageBox.Show("kk" + kk);
                    }
                }
            }
            if(GameOver==true)
            {
                gf.DrawImage(img,0,0);
                
            }
            if(Gdead==true)
            {
                gg = new Bitmap(gg, new Size(ClientSize.Width, ClientSize.Height));
                gf.DrawImage(gg, 0, 0);
            }
           
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
