   M S B A M L   `   `   `  ���� E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View      ProjectMSG.View.Profile   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:ProjectMSG.View     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���     MaterialDesignPaper  N� 
Background#  �  $��Medium"�$��14(� N� Title$ Profile�� N� 
FontFamily :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext �� *ProfileViewModel+  ViewModelLocator �� Source# [ .���  � RowDefinitions �� $��70 ��� .+�)  #MaterialDesignThemes.Wpf.DrawerHost  $��2�� K� ZIndex$	 100��   LeftDrawerContent �� 
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
Horizontal=�.+�d� -    d�Name$ MenuToggleButton��#���     OpenDrawerCommand#��Z #��Z	 � $��1�� �� �� .+��� $��0��$��Center=�$��Center=�.+���  �� TextAlignment$ Center=�$
��Bold"�$��Arial)�$��28(�$��5q����� *	Firstname+ �� UpdateSourceTrigger$ PropertyChanged=��� $ Center=�$
��Bold"�$��Arial)�$��28(�$��5q����� *	Surname+$ PropertyChanged=��� $��1��.+��� $��3q�$'��!Завершенные тесты����  J� IsHitTestVisible$ False��$��5q����� *	Results+$ PropertyChanged=�