   M S B A M L   `   `   `  ����  
ProjectMSG    ProjectMSG.View.TakeTest   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Medium"�5	   	   $��14(�5
   	     � Title$  Тестирование��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � .+�5   
   �� $��10q�6   $	��250��6!   $	��500��61   $	��500��6@   $	��800��6O   .+�5      �� $��Вопрос��6   .��5      �� -   5         ��Name$ 
GroupTitle��5   ;   $
��Wrap=�6   $��5q�60   $��24(�6m   ��6O   �� *QuestionText+6m   5      �� 5      -   5         ��Name$ 	AnswerBox��5   1   $��Center=�6   $��Arial)�6D   $��20(�6W   $	��0,2q�6e   ��5      �� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5   "   	 �� 
TargetType"	 ��62   .R�5   &   �� 
 ��Name$
 listItem��61   .+�5   *   �� $��3q�64   $
��Wrap=�6?   ��6S   �� *
AnswerText+�� 5   *   66   5   '    �� Triggers 5   &   P� 5    *    P� Property �@J�IsMouseOver P� Value$
 True��6I   . �5!   .   ��  �� 
TargetName$ listItem��65    � ��
 ��ح�6a   5"   +   5$   #   5&      -   5        5(      5*      �� 5+      -   5        $ MessageError��5+      $y�	Collapsed=�6.   $��Center=�6E   $��18(�6b   $��Arial)�5,      
���  ��$/��)Выбран неверный ответ!��6<   5-      )  #MaterialDesignThemes.Wpf.DialogHost  5.   
   -   5          Name$ 	DialogEnd��5.   3      IsOpen$ False��6$      
Identifier$ 
endTesting��6F      DialogContent 5/      � 50      $��20q�6   .+�51      �� .+�52      �� $��5q�6$   $��Center=�6/   $��Center=�6J   
��� � �$��20(�53   7   $9��3Поздравляем! Вы прошли тест!��6E   �� 54      -   5         ��Name$ GoFinish��54   M   
�������$��5q�6_   $
��Ок��6j   55      56      58      59      5:      