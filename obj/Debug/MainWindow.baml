   M S B A M L   `   `   `  ����C  ?Register, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Register.ViewsRegister.Views  5   	   #clr-namespace:RegisterRegister  5   	       Register.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +vwclr-namespace:Register.Views     5   	   (localclr-namespace:Register     5   	     � Title$8  2РЕГИСТР ЗАСТРАХОВАННЫХ СМО��5   	   $	��480��6,   $	��640��6<    � WindowStartupLocation$ CenterScreen=�6K    � WindowState$ 	Maximized=�6p   .��5      � ��5   
   �� 5	       �� ImageSource$ LightBrushedx.jpg��6    j� TileMode$
 Tile=�69    j� ViewportUnits$ Absolute=�5
       j� Viewport$ 0,0,200,200�62    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   o� $��0��6   .@�5      m� $��СЕРВИС��6   6)   m� 5      $��ОТЧЁТЫ��6   6)   m� 5      $��
ВЫХОД��6   6(   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   62   �� 5      $
��Auto �6#   62   �� 5      $��* �6#   6/   .+�5!      (   "Register.Views.PersonSelectionView  $��0��6%   �� 5#      $��1��6   $
��Left=�6+   $��Stretch=�6F   	 �� ResizeBehavior$	 PreviousAndNext=�5$      $��5��68   6D   "   Register.Views.PersonDisplay  5&      $��2��6   5(      � 5*   
   $��2��6   .+�5+      9� $3��-История застрахованного��6   .��5,         Register.Views.MovesView  6!   5-      5.      � 50   
   $��3��6   .+�51      9� $��ЕРЗ��6   .��52          Register.Views.AnswersView  6#   53      54      �� 56   
   $��4��6   6#   58      59      