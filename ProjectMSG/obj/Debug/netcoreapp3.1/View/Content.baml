   M S B A M L   `   `   `  ����E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  5      3clr-namespace:ProjectMSG.ModelProjectMSG.Model  5      'clr-namespace:ProjectMSG
ProjectMSG  5	          ProjectMSG.View.Content   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ProjectMSG.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      *modelclr-namespace:ProjectMSG.Model  5      )
projectMsgclr-namespace:ProjectMSG  5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5
         MaterialDesignBody#���   5        MaterialDesignPaper  N� 
Background#  �  5      $��Medium"�5      $��14(�5       N� Title$ Content��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext 5      �� *ContentViewModel+  ViewModelLocator �� Source# [ .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      .+�5   
   )  #MaterialDesignThemes.Wpf.DrawerHost  $��2��6$    K� ZIndex$	 100��65      LeftDrawerContent 5      �� 5      
�������$	��200��64   .+�5      d�  ' #MaterialDesignHamburgerToggleButton#��[ 5      $	��Top=�5      $��Right=�5       $��16q�5!         CloseDrawerCommand#��Z 5#      "  System.Windows.Controls.Dock	   Left#��Z	 5$      
 d� 	IsChecked
 5"      ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked� �� Mode$ TwoWay=�5$      �� 5%      $��10q�6   .@�5&      �� .��5'      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��5(   ?   �� *SelectContent+.��5)   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5*   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�6>   �� 5+   &   $��10,0,0,0q�60   $��Главная��6B   5,   #   5-      5.      �� 5/      .��50      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��51   ?   �� *SelectTesting+.��52   "   �� $ 
Horizontal=�6-   .+�53   &     $ Pencil=�6>   �� 54   &   $��10,0,0,0q�60   $��
Тесты��6B   55   #   56      57      �� 58      .��59      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��5:   ?   �� *SelectProfile+.��5;   "   �� $ 
Horizontal=�6-   .+�5<   &     $ Account=�6>   �� 5=   &   $��10,0,0,0q�60   $��Профиль��6B   5>   #   5?      5@      5A      5B      .��5D      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryLight=�6'   $��16q�6;   .��5E      �� $ 
Horizontal=�6   .+�5F      d� -   5         d�Name$ MenuToggleButton��5F   #   #���  5G   #      OpenDrawerCommand#��Z 5H   #   #��Z	 5I   #   5J      5K      5L      � 5M   
   $��1��6    � ColumnDefinitions 5N      �� 5O      $	��200 �6#   �� 5P      .+�5R      �� $��0��6   ���#F2F2F26(   R� 5S      $��0��6   $��5q�6'   $
��Auto=�62   $��Disabled=�5T      ��6M   �� *
Sections+*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5U      -   'ProjectMSG.BindableSelectedItemBehavior  5V         SelectedItem 6>   �� *SelectArticle+$ TwoWay=���5X      �� 5Y       �� DataType" ��6O    �� ItemsSource 6/   �� *	Article+.R�5Z      �� $
��Wrap=�6$   ��68   �� *SectionName+ �� ItemTemplate 5[      �� 5\         ProjectMSG.Model.Article"  67   .R�5]   "   �� $
��Wrap=�6,   ��6@   �� *ArticleName+5^      5`      5b      -� 5c      $��1��6!   .��5d      /� .T�5e      J�  �� TextAlignment$ Center=�6    .*�67   .*�5f      �� 
���   �$
��Bold"�61   $��20(�6C   �5g      �� *ArticleName+ �� UpdateSourceTrigger$ PropertyChanged=�5h      J� 5i      .*�6    .*�5j      �� 
���   ��61   �� *ArticleText+$ PropertyChanged=�5k      J� 5l      $ Center=�6    .*�67   .*�5m      �� $��Center=�6#   $��Center=�6>   $��Disabled=�5o   #   ��5n   #   �� *Photos+$ PropertyChanged=���5p      �� 5q   "   .R�5r   &   �� 5s   #   ��5u      �� 5v   "   .R�5w   &   �� $	��200��61   $	��500��6A   $	��100��6P   $	��100��6`   .+�5x   *   �� $��5q�60   $��UniformToFill=�6;   ��5y   0   �� *ArticlePhoto+$ PropertyChanged=�5z   '   5{   #   ��5}      �� 5~   "    �� 
TargetType" ��6(   .�5   &   ��  �� Property � �� �� Value 5�   *   �� 5�   .    �� 
TargetType" ��6>   .R�5�   2   �� 5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      