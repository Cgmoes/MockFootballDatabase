   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$  
MainWindow��5   	   $	��700��6   $
��1000��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%k  '��       �� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5       5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   ��  � ��
 ���� 6?   5      5      5      5      5      .��5      � 
�������	 � RowDefinitions	 5   
   �� 5       $	��.6* �6   �� 5!      $	��.2* �6   �� 5"      $��4* �6   
 � ColumnDefinitions
 5$   
   �� 5%      $��1* �6   �� 5&      $��1* �6   .+�5(   
      GUI.TopButtonBar  -   5          Name$ TopBar��5(      $��0��6-   $��2��6:      GUI.StandingsTable  5)   
   -   5          Name$ StandingsTable��5)      $��1��67   $��2��6H      GUI.InsertControl  5*   
   -   5          Name$ InsertControl��5*   P   $��2��6   $��2��6+   $��2��6?   $y�Hidden=�6g      GUI.UpdateControl  5+   
   -   5          Name$ UpdateControl��5+   P   $��2��6   $��2��6+   $��2��6?   $y�Hidden=�6g      GUI.SearchControl  5,   
   -   5          Name$ SearchControl��5,   Q   $��2��6   $��2��6,   $��2��6@   $y�Hidden=�6h   � 5-   
   $��0��6   $��2��6   	 5.      �� 5/      �� 50      .+�52         GUI.RankQBsQuery  -   5          Name$ RankQb��52   !   $��1��61      GUI.ShowResultsByWeek  53      -   5          Name$ ResultByWeek��53   &   $��0��6<   54      55      56      