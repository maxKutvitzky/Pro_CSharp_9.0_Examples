   M S B A M L   `   `   `  ����W  SPictureHandlerWithAsyncAwait, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PictureHandlerWithAsyncAwaitPictureHandlerWithAsyncAwait  5      -    'PictureHandlerWithAsyncAwait.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:PictureHandlerWithAsyncAwait     5        � Title$  Fun with TPL��5      $	��400��6   $	��800��6$   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   .��6-   :8Feel free to type here while the images are processed...5      �� 5   
   $��1��6   $��0��6   $��10,10,10,10q�6/   � 5   
   $��2��6   $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��	cmdCancel��5      $��0��6&   $��0��63   $��
10,10,0,10q�6C   .��5      Cancel5      �� 5      -   5        $��
cmdProcess��5      $��0��6'   $��2��64   $��
0,10,10,10q�6D   .��5      Click to Flip Your Images!5      5      5       5!      