using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Melodia
{
    public partial class Form1 : Form
    {
        int times = 0; int times1 = 0; int times2 = 0; int k = 0; int s = 0;
        int i = 0; int i1 = 0; int i2 = 0;
        int j = 0;
        int rbutton = 0;
        int randbat1 = 0; int randbat2 = 0; int randbat3 = 0; int randbat4 = 0;
        string[] name = new string[50];
        int count = 0;
        int rmusic;
        SoundPlayer mus;
        public string NameMusic(string name)
        {
            string name1 = ""; char name2 = '\\';
            for (int i = 0; i < name.Length; i++)
                if (name[i] == '.') break;
                else
                    if (name[i] == name2) name1 = ""; else name1 = name1 + name[i];
            return name1;
        }
        public void GameOver()
        {

            NewGame();
            k++;
            progressBar1.Visible = false;
            label1.Visible = false;
            button1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            label3.Visible = false;
            button3.Visible = false;
            label4.Visible = false;
            button4.Visible = false;
            MessageBox.Show("Ваш результат  " + i + " вгаданих композицій  за  " + (int)times / 10 + "  сeкунд!!!");
            i1 = i;
            times1 = i;
            times = 0;
            i = 0;
            j = 0;
            if (button8.Visible == false)
            {
                label5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
            }
            if (button5.Visible == false)
            {
                if (k == 1)
                {
                    NewGame();
                    i2 = i1;
                    times2 = times1;
                    Work();
                }
                if (k == 2)
                {
                    if (i2 > i1) MessageBox.Show("Переміг ПЕРШИЙ гравець з рахунком вгаданих композицій " + i2 + " : " + i1);
                    else if (i2 < i1) MessageBox.Show("Переміг ДРУГИЙ гравець з рахунком вгаданих композицій " + i1 + " : " + i2);
                    if (i1 == i2)
                        if (times1 > times2) MessageBox.Show("Переміг ПЕРШИЙ гравець при однаковій кількості вгаданих композицій на за час " + times2 + " секунд проти " + times1 + " секунд");
                        else if (times1 < times2) MessageBox.Show("Переміг ДРУГИЙ гравець при однаковій кількості вгаданих композицій на за час " + times1 + " секунд проти " + times2 + " секунд");
                    if ((i1 == i2) && (times1 == times2)) MessageBox.Show("НІЧЬЯ. Перемогла дружба");
                    label5.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    button8.Visible = false;
                    k = 0;
                }
            }
            button5.Visible = false;


        }
        public void Read()
        {
            MessageBox.Show("Виберіть папку з музикой формату .WAV (Не більше ніж 50 пісень) (Якщо у вас немає такої музики можете завантажити з папки Content яку знайдете у папці проекту)");
            MessageBox.Show("Якщо Ви вже вибирали папку і немаєте бажання її змінювати то наступне вікно можете закрити, но якщо Ви граєте перший раз то виберіть папку інакше гра не розпочнеться");
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string File in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                {
                    name[count] = File;
                    count++;
                }
            }

        }
        public void RandButonn()
        {
            Random ra = new Random();
            rmusic = 0;
            rmusic = ra.Next(1, count);
            rbutton = ra.Next(4);
            randbat1 = ra.Next(1, count);
            randbat2 = ra.Next(1, count);
            randbat3 = ra.Next(1, count);
            randbat4 = ra.Next(1, count);
            if (s < 30)
            {
                s++;
                if (rmusic == randbat1) RandButonn();
                else
                    if (rmusic == randbat2) RandButonn();
                    else
                        if (rmusic == randbat3) RandButonn();
                        else
                            if (rmusic == randbat4) RandButonn();
                            else
                                if (randbat1 == randbat2) RandButonn();
                                else
                                    if (randbat1 == randbat3) RandButonn();
                                    else
                                        if (randbat1 == randbat4) RandButonn();
                                        else
                                            if (randbat2 == randbat3) RandButonn();
                                            else
                                                if (randbat2 == randbat4) RandButonn();
                                                else
                                                    if (randbat4 == randbat3) RandButonn();
            }
        }
        public void VvidButton()
        {
            progressBar1.Visible = true;
            if (rbutton == 0) button1.Text = NameMusic(name[rmusic]); else button1.Text = NameMusic(name[randbat1]);
            if (rbutton == 1) button2.Text = NameMusic(name[rmusic]); else button2.Text = NameMusic(name[randbat2]);
            if (rbutton == 2) button3.Text = NameMusic(name[rmusic]); else button3.Text = NameMusic(name[randbat3]);
            if (rbutton == 3) button4.Text = NameMusic(name[rmusic]); else button4.Text = NameMusic(name[randbat4]);
        }

        public void Work()
        {
            progressBar1.Value = 0;
            RandButonn();
            s = 0;
            mus = new SoundPlayer(name[rmusic]);
            mus.Play();
            VvidButton();
            timer1.Start();
        }
        public Form1()
        {
            InitializeComponent();
            NewGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbutton + 1 == 1) i++; else j++;
            if (j > 2) GameOver();
            else
            {
                label1.Text = Convert.ToString(i);
                label3.Text = Convert.ToString(j);
                Work();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rbutton + 1 == 2) i++; else j++;
            if (j > 2) GameOver();
            else
            {
                label1.Text = Convert.ToString(i);
                label3.Text = Convert.ToString(j);
                Work();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rbutton + 1 == 3) i++; else j++;
            if (j > 2) GameOver();
            else
            {
                label1.Text = Convert.ToString(i);
                label3.Text = Convert.ToString(j);
                Work();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rbutton + 1 == 4) i++; else j++;
            if (j > 2) GameOver();
            else
            {
                label1.Text = Convert.ToString(i);
                label3.Text = Convert.ToString(j);
                Work();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Read();
                Work();
            }
            catch { MessageBox.Show("Ви не вибрали папку з якої хочете відтворити музику"); }

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("За допомогою цієї програми ви можете пограти в гру Вгадай мелодію. Ви можете пограти в одиночну гру або з другом. Також вам надається можливість самостійно вибрати музику з якою будете грати. Удачної гри!!!");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void NewGame()
        {
            try
            {
                mus.Stop();
            }
            catch { }
            timer1.Stop();
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            label1.Text = "";
            label3.Text = "";
            label5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            label1.Visible = true;
            button1.Visible = true;
            label2.Visible = true;
            button2.Visible = true;
            label3.Visible = true;
            button3.Visible = true;
            label4.Visible = true;
            button4.Visible = true;
            progressBar1.Value = 0;
            j = 0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer time = new Timer();
            times++;
            time.Interval = 1000;
            progressBar1.Increment(+1);
            if (progressBar1.Value == 100)
            {
                if (j > 2)
                {
                    progressBar1.Value = 0;
                    timer1.Stop();
                    GameOver();
                }
                else
                {
                    progressBar1.Value = 0;
                    timer1.Stop();
                    j++;
                    label1.Text = Convert.ToString(i);
                    label3.Text = Convert.ToString(j);
                    Work();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Read();
                Work();
            }
            catch { MessageBox.Show("Ви не вибрали папку з якої хочете відтворити музику"); }


        }

        private void граОдногоГравцяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button8.Visible = false;
        }

        private void граДвохГравцівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button5.Visible = false;
        }
    }
}
