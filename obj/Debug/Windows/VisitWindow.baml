   M S B A M L   `   `   `  ����M  IWpfAssortmentCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WpfAssortmentCheck.WindowsWpfAssortmentCheck.Windows  5   	   ,    &WpfAssortmentCheck.Windows.VisitWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      4local(clr-namespace:WpfAssortmentCheck.Windows  5   	     � Title$  Расписание��5
   
   $	��160��6   $	��800��6*      base_window_1#��[  66    � WindowStartupLocation$ CenterScreen=�6]   .��5      �  � RowDefinitions 5   
   �� 5      $	��90* �6   �� 5      $	��89* �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��187 �6   �� 5      .+�5   
   �� $��Абонемент��6   $��Center=�6%   $��0��6@   $��20 0 0 0q�6M   $��0��6`   $��30��6p   �� 5   
   -   5         ��Name$ TbInfo��5   >   $��1��6   $��Center=�6#   $��0��6N   $��30��6[   $	��0,7q�6g    �� 
IsReadOnly . 6t   �� 5   
   $��Время ��6   $��Center=�6"   $��1��6=   $��20 0 0 0q�6K   $��0��6^   $��20��6n   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5          Name$ DatePickerDate��5      $
��Left=�6l   $��1��5      $��1��6,   $	��240��6<   $��2��6H   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5   7   �� *
DateTime+ �� ConverterCulture$ ru-RU��5   H   �� 5   
   $��Center=�6   	 �� Orientation$	 
Horizontal=�62   $��5��6K   $��2��6X   $��127,0,103,0q�6l   $	��162��6�   .+�5       �� -   5        
 �� 	IsDefault
 . $��60��5    '   $��5q�65   .��6U   OK6Y   �� 5!       �� IsCancel . $��60��6%   $��5q�63   .��6>   Отмена6F   5"      5#      5$      