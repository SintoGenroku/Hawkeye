   M S B A M L   `   `   `  ����J  FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components  5      F BHawkeye.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Hawkeye.WPF.ViewsHawkeye.WPF.Views 5      (   "Hawkeye.WPF.Views.RegistrationView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     5      1localclr-namespace:Hawkeye.WPF.Views     5        � 	Resources  5
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
��0,10q�6%   $��Center=�5+      $��18(�5,      $
��Thin"�5-      $O��Iкаталог фильмов мультков и всего такого��5.      � 50      $��2��6   $
��0,20q�6    
 51      �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $
��auto �6$   �� 56      $
��auto �6$   �� 57      $
��auto �6$   .+�5:      � $��0��6   $
��0,10q�6$    � ColumnDefinitions 5;      �� 5<      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5=      $	��300 �6+   .+�5@      �� $��0��6    $��Имя��60   $��16(�6;   �� 5A      $��1��6   $��20,0,0,0q�6.   $��18(�6@   ��5B      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5C      � 5E      $��1��6   $
��0,10q�6$    5F      �� 5G      $
��auto �6+   $ Label��68   �� 5H      $	��300 �6+   .+�5K      �� $��0��6    $��Пароль��60   $��16(�6>   4   .PasswordBoxMVVM.Components.BindablePasswordBox  5L      $��1��65   $��20,0,0,0q�6E   $��18(�6W      Password 5M      �� *
Password+5N      � 5P      $��2��6   $
��0,10q�6$    5Q      �� 5R      $
��auto �6+   $ Label��68   �� 5S      $	��300 �6+   .+�5V      �� $��0��6    $)��#Подтвердить пароль��60   $��16(�6J     5W      $��1��65   $��20,0,0,0q�6E   $��18(�6W    5X      �� *ConfirmPassword+5Y      �� 5[      $��3��6   $
��0,10q�6&   $��Center=�5\      $*��$Зарегистрироваться��5^       �� 	IsDefault$
 True��5_      ��5]      �� *RegisterCommand+5_      �� 5a      $��4��6   $��0,10,0,0q�6&   $��Center=�5b      
������ $.��(Уже есть свой аккаунт?��5e      $��14(�5f      
����  ���5d      �� *ViewLoginCommand+5g      �� 5i      $��5��6   $��0,10,0,0q�6)   $��Center=�5j      
���  �� � DataContext 5k      �� *ErrorMessageViewModel+��5m      �� *	Message+y�5n      �� *
HasMessage+ �� 	Converter# [  5o      5p      5q      5r      