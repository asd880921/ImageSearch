   M S B A M L   `   `   `  ���� F  BImageSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ImageSearch.ControlsImageSearch.Controls  )    #ImageSearch.Controls.CustomTitleBar   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:ImageSearch.Controls     $��42��$	��Top=�$��Stretch=�  � 	Resources     TitleBarDefaultButtonStyle �� 
TargetType �� Property �� Value  TextFillColorPrimaryBrush'  !System.Windows.Shell.WindowChrome �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value ' #ControlAltFillColorQuarternaryBrush
 ^� 
Conditions �� Binding �� Path �� Value �� RelativeSource �� Mode " SystemColorHighlightColorBrush & "SystemColorHighlightTextColorBrush # TitleBarDefaultCloseButtonStyle �� BasedOn��%c  &	        &	 1    7   �� " ��.���  � ��$ 48����  � ��$ 32����  � ��
 ���� ��  � ��
 ���� ��  � ��# �  ��  � ��$	 Top=���   �@ IsHitTestVisibleInChrome$
 True����  � �� �� " ��.R��� $ EnclosingBorder��#��z��#��z��#��z��$
 True��._��� #��z��#��z��$
��True��# z  P�  �@J�IsMouseOver$
	 True��. ���  � ��# �  ^� 
 ��  �� $% (SystemParameters.HighContrast)� True��  �� *IsMouseOver+ �� $
 Self=� True.0���  � ��# �  ��  � ��# �  �� 8   " �� P�  �@J�IsMouseOver$
	 True��. ���  � �� �#C42B1C��  � ��
 �����^� 
 ��  �� $% (SystemParameters.HighContrast)� True��  �� *IsMouseOver+ �� $
 Self=� True.0���  � ��# �  ��  � ��# �  .��� -    �Name$ TitlebarGrid��$��0��$��42�� � ColumnDefinitions �� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��4,0,0,0q� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ 	TitleIcon��$��24��$��Center=�$y�	Collapsed=��� -    ��Name$ 	TitleText��$��16,0,0,0q�$��Center=�  CaptionTextBlockStyle#��[ $��	TitleText���� -    ��Name$ MinimizeButton��$��1��#��[  .���� $��Center=�  SymbolThemeFontFamily#��[ $��10(�$	������ -   $ MaximizeButton��$��2��#��[  .���� -   $ MaximizeIcon��$��Center=�#��[ $��10(�$	������ -   $ CloseButton��$��3��#��[ .���� $��Center=�#��[ $��16(�$	����