   M S B A M L   `   `   `  ����M  IWpfControlsAndAPIs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfControlsAndAPIsWpfControlsAndAPIs  5   	   #    WpfControlsAndAPIs.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WpfControlsAndAPIs     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��800��6)    � 	Resources 5	      *   $WpfControlsAndAPIs.MyDoubleConverter   DoubleConverter��%   &	          5
   
   6"   5      .��5      � .+�5   
   �� -   5        $��MyTabControl��5      $��Stretch=�6)   $��Stretch=�6G   .@�5      �� $��Ink API��6   .��5      �� ���	#FFE5E5E5.+�5      c� -   5        $��
InkToolBar��5      $��60��60   .@�5      �� $��	0,2,0,2.4q�6!   $	��280��64   $��Center=�6@   ._�5      � .+�5   "   	� -   5         	�Name$ inkRadio��5   .   $
��5,10q�6@   $��	Ink Mode!��6N    d� 	IsChecked$
 TrueY�6b   6s   	� 5   "   -   5        $ 
eraseRadio��5   .   $
��5,10q�6B   $��Erase Mode!��6P   6f   	� 5   "   -   5        $ selectRadio��5   .   $
��5,10q�6C   $��Select Mode!��6Q   6h   5      5      �� 5      �� 5      -   5         ��Name$ comboColors��5   #   $	��175��68   $��10,0,0,0q�6D   .@�5      ��  �� Orientation$ 
Horizontal=�6)   
 � Tag$	 Red��6C   .+�5   "   A� 
���  ��$��50��66   $��50��6C   �� 5   "   $��20(�6(   $��Center=�67   $��Center=�6T   $	��Red��6o   5      �� 5      $ 
Horizontal=�6)   $ Green��6C   .+�5   "   A� 
��� � �$��50��68   $��50��6E   �� 5    "   $��20(�6(   $��Center=�67   $��Center=�6T   $��Green��6o   5!      �� 5"      $ 
Horizontal=�6)   $
 Blue��6C   .+�5#   "   A� 
����  �$��50��67   $��50��6D   �� 5$   "   $��20(�6(   $��Center=�67   $��Center=�6T   $
��Blue��6o   5%      5&      �� 5'      � 5(       � ColumnDefinitions 5)      �� 5*   "   $
��Auto �63   �� 5+   "   $
��Auto �63   �� 5,   "   $
��Auto �63   .+�5.      �� -   5         ��Name$ btnSave��5.   5   $��0��6%   $��10,10q�6F   $��70��6U   $��	Save Data��6`   6t   �� 5/      -   5        $ btnLoad��5/   5   $��1��6%   $��10,10q�6F   $��70��6U   $��	Load Data��6`   6t   �� 50      -	   5        $ btnClear��50   5   $��2��6%   $��10,10q�6G   $��70��6V   $��Clear��6a   6q   51      52      �� 53      -
   5        	 ��Name$	 MyInkCanvas��53       
 �� 
Background
 �	#FFB6F4F165   54      55      �� 56      -   5         ��Name$ tabDataBinding��56      $��Data Binding��6.   .��57      �� $	��250��6    � DataContext 6*   ��  �� ElementName$
 mySB��.+�58      �� $2��,Move the scroll bar to see the current value��6   �� 5:      -   5         ��Name$
 mySB��5:        �� Orientation$ 
Horizontal=�6.   $��30��6G    � Minimum$ 1Q�6S    � Maximum$	 100Q�6a    � LargeChange$ 1Q�6q    � SmallChange$ 1Q�6�   �� 5=      -   5         ��Name$ labelSBThumb��5=      $��30��62   
����  �$��2q�6Q   ��6e   ��  �� Path$ Value� �� 	Converter# [  �� 5>      $��Click��6   $	��200��6-   ��6:   �� $ Value�5?      5@      �� 5A      -   5        $ tabDataGrid��5A      $��DataGrid��6+   .��5B      �� .+�5C      &   System.Windows.Controls.DataGrid  -   5          Name$ gridInventory��5C      $	��288��66   5D      5E      5F      5H      5I      