   M S B A M L   `   `   `  ����E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  5          ProjectMSG.View.Testing   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ProjectMSG.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5         MaterialDesignBody#���   5	        MaterialDesignPaper  N� 
Background#  �  5
      $��Medium"�5      $��14(�5       N� Title$ Testing��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext 5      �� *TestingViewModel+  ViewModelLocator �� Source# [ .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      .+�5   
   )  #MaterialDesignThemes.Wpf.DrawerHost  $��2��6$    K� ZIndex$	 100��65      LeftDrawerContent 5      �� 5      
�������$	��200��64   .+�5      d�  ' #MaterialDesignHamburgerToggleButton#��[ 5      $	��Top=�5      $��Right=�5      $��16q�5         CloseDrawerCommand#��Z 5!      "  System.Windows.Controls.Dock	   Left#��Z	 5"      
 d� 	IsChecked
 5       ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked� �� Mode$ TwoWay=�5"      �� 5#      $��10q�6   .@�5$      �� .��5%      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��5&   ?   �� *SelectContent+.��5'   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5(   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�6>   �� 5)   &   $��10,0,0,0q�60   $��Главная��6B   5*   #   5+      5,      �� 5-      .��5.      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��5/   ?   �� *SelectTesting+.��50   "   �� $ 
Horizontal=�6-   .+�51   &     $ Pencil=�6>   �� 52   &   $��10,0,0,0q�60   $��
Тесты��6B   53   #   54      55      �� 56      .��57      �� $
��Left=�6%   $	��174��6G   
������ 
������ ��58   ?   �� *SelectProfile+.��59   "   �� $ 
Horizontal=�6-   .+�5:   &     $ Account=�6>   �� 5;   &   $��10,0,0,0q�60   $��Профиль��6B   5<   #   5=      5>      5?      5@      .��5B      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryLight=�6'   $��16q�6;   .��5C      �� $ 
Horizontal=�6   .+�5D      d� -   5         d�Name$ MenuToggleButton��5D   #   #���  5E   #      OpenDrawerCommand#��Z 5F   #   #��Z	 5G   #   5H      5I      5J      �� 5K   
   -   5         ��Name$ ListTest��5K      $��1��6$   $
��Auto=�61   $��10q�6a    �� SelectedItem 5L      �� *
SelectTest+��66   �� *Tests+ �� UpdateSourceTrigger$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5M      +  %Microsoft.Xaml.Behaviors.EventTrigger  5N         	EventName$ MouseDoubleClick��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5O      2	  ,Microsoft.Xaml.Behaviors.InvokeCommandAction	   	  Command 6,   �� *
GoToTest+ 	  CommandParameter 5P   ,   �� $ ListTest��$ SelectedItem�5Q      ��5S      �� 5T      .R�5U      �� $ 
Horizontal=�6!   .+�5V        $ Pencil=�62   �� 5W       ��Name$ tb��6$   
���   �$
��Wrap=�5X   c   ��6$   �� *
TestName+$ PropertyChanged=�6c   5Y      5Z      5\      5]      5^      