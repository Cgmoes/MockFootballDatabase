   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.ResultInsertWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$  Insert a Result��5   	   $	��350��6!   $	��400��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��.8* �6   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��20(�6   $��Black"�6&   $��7q�69   Week:6K   �� 5      
����p��
���   �$��2q�6C   $��22��6W   ._�5         GUI.CountBox  -   5          Name$ countBox��5   !   5      5      �� 5   
   $��1��6   $��0��6"   $ 
Horizontal=�62   .+�5      �� $��15(�6   $��18q�6&   
Home Team:6>   �� 5      -   5        $��homeTeamBox��5      $��20��6*   $	��184��66   6D   5      �� 5   
   $��2��6   $��0��6"   $ 
Horizontal=�62   .+�5      �� $��15(�6   $��18q�6&   
Away Team:6>   �� 5      -   5        $��awayTeamBox��5      $��20��6*   $	��184��66   6D   5      �� 5    
   $��3��6   $��0��6"   $ 
Horizontal=�62   .+�5!      �� $��15(�6   $��17q�6&   Home Team Points:6E   �� 5"      -   5        $��homeTeamPointsBox��5"      $��44��6/   $��18��6:   6H   5#      �� 5$   
   $��4��6   $��0��6"   $ 
Horizontal=�62   .+�5%      �� $��15(�6   $��17q�6&   Away Team Points:6E   �� 5&      -   5        $��awayTeamPointsBox��5&      $��44��6/   $��18��6:   6H   5'      �� 5(   
   -   5        $��SubmitButtonResults��5(      $��5��6,   $��17(�69   $��
31,0,240,0q�6G   $��26��6[   $��Center=�6g   .��6�   Submit6�   5)      5*      