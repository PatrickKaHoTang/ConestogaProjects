   M S B A M L   `   `   `  ����K  GPTangAssignment3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PTangAssignment3PTangAssignment3  5   	   !    PTangAssignment3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PTangAssignment3     5   	     � Title$  Game of N-Puzzle��5   	   $	��350��6"   $	��525��6/   .��5	      � ��5
   
   �� 5       �� EndPoint$	 1,1&�6"    �� 
StartPoint$ 0.5,0&�61   .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ White��6   5      .+�5   
   �� -   5         ��Name$ textBoxRows��5      $
��Left=�6'   $��23��6B   $��	90,25,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   -   5        $ textBoxColumns��5      $
��Left=�6*   $��23��6E   $��	90,55,0,0q�6Q   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5   
   -   5         ��Name$ btnGenerate��5      $��Generate��6&   $
��Left=�69   $��25��6T   $��
226,25,0,0q�6`   $	��Top=�6t   $��90��6�   6�   �� 5   
   -   5        $ btnSave��5      $
��Save��6"   $
��Left=�61   $��25��6L   $��
404,26,0,0q�6X   $	��Top=�6l   $��90��6�   6�   �� 5   
   -   5        $ btnLoad��5      $
��Load��6"   $
��Left=�61   $��25��6L   $��
404,56,0,0q�6X   $	��Top=�6l   $��90��6�   6�   �� 5   
   -   5         ��Name$ lblRows��5      $��Rows:��6!   $
��Left=�61   $��	20,25,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $ 
lblColumns��5      $��Columns:��6$   $
��Left=�67   $��	20,55,0,0q�6R   $	��Top=�6e   � 5   
   -   5        	 �Name$	 gridPlayField��5      $
��Left=�6&   $��25��6A   $��
50,100,0,0q�6M   $	��Top=�6a   $��29��6y   �� 5   
   -	   5        $ 
lblCounter��5      $��Counter:��6$   $
��Left=�67   $��
226,55,0,0q�6R   $	��Top=�6f   �� 5   
   -
   5        $ lblTextCounter��5      $�� ��6(   $
��Left=�63   $��
280,55,0,0q�6N   $	��Top=�6b   5      5      