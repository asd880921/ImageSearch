   M S B A M L   `   `   `  ���� F  BImageSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ImageSearch.PagesImageSearch.Pages  "    ImageSearch.Pages.SearchPage   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:ImageSearch.Pages     A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml    N� Title$  
SearchPage��.��� $��5q�.+��� $��卡面搜尋��   TextFillColorPrimaryBrush#���   $��30(�$
��Bold"�$
��Left=�$	��Top=�]� $��	8,54,8,50q�.+�� $	��Top=� � ColumnDefinitions �� $��* ��� $��* �.+�� $��0��.+��� $��6,4,0,0q�.+��� $��團體名稱 :��$��16(�$
��Bold"�#���   $	��Top=�$
��Left=��� -    ��Name$ Team_ComboBox��$��14(�$	��200��#���   $	��Top=�$��Stretch=�$��0,10,4,0q�� $��1��.+��� $��檢查矩形��$��16(�$
��Bold"�#���   $	��Top=�$��Right=�$��0,0,4,0q�"  Wpf.Ui.Controls.ToggleSwitch  -     Name$ 	CheckRect��#���   $	��Top=�$��Right=�$��0,0,80,0q��� $��擴大搜尋��$��16(�$
��Bold"�#���   $	��Top=�$��Right=�$��0,30,4,0q�  -   $ ExpandSearch��#���   $	��Top=�$��Right=�$��	0,30,80,0q�� $��0,16,0,0q�$	��Top=� �� $��* ��� $��* �.+�� $��0��.+��� $��6,0,4,0q�.+�  Wpf.Ui.Controls.Button  -     Name$ SearchButton��$��搜尋資料夾��$
��Bold"�#���   $	��Top=�$��Stretch=�� $��1��$��4,0,0,0q�.+�  -   $ PublishButton��$��發佈資料夾��$
��Bold"�#���   $	��Top=�$��Stretch=��� -    ��Name$ ContentInput��$	��Top=�$��0,16,0,0q�$��Stretch=� �� AcceptsReturn$
 True�� �� TextWrapping$
 Wrap=� �� 
IsReadOnly$
 True��  -   $ StartSearchButton��$��開始搜尋��$��Bottom=�$��Stretch=�$��8q�