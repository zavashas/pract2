   M S B A M L   `   `   `  ����C  ?WpfApp14, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp14WpfApp14  5   	       WpfApp14.StudentsCoursesW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp14     5   	     � Title$)  #Студенты и их курсы��5   	   $	��450��6%   $	��800��62   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ StudentsCoursesGrd��5         AutoGenerateColumns .  $��0��6K   $��4��6X      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО студента��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *StudentFullName+  5      $! Название курса��6%    6=   �� *CourseTitle+5      �� 5   
   -   5         ��Name$ ComboBoxStudents��5      $��1��6-   $��1��6:   $	��200��6J   	 �� SelectedValuePath$	 
ID_Student��5      �� 5!   
   -   5        $ ComboBoxCourses��5!      $��2��6,   $��1��69   $	��200��6J   $	 	ID_Course��5"      �� 5$   
   -   5        $��Добавить��5$      $	��Top=�6<   $��0��6T   $��1��6a   $	��100��6q   $
��Left=�6}   ���	#FF6C84646�   �� 5%   
   -   5        $��Изменить��5%      $	��Top=�6?   $��0��5&      $��1��6   $	��100��6   $��Center=�5'      ���	#FF6C84646   �� 5(   
   -   5        $��Удалить��5(      $	��Top=�6>   $��0��6V   $��2��6c   $	��100��6s   $��Right=�6   ���	#FF6C84646�   �� 5)   
   $7��1Выберите фамилию студента:��6   $��Center=�66   $	��Top=�6S   $��1��6k   $��1��6{   6�   �� 5*   
   $3��-Выберите название курса:��6   $��Center=�64   $	��Top=�6Q   $��1��6i   $��2��6y   6�   �� 5+   
   -   5        $��
Назад��5+      $��1��64   $��3��6D   $	��100��6R   $��Right=�6^   $��Bottom=�6z   ���	#FF6C8464���	#FF4159276�   5-      5.      