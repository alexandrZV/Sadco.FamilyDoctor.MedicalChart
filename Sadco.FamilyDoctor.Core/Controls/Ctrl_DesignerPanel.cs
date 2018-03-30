﻿using Sadco.FamilyDoctor.Core.Controls.DesignerPanel;
using Sadco.FamilyDoctor.Core.Entities;
using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Sadco.FamilyDoctor.Core.Controls
{
    /// <summary>
    /// Determines the insertion mode of a drag operation
    /// </summary>
    public enum I_InsertionMode
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// The source item will be inserted before the destination item
        /// </summary>
        Before,
        /// <summary>
        /// The source item will be inserted after the destination item
        /// </summary>
        After
    }

    public partial class Ctrl_DesignerPanel : ListBox
    {
        public Ctrl_DesignerPanel()
        {
            ItemHeight = 24;
            InitializeComponent();
            //Initialize();
            this.DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawFixed;
            m_InsertionLineColor = Color.Red;
            InsertionIndex = InvalidIndex;
        }

        private bool m_AllowItemDrag;
        [Category("Behavior")]
        [DefaultValue(false)]
        public virtual bool p_AllowItemDrag {
            get { return m_AllowItemDrag; }
            set {
                if (this.p_AllowItemDrag != value)
                {
                    m_AllowItemDrag = value;
                    this.OnAllowItemDragChanged(EventArgs.Empty);
                }
            }
        }

        private bool m_ReadOnly = false;
        /// <summary>Флаг только чтения</summary>
        public bool p_ReadOnly {
            get {
                return m_ReadOnly;
            }
            set {
                m_ReadOnly = value;
                if (m_ReadOnly)
                {
                    ContextMenuStrip = null;
                }
                else
                {
                    ContextMenuStrip = ctrlMenu;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="e_AllowItemDragChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnAllowItemDragChanged(EventArgs e)
        {
            EventHandler handler;
            handler = this.e_AllowItemDragChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private const int WM_PAINT = 0xF;
        private Color m_InsertionLineColor;
        protected int DragIndex { get; set; }
        protected Point DragOrigin { get; set; }
        protected int InsertionIndex { get; set; }
        protected I_InsertionMode InsertionMode { get; set; }
        protected bool IsDragging { get; set; }
        private const int InvalidIndex = -1;

        #region Events
        /// <summary>
        /// Occurs when the AllowItemDrag property value changes.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler e_AllowItemDragChanged;

        /// <summary>
        /// Occurs when the InsertionLineColor property value changes.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler InsertionLineColorChanged;

        ///// <summary>
        ///// Occurs when the user begins dragging an item.
        ///// </summary>
        //[Category("Drag Drop")]
        //public event EventHandler<ListBoxItemDragEventArgs> ItemDrag;

        ///// <summary>
        ///// Occurs when a drag-and-drop operation for an item is completed.
        ///// </summary>
        //[Category("Drag Drop")]
        //public event EventHandler<CancelListBoxItemDragEventArgs> ItemDragging;
        #endregion


        private Ctrl_TreeElements m_ToolboxService = null;
        public Ctrl_TreeElements p_ToolboxService {
            get { return m_ToolboxService; }
            set {
                m_ToolboxService = value;
                //if (m_ToolboxService != null)
                //{
                //    serviceContainer.AddService(typeof(IToolboxService), m_ToolboxService);
                //    m_ToolboxService.m_DesignPanel = this;
                //    //PopulateToolbox(p_ToolboxService);
                //}
            }
        }

        #region Name
        public string f_CreateName(System.Type a_DataType)
        {
            return f_CreateName(a_DataType.Name);

        }

        public string f_CreateName(string a_Name)
        {
            int i = 0;
            string name = a_Name;
            while (true)
            {
                i++;
                if (Controls[name + i.ToString()] == null)
                    break;
            }
            return name + i.ToString();
        }
        #endregion

        //protected override void OnResize(EventArgs eventargs)
        //{
        //    base.OnResize(eventargs);

        //}



        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_PAINT:
                    this.OnWmPaint(ref m);
                    break;
            }
        }

        protected virtual void OnWmPaint(ref Message m)
        {
            this.DrawInsertionLine();
        }

        private void DrawInsertionLine()
        {
            if (this.InsertionIndex != InvalidIndex)
            {
                int index;

                index = this.InsertionIndex;

                if (index >= 0 && index < this.Items.Count)
                {
                    Rectangle bounds;
                    int x;
                    int y;
                    int width;

                    bounds = this.GetItemRectangle(this.InsertionIndex);
                    x = 0; // aways fit the line to the client area, regardless of how the user is scrolling
                    y = this.InsertionMode == I_InsertionMode.Before ? bounds.Top : bounds.Bottom;
                    width = Math.Min(bounds.Width - bounds.Left, this.ClientSize.Width); // again, make sure the full width fits in the client area

                    this.DrawInsertionLine(x, y, width);
                }
            }
        }

        private void DrawInsertionLine(int x1, int y, int width)
        {
            using (Graphics g = this.CreateGraphics())
            {
                Point[] leftArrowHead;
                Point[] rightArrowHead;
                int arrowHeadSize;
                int x2;

                x2 = x1 + width;
                arrowHeadSize = 7;
                leftArrowHead = new[]
                                {
                          new Point(x1, y - (arrowHeadSize / 2)), new Point(x1 + arrowHeadSize, y), new Point(x1, y + (arrowHeadSize / 2))
                        };
                rightArrowHead = new[]
                                 {
                           new Point(x2, y - (arrowHeadSize / 2)), new Point(x2 - arrowHeadSize, y), new Point(x2, y + (arrowHeadSize / 2))
                         };

                using (Pen pen = new Pen(this.m_InsertionLineColor))
                {
                    g.DrawLine(pen, x1, y, x2 - 1, y);
                }

                using (Brush brush = new SolidBrush(this.m_InsertionLineColor))
                {
                    g.FillPolygon(brush, leftArrowHead);
                    g.FillPolygon(brush, rightArrowHead);
                }
            }
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index != -1)
            {
                if (Items[e.Index] is Ctrl_Element)
                {
                    Ctrl_Element el = (Ctrl_Element)Items[e.Index];
                    el.f_Draw(e.Graphics, e.Bounds);
                }
            }
        }

        /// <summary>
        /// Invalidates the specified item, including the adjacent item depending on the current <see cref="InsertionMode"/>.
        /// </summary>
        /// <param name="index">The index of the item to invalidate.</param>
        protected void Invalidate(int index)
        {
            if (index != InvalidIndex)
            {
                Rectangle bounds;
                bounds = this.GetItemRectangle(index);
                if (this.InsertionMode == I_InsertionMode.Before && index > 0)
                {
                    bounds = Rectangle.Union(bounds, this.GetItemRectangle(index - 1));
                }
                else if (this.InsertionMode == I_InsertionMode.After && index < this.Items.Count - 1)
                {
                    bounds = Rectangle.Union(bounds, this.GetItemRectangle(index + 1));
                }
                this.Invalidate(bounds);
            }
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if (this.IsDragging)
            {
                int insertionIndex;
                I_InsertionMode insertionMode;
                Point clientPoint;

                clientPoint = this.PointToClient(new Point(drgevent.X, drgevent.Y));
                insertionIndex = this.IndexFromPoint(clientPoint);

                if (insertionIndex != InvalidIndex)
                {
                    Rectangle bounds;

                    bounds = this.GetItemRectangle(insertionIndex);
                    insertionMode = clientPoint.Y < bounds.Top + (bounds.Height / 2) ? I_InsertionMode.Before : I_InsertionMode.After;

                    drgevent.Effect = DragDropEffects.Move;
                }
                else
                {
                    insertionIndex = InvalidIndex;
                    insertionMode = I_InsertionMode.None;

                    drgevent.Effect = DragDropEffects.None;
                }

                if (insertionIndex != this.InsertionIndex || insertionMode != this.InsertionMode)
                {
                    this.Invalidate(this.InsertionIndex); // clear the previous item
                    this.InsertionMode = insertionMode;
                    this.InsertionIndex = insertionIndex;
                    this.Invalidate(this.InsertionIndex); // draw the new item
                }
            }

            base.OnDragOver(drgevent);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            //base.OnDragLeave(e);
            //pasteEl = null;
            this.Invalidate(this.InsertionIndex);
            this.InsertionIndex = InvalidIndex;
            this.InsertionMode = I_InsertionMode.None;

            base.OnDragLeave(e);

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.IsDragging = false;
                this.DragOrigin = e.Location;
                this.DragIndex = this.IndexFromPoint(e.Location);
            }
            else
            {
                this.DragOrigin = Point.Empty;
                this.DragIndex = InvalidIndex;
                if (e.Button == MouseButtons.Right)
                {
                    var index = IndexFromPoint(e.Location);
                    if (index != ListBox.NoMatches)
                    {
                        Control ctrl = Items[index] as Control;
                        if (ctrl != null)
                        {
                            SelectedIndex = index;
                            if (ctrl.ContextMenuStrip != null)
                            {
                                ctrl.ContextMenuStrip.Show(Cursor.Position);
                                ctrl.ContextMenuStrip.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.p_AllowItemDrag && !this.IsDragging && e.Button == MouseButtons.Left && this.f_IsOutsideDragZone(e.Location))
            {
                this.IsDragging = true;
                this.DoDragDrop(this.DragIndex, DragDropEffects.Move);
            }
            base.OnMouseMove(e);
        }

        private bool f_IsOutsideDragZone(Point location)
        {
            Rectangle dragZone;
            int dragWidth;
            int dragHeight;

            dragWidth = SystemInformation.DragSize.Width;
            dragHeight = SystemInformation.DragSize.Height;
            dragZone = new Rectangle(this.DragOrigin.X - (dragWidth / 2), this.DragOrigin.Y - (dragHeight / 2), dragWidth, dragHeight);

            return !dragZone.Contains(location);
        }

        protected bool f_HasElements(Cl_Element[] a_Elemnts)
        {
            foreach (Ctrl_Element el in Items)
            {
                if (a_Elemnts.Contains(el.p_Element))
                    return true;
            }
            return false;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            string[] formats = e.Data.GetFormats();
            foreach (string format in formats)
            {
                var item = e.Data.GetData(format);
                if (item is Ctrl_TreeNodeElement || item is Ctrl_TreeNodeTemplate)
                {
                    if (item is Ctrl_TreeNodeElement)
                    {
                        Ctrl_TreeNodeElement nodeEl = (Ctrl_TreeNodeElement)item;
                        if (f_HasElements(new Cl_Element[] { nodeEl.p_Element }))
                        {
                            e.Effect = DragDropEffects.None;
                            return;
                        }
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
            }
            e.Effect = e.AllowedEffect;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (this.IsDragging)
            {
                try
                {
                    if (this.InsertionIndex != InvalidIndex)
                    {
                        int dragIndex;
                        int dropIndex;

                        dragIndex = (int)drgevent.Data.GetData(typeof(int));
                        dropIndex = this.InsertionIndex;

                        if (dragIndex < dropIndex)
                        {
                            dropIndex--;
                        }
                        if (this.InsertionMode == I_InsertionMode.After && dragIndex < this.Items.Count - 1)
                        {
                            dropIndex++;
                        }

                        if (dropIndex != dragIndex)
                        {
                            //ListBoxItemDragEventArgs args;
                            Point clientPoint;

                            clientPoint = this.PointToClient(new Point(drgevent.X, drgevent.Y));
                            //args = new ListBoxItemDragEventArgs(dragIndex, dropIndex, this.InsertionMode, clientPoint.X, clientPoint.Y);

                            //this.OnItemDrag(args);

                            //if (!args.Cancel)
                            {
                                object dragItem;

                                dragItem = this.Items[dragIndex];

                                this.Items.Remove(dragItem);
                                this.Items.Insert(dropIndex, dragItem);
                                this.SelectedItem = dragItem;
                            }
                        }
                    }
                }
                finally
                {
                    this.Invalidate(this.InsertionIndex);
                    this.InsertionIndex = InvalidIndex;
                    this.InsertionMode = I_InsertionMode.None;
                    this.IsDragging = false;
                }
            }
            else
            {
                if (drgevent.Data.GetData(drgevent.Data.GetFormats()[0]) is Control)
                {
                    f_DragControl(drgevent.Data.GetData(drgevent.Data.GetFormats()[0]) as Control, drgevent.X, drgevent.Y);
                }
                else if (drgevent.Data.GetData(drgevent.Data.GetFormats()[0]) is Ctrl_TreeNodeElement)
                {
                    f_DragNewControl(drgevent.Data.GetData(drgevent.Data.GetFormats()[0]) as Ctrl_TreeNodeElement, drgevent.X, drgevent.Y);
                }
            }

            base.OnDragDrop(drgevent);
        }

        private void f_DragControl(Control control, int x, int y)
        {
            if (control == null)
                return;
            //control.Location = PointToClient(new Point(x - deltaX, y - deltaY));
        }



        private void f_DragNewControl(Ctrl_TreeNodeElement controlNode, int posX, int posY)
        {
            if (controlNode == null)
                return;
            if (controlNode.p_Element == null)
                return;

            Ctrl_Element ctrlEl = new Ctrl_Element();
            ctrlEl.p_Element = controlNode.p_Element;
            ctrlEl.Name = f_CreateName(ctrlEl.p_Name);
            Items.Add(ctrlEl);
        }

        #region Menu
        private void ctrlMenuDel_Click(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                if (SelectedItem is Ctrl_Element)
                {
                    Ctrl_Element el = (Ctrl_Element)SelectedItem;

                    Items.Remove(el);
                }
            }
        }
        #endregion
    }
}
