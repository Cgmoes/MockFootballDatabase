   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	   !    GUI.SpecialTeamsStatsWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$  Special Teams ��5   	   $	��300��6    $	��350��6-   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      $��45 �6   �� 5      .+�5   
   �� $��30(�6   Edit Special Team Stats:6<   �� 5   
   $��1��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5      �� $��15(�6   $��12q�6&   Field Goal Attempts:6H   �� 5      -   5        $��fgAttemptsBox��5   -   $��66��6   $��19��6!   6-   5      �� 5   
   $��2��6   $��0��6"   $ 
Horizontal=�62   .+�5      �� $��15(�6   $��13q�6&   Field Goals Made:6E   �� 5      -   5        $��	fgMadeBox��5   -   $��66��6   $��19��6!   6-   5      �� 5   
   $��3��6   $��0��6"   $ 
Horizontal=�62   .+�5      �� $��15(�6   $��13q�6&   Punts:6:   �� 5      -   5        $��puntsBox��5   -   $��66��6   $��19��6!   6-   5      �� 5    
   $��4��6   $��0��6"   $ 
Horizontal=�62   .+�5!      �� $��15(�6   $��13q�6&   
Punt Yards6>   �� 5"      -   5        $��puntYardsBox��5"   .   $��66��6   $��19��6!   6.   5#      �� 5$   
   -   5        $"��SubmitButtonSpecialTeamStats��5$      $��7��65   $��17(�6V   $��31,10,175,10q�6d   .��6{   Submit6�   5%      5&      