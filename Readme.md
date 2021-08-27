<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128631779/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2573)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DataSet1.cs](./CS/WindowsApplication3/DataSet1.cs) (VB: [DataSet1.vb](./VB/WindowsApplication3/DataSet1.vb))
* [Form1.cs](./CS/WindowsApplication3/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication3/Form1.vb))
* [Program.cs](./CS/WindowsApplication3/Program.cs) (VB: [Program.vb](./VB/WindowsApplication3/Program.vb))
<!-- default file list end -->
# How to show images in the column's filter drop-down list


<p>Imagine, that you are using an in-place ImageComboBoxEdit for any grid column and you wish to show corresponding images along with the items' descriptions in the grid column's filter drop-down list.</p><p>To achieve the required result you need to follow these steps:</p><p>- handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShowFilterPopupListBoxtopic">GridView.ShowFilterPopupListBox event </a>;</p><p>- obtain the RepositoryItemComboBox instance by using the e.ComboBox property in this event handler;</p><p>- subscribe to the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsRepositoryRepositoryItemComboBox_DrawItemtopic">RepositoryItemComboBox.DrawItem event </a>;</p><p>- draw the filter combo box's content manually, as your needs dictate</p><p>This example illustrates this approach in action.</p>

<br/>


