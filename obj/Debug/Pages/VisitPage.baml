   M S B A M L   `   `   `  ����M  IWpfAssortmentCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WpfAssortmentCheck.PagesWpfAssortmentCheck.Pages  5      (    "WpfAssortmentCheck.Pages.VisitPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:WpfAssortmentCheck.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$  Посещение��5
         	base_page#��[  6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��2��6.   .+�5      �� $)��#Выберите абонемент��6    $  MaterialDesignSubtitle2TextBlock#��[ 66   �� 5      -   5         ��Name$ 
ComboGoods��5   5   $��Stretch=�6   $	��600��6I    �� SelectedValuePath$ Id��5       �� DisplayMemberPath$ GetInfo��5      5      #  MaterialDesignThemes.Wpf.Card  5   
   -   5          Name$ CardTrainer��5   7   $	��300��6   $	��400��6*   $	��Top=�6L   $��1��6d   ��6q   �� *Status.Color+.��5      � .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ SecondaryMid=�6    5      �� 5       $��80 �6+   �� 5!      $	��200 �6+   �� 5"      $��* �6+   .+�5%      �� $��0��6   $��10q�6/   $��Center=�6<   .+�5'      ��  
 akcent#��[ 6^   $
��Wrap=�6�   $��Center=�6�   $
��Bold"�5(   2   $��10q�6D   $��16(�5)   1   ��5'   $   �� *)'Abonement.CategoryTrainer.Category.Name+5)   1   5*      �� 5+      $��1��6]   $	��200��6k   $	��260��6y   $��10q�6�   $��Uniform=�6�   ��6   �� 	 �� Path$0	 *Abonement.CategoryTrainer.Trainer.GetPhoto�6�   �� 5-      $��2��6!   $��10q�63   $��Center=�6?   .+�5.      �� $
��Wrap=�6_   $��Center=�6s   $
��Bold"�5/   2   $��14(�50   1   ��5.   %   �� **(Abonement.CategoryTrainer.Trainer.GetFio+50   1   �� 51      $��Center=�6(   $��Center=�6C   $
��Bold"�6`   $��5q�52   m   
���  ����6%   �� *LessonsLeftCount+
 �� StringFormat$*
 $ осталось {0} занятий��6x   55      58      59      &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ DtData��5=         AutoGenerateColumns .  $��1��6@   $��1��6M      
IsReadOnly .    SelectionMode$ Single =�5?         Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ № п��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Id+  5B      $ Дата и время��6%    6;   �� *
DateTime+ �� ConverterCulture$ ru-RU��5F      �� 5G   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6f   .+�5H      �� -   5         ��Name$ btnAdd��5H      $��Добавить��6%   68   �� 5I      -   5        $ 	btnDelete��5I      $��Удалить��6(   6:   5J      5L      5M      