   M S B A M L   `   `   `  ���� E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  "    ProjectMSG.View.AdminArticle   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:ProjectMSG.View     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors     MaterialDesignBody#���     MaterialDesignPaper  N� 
Background#  �  $��Medium"�$��14(� N� Title$ AdminArticle�� N� 
FontFamily :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext �� *AdminArticleViewModel+  ViewModelLocator �� Source# [ .���  � RowDefinitions �� $��55 ��� �� $��55 �.+�� $��0�� � ColumnDefinitions �� �� $	��100 �.+��� $��1��$��
Назад��
�������$��Right=�$��10q����� *Back+�� $��10q�$��Center=�$
��Wrap=����� *GetSetctionName+ �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ listArticle��$��1��$
��Auto=�$��10q�	 �� SelectedItem	 �� *SelectArticle+���� *
Articles+$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *
GoToTest+   CommandParameter ��  �� ElementName$ listArticle�� �� Path$ SelectedItem� � ContextMenu �� .@�m� $��Удалить�� m� Command �� *DelArticleCommand+m� $��Изменить�� �� *EditArticleCommand+���� .R���  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Book=���  ��Name$ tb��
���   �$
��Wrap=����� *ArticleName+$ PropertyChanged=��� $��2��$��10q�$
��Left=�$��Bottom=�$��Добавить��
����������� *AddArticleCommand+