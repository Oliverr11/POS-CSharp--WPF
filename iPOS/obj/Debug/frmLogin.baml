   M S B A M L   `   `   `  ����?  ;iPOS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:iPOSiPOS  5   	       iPOS.frmLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:iPOS     5   	     � WindowState$  	Maximized=�5       � Title$ 
MainWindow��5	   	   $
��1200��6   $
��1920��6*   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��2.5* �6   �� 5      $��2* �6   .+�5   
   � $��0��6   
����  �.+�5      �� $��icon/StepLogo.png��6   $��Center=�6/   $��Center=�6J   $	��800��6g   5      � 5   
   $��1��6   .+�5      �� $��Center=�6   $��0q�63   $	��600��6I   $
��1000��6U   ._�5      �  � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      � $��0��6   .+�5      �� $��Login��6$   $��Center=�61   $��Center=�6L   $	��250(�6i   $
��Bold"�6x   $��Vladimir Script font)�6�   5      � 5      $��Center=�6   $��Center=�62   $��1��6O   .+�5       �� $	��600��6!    �� Orientation$ Vertical=�6-   $��Center=�6D   .+�5!      �� $��0,0,0,20q�6$   $��Username��66   $��40(�6F   $��
ExtraLight"�6T   �� 5"      -   5        $��txtUsername��5"   <   $��70��6"   $��40(�6.   .��6O    � 	Resources 5#       �� 
TargetType �� Property �� Value��%_   '��       �� 5$   "   " ��6(   .�5%   &   ��  �@��CornerRadius$ 10��6E   5&   #   5'      .��61   5(      �� 5)      $��0,0,0,20q�6(   $��Password��6:   $��40(�6J   $��
ExtraLight"�6X   �� 5*      	 �� CornerRadius$	 10��6!   
�������$��1q�6F   ._�5+      G� -   5        $��txtPassword��5+   X   $��60��6*   $��40(�66   
�������6X   5,      5-      5/      � 50      $��2��6   .+�51      �  52      �� 53      $	��12* �6/   �� 54      $
��321* �6/   �� 55      $	��33* �6/   �� 56      $
��332* �6/   .+�58      �� -   5        $��0q�58   !   
��� E��
�������$��Right=�6_   $��1��6{   $	��220��6�   $��70��6�   $��CLOSE��6�   $��35(�6�   $
��Bold"�6�    59      ��%_   '��       �� 5:   "   " ��6(   .�5;   &   ��  �@��CornerRadius$ 10��6E   5<   #   5=      5>      �� 5?      -   5        $��0q�5?   %   
����  �
�������$
��Left=�6c   $��3��6~   $	��220��6�   $��70��6�   $��LOGIN��6�   $��35(�6�   $
��Bold"�6�    5@      ��%_   '��       �� 5A   "   " ��6(   .�5B   &   ��  �@��CornerRadius$ 10��6E   5C   #   5D      5E      5G      5H      5I      5J      5L      5M      5N      