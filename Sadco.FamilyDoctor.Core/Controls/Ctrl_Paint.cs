﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sadco.FamilyDoctor.Core.Controls
{
    /// <summary>
    /// Контрол редактора рисунка
    /// </summary>
    public class Ctrl_Paint : PictureBox
    {
        /// <summary>Режим чтения</summary>
        public bool p_ReadOnly { get; set; }

        private Point m_StartSelectPoint = new Point();
        private Rectangle m_SelectRect = new Rectangle();

        public new Image Image {
            get { return base.Image; }
            set {
                if (value != null)
                    base.Image = (Image)value.Clone();
                else
                    base.Image = null;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            m_StartSelectPoint = e.Location;
            m_SelectRect.Location = e.Location;
            m_SelectRect.Width = 0;
            m_SelectRect.Height = 0;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= m_StartSelectPoint.X)
                {
                    m_SelectRect.X = m_StartSelectPoint.X;
                    m_SelectRect.Width = e.X - m_StartSelectPoint.X;
                }
                else
                {
                    m_SelectRect.X = e.X;
                    m_SelectRect.Width = m_StartSelectPoint.X - e.X;
                }
                if (e.Y >= m_StartSelectPoint.Y)
                {
                    m_SelectRect.Y = m_StartSelectPoint.Y;
                    m_SelectRect.Height = e.Y - m_StartSelectPoint.Y;
                }
                else
                {
                    m_SelectRect.Y = e.Y;
                    m_SelectRect.Height = m_StartSelectPoint.Y - e.Y;
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!p_ReadOnly)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Graphics grImg = Graphics.FromImage(Image);
                    grImg.DrawEllipse(new Pen(Color.Red, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid }, new Rectangle(m_SelectRect.X, m_SelectRect.Y, m_SelectRect.Width, m_SelectRect.Height));
                }
                m_SelectRect.Width = 0;
                m_SelectRect.Height = 0;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (!p_ReadOnly)
            {
                if (m_SelectRect.Width > 0 && m_SelectRect.Height > 0)
                {
                    pe.Graphics.DrawEllipse(new Pen(Color.Blue, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }, m_SelectRect);
                }
            }
        }
    }
}
