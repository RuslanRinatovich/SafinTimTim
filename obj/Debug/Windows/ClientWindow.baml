   M S B A M L   `   `   `  ����M  IWpfAssortmentCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WpfAssortmentCheck.WindowsWpfAssortmentCheck.Windows  5   	   -    'WpfAssortmentCheck.Windows.ClientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   4local(clr-namespace:WpfAssortmentCheck.Windows  5   	     � Title$  Мой профиль��5	   
    � WindowStartupLocation$ CenterScreen=�6   $	��500��6E   $	��800��6R      base_window_1#��[  6^   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��80 �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��0��6,   $��Center=�6<   $��0��6W   $��30��6d   $	��0,7q�6p    �� 
IsReadOnly . ��6   �� *
UserName+6}   �� 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия��6,   $��20 5 0 0q�6V   $��0��6i   $��Center=�6y   $��1��6�   $��30��6�   $	��0,7q�6�   ��6   �� *
LastName+6�   �� 5   
   $ Имя��6-   $��20 5 0 0q�6S   $��0��6f   $��Center=�6v   $��2��6�   $��30��6�   $	��0,7q�6�   ��6   �� *	FirstName+6�   �� 5   
   $ Отчество��6.   $��20 5 0 0q�6Y   $��0��6l   $��Center=�6|   $��3��6�   $��30��6�   $	��0,7q�6�   ��6   �� *
MiddleName+6�   �� 5    
   $ Телефон��6)   $��20 5 0 0q�6S   $��0��6f   $��Center=�6v   $��4��6�   $��30��6�   $	��0,7q�6�   ��6   �� *Phone+6�   �� 5!   
   $ E-mail��6)   $��20 5 0 0q�6R   $��0��6e   $��Center=�6u   $��5��6�   $��30��6�   $	��0,7q�6�   ��6   �� *Email+6�   �� 5"   
   $! Серия паспорта��62   $��20 5 0 0q�6c   $��0��6v   $��Center=�6�   $��6��6�   $��30��6�   $	��0,7q�6�   ��6   �� *PassportSeries+6�   �� 5#   
   $! Номер паспорта��6/   $��20 5 0 0q�6`   $��0��6t   $��Center=�6�   $��7��6�   $��30��6�   $	��0,7q�6�   ��6   �� *PassportNum+6�   �� 5$   
   -   5         ��Name$ CheckBoxChangePassword��5$      $#��Изменить пароль��63   $	��200��6M   $��Center=�6Z   $
��Left=�6u   $��8��6�   $��20 0 0 0q�6�   $��0��6�   $��30��6�   G� 5%   
   -   5         G�Name$ PasswordBoxOldPassword��5%   :   $��0��6   $��	200 0 0 0q�6'   $��Center=�6[   $. (Введите старый пароль��6v   $��8��6�   $��30��6�   G� 5&   
   -   5        $ PasswordBoxNewPassword1��5&   U   $��0��6   $��	200 0 0 0q�6'   $��Center=�6:   $, &Введите новый пароль��6v   $��9��6�   $��30��6�   G� 5'   
   -   5        $ PasswordBoxNewPassword2��5'   U   $��0��6   $��	200 0 0 0q�6'   $��Center=�6:   $, &Введите новый пароль��6w   $��10��6�   $��30��6�   �� 5(   
   $��Center=�6    �� Orientation$ 
Horizontal=�62   $��11��6K   $��2��6Y   $��127,0,103,0q�6m   $	��162��6�   .+�5)      �� -   5        	 �� 	IsDefault	 . $��60��5)   ;   $��5q�6I   .��6T   OK6X   �� 5*      
 �� IsCancel
 . $��60��6%   $��5q�63   .��6>   Отмена6F   5+      5-      5.      