   M S B A M L   `   `   `  ����E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  5   	   &     ProjectMSG.View.AddArticleDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ProjectMSG.View     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5	   	   $��Medium"�5
   	   $��14(�5   	     � Title$#  Добавить статью��5   	    � SizeToContent$ WidthAndHeight=�6!    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ NoResize=�5   	   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� .+�5      �� -   5         ��Name$ articleName��5      $	��600��6+   $	��600��6:   $��5q�6I   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Название статьи��5       % !MaterialDesignFloatingHintTextBox#��[ 5      $��Champagne & Limousines)�6Q   $��18(�5      �� 5      -   5         ��Name$ articleText��5      $	��600��6/   $	��600��6>   $	��250��6M   $	��250��6]   $��5q�6m   $ Текст статьи��5        MaterialDesignRichTextBox#��[ 5      $
��Auto=�5      $��Champagne & Limousines)�6J   $��18(�5      �� 5       -   5         ��Name$ articleImageAdd��5!   R   $	��600��5       $	��600��6&   $	��300��65   $	��300��6E   $��Center=�6U   $��Center=�5!      $
��Auto=�5"      $
��Auto=�6G   ��5!   4   �� *Photo+	 � ContextMenu	 5#      �� 5$      .@�5%      m� -   5        
 m�Name$
 deleteImageFromArticle��5%   #   $��Удалить��6h   5&      ��5(      �� 5)      .R�5*      A�  A� Columns$ 2��6&   5+      ��5-      �� 5.      .R�5/      �� $	��250��6!   $	��300��6.   ._�50      �� ��6$   �� *ArticlePhoto+51      52      ��54      �� 55       �� 
TargetType" ��6   .�56      ��  �� Property � �� �� Value 57      �� 58   "    �� 
TargetType" ��62   .R�59   &   �� 5:   #   5<      -   5        5?      5A      �� 5B      -   5         ��Name$ addArticleImage��5B   R   
�������$��10q�6F   $-��'Добавить изображение��5C      5D      � 5F   
   $��1��6   $��Right=�6!   $��0,15,0,0q�6=   .+�5G      �� -   5        
������� �� 	IsDefault$
 True��5G   (   $��60��6N   $��0,0,10,0q�6\   .��6n   OK6r   �� 5H      
������� �� IsCancel$
 True��6(   $��60��68   .��6F   Отмена6N   5I      5J      5K      