   M S B A M L   `   `   `  ����F  BImageSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ImageSearch.ControlsImageSearch.Controls  5      )    #ImageSearch.Controls.CustomTitleBar   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:ImageSearch.Controls     5      $��42��5      $	��Top=�5	      $��Stretch=�5
        � 	Resources  5         TitleBarDefaultButtonStyle �� 
TargetType �� Property �� Value  TextFillColorPrimaryBrush'  !System.Windows.Shell.WindowChrome �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value ' #ControlAltFillColorQuarternaryBrush
 ^� 
Conditions �� Binding �� Path �� Value �� RelativeSource �� Mode " SystemColorHighlightColorBrush & "SystemColorHighlightTextColorBrush # TitleBarDefaultCloseButtonStyle �� BasedOn��%�  &	        &	 �    7   �� 5   
   " ��63   .�5      ��  � ��$ 48��6)   �� 5       � ��$ 32��6*   �� 5       � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��# �  6+   �� 5       � ��$	 Top=�62   �� 5        �@ IsHitTestVisibleInChrome$
 True��6F   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ EnclosingBorder��6!   #��z��5      #��z��5      #��z��5      $
 True��5      ._�5      �� #��z��6/   #��z��5   !   $
��True��5   !   # z 5    !   5!      5"      5$       5%      P� 5&       �@J�IsMouseOver$
	 True��61   . �5'      ��  � ��# �  63   5(      ^� 5)      
 5*      �� 5+       6$   �� $% (SystemParameters.HighContrast)� True6]   �� 5,       6$   �� *IsMouseOver+ �� $
 Self=� True6o   .0�5.      ��  � ��# �  63   �� 5/       � ��# �  63   50      52      �� 54   
   8   " ��6n    55      P� 56       �@J�IsMouseOver$
	 True��61   . �57      ��  � �� �#C42B1C63   �� 58       � ��
 �����63   59      ^� 5:      
 5;      �� 5<       6$   �� $% (SystemParameters.HighContrast)� True6]   �� 5=       6$   �� *IsMouseOver+ �� $
 Self=� True6o   .0�5?      ��  � ��# �  63   �� 5@       � ��# �  63   5A      5C      5D      .��5F      � -   5         �Name$ TitlebarGrid��5F      $��0��5G   	   $��42��5H   	    � ColumnDefinitions 5I   
   �� 5J      $��* �6   �� 5K      $
��Auto �6   �� 5L      $
��Auto �6   �� 5M      $
��Auto �6   .+�5P   
   �� $��0��6   $��4,0,0,0q�5Q       �� Orientation$ 
Horizontal=�5R      .+�5S      �� -   5         ��Name$ 	TitleIcon��5S      $��24��5T      $��Center=�5U      $y�	Collapsed=�5V      �� 5W      -   5         ��Name$ 	TitleText��5W      $��16,0,0,0q�5X      $��Center=�5Y        CaptionTextBlockStyle#��[ 5Z      $��	TitleText��5[      5\      �� 5^   
   -   5         ��Name$ MinimizeButton��5^      $��1��5_      #��[  5a      .��5b      �� $��Center=�6     SymbolThemeFontFamily#��[ 5c      $��10(�5d      $	����5e      5f      �� 5h   
   -   5        $ MaximizeButton��5h      $��2��5i      #��[  5k      .��5l      �� -   5        $ MaximizeIcon��5l      $��Center=�5m      #��[ 5n      $��10(�5o      $	����5p      5q      �� 5s   
   -   5        $ CloseButton��5s      $��3��5t      #��[ 5v      .��5w      �� $��Center=�6   #��[ 5x      $��16(�5y      $	����5z      5{      5}      5      