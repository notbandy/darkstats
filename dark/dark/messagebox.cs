using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using Transitions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace dark
{
    public partial class msgbox : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public enum Icons
        {
            Error,
            Info
        }
        Form1.finish fein; //boilerplate
        public msgbox(Form1.finish f, string title = "title", string text = "text", Icons icon = Icons.Info)
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            caption.Text = title;
            message.Text = text;
            fein = f; //severe boilerplate
            if(icon == Icons.Error)
            {
                pictureBox1.Image = Properties.Resources.whiteerror;
                this.Icon = Properties.Resources.error;
            }

            Show();
            this.Top = 0;
            
            Transition.run(this, "Top", Screen.PrimaryScreen.Bounds.Height / 2 - 170, new TransitionType_EaseInEaseOut(800));
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            fein();
            Close();
            
        }

        private void sButton2_Click(object sender, EventArgs e)
        {
            fein();
            Close();
            
        }
    }
}
