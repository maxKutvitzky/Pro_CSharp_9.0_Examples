   M S B A M L   `   `   `  ����D  @MyWordPad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MyWordPad	MyWordPad  5   	       MyWordPad.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MyWordPad     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      5   	     5   
   -   5        $ ApplicationCommands.Save��5      5   	   .��5      ]� .+�5   
   o� $	��Top=�6   $
��Left=�6%   
�������
���   �.@�5      m� $��_Edit��6   .@�5      m�  m� Command$ ApplicationCommands.Copy��6   m� 5      $ ApplicationCommands.Cut��6   m� 5      $ ApplicationCommands.Paste��6   5      m� 5      $��_Tools��6   .@�5      m� -   5        $��_Spelling Hints��5      5       5!      m� 5"      $��_File��6   .@�5#      m� $ ApplicationCommands.Open��6   m� 5$      $ ApplicationCommands.Save��6   �� 5%      m� 5&      -   5        $��_Exit��5&      5(   .   5)      5*      c� 5,   
   $	��Top=�6   .@�5-      �� -   5        $
��Exit��5-      6c   �� 5.      �� 5/      -   5        $��Check��5/       � Cursor$
 Help��6�   50      �� 52   
   $��Bottom=�6   
�������.@�53      �� .��54      �� -   5        $��statBarText��54      $��Ready��6/   55      56      � 57   
   $
��Left=�6   
������� � ColumnDefinitions 59      �� 5:      �� 5;      .+�5=      �� $��0��6   $��5��6,   
�������67   �� 5>      $��0��6   $��Stretch=�6)   .+�5?      �� -   5        $��lblSpellingInstructions��5?      $��14(�67   $��	10,10,0,0q�6E   .��6X   Spelling Hints5A      9� 5B      -	   5        $��expanderSpelling��5B      $��
Try these!��63   $��10,10,10,10q�6H   .��5D      �� -
   5        $��lblSpellingHints��5D      $��12(�65   5E      5F      �� 5H      -   5        $��txtData��5K      $��1��5H       �� 	IsEnabled$
 True��5I       �� AcceptsReturn$
 True��5J      $��14(�5K      
����  �" �� VerticalScrollBarVisibility$
 Auto=�5M      $	 �� HorizontalScrollBarVisibility$
	 Auto=�5N      .��63   5O      5P      5Q      5R      