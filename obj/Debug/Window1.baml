   M S B A M L   `   `   `  ����  WpfApplication1    WpfApplication1.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      a ]Awesomium.Windows.Controls, Version=1.7.4.1, Culture=neutral, PublicKeyToken=7a34e179b8b61c39,awe"http://schemas.awesomium.com/winfx  5        � Title$  Window1��5      $	��342��6   $	��474��6"   .��5      �  J� Effect 5   
   -  'System.Windows.Media.Effects.BlurEffect  5      6    � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��20q�6   
������� 5      �� 5      -   5         ��Name$ Col00��5   .   $��1* �6#   6.   �� 5      -   5        $ Col01��5   .   $��1* �6#   6.   .+�5      �� $��5��6   
����� �6%   5      � 5   
   $��20q�6   $��1��6   
������� 5      �� 5      ��6#   ��  �� ElementName$ Col00�� �� Path$ Width��� 5      ��6#   �� $ Col01��$ Width�.+�5      �� 
����d�6   5      � 5    
   $��1��6    5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"      6%   .+�5$      A� $��Center=�5%      $��Center=�5&      $	��100��5'      $	��100��6   $��5��5(      
��� � � �� StrokeDashArray$ 50 50R�5*       �� StrokeDashCap$ Round=�5+       J� RenderTransformOrigin$ 0.5,0.5&�5,      z�5-      �� 5.      	 �� Angle$	 0Q�6&   
 � Triggers
 50      :� 51       :� RoutedEvent$ Loaded��6#   .[�52      �� .��53      �� .��54   "   W�  �� TargetProperty$ RenderTransform.Angle�62    g� Duration$ 0:0:1.7D�6d    W� From$ 0X�6w   	 W� To$	 360X�6�    g� RepeatBehavior$ Forever��6�   W� 55   "    g� AutoReverse . $ Opacity�6E   $ 0:0:0.7D�6i   $ 0X�6|   $ 1X�6�   $ Forever��6�   56      57      58      5:      5;      5=      5>      