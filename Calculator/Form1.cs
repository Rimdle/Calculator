using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public static readonly Assembly ass = Assembly.GetExecutingAssembly();
        public Image hvr = Image.FromStream(ass.GetManifestResourceStream("Calculator.btnhvr.png"));
        public Image dwn = Image.FromStream(ass.GetManifestResourceStream("Calculator.btndown.png"));
        public Image btn = Image.FromStream(ass.GetManifestResourceStream("Calculator.btn.png"));
        public Image actbtn = Image.FromStream(ass.GetManifestResourceStream("Calculator.act.png"));
        public Image acthvr = Image.FromStream(ass.GetManifestResourceStream("Calculator.acthvr.png"));
        public Image actdwn = Image.FromStream(ass.GetManifestResourceStream("Calculator.actdwn.png"));
        public Image eqdwn = Image.FromStream(ass.GetManifestResourceStream("Calculator.eqdwn.png"));
        public Image eqhvr = Image.FromStream(ass.GetManifestResourceStream("Calculator.eqhvr.png"));
        public Image eq = Image.FromStream(ass.GetManifestResourceStream("Calculator.eq.png"));
        public Image ce = Image.FromStream(ass.GetManifestResourceStream("Calculator.ce.png"));
        public Image cehvr = Image.FromStream(ass.GetManifestResourceStream("Calculator.cehvr.png"));
        public Image cedwn = Image.FromStream(ass.GetManifestResourceStream("Calculator.cedwn.png"));
        public Image cdwn = Image.FromStream(ass.GetManifestResourceStream("Calculator.cdwn.png"));
        public Image chvr = Image.FromStream(ass.GetManifestResourceStream("Calculator.chvr.png"));
        public Image c = Image.FromStream(ass.GetManifestResourceStream("Calculator.c.png"));
        public double? d1 = null;
        public double d2;
        public char action;
        public bool mD;
        public Point lL;
        public bool preview = false;


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Res.Text = null;
        }

        private void Result()
        {
            double? res = 0;
            switch (action)
            {
                case '+':
                    res = d1 + d2;
                    break;

                case '-':
                    res = d1 - d2;
                    break;

                case '*':
                    res = d1 * d2;
                    break;

                case '/':
                    res = d1 / d2;
                    break;
            }
            d1 = res;
            Res.Text = res.ToString();
            Resize();
            preview = true;
        }

        private void Resize()
        {
            switch ( Res.Text.Length)
            {
                case 0:
                    Res.Font = new Font("Bahnschrift Condensed", 48, FontStyle.Bold);
                    return;

                case 12:
                    Res.Font = new Font("Bahnschrift Condensed", 36, FontStyle.Bold);
                    return;

                case 18:
                    Res.Font = new Font("Bahnschrift Condensed", 24, FontStyle.Bold);
                    return;

                case 36:
                    Res.Font = new Font("Bahnschrift Condensed", 18, FontStyle.Bold);
                    return;

                case 48:
                    Res.Font = new Font("Bahnschrift Condensed", 12, FontStyle.Bold);
                    return;

            }
        }

        //Digit buttons dynamic bg images handling
        private void B1_MouseHover(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = hvr;
            }
        }

        private void B1_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = btn;
            }
        }

        private void B1_MouseDown(object sender, MouseEventArgs e)
        {
            if (preview)
            {
                Res.Text = null;
                preview = false;
            }
            if (sender is Button button)
            {
                button.BackgroundImage = dwn;
                Res.Text += button.Text;
            }
            Resize();
        }

        private void B1_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = hvr;
            }
        }

        //Action buttons dynamic bg images handling

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Res.Text += ',';
            Resize();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = acthvr;
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = actbtn;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = acthvr;
            }
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            EQB.BackgroundImage = eqdwn;
            d2 = double.Parse(Res.Text);
            Result();
            Resize();
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            EQB.BackgroundImage = eqhvr;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            EQB.BackgroundImage = eq;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            EQB.BackgroundImage= eqhvr;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            CEB.BackgroundImage = cedwn;
            Res.Text = null;
            d1 = null;
            d2 = 1;
            action = 'b';
            Resize();
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            CEB.BackgroundImage = cehvr;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            CEB.BackgroundImage = ce;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            CEB.BackgroundImage = cehvr;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            CB.BackgroundImage = cdwn;
            Res.Text = Res.Text.Substring(0, Res.Text.Length - 1);
            Resize();
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            CB.BackgroundImage= chvr;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            CB.BackgroundImage = c;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            CB.BackgroundImage = chvr;
        }

        private void button6_MouseDown_1(object sender, MouseEventArgs e)
        {
            Application.Exit();
            Resize();
        }

        private void button6_MouseHover_1(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Red;
        }

        private void button6_MouseLeave_1(object sender, EventArgs e)
        {
            button6.ForeColor = Color.White;
        }

        private void button7_MouseDown_1(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Resize();
        }

        private void Mover_MouseDown(object sender, MouseEventArgs e)
        {
            lL = new Point(e.X, e.Y);
        }

        private void Mover_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lL.X;
                this.Top += e.Y - lL.Y;
            }
        }

        private void Mover_MouseUp(object sender, MouseEventArgs e)
        {
            mD = false;
            this.Capture = false;
        }

        private void Sum_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = actdwn;
            }
            if (action != null && d1 != null && !preview)
            {
                d2 = double.Parse(Res.Text);
                Result();
                action = '+';
            }
            else if (Res.Text != "" && Res.Text != ",")
            {
                d1 = double.Parse(Res.Text);
                action = '+';
                Res.Text = null;
            }
            Resize();
        }

        private void Sub_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = actdwn;
            }
            if (action != null && d1 != null && !preview)
            {
                d2 = double.Parse(Res.Text);
                Result();
                action = '-';
            }
            else if (Res.Text != "" && Res.Text != ",")
            {
                d1 = double.Parse(Res.Text);
                action = '-';
                Res.Text = null;
            }
            Resize();
        }

        private void Mult_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = actdwn;
            }
            if (action != null && d1 != null && !preview)
            {
                d2 = double.Parse(Res.Text);
                Result();
                action = '*';
            }
            else if (Res.Text != "" && Res.Text != ",")
            {
                d1 = double.Parse(Res.Text);
                action = '*';
                Res.Text = null;
            }
            Resize();
        }

        private void Div_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundImage = actdwn;
            }
            if (action != null && d1 != null && !preview)
            {
                d2 = double.Parse(Res.Text);
                Result();
                action = '/';
            }
            else if (Res.Text != "" && Res.Text != ",")
            {
                d1 = double.Parse(Res.Text);
                action = '/';
                Res.Text = null;
            }
            Resize();
        }
    }

}
