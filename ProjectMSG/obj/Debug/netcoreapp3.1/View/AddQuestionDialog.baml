   M S B A M L   `   `   `  ����E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  5   	   '    !ProjectMSG.View.AddQuestionDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProjectMSG.View     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5	   	   $��Medium"�5
   	   $��14(�5   	     � Title$#  Добавить вопрос��5   	    � SizeToContent$ WidthAndHeight=�6!    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ NoResize=�5   	   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� .+�5      �� -   5         ��Name$ QuestionText��5      $	��500��6,   $	��500��6;   $��5q�6J   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Вопрос��5       % !MaterialDesignFloatingHintTextBox#��[ 6>   $��Champagne & Limousines)�5      $��18(�6>   �� 5      -   5         ��Name$ 
AnswerList��5      $��5q�6*   $	��250��65   $	��250��6E   $	��500��6U    � ContextMenu 5      �� 5      .@�5      m� -   5        	 m�Name$	 	DelAnswer��5   4   $��Удалить��6#   6G   5      ��5       �� 5!      .R�5"      �� 
 �� Orientation$
 
Horizontal=�6%   .+�5#      	�  	�Name$ CorrectAnswerCB��5$   *    	� 	GroupName$ 	AnswersRb��6b    d� 	IsChecked 5#   *   ��  �� Path$ AnswerCorrect� �� Mode$ OneWayToSource=���5$   C   �� *
AnswerText+6b   5%      5&      ��5(      �� 5)       �� 
TargetType" ��6   .�5*      ��  �� Property � �� �� Value 5+      �� 5,   "    �� 
TargetType" ��62   .R�5-   &   �� 5.   #   50      -   5        52      54      �� 55      -   5        $ Answer��55   %   $	��500��6   $	��350��65   $��5q�6D   $ 
Ответ��6O   #��[ 56      $��Champagne & Limousines)�6Q   $��18(�57      �� 58      -   5         ��Name$ 	AddAnswer��58      $��5q�6B   
�������$!��Добавить ответ��6`   59      � 5:   
   $��1��6   $��Right=�6!   $��0,15,0,0q�6=   .+�5;      �� -   5        
������� �� 	IsDefault$
 True��5;   (   $��60��6T   $��0,0,10,0q�6b   .��6t   OK6x   �� 5<      
������� �� IsCancel$
 True��6(   $��60��68   .��6F   Отмена6N   5=      5>      5?      