   M S B A M L   `   `   `  ���� K  GPTangAssignment2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PTangAssignment2PTangAssignment2  !    PTangAssignment2.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:PTangAssignment2       � Title$  Tic Tac Toe��$	��355��$	��335�� � 
ResizeMode$ NoResize=� � 	Resources    img �� 
TargetType �� Property �� Value �� 
TargetType��%{   &	        �� " ��.���  � ��
 ���� ��  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=�.��� ����  �� ImageSource$ images/bg2.png�� �� Opacity$	 0.6Q�.+�� -   $��GridTicTacToe��$	��307��$	��309��$	��Top=�$
��Left=�$��9,9,0,0q�	 � ColumnDefinitions	 �� �� �� 
 � RowDefinitions
 �� �� �� .+��� -    ��Name$
 btn1��#��[  $
��Left=�$	��Top=�$��90��$��90��$��4,4,0,0q�$��0��$��0��$
��0.01(��� -   $
 btn2��#��[  $
��Left=�$	��Top=�$��90��$��90��$��7,4,0,0q�$��1��$��0��$
��0.01(��� -   $
 btn3��#��[  $
��Left=�$	��Top=�$��90��$��90��$��9,4,0,0q�$��2��$��0��$
��0.01(��� -   $
 btn4��#��[  $
��Left=�$	��Top=�$��90��$��90��$��4,7,0,0q�$��0��$��1��$
��0.01(��� -   $
 btn5��#��[  $
��Left=�$	��Top=�$��90��$��90��$��7,7,0,0q�$��1��$��1��$
��0.01(��� -   $
 btn6��#��[  $
��Left=�$	��Top=�$��90��$��90��$��9,7,0,0q�$��2��$��1��$
��0.01(��� -   $
 btn7��#��[  $
��Left=�$	��Top=�$��90��$��90��$��4,10,0,0q�$��0��$��2��$
��0.01(��� -	   $
 btn8��#��[  $
��Left=�$	��Top=�$��90��$��90��$��7,10,0,0q�$��1��$��2��$
��0.01(��� -
   $
 btn9��#��[  $
��Left=�$	��Top=�$��90��$��90��$��9,10,0,0q�$��2��$��2��$
��0.01(�