   M S B A M L   `   `   `  ����E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  5      "    ProjectMSG.View.AdminSection   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ProjectMSG.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��Medium"�5      $��14(�5       N� Title$ AdminSection��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext 5      �� *AdminSectionViewModel+  ViewModelLocator �� Source# [ .��5      �  � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      �� 5      $��55 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      $	��100 �6#   .+�5      �� $��1��6   $��
Назад��6>   
�������$��Right=�5      $��10q�61   ��5   %   �� *Back+5   1   �� 5       $$��Список разделов:��6   $��10q�60   $��Center=�6<   $
��Wrap=�6W   5!      �� 5"   
   -   5         ��Name$ listSection��5"      $��1��6'   $
��Auto=�64   $��10q�6d    �� SelectedItem 5#      �� *SelectSection+��5$      �� *
Sections+	 �� UpdateSourceTrigger$	 PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5%      +  %Microsoft.Xaml.Behaviors.EventTrigger  5&         	EventName$ MouseDoubleClick��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5'      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *GoToArticle+   CommandParameter 5(   ,   ��  �� ElementName$ listSection�� �� Path$ SelectedItem�5)       � ContextMenu 5+      �� 5,      .@�5-      m� $��Удалить��6    m� Command 60   �� *DelSectionCommand+m� 5.      $��Изменить��6    61   �� *EditSectionCommand+5/      ��51      �� 52      .R�53      ��  �� Orientation$ 
Horizontal=�6!   .+�54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Book=�62   �� 55       ��Name$ tb��6$   
���   �$
��Wrap=�57   $   ��56   $   �� *SectionName+$	 PropertyChanged=�57   $   58      59      5;      �� 5<   
   $��2��6   $��10q�6D   $
��Left=�6P   $��Bottom=�5=      $��Добавить��6,   
���������5<      �� *AddSectionCommand+5=   ?   5>      5?      