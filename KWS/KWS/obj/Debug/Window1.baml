   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   C   j fExpression.Samples.PathListBoxUtils, Version=4.0.0.0, Culture=neutral, PublicKeyToken=76319f7ba805fb35�^clr-namespace:Expression.Samples.PathListBoxUtils;assembly=Expression.Samples.PathListBoxUtils#Expression.Samples.PathListBoxUtils 6�    KWS   KWS.Window1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      d `Microsoft.Expression.Controls, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35>ec5http://schemas.microsoft.com/expression/2010/controls  5      3System&clr-namespace:System;assembly=mscorlib  6C   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6y   �#Expression_Samples_PathListBoxUtils^clr-namespace:Expression.Samples.PathListBoxUtils;assembly=Expression.Samples.PathListBoxUtils  6�   -   5          �Name$  Window��5       � Title$ Window1��5      $
��1980��5      $
��1080��6    � WindowStyle$
 None=�6    � WindowState$ 	Maximized=�60      ImageBrush1#���   6H    � 	Resources 5	       �� ImageSource  ItemTemplate  PathListBoxStyle1 �� 
TargetType/  )Microsoft.Expression.Controls.PathListBox �� Property �� Value-  'Microsoft.Expression.Controls.PathPanel	 K� IsItemsHost
 �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime R� Value  System.Windows.Visibility �� CornerRadius �� Padding ��Name � ToolTip _�Name _� 	Placement � Triggers :� RoutedEvent �Name J� Opacity J� RenderTransformOrigin T� X   Transitions%  System.Windows.VisualTransition   GeneratedDuration    From!   GeneratedEasingFunction"   
Storyboard	#   To$ g� Duration	% W� To& W� EasingFunction-  'System.Windows.Media.Animation.BackEase'   	Amplitude7	  1System.Windows.Media.Animation.EasingFunctionBase( 	  
EasingMode) � UseLayoutRoundingD
  >Expression.Samples.PathListBoxUtils.PathListBoxItemTransformer* 
  
IsCentered+ 
  
ScaleRange, 
  OpacityRange- T� Y. 
  Ease-  'System.Windows.Media.Animation.SineEase��%�  &	        &	 8     &	 �     �� 5
      $$ pack://siteoforigin:,,,/bg.jpg��6#   �� 5      .R�5      �� .+�5      �� $
��Left=�6)   $	��170��6D   $	��170��6Q   ��6   �� *	Property1+6Q   5      5      �� 5      "  6$   .�5      ��  � �� .  6!   �� 5       �@�UseLayoutRounding .  6)   �� 5       � �� 5      �� 5      .R�5        	 . 6   5      5      �� 5       � �� 5      �� 5      "
  6   .R�5      �  5   	     5   
   ValidationStates��. 5         	Valid��6     5!      InvalidUnfocused��. 5"      �� .��5#      T� $ 
Visibility�6+   $ ValidationErrorElement��6R   ..�5$      i� $ 0��6%    5%       5&      Visible=�6$   5(      5)      5*      5+        5,      InvalidFocused��. 5-      �� .��5.      T� $ 
Visibility�6+   $ ValidationErrorElement��6R   ..�5/      i� $ 0��6%    50       51      Visible=�6$   53      54      T� 55      $ IsOpen�6+   $ validationTooltip��6N   ..�56      i� $ 0��6%    57      ��58      True��6%   5:      5;      5<      5=      5>      .+�5@   	   �� #��z��6   #��z��6<   #��z��6p   $ 2��6�   # z��6�   ._�5A   
   �� 5B   
   �� 5C   	   $ ValidationErrorElement��6   ���	#FFDB000C#��z��6H   $ 2��6|   $y�	Collapsed=�6�    5D   
   _� 5E      $ validationTooltip��6   $ Right=�6.    5F      :� 5G      $ FrameworkElement.Loaded��6   .[�5H      �� .��5I      �� .��5J      T� $ IsHitTestVisible�6.   $ validationTooltip��6[   ..�5K      i� $ 0��6(    5L      ��5M      True��6(   5O      5P      5Q      5R      5S      ��5U      �� 5V      .R�5W      � $
 Root��6   $	��5,0q�6!   $ 0Q�6.   $	 0,0&�6:   z�5X      T� 5Y      $	 -25Q�6#    5[        5\      
OpenStates�� 5]        5^      $ 0D�63     6#   Z� ! 6I   Z� " 6l   Z� # 6�   Z�   5_      $ 0:0:0.2D�63   $
# Open��6r     6#   Z� ! 6O   Z� ." 5`      �� .��5a      W� $$ 0:0:0.2D�6$   $% 0X�67   $ X�6>   $ xform��6\   & 5b        5c      $	' 0.3Q�6   $( EaseOut=�6/   5e      W� 5f      $$ 0:0:0.2D�6$   $% 1X�67   $ Opacity�6>   $
 Root��6b   5g      5h      . 5j        
Closed��. 5k      �� .��5l      W� $$ 0D�6#   $% 0X�60   $ Opacity�67   $
 Root��6[   5m      5n        5o      Open��. 5p      �� .��5q      W� $$ 0D�6#   $% 0X�60   $ X�67   $ xform��6U   W� 5r      $$ 0D�6#   $% 1X�60   $ Opacity�67   $
 Root��6[   5s      5t      5u      .+�5w      �� ���	#052A2E31$ 5��6-   $��	4,4,-4,-4q�6>   �� 5x      ���	#152A2E31$ 4��6-   $��	3,3,-3,-3q�6>   �� 5y      ���	#252A2E31$ 3��6-   $��	2,2,-2,-2q�6>   �� 5z      ���	#352A2E31$ 2��6-   $��	1,1,-1,-1q�6>   �� 5{      ���	#FFDC000C$ 2��6-   �� 5|      $ 2��6   ._�5}      �� 
�������$	��250��6-   $	��8,4q�6<   $
��Wrap=�6I   ) .  ��6]   �� *%#(Validation.Errors)[0].ErrorContent+6�   5~      5      5�      5�      ._�5�   
   � 
������ $��Right=�6(   $��10��6D   $��	0,-4,-4,0q�6P   $	��Top=�6c   $��10��6{   .+�5�      F� ;����@B     р�[     � z �� ��� �� �J]� z ��j 	���	#FFDC000C$��-1,3,0,0q�6E   F� 5�      +����        р�     � z ��[ � z  z 	
�������$��-1,3,0,0q�65   5�      5�   
   
  5�   	   $
��Left=�6H   $	��Top=�6c   * . $+ 0.8,3.6&�6�   $, 0.2,0.99&�6�   $ 0.5,0.5&�6�   z�5�   
   V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      $- 98Q�6   $ 33Q�6&   5�      . 5�   
     5�      $( EaseIn=�6   .��5�   
   � $ TransformerParentGrid��6   $��Stretch=�6.   $
��Auto��6L   $��Stretch=�6Z   $
��Auto��6v   5�   
   5�   	   5�      5�      5�      5�      .��5�      � -   5        $ 
LayoutRoot��5�      / � DataContext/ 6   ��   SampleDataSource10 �� Source#0 [ .+�5�      F� -   5        1 F�Name$
1 path��5�   	   ]����x��s�x�����p�	�ѐ`�lj�h	�$g]g3�p�e~?k"��;i��.�l�mxDa7Q��7q�����@ѐ��r���B	$��Right=�6�   $��0,-84,25.999,-60q�6�   2 �� Stretch$
2 Fill=�6	  $��464.001��6    5�      -   5        3  Name$3 deckScroller��5�      $��Right=�6)   $��515.5��6E   4   	WrapItems4 . #���  6d   #���  6�   ��6�   �� *
Collection+5   LayoutPaths5 5�      .  (Microsoft.Expression.Controls.LayoutPath  5�      6   Distribution$
6 Even=�6?   7   Capacity?  9Microsoft.Expression.Controls.LayoutPathCapacityConverter$7 14 6S   8   Start$
8 0.07Q�6a   9   FillBehavior$9 	NoOverlap=�6n   :   SourceElement: 6   �� ; �� ElementName$
; path��6n   .  (System.Windows.Interactivity.Interaction<   	Behaviors< 5�      C  =Expression.Samples.PathListBoxUtils.PathListBoxScrollBehavior  5�      =   DesiredOffset$	= 0.5Q�6D   >   HideEnteringItem> . ?   Ease? 5�        5�      $( EaseOut=�6   $	' 0.7Q�6&   @   Triggers@ 5�      /  )System.Windows.Interactivity.EventTrigger  5�      3  -System.Windows.Interactivity.EventTriggerBaseA   
SourceName$A deckScroller��6   B   	EventName$B Click��6a   C   SourceObjectC 61   �� $; 
downButton��.  (System.Windows.Interactivity.TriggerBaseD   Actions.D 5�   	   6  0System.Windows.Interactivity.InvokeCommandAction  E   CommandName$E DecrementCommand��6   5�   	     5�      $A deckScroller��6   $B Click��6_   C 61   �� $; upButton��.D 5�   	     $E IncrementCommand��6   5�   	     5�      $A deckScroller��6   $B SelectionChanged��61   .D 5�   	     $E ScrollSelectedCommand��6   5�   	   5�      5�      �� 5�      -   5        F ��Name$F 
downButton��5�      $��v��6   $��Right=�6+   $
��52.5��6G   $��0,0,515.5,5.5q�6U   $��Bottom=�6l   $
��48.5��6�   �� 5�      -   5        $F upButton��5�      $��^��6   $��40��6)   $
��48.5��65   $��Right=�6B   $��0,8,515.5,0q�6^   $	��Top=�6s   $ 2.077,0.043&�6�   5�      5�      