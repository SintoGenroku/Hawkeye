   M S B A M L   `   `   `  ����F  BHawkeye.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Hawkeye.WPF.ViewsHawkeye.WPF.Views  5      %    Hawkeye.WPF.Views.PlaylistsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Hawkeye.WPF.Views     5        � 	Resources  5	          BooleanToVisibilityConverter��%   &	        �� 5
   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      .+�5   
   �� $��0��6     BrushNavigation#��[ 5      $��	0, 0, 0,3q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      Color$
 Gray��63   ._�5      �� $��Плейлисты��6   $��30(�6)   $��Center=�67   5      �� 5   
   $��1��6   $��0q�5        PlaylistsListTemplate#��[ 5      $��Disabled=�5       ��5      �� *	Playlists+ �� SelectedItem 5      �� *SelectedPlaylist+��5"      �� 5#      .R�5$      � $
��Left=�6    5%      5(      �� 5)   
   $��2��6   $��1q�6   
�������$	��260��6E   $	��310��6Q    �� CornerRadius$ 15��6^   ._�5*      � $��5q�6   $
��auto��6   
������� 5+      �� 5,      $
��auto �6$   �� 5-      $
��auto �6$   �� 5.      $
��auto �6$   .+�50      �� $��0��6   $	��140��6&   $	��140��63   $ 15��6?   ��51      �� 52       �� ImageSource$&  /Resources/clapperboard-icon.png��6%   54      �� 55      $��1��6    �� Orientation$ Vertical=�6*   .+�56      �� $2��,Создайте новый плейлист��57      $
��Wrap=�58      $��20(�59      $��Center=�5:      �� 5;      $ 
Horizontal=�6!   .+�5<      �� $��Название��6$   $��5q�64   �� 5=      $��18(�5>      $	��180��5?      	 �� TextWrapping$
	 Wrap=�5@      $��Center=�5A      ��5B      �� *NewPlaylistName+5C      �� 5D      $��Создать��6   $
��5,10q�6/   ��5E      �� *CreatePlaylistCommand+5F      �� 5G      $��2��6   $��0 10 0 0q�6)   $��Center=�5H      
���  ��$
��Wrap=�5L      
 � DataContext
 5I      �� *ErrorMessageViewModel+��5K      �� *	Message+y�5M      �� *
HasMessage+ �� 	Converter# [  5N      5O      5P      5Q      