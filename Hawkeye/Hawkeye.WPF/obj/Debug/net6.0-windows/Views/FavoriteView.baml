   M S B A M L   `   `   `  ����F  BHawkeye.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Hawkeye.WPF.ViewsHawkeye.WPF.Views  5      $    Hawkeye.WPF.Views.FavoriteView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Hawkeye.WPF.Views     5        � 	Resources  5	          BooleanToVisibilityConverter��%   &	        �� 5
   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6     BrushNavigation#��[ 5      $��	0, 0, 0,3q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      Color$
 Gray��63   ._�5      �� $��30(�6   $��Center=�6&   �� 5      $.�(Твои избранные фильмы��6   5      5      �� 5   
   $��1��6   $��0q�5        FavoriteTemplate#��[ 5!      $��Disabled=�5"      $
��True��5#      ��5      �� *
Favorite+ �� SelectedItem 5       �� *SelectedFilm+��5%      �� 5&      .R�5'      � $��Center=�6    5(      5*      5-      5.      