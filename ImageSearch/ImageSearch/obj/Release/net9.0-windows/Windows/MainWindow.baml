   M S B A M L   `   `   `  ���� F  BImageSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ImageSearchImageSearch  9!clr-namespace:ImageSearch.WindowsImageSearch.Windows  5clr-namespace:ImageSearch.PagesImageSearch.Pages  ;"clr-namespace:ImageSearch.ControlsImageSearch.Controls      ImageSearch.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ImageSearch     A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  .window!clr-namespace:ImageSearch.Windows  *pageclr-namespace:ImageSearch.Pages  0control"clr-namespace:ImageSearch.Controls  T PEleCho.WpfSuite.Controls, Version=0.10.3.0, Culture=neutral, PublicKeyToken=nullR NEleCho.WpfSuite.Helpers, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullP	 LEleCho.WpfSuite.Input, Version=0.9.1.0, Culture=neutral, PublicKeyToken=nullR
 NEleCho.WpfSuite.Layouts, Version=0.9.1.0, Culture=neutral, PublicKeyToken=nullQ MEleCho.WpfSuite.Markup, Version=0.9.0.0, Culture=neutral, PublicKeyToken=nullP LEleCho.WpfSuite.Media, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullZ VEleCho.WpfSuite.ValueConverters, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null8ws#https://schemas.elecho.dev/wpfsuite   	 
    *  $EleCho.WpfSuite.Helpers.WindowOption    Backdrop$  MicaAlt=�
������ $	��600��$	��800��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=� � Title$ 卡面搜尋系統�� � Icon$ /Resources/icon_32.png��'  !System.Windows.Shell.WindowChrome   WindowChrome      GlassFrameThickness$ -1q�.��� -    �Name$ MainGrid��.+�)   #ImageSearch.Controls.CustomTitleBar  -     Name$ Titlebar��$��45,0,0,0q�   Title$ 卡面搜尋系統��	   	TitleSize$	 13��
   TitleWeight$

 Bold"�   Icon$ /Resources/Icon_32.png��   IconSize$ 22���� -    ��Name$ 
MenuButton��$��0��$��5q�$	��Top=�$
��Left=�   IsHitTestVisibleInChrome$
 True��
������ 
������ .���� $	��☰��$��16(�$
��Bold"�$��Center=�� -   $ ContentGrid��$��0,42,0,0q�.+�]� .+��� -    ��Name$
 Menu�� '  #CardBackgroundFillColorDefaultBrush#���   $��Stretch=�$
��Left=�$��5,0,0,5q� �� CornerRadius$ 5��._�]� -    ]�Name$ 	MenuPanel��$
��Left=�$��10q�.+�  Wpf.Ui.Controls.Button  -     Name$ SettingButton��$��Bottom=�$��Stretch=�.����  �� Orientation$ 
Horizontal=�$��Center=�.+�   Wpf.Ui.Controls.SymbolIcon  $��Center=�   Symbol$ 
Settings20=��� $��設定��$��5,0,0,0q�$��Center=�R� -    R�Name$ MenuList��$��Stretch=�$
��Left=�$	��200��.@�Q� -	    Q�Name$ Search������ $ 
Horizontal=�.+�  $��Center=�$ Search16=��� $��搜尋��$��5q� � -
     �Name$ PageContent��$��Stretch=�$��Stretch=�$��5,0,5,0q�� -   $ ProcessBarView�����	#90000000$y�	Collapsed=�.+�(� .�� � $
��1920��$
��1080����&    ImageSearch.Pages.ProcessBarPage  