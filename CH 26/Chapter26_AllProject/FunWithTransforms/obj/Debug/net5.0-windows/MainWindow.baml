   M S B A M L   `   `   `  ����L  HFunWithTransforms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FunWithTransformsFunWithTransforms  5   	   "    FunWithTransforms.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FunWithTransforms     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   .+�5      �� -   5        $��btnSkew��5      $
��Skew��6$   63   �� 5      -   5        $��	btnRotate��5      $��Rotate��6&   67   �� 5      -   5        $��btnFlip��5      $
��Flip��6$   63   5      �� 5   
   -   5         ��Name$ myCanvas��5      $��1��6#   $��0��63    J� RenderTransformOrigin$ 0.5,0.5&�6@    � LayoutTransform 5      V� 5      .~�5      ��  �� ScaleX$ 1Q�6%   �� 5       �� AngleX$ 0Q�6$   �� 5       �� Angle$ 0Q�6&   T� 5       T� X$ 0Q�6)   	 T� Y$	 0Q�6/   5      z�5      V� 5      .~�5      �� �� 5      �� 5       T� 5!      5"      .+�5$      A� $
��Left=�6   $	��Top=�61   $	��186��6I   $��92��6V   
���   �
 �� Left$
 20��6p   
 �� Top$ 31��6�   ��5%      
� 5&      .��5'      �  � Color$ 	#FF951ED8��6'    � Offset$ 0.215Q�69   � 5(      $ 	#FF2FECB0��6'   $ 1Q�69   5)      5+      A� 5,      $
��Left=�6   $	��Top=�61   $	��101��6I   $	��110��6V   
���   �$	
 122��6q   $	 126��6�   ��5-      �� 5.       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5/      � $ 	#FFB91DDC��6'   $ 0.355Q�69   � 50      $ 	#FFB0381D��6'   $ 1Q�69   51      53      54      55      56      