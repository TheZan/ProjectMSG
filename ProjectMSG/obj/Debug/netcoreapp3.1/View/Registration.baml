   M S B A M L   `   `   `  ����E  AProjectMSG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ProjectMSG.ViewProjectMSG.View  5      "    ProjectMSG.View.Registration   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VDevExpress.Mvvm.UI, Version=19.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ProjectMSG.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5        MaterialDesignPaper  N� 
Background#  �  5	      $��Medium"�5
      $��14(�5       N� Title$ Registration��5       N� 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � DataContext 5      �� *RegistrationViewModel+  ViewModelLocator �� Source# [  � 	Resources 5        loadingVisability��%   &	       �� 5   
   6'   5      .��5      � ���#00B0FF.+�5   
   �� $��10q�6    �� RadiusY$ 10��6     �� RadiusX$ 10��6-   $��Center=�6:   
�������$	��350��6b   $	��300��5      �� 5   
   $��Center=�6   $	��250��60   .+�5      ��  % !MaterialDesignFloatingHintTextBox#��[ 6;   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя��5      $��10q�6;   {�5      �� *ControlDisable+��5      �� *	Firstname+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5      #��[ 6;   $ Фамилия��5      $��10q�6?   {�5      �� *ControlDisable+��5      �� *	Surname+$	 PropertyChanged=��� 5       #��[ 6;   $ 
Логин��5!      $��10q�6=   {�5       �� *ControlDisable+��5"      �� *Login+$	 PropertyChanged=�G� 5#      -   5        
 G�Name$
 password��5#   ?    ) %MaterialDesignFloatingHintPasswordBox#��[ 5$      $ Пароль��5%      $��10q�6B   {�5#      �� *ControlDisable+5%   B   �� 5&      $��5q�6    �� Orientation$ 
Horizontal=�6$   .+�5'      �� 
�������$��
Назад��5(      {�5'      �� *ControlDisable+��6>   �� *
BackToAuth+5(      �� 5)      $��50,0,0,0q�6   
�������$��Регистрация��5+   ,   {�5)   +   �� *ControlDisable+��6P   �� *RegisterUser+��5*      ��  �� ElementName$ password��$	 PropertyChanged=�5+   ,   5,      �� 5-      $
��Wrap=�6   $��5q�6I    �� TextAlignment$ Center=�6T   
���������6,   �� *WarningText+5.      5/      � 50   
   $��30��52      $��30��6    % !MaterialDesignCircularProgressBar#��[ 6$    � IsIndeterminate$
 True��6_   $��Center=�53      $��Center=�6(   y�51      �� *LoadingVisability+$	 PropertyChanged=� �� 	Converter# [ 53   (   54      55      