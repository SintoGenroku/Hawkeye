   M S B A M L   `   `   `  ����J  FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components  5      F BHawkeye.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Hawkeye.WPF.ViewsHawkeye.WPF.Views 5      !   Hawkeye.WPF.Views.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Hawkeye.WPF.Views     5        � 	Resources  5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      ��5      �� 5   
    �� ImageSource$# \Resources\HomeViewScreen.jpg��5       �� Opacity$	 0.5Q�5       j� Stretch$ UniformToFill=�5      .��5      �� $��25q�6    �� Padding$ 50q�6   $��Center=�5   	   $��Center=�5   	   
�������  BrushNavigation#��[ 5   	   $��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Color$
 Gray��6/   ._�5   
   � 	 � IsSharedSizeScope$
	 True��6   
 � RowDefinitions
 5      �� 5       $
��auto �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6    .+�5%      �� $��0��6   $��Center=�5&      $��48(�5'      $��Hawkeye��5(      �� 5*      $��1��6   $
��0 10q�6%   $��Center=�5+      $��18(�5,      $
��Thin"�5-      $O��Iкаталог фильмов мультков и всего такого��5.      � 50      $��2��6   $
��0 20q�6    
 51      �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $
��auto �6$   �� 56      $
��auto �6$   .+�59      � $��0��6   $
��0 10q�6$    � ColumnDefinitions 5:      �� 5;      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5<      $	��300 �6+   .+�5?      �� $��0��6    $��Имя��60   $��16(�6;   �� 5@      $��1��6   $��20 0 0 0q�6.   $��18(�6@   ��5A      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5B      � 5D      $��1��6   $
��0 10q�6$    5E      �� 5F      $
��auto �6+   $ Label��68   �� 5G      $	��300 �6+   .+�5J      �� $��0��6    $��Пароль��60   $��16(�6>   4   .PasswordBoxMVVM.Components.BindablePasswordBox  5K      $��1��65   $��20 0 0 0q�6E   $��18(�6W      Password 5L      �� *
Password+5M      �� 5O      $��2��6   $
��0 10q�6&   $��Center=�5P      $��
Войти��5R       �� 	IsDefault$
 True��5S      ��5Q      �� *LoginCommand+5S      �� 5U      $��3��6   $��0 10 0 0q�6&   $��Center=�5V      
������ $ ��Нету аккаунта?��5Y      $��14(�5Z      
����  ���5X      �� *ViewRegisterCommand+5[      �� 5]      $��4��6   $��0 10 0 0q�6)   $��Center=�5^      
���  �� � DataContext 5_      �� *ErrorMessageViewModel+��5a      �� *	Message+y�5b      �� *
HasMessage+ �� 	Converter# [  5c      5d      5e      5f      