   M S B A M L   `   `   `  ���� E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  &     ProjectMSG.View.AddArticleDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:ProjectMSG.View     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���     MaterialDesignPaper#���  $��Medium"�$��14(�  � Title$#  Добавить статью�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=���:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� .+��� -    ��Name$ articleName��$	��600��$	��600��$��5q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Название статьи�� % !MaterialDesignFloatingHintTextBox#��[ $��Champagne & Limousines)�$��18(��� -    ��Name$ articleText��$	��600��$	��600��$	��250��$	��250��$��5q�$ Текст статьи��  MaterialDesignRichTextBox#��[ $
��Auto=�$��Champagne & Limousines)�$��18(��� -    ��Name$ articleImageAdd��$	��600��$	��600��$	��300��$	��300��$��Center=�$��Center=�$
��Auto=�$
��Auto=����� *Photo+	 � ContextMenu	 �� .@�m� -   
 m�Name$
 deleteImageFromArticle��$��Удалить������ .R�A�  A� Columns$ 2������ .R��� $	��250��$	��300��._��� ���� *ArticlePhoto+����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R��� -   �� -    ��Name$ addArticleImage��
�������$��10q�$-��'Добавить изображение��� $��1��$��Right=�$��0,15,0,0q�.+��� -   
������� �� 	IsDefault$
 True��$��60��$��0,0,10,0q�.��OK�� 
������� �� IsCancel$
 True��$��60��.��Отмена