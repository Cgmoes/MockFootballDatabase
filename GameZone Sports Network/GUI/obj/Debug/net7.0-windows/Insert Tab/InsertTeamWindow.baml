   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.InsertTeamWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$  
Add a Team��5      $	��250��6   $	��350��6,   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��30(�6   Enter in a Team:64   �� 5   
   $��1��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5      �� $��15(�6   $��12q�6'   
Team Name:6?   �� 5      -   5         ��Name$ nameBox��5      $	��194��6(   $��22��64   5      �� 5   
   $��2��6   $��0��6"   $ 
Horizontal=�62   .+�5      �� $��15(�6   $��11q�6&   
Team City:6>   �� 5      -   5        $ cityBox��5      $	��175��6'   $��22��63   5      �� 5   
   $��3��6   $��0��6"   $ 
Horizontal=�62   .+�5      �� $��15(�6   $��11q�6&   Year Established:6E   �� 5      -   5        $ yearBox��5      $��80��6'   $��22��62   5      �� 5   
   -   5         ��Name$ SubmitButtonTeam��5      $��10��6?   $��17(�6M   $��31,10,220,10q�6[   .��6q   Submit6y   5      5       