   M S B A M L   `   `   `  ����  WpfApplication1    WpfApplication1.Win3D   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  Win3D��5      $	��512��6   $	��736��6    .��5      � .+�5   
   � 
���   �$��0 0 0 40q�6"   .+�5      '� -   5         '�Name$ viewport3D1��5       '� Camera 5	      =� 5
      -   5        camMain�� � Position$ 0 10 101�5
   ;    � LookDirection$ 0 -1 -15�6P    �� 	Transform 5      Y� 5      .�5   "   ��  �� Rotation 5   &   �� 5   *   -   5        
rotate�� �� Axis$ 0 1 05�5   N   5   #   �� 5   "    5   &   �� 5   *   -   5        rotate2��$ 1 0 05�5   O   5   #   5      5      5;      5<      �� 5>   
   $��20��5?      $��10q�5@      $��Bottom=�5A       � Maximum$	 360Q�5B      	 � Value	 5C      �� 
 �� ElementName$
 rotate2�� �� Path$ Angle�5D      5E      