   M S B A M L   `   `   `  ���� E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  3clr-namespace:ProjectMSG.ModelProjectMSG.Model  'clr-namespace:ProjectMSG
ProjectMSG      ProjectMSG.View.Content   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:ProjectMSG.View     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  *modelclr-namespace:ProjectMSG.Model  )
projectMsgclr-namespace:ProjectMSG  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors     MaterialDesignBody#���     MaterialDesignPaper  N� 
Background#  �  $��Medium"�$��14(� N� Title$ Content�� N� 
FontFamily :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext �� *ContentViewModel+  ViewModelLocator �� Source# [ .���  � RowDefinitions �� $��70 ��� .+�)  #MaterialDesignThemes.Wpf.DrawerHost  $��2�� K� ZIndex$	 100��   LeftDrawerContent �� 
�������$	��200��.+�d�  ' #MaterialDesignHamburgerToggleButton#��[ $	��Top=�$��Right=�$��16q�   CloseDrawerCommand#��Z "  System.Windows.Controls.Dock	   Left#��Z	 
 d� 	IsChecked
 ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked� �� Mode$ TwoWay=��� $��10q�.@��� .���� $
��Left=�$	��174��
������ 
������ ���� *SelectContent+.����  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=��� $��10,0,0,0q�$��Главная���� .���� $
��Left=�$	��174��
������ 
������ ���� *SelectTesting+.���� $ 
Horizontal=�.+�  $ Pencil=��� $��10,0,0,0q�$��
Тесты���� .���� $
��Left=�$	��174��
������ 
������ ���� *SelectProfile+.���� $ 
Horizontal=�.+�  $ Account=��� $��10,0,0,0q�$��Профиль��.��(  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryLight=�$��16q�.���� $ 
Horizontal=�.+�d� -    d�Name$ MenuToggleButton��#���     OpenDrawerCommand#��Z #��Z	 � $��1�� � ColumnDefinitions �� $	��200 ��� .+��� $��0�����#F2F2F2R� $��0��$��5q�$
��Auto=�$��Disabled=����� *
Sections+*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors -   'ProjectMSG.BindableSelectedItemBehavior     SelectedItem �� *SelectArticle+$ TwoWay=�����  �� DataType" �� �� ItemsSource �� *	Article+.R��� $
��Wrap=����� *SectionName+ �� ItemTemplate ��    ProjectMSG.Model.Article"  .R��� $
��Wrap=����� *ArticleName+-� $��1��.��/� .T�J�  �� TextAlignment$ Center=�.*�.*��� 
���   �$
��Bold"�$��20(���� *ArticleName+ �� UpdateSourceTrigger$ PropertyChanged=�J� .*�.*��� 
���   ���� *ArticleText+$ PropertyChanged=�J� $ Center=�.*�.*��� $��Center=�$��Center=�$��Disabled=����� *Photos+$ PropertyChanged=����� .R��� ���� .R��� $	��200��$	��500��$	��100��$	��100��.+��� $��5q�$��UniformToFill=����� *ArticlePhoto+$ PropertyChanged=�����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R��� 