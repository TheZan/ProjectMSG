   M S B A M L   `   `   `  ����E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  5          ProjectMSG.View.Profile   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ProjectMSG.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5        MaterialDesignPaper  N� 
Background#  �  5	      $��Medium"�5
      $��14(�5       N� Title$ Profile��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext 5      �� *ProfileViewModel+  ViewModelLocator �� Source# [ .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      .+�5   
   )  #MaterialDesignThemes.Wpf.DrawerHost  $��2��6$    K� ZIndex$	 100��65      LeftDrawerContent 5      �� 5      
�������$	��200��64   .+�5      d�  ' #MaterialDesignHamburgerToggleButton#��[ 5      $	��Top=�5      $��Right=�5      $��16q�5         CloseDrawerCommand#��Z 5       "  System.Windows.Controls.Dock	   Left#��Z	 5!      
 d� 	IsChecked
 5      ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked� �� Mode$ TwoWay=�5!      �� 5"      $��10q�6   .@�5#      �� .��5$      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��5%   ?   �� *SelectContent+.��5&   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5'   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�6>   �� 5(   &   $��10,0,0,0q�60   $��Главная��6B   5)   #   5*      5+      �� 5,      .��5-      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��5.   ?   �� *SelectTesting+.��5/   "   �� $ 
Horizontal=�6-   .+�50   &     $ Pencil=�6>   �� 51   &   $��10,0,0,0q�60   $��
Тесты��6B   52   #   53      54      �� 55      .��56      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��57   ?   �� *SelectProfile+.��58   "   �� $ 
Horizontal=�6-   .+�59   &     $ Account=�6>   �� 5:   &   $��10,0,0,0q�60   $��Профиль��6B   5;   #   5<      5=      5>      5?      .��5A      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryLight=�6'   $��16q�6;   .��5B      �� $ 
Horizontal=�6   .+�5C      d� -   5         d�Name$ MenuToggleButton��5C   #   #���  5D   #      OpenDrawerCommand#��Z 5E   #   #��Z	 5F   #   5G      5H      5I      � 5J   
   $��1��6    5K      �� 5L      �� 5M      .+�5O      �� $��0��6   $��Center=�6&   $��Center=�6A   .+�5P      ��  �� TextAlignment$ Center=�6   $
��Bold"�5Q      $��Arial)�6.   $��28(�6A   $��5q�6O   ��5P   3   �� *	Firstname+ �� UpdateSourceTrigger$ PropertyChanged=�5Q   O   �� 5R      $ Center=�6   $
��Bold"�5S      $��Arial)�6.   $��28(�6A   $��5q�6O   ��5R   3   �� *	Surname+$ PropertyChanged=�5S   O   5T      �� 5U      $��1��6   .+�5V      �� $��3q�6   $'��!Завершенные тесты��6'   �� 5W       J� IsHitTestVisible$ False��6   $��5q�63   ��5X      �� *	Results+$ PropertyChanged=�5Y      5Z      5[      5\      