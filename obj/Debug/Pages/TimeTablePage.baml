   M S B A M L   `   `   `  ����M  IWpfAssortmentCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WpfAssortmentCheck.PagesWpfAssortmentCheck.Pages  5      ,    &WpfAssortmentCheck.Pages.TimeTablePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:WpfAssortmentCheck.Pages     5        N� Title$  Расписание��5	   	      	base_page#��[  6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��2��6.   .+�5      �� $%��Выберите учителя��6    $  MaterialDesignSubtitle2TextBlock#��[ 64   �� 5      -   5         ��Name$ 
ComboGoods��5   5   $��Stretch=�6   $	��400��6I    �� SelectedValuePath$ Id��5       �� DisplayMemberPath$ GetFio��5      5      � 5   
   -   5         �Name$ GridGood��5      $	��300��6!   $��1��6-   $��0��6:    5      �� 5      $	��310 �6    �� 5!      $
��auto �6    .+�5$      �� $	��240��6   $��0��6    $��Uniform=�6-   $��Center=�5%       ��5&       ��  �� Path$ GetPhoto��� 5'      $��1��65   $
��Wrap=�6B   	 �� TextAlignment$	 Center=�6V    
 akcent#��[ 6m   $��Center=�5(   1   $
��Bold"�6N   $��Center=�6`   $��14(�5)   1   $��10q�6?   $	��280��6K   ��5'      �� *GetFio+5)   K   5,      &   System.Windows.Controls.DataGrid  5-   
   -   5        
  Name$
 DtData��5-         AutoGenerateColumns .  $��1��6@   $��1��6M      
IsReadOnly .    SelectionMode$ Single =�5/         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ № п��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Id+  52      $ Программа��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6j    68   �� *CategoryTrainer.Category.Name+6j     53      $ День недели��6%    6:   �� *	DayWeek+  54      $ Время занятий��6%   $ * 6j    6<   �� *	DayTime+ �� StringFormat$ t��6j   57      �� 58   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6f   .+�59      �� -   5         ��Name$ btnAdd��59      $��Добавить��6%   68   �� 5:      -   5        $ 	btnChange��5:      $��Изменить��6(   6;   �� 5;      -   5        $ 	btnDelete��5;      $��Удалить��6(   6:   5<      5>      5?      