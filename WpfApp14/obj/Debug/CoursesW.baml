   M S B A M L   `   `   `  ����C  ?WpfApp14, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp14WpfApp14  5   	       WpfApp14.CoursesW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp14     5   	     � Title$  
Курсы��5   	   $	��450��6   $	��800��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CoursesDataSet��5         AutoGenerateColumns .  $��0��6z   $��4��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Title+  5      $ Описание��6%    67   �� *DescriptionCourse+5      �� 5   
   -   5        $��Добавить��5      $	��Top=�6<   $��0��6T   $��1��6a   $	��100��6q   $
��Left=�6}   ���	#FF6C84646�   �� 5   
   -   5        $��Изменить��5      $	��Top=�6?   $��0��5      $��1��6   $	��100��6"   $��Center=�5       ���	#FF6C84646"   �� 5!   
   -   5        $��Удалить��5!      $	��Top=�6>   $��0��6V   $��2��6c   $	��100��6s   $��Right=�6   ���	#FF6C84646�   �� 5"   
   -   5         ��Name$ TextBoxTitle��5"   C   $��1��6Y   $��1��6f   $��300px��6v   $��30��6�   ���	#3389B4986�   �� 5#   
   -   5        $ TextBoxDescription��5#      $��2��6.   $��1��6;   $��300px��6K   $��70��6Y   ���	#3389B4986e   �� 5$   
   $��Название:��6   $	��Top=�6&   $��1��6>   $��1��6N   $��Center=�6[   6z   �� 5%   
   $��Описание:��6   $��Center=�6%   $	��Top=�6B   $��1��6Z   $��2��6j   6y   �� 5&   
   -   5        $��
Назад��5&      $��1��64   $��3��6D   $	��100��6R   $��Right=�6^   $��Bottom=�6z   ���	#FF6C8464���	#FF4159276�   5(      5)      