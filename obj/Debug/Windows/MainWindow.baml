   M S B A M L   `   `   `  ����M  IWpfAssortmentCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfAssortmentCheckWpfAssortmentCheck  5   	   #    WpfAssortmentCheck.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ,local clr-namespace:WpfAssortmentCheck  5   	   -   5        $	��450��5   	   $	��800��6     � Icon$d  ^/WpfAssortmentCheck;component/Resources/6771568_book_education_learning_puzzle_school_icon.ico��6"    � WindowStartupLocation$ CenterScreen=�5   !      base_window_1#��[  6F    � Title 5	      ��  �� ElementName$ 	MainFrame�� �� Path$ Content.Title�.��5      �  � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � �� 5   
     PrimaryHueLightBrush#��[ 6   �� 5   
   $d��^/WpfAssortmentCheck;component/Resources/6771568_book_education_learning_puzzle_school_icon.png��6   $��
20,10,0,10q�5      $
��Left=�5      $��55��6+   $��63��67   �� 5   
   $��0��6   $J��DАИС «Центр детского развития ТимТим»��6!   $��Center=�5      $��	20 0 0 0 q�61   $��Center=�5      
�������$��20(�5      $
��Bold"�5       � 5   
   -   5          �Name$ 	MainFrame��5      $��1��6#     � NavigationUIVisibility$ Hidden=�5       $��1q�5!      6$   �� 5"   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0 0 20 0q�6W   .+�5#      �� -   5        	 ��Name$	 BtnEditGoods��5#      
 � ToolTip$
 Тренеры��6F   $y�	Collapsed=�6X   .��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountMultiplePlus=�6+   $��0q�6F   5%      �� 5&      -   5        $	 BtnOrder��5&      $
 Заявки��6?   $y�	Collapsed=�6P   .��5'        $ OrderBoolAscending=�6+   $��0q�6E   5(      �� 5)      -   5        $	 BtnBuyes��5)      $
 Абонементы��6?   $y�	Collapsed=�6T   .��5*        $
 Cash=�6+   $��0q�67   5+      �� 5,      -   5        $	 BtnMyAccount��5,      $
 Мой профиль��6G   $y�	Collapsed=�6]   .��5-        $ Account=�6+   $��0q�6:   5.      �� 5/      -   5        $	 BtnMyOrders��5/      $#
 Оставить заявку��6E   $y�	Collapsed=�6_   .��50        $ 
StarBorder=�6+   $��0q�6=   51      �� 52      -   5        $	 BtnEnter��52      $
 
Войти��6?   .��53        -	   5          Name$ 
IconBtnKey��53   *   $ Login=�6?   $��0q�6L   54      �� 55      -
   5        $	 BtnBack��55      $
 
Назад��56   '   $y�	Collapsed=�67   .��57        $ 	ArrowBack=�6+   $��0q�6<   59      5:      �� 5;   
   $��2��6   #��[ 6!   5=      5>      