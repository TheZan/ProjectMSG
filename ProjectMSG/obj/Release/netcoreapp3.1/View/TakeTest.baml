   M S B A M L   `   `   `  ����   
ProjectMSG    ProjectMSG.View.TakeTest   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���     MaterialDesignPaper#���  $��Medium"�$��14(�  � Title$  Тестирование�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=���:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��� .+��� $��10q�$	��250��$	��500��$	��500��$	��800��.+��� $��Вопрос��.���� -    ��Name$ 
GroupTitle��$
��Wrap=�$��5q�$��24(����� *QuestionText+�� -    ��Name$ 	AnswerBox��$��Center=�$��Arial)�$��20(�$	��0,2q����� ����  �� 
TargetType" ��.���  �� Property � �� �� Value �� 	 �� 
TargetType"	 ��.R��� 
 ��Name$
 listItem��.+��� $��3q�$
��Wrap=����� *
AnswerText+��  �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ listItem�� � ��
 ��ح�-   �� -   $ MessageError��$y�	Collapsed=�$��Center=�$��18(�$��Arial)�
���  ��$/��)Выбран неверный ответ!��)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ 	DialogEnd��   IsOpen$ False��   
Identifier$ 
endTesting��   DialogContent � $��20q�.+��� .+��� $��5q�$��Center=�$��Center=�
��� � �$��20(�$9��3Поздравляем! Вы прошли тест!���� -    ��Name$ GoFinish��
�������$��5q�$
��Ок��