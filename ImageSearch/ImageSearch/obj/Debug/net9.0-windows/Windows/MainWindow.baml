   M S B A M L   `   `   `  ����F  BImageSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ImageSearchImageSearch  5   	   9!clr-namespace:ImageSearch.WindowsImageSearch.Windows  5   	   5clr-namespace:ImageSearch.PagesImageSearch.Pages  5	   	   ;"clr-namespace:ImageSearch.ControlsImageSearch.Controls  5
   	       ImageSearch.MainWindow   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ImageSearch     5   	   A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   .window!clr-namespace:ImageSearch.Windows  5   	   *pageclr-namespace:ImageSearch.Pages  5	   	   0control"clr-namespace:ImageSearch.Controls  5
   	   T PEleCho.WpfSuite.Controls, Version=0.10.3.0, Culture=neutral, PublicKeyToken=nullR NEleCho.WpfSuite.Helpers, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullP	 LEleCho.WpfSuite.Input, Version=0.9.1.0, Culture=neutral, PublicKeyToken=nullR
 NEleCho.WpfSuite.Layouts, Version=0.9.1.0, Culture=neutral, PublicKeyToken=nullQ MEleCho.WpfSuite.Markup, Version=0.9.0.0, Culture=neutral, PublicKeyToken=nullP LEleCho.WpfSuite.Media, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullZ VEleCho.WpfSuite.ValueConverters, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null8ws#https://schemas.elecho.dev/wpfsuite   	 
    5   	   $	��600��5   	   $	��800��6   $	��600��5   	   $	��800��6     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 卡面搜尋系統��5   	    � Icon$ /Resources/icon_32.png��6   .��5      � -   5         �Name$ MainGrid��5      .+�5   
   )   #ImageSearch.Controls.CustomTitleBar  -   5          Name$ Titlebar��5   !   $��45,0,0,0q�5         Title$ 卡面搜尋系統��5         	TitleSize$ 13��5         TitleWeight$
 Bold"�5         Icon$ /Resources/Icon_32.png��5      	   IconSize$	 22��5      �� 5   
   -   5        
 ��Name$
 
MenuButton��5      $��0��5      $��5q�5      $	��Top=�5      $
��Left=�5      '  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome$
 True��5       
������ 
������ .��5$      �� $	��☰��6   $��16(�6!   $
��Bold"�6/   $��Center=�6A   5%      � 5'   
   -   5        $ ContentGrid��5'      $��0,42,0,0q�6$   .+�5(      ]� .+�5)      �� -   5         ��Name$
 Menu��5)       '  #CardBackgroundFillColorDefaultBrush#���   5*      $��Stretch=�5+      $
��Left=�5,      $��5,0,0,5q�5-       �� CornerRadius$ 5��5.      ._�50      ]� -   5         ]�Name$ 	MenuPanel��50       $
��Left=�51      $��10q�52      .+�55        Wpf.Ui.Controls.Button  -   5          Name$ SettingButton��55   $   $��Bottom=�56      $��Stretch=�57      .��59      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5:   "      Wpf.Ui.Controls.SymbolIcon  $��Center=�60      Symbol$ 
Settings20=�6K   �� 5;   "   $��設定��6,   $��5,0,0,0q�66   $��Center=�6G   5<      5=      R� 5@      -   5         R�Name$ MenuList��5@   #   $��Stretch=�5A      $
��Left=�5B      $	��200��5C      .@�5G      Q� -	   5         Q�Name$ Search��5G   +   ��5H   "   �� 5I   &   $ 
Horizontal=�61   .+�5J   *     $��Center=�68   $ Search16=�6S   �� 5K   *   $��搜尋��64   $��5q�6>   5L   '   5N      5P      5Q      5S       � 5U      -
   5          �Name$ PageContent��5U      $��Stretch=�6-   $��Stretch=�6K   $��5,0,5,0q�6g   5W      5X      � 5Z   
   -   5        $ ProcessBarView��5Z      ���	#90000000$y�	Collapsed=�6>   .+�5\      (� .��5]       � $
��1920��6   $
��1080��6%   ��5^      &    ImageSearch.Pages.ProcessBarPage  5_      5a      5b      5c      5d      5e      