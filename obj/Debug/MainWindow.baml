   M S B A M L   `   `   `  ����P  LAvalonEditorExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:AvalonEditorExtension;assembly=AvalonEditorExtensionAvalonEditorExtension  5      J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5          WpfApplication1.MainWindow   5      JavaBclr-namespace:AvalonEditorExtension;assembly=AvalonEditorExtension  'localclr-namespace:WpfApplication1  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      a ]Awesomium.Windows.Controls, Version=1.7.4.1, Culture=neutral, PublicKeyToken=7a34e179b8b61c39,awe"http://schemas.awesomium.com/winfx  5      -   5          �Name$	  Win��5   I    � Title$ 
MainWindow��5      $	��350��6   $	��525��6%    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name	 J� Opacity
 �� Triggers P� Property P� Value �� 
TargetName��%Z  '��       �� 5
   
   " ��6   .�5      ��  � ��$ 50��6&   �� 5       � ��$ 50��6'   �� 5       � �� 5      ��5      Pink��6"   5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� 
��� � �$��2q�65   $ 5��6I   #��z��6Z   ._�5      � .+�5   "   �� #��z��61   #��z��6p   #��z��6�   �� 5   "   $ HR��6,   ���	#7FFFFFFF$	 0Q�6I   5      5      
 5      P� 5       �@J�IsMouseOver . . �5   "   �� $ HR��6)    �@J�Opacity$ 1Q�6L   5      5       5"      5#      5%      .��5&      �  � RowDefinitions 5'   
   �� 5(      $��1* �6   �� 5)      $��1* �6   �� 5*      $��1* �6    � LayoutTransform 5,   
   �� 5-      -   5        WinScale�� �� ScaleX$ 1Q�5-   /    �� ScaleY$ 1Q�6:    � ColumnDefinitions 50   
   �� 51      $��1* �6   �� 52      $��1* �6   .+�55   
   � $��20 20 10 20q�6   ���#EEE 56      �� 57      -   5         ��Name$
 Col1��57   #   $��1* �61   �� 58      -   5        $
 Col2��58   #   $��1* �61   .+�5:      �� $��4��6   
���  ��6%   �� 5;      -   5        $��Button��5;      $��	0 0 -25 0q�6&   $��Right=�69   
���  ��6j   5<      � 5>   
   $��20 20 10 20q�6   ���#EEE$��1��66    5?      �� 5@      ��6#   �� *Width+ �� ElementName$
 Col1���� 5A      ��6#   �� *Width+$
 Col2��.+�5C      �� 
����d�$��1��6.   �� 5D      $
��Test��6   5E      A� 5G   
    J� RenderTransformOrigin$ 0.5 0.5&�6   $��50��62   $��50��6=   
��� � �$��5��6X    �� StrokeDashCap$ Round=�6l    �� StrokeDashArray$
 20 5R�6�   $��	50,50,0,0q�6�   $	��Top=�6�   $
��Left=�6�   z�5H      �� 5I       �� Angle$ 0Q�6"    � Triggers 5K      :� 5L       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5M      �� .��5N      �� .��5O      W�  �� TargetProperty$ RenderTransform.Angle�6.    W� From$ 0X�6`   	 W� To$	 360X�6i    g� Duration$ 0:0:1D�6r    g� AutoReverse .    g� RepeatBehavior$  Forever��6�   5P      5Q      5R      5T      �� 5Y   
   -   5        ! ��Name$! ic��5Y      $��1��6m   $��2��6}   $��10 20 20 20q�6�   ���#eee" � DataContext" 6#   �� *
Personal+$	 Win����6U   �� ��5Z      �� 5[      .R�5\      �� 5]      ��5_      �� 5`      # �� DataType$# local:Person��6   .R�5a      � .+�5b      �� ��6!   Z� ��5c      �� 5d   "   $ �� EndPoint$$ 0.5,1&�66   % �� 
StartPoint$% 0.5,0&�6G   .��5e   &   � & � Color$& 	#FFF0F0F0��63   ' � Offset$' 1Q�6E   � 5f   &   $& White��63   $' 0Q�6A   5g   #   5i      �� 5j      $
��Left=�6B   ��6)   �� *Name+6B   �� 5k      $��Right=�6C   ��6)   �� *Alter+6C   5l      5m      5o      �� 5u   
   $��2��6   $��2��6#   . �5v      /� .T�5w      J� .*�6   .*�5x      �� $�Hallo Titel��6   $��18(�6-   $��Italic$�6;   $
��Bold"�6N   �� 5y      �� 5z      -   5        ( � Cursor$
( Hand��5z       ���	#FF0046FF$��	google.de?�6E   .�6u   Text6{   �� 5{      �� 5|      $���Orbit Logistics ist ein international führender Anbieter von Bestandsmanagement-Lösungen (VMI - Vendor Managed Inventory und SCM - Supply Chain Management) und globaler Echtzeit-Prozessdatenerfassung. Das Unternehmen, gegründet im Jahr 2003, liefert ein modular aufgebautes System für elektronisches Prozessdatenmanagement und betreibt ein weltweites Netzwerk mit eigenen Rechenzentren. Ein hoch qualifiziertes Team aus über 40 Ingenieuren und Technikern bietet maßgeschneiderte Komplettlösungen für Prozessüberwachung und -management.��6   5}      5~      5      5�      5�      