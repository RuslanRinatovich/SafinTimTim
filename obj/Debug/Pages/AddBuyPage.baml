   M S B A M L   `   `   `  ����M  IWpfAssortmentCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WpfAssortmentCheck.PagesWpfAssortmentCheck.Pages  5      )    #WpfAssortmentCheck.Pages.AddBuyPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:WpfAssortmentCheck.Pages     5      X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5           	base_page#��[  5
        N� Title$)  #Покупка абонемента��5   
   .��5      �  � RowDefinitions 5   
   �� 5      -   5         ��Name$ 
rwOrderNum��5   (   $��40 �6   6(   �� 5      $��90 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      -   5        $ rwPrice��5   (   $��40 �6   6(   �� 5      -   5        $ rwButton��5   (   $��60 �6   6(    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5!   
   �� $��0��6   $��2��6!   �� 5"   
   $��0��6   $��0��6   $&�� Номер абонемента:��6-   $��Center=�6I   $
��Left=�6e   $��20,6,0,6q�6�   $��18(�6�   $	��172��6�   �� 5#   
   -   5         ��Name$ 	tbOrderId��5#      $��0��6%   $��1��62   $��60��6B    �� 
IsReadOnly . $
��Left=�6`   $��18(�6�   $	��0,2q�6�   ��6{   �� *Id+6�   �� 5$   
   -   5         ��Name$ TbLessonsLeft��5$      $��0��6+   $��1��68   $��60 0 0 0q�6H   $��Right=�6Z   $��18(�6w    �� Padding$	 0,2q�6�   �� 5'   
   -   5        $ tbClient��5'      $��1��6$   $��1��61    . $��18(�6T   $	��0,2q�6b   �� 5(   
   $��1��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5)      �� $��Клиент:��6   $	��Top=�6'   $
��Left=�6@   $
��20,0q�6[   $��18(�6i   �� 5*      -   5        	 ��Name$	 btnLoadClient��5*      $	��Top=�6,   $��Right=�6E   $��0q�6a   $��40��6n   .��5+      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Search=�6*   5,      5-      �� 5.   
   $��Абонемент ��6   $��Center=�6&   $��4��6A   $��20 0 0 0q�6O   $��0��6b   $��20��6r   $��18(�6~   �� 5/   
   $��Дата покупки ��6   $��Center=�6)   $��5��6D   $��20 0 0 0q�6R   $��0��6e   $��20��6u   $��18(�6�   �� 52   
   $��3��6   $��0��6!   $��Учитель��61   $��20 0 0 0q�6B   $��Center=�6U   $��18(�6q   �� 53   
   $��2��6   $��0��6!   $��Программа��61   $��20 0 0 0q�6D   $��Center=�6W   $��18(�6r   �� 54   
   -	   5         ��Name$ ComboCategory��54      $��2��6M   $��18(�6Z   $��1��6h    �� DisplayMemberPath$
 Name��6y    �� SelectedValuePath$ Id��55       �� SelectedItem 54   +   �� *
Category+55   *   �� 56   
   -
   5        $ ComboTrainer��56      $ Id��6*   $��3��6B   $��1��6O   $��18(�6_   ��57      �� 58      .R�59      �� $ 
Horizontal=�6!   .+�5:      �� $��15��6<   $��5 0 5 0q�6G   ��6    �� *
GetPhoto+6G   �� 5;      ��6$   �� *GetFio+5<      5=      5?      �� 5@   
   -   5        $ ComboAbonement��5@      $��4��6-   $��1��6:   $ Id��6J   $��18(�6a   ��5A      �� 5B      .R�5C      �� $ 
Horizontal=�6!   .+�5D      �� $��Center=�6,   $��Center=�6G   $
��Bold"�6d    
 akcent#��[ 5E   _   ��6%   �� *LessonCount+ �� StringFormat$ {0} занятий��6_   �� 5F      $��Center=�6-   $��Center=�6H   ���	#FF18BADE$
��Bold"�6}   ��5G   %   �� *Price+$ c�� �� ConverterCulture$ ru-RU��5I      5J      5L      &   Xceed.Wpf.Toolkit.DateTimePicker  5N   
   -   5          Name$ DatePickerDate��5N      $��5��66   $��1��6C   $��20 0 0 0q�6S   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   CultureInfo$ ru-RU��6�   $��18(�6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6g   �� *
DateTime+6�   �� 5O   
   $��6��6   $��0��6   $(��"Статус абонемента:��6-   $��Center=�6J   $
��Left=�6f   $
��20,0q�6�   $��18(�6�   �� 5P   
   -   5        $ ComboStatus��5P      $��6��6I   $��1��6V   $
 Name��6g   $��18(�6�   $ Id��5Q       5P   )   �� *Status+5Q      �� 5S   
   $ 
Horizontal=�6   $��7��6/   $��2��6<   $��10q�6P   $��Center=�6\   .+�5T      �� -   5        $	 btnSave��5T      $��Сохранить��6'   $��Center=�6<   $��Bottom=�6Y   $	��120��6t   6�   �� 5U      -   5        $	 btnExcel��5U      $��Квитанция��6(   $��Center=�6=   $��Bottom=�6Z   $	��120��6u   $y�	Collapsed=�6�   6�   5V      )  #MaterialDesignThemes.Wpf.DialogHost  5X   
   -   5          Name$ hostLoadClient��5X   E   $��8��6$   $��2��61   $��1q�5Y   $   $��Center=�5Z   $   $��Center=�5[   $      DialogContent 5\      �� 5]      $��20q�6   .+�5^      �� -   5         ��Name$ lbClient��5^      $��2��60   $
��Auto=�6=   $ AirID��6o   $	��600��6�   ��5_      �� 5`      .R�5b   "   �� .+�5c   &   �� $��18(�60   $
��Left=�6]   ��6>   ��  �� Path$ UserName�6]   �� 5d   &   $��18(�60   $
��Left=�6]   ��6>   �� $ LastName�6]   �� 5e   &   $��18(�60   $
��Left=�6^   ��6>   �� $ 	FirstName�6^   �� 5f   &   $��14(�60   $
��Left=�6Z   $��WrapWithOverflow=�6u   $	��500��6�   ��6>   �� $ Phone�6�   5g   #   5i      5k      �� 5l      $ 
Horizontal=�6!   $��Center=�6:   .+�5m      �� -   5        $	 btnClientOK��5m   !   .��5n      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5o   "     $
 Check=�6:   $��5q�6H   $��Center=�6S   �� 5p   "   $��OK��6,   $��Center=�66   5q      5r      �� 5s      -   5        $	 btnClientCancel��5s   !   .��5t      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5u   "     $
 Cancel=�6:   $��5q�6I   $��Center=�6T   �� 5v   "   $��Cancel��6,   $��Center=�6:   5w      5x      5y      5z      5|      5~      5      