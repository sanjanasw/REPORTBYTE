﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ButtonDemo
{
    class ButtonLastest : System.Windows.Forms.Button
    {
        public Color BorderColor = Color.White;
        public int BorderSize = 0;
        public ButtonLastest()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.White;
            FlatAppearance.BorderColor = BorderColor;
            FlatAppearance.BorderSize = BorderSize;
            Font = new System.Drawing.Font("VAGRounded-Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(221)))), ((int)(((byte)(23)))));
            //FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100))), ((int)(((byte)(221)))), ((int)(((byte)(23)))));
            //FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.MouseDown += new MouseEventHandler(ButtonLastest_MouseDown);
            this.MouseUp += new MouseEventHandler(ButtonLastest_MouseUp);


        }

        void ButtonLastest_MouseUp(object sender, MouseEventArgs e)
        {
            ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(221)))), ((int)(((byte)(23)))));
            BackColor = Color.White;
        }

        void ButtonLastest_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(221)))), ((int)(((byte)(23)))));
            ForeColor = System.Drawing.Color.White;

        }
        int top;
        int left;
        int right;
        int bottom;


        protected override void OnPaint(PaintEventArgs pevent)
        {

            base.OnPaint(pevent);
            int CornerRadius = 20;
            Color FillColor = Color.White;
            Pen DrawPen = new Pen(BorderColor);
            GraphicsPath gfxPath_mod = new GraphicsPath();

            top = 0;
            left = 0;
            right = Width;
            bottom = Height;

            gfxPath_mod.AddArc(left, top, CornerRadius, CornerRadius, 180, 90);
            gfxPath_mod.AddArc(right - CornerRadius, top, CornerRadius, CornerRadius, 270, 90);
            gfxPath_mod.AddArc(right - CornerRadius, bottom - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gfxPath_mod.AddArc(left, bottom - CornerRadius, CornerRadius, CornerRadius, 90, 90);

            gfxPath_mod.CloseAllFigures();

            pevent.Graphics.DrawPath(DrawPen, gfxPath_mod);


            int inside = 1;

            Pen newPen = new Pen(BorderColor, BorderSize);
            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(left + inside + 1, top + inside, CornerRadius, CornerRadius, 180, 100);

            gfxPath.AddArc(right - CornerRadius - inside - 2, top + inside, CornerRadius, CornerRadius, 270, 90);
            gfxPath.AddArc(right - CornerRadius - inside - 2, bottom - CornerRadius - inside - 1, CornerRadius, CornerRadius, 0, 90);

            gfxPath.AddArc(left + inside + 1, bottom - CornerRadius - inside, CornerRadius, CornerRadius, 95, 95);


            // draws arc to the four edges of the button.
            pevent.Graphics.DrawPath(newPen, gfxPath);



            //clips edges to make the curve looks
            this.Region = new System.Drawing.Region(gfxPath_mod);

        }
    }
}
