Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls


Namespace WindowsApplication3
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private imageSize As New Size(15, 15)

        Public Sub InitData()
            dataSet11.Tables(0).Rows.Add(1, "Honda", 1)
            dataSet11.Tables(0).Rows.Add(2, "Mazda", 2)
            dataSet11.Tables(0).Rows.Add(3, "Nissan", 3)
            dataSet11.Tables(0).Rows.Add(4, "Subaru", 4)
            dataSet11.Tables(0).Rows.Add(5, "Toyota", 5)
            dataSet11.Tables(0).Rows.Add(6, "Chrysler", 6)
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            InitData()
        End Sub

        Private Sub OnShowFilterPopupListBox(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs) Handles gridView1.ShowFilterPopupListBox
            RemoveHandler e.ComboBox.DrawItem, AddressOf OnDrawItem
            AddHandler e.ComboBox.DrawItem, AddressOf OnDrawItem
        End Sub

        Private Sub OnDrawItem(ByVal sender As Object, ByVal e As ListBoxDrawItemEventArgs)
            Dim fComboBox As ColumnFilterPopup.FilterComboBox = TryCast(sender, ColumnFilterPopup.FilterComboBox)
            Dim fItem As FilterItem = TryCast(e.Item, FilterItem)
            If fItem Is Nothing OrElse TypeOf fItem.Value Is FilterItem Then
                Return
            End If
            Dim iItem As ImageComboBoxItem = GetItem(fItem)
            If iItem Is Nothing Then
                Return
            End If
            FillBackground(e)
            DrawImage(e, iItem)
            DrawDescription(e, iItem)
            e.Handled = True
        End Sub

        Private Sub FillBackground(ByVal e As ListBoxDrawItemEventArgs)
            e.Appearance.FillRectangle(e.Cache, e.Bounds)
        End Sub

        Private Sub DrawDescription(ByVal e As ListBoxDrawItemEventArgs, ByVal iItem As ImageComboBoxItem)
            Dim textRect As Rectangle = e.Bounds
            textRect.X += imageSize.Width + 3
            e.Appearance.DrawString(e.Cache, iItem.Description, textRect)
        End Sub

        Private Sub DrawImage(ByVal e As ListBoxDrawItemEventArgs, ByVal iItem As ImageComboBoxItem)
            Dim img As Image = GetImage(iItem)
            If img Is Nothing Then
                Return
            End If
            Dim imgRect As New Rectangle(e.Bounds.X + 2, e.Bounds.Y, imageSize.Width, imageSize.Height)
            e.Cache.Paint.DrawImage(e.Cache.Graphics, img, imgRect)
        End Sub

        Private Function GetImage(ByVal iItem As ImageComboBoxItem) As Image
            Dim imageList As ImageList = TryCast(iItem.Images, ImageList)
            Return imageList.Images(iItem.ImageIndex)
        End Function

        Private Function GetItem(ByVal fItem As FilterItem) As ImageComboBoxItem
            Return repositoryItemImageComboBox1.Items.GetItem(fItem.Value)
        End Function
    End Class
End Namespace
