   M S B A M L   `   `   `  ����?  ;Lab8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab8Lab8  5   	       Lab8.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab8     5   	     � Title$  Аэропорт��5   	   $	��250��6   $	��334��6'    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 	20 8 20 8q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 30��6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
PlanesGrid��5   /      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Самолет��6?   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Title+6P     5      $	 Компания��6A   $	
 110 6S    6%   �� *	Company+6S     5      $	 Год��6>   $
 70 6K    6%   �� *Year+6K   5      �� 5   
   $��Center=�6   $��1��63    �� Orientation$ 
Horizontal=�6@   .+�5      �� -   5         ��Name$ updateButton��5      $��Обновить��6+   $
��Auto��6Y   $��8q�6f   �� 5      -   5        $ deleteButton��5      $��Удалить��6+   $��8q�6X   $
��Auto��6c   �� 5       -   5        $��Запрос��5       $
��Auto��6&   $��8q�64   $
��Auto��6?   6L   �� 5!      -   5        $��Транзакция��5!      $
��Auto��6*   $��8q�68   $
��Auto��6C   6P   5"      5#      5$      