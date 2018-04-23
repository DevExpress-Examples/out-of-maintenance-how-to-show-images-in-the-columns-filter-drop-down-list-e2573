using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;


namespace WindowsApplication3 {
    public partial class Form1: XtraForm {
        public Form1() {
            InitializeComponent();
        }

        Size imageSize = new Size(15, 15);

        public void InitData() {
            dataSet11.Tables[0].Rows.Add(1, "Honda", 1);
            dataSet11.Tables[0].Rows.Add(2, "Mazda", 2);
            dataSet11.Tables[0].Rows.Add(3, "Nissan", 3);
            dataSet11.Tables[0].Rows.Add(4, "Subaru", 4);
            dataSet11.Tables[0].Rows.Add(5, "Toyota", 5);
            dataSet11.Tables[0].Rows.Add(6, "Chrysler", 6);
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitData();
        }

        private void OnShowFilterPopupListBox(object sender, DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs e) {
            e.ComboBox.DrawItem -= OnDrawItem;
            e.ComboBox.DrawItem += OnDrawItem;
        }

        void OnDrawItem(object sender, ListBoxDrawItemEventArgs e) {
            ColumnFilterPopup.FilterComboBox fComboBox = sender as ColumnFilterPopup.FilterComboBox;
            FilterItem fItem = e.Item as FilterItem;
            if(fItem == null || fItem.Value is FilterItem) return;
            ImageComboBoxItem iItem = GetItem(fItem);
            if(iItem == null) return;
            FillBackground(e);
            DrawImage(e, iItem);
            DrawDescription(e, iItem);
            e.Handled = true;
        }

        private void FillBackground(ListBoxDrawItemEventArgs e) {
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
        }

        private void DrawDescription(ListBoxDrawItemEventArgs e, ImageComboBoxItem iItem) {
            Rectangle textRect = e.Bounds;
            textRect.X += imageSize.Width + 3;
            e.Appearance.DrawString(e.Cache, iItem.Description, textRect);
        }

        private void DrawImage(ListBoxDrawItemEventArgs e, ImageComboBoxItem iItem) {
            Image img = GetImage(iItem);
            if(img == null) return;
            Rectangle imgRect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, imageSize.Width, imageSize.Height);
            e.Cache.Paint.DrawImage(e.Cache.Graphics, img, imgRect);
        }

        private Image GetImage(ImageComboBoxItem iItem) {
            ImageList imageList = iItem.Images as ImageList;
            return imageList.Images[iItem.ImageIndex];
        }

        private ImageComboBoxItem GetItem(FilterItem fItem) {
            return repositoryItemImageComboBox1.Items.GetItem(fItem.Value);
        }
    }
}
