   M S B A M L   `   `   `  ����  Hawkeye.WPF#    Hawkeye.WPF.Views.ProfileView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��50 �6   �� 5      $��50 �6   �� 5      .+�5   
   �� $��0��6      BrushNavigation#��[  5      $��	0, 0, 0,3q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      Color$
 Gray��63   ._�5      �� $��30(�6   $��Center=�6'   �� 5      $:�4Личный кабинет пользователя��6    �� 5      �6   �� *LoggedUser.Name+5      5      �� 5   
   $��1��6   $��80��6   $��Right=�6)   $��
Выйти��6E   ��5      �� *LogoutCommand+� 5   
   $��2��6     5      �� 5      $��80 �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    �� 5!      $
��auto �6    .+�5$      �� $��0��6   
�������$��45(�6;   $"��Данные профиля:��6I   $��Center=�6`   �� 5%      $��1��6   $��	30,50,0,0q�6%   $��20(�68   �� 5&      $&� Дата регистрации:��6   $��DemiBold"�6/    �� 5'      �6   �� *LoggedUser.RegistrationDate+5(      �� 5)      $��2��6   $��	30,50,0,0q�6%   $��20(�68   �� 5*      $(�"Избранных фильмов:��6   $��DemiBold"�60    �� 5+      �6   �� *FavoriteFilmsCount+5,      �� 5.      $��3��6   $��	30,50,0,0q�6%   $��20(�68   �� 5/      $0�*Количество плейлистов:��6   $��DemiBold"�64    �� 50      �6   �� *PlaylistsCount+51      �� 53      $��4��6   $��	30,50,0,0q�6%   $��20(�68   �� 54      $2�,Оставлено комментариев:��6   $��DemiBold"�65    �� 55      �6   �� *CommentsCount+56      57      5:      5;      