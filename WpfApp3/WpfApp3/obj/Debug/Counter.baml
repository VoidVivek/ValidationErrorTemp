   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5          WpfApp3.Counter   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp3     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6    z� SharedSizeGroup$ labels��6,   �� 5      $
��Auto �6   .+�5   
   �� $��6,0,5,0q�6   $��Center=�6%   $��Stretch=�6@   $��0��6^   $��0��6k   $��Counter Type��6{   �� 5   
   $��0,2,0,2q�6   $��Center=�6%   $��Stretch=�6@   $��0��6^   $��1��6k   ��6{   ��  �� Path$ Values� �� SelectedValue 5      �� *SelectedValue+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5      �� *SelectedValue+$ PropertyChanged=�5      �� 5   
   $��6,0,5,0q�6   $��Center=�6%   $��Stretch=�6@   $��1��6^   $��0��6k   $��
Sequential��6{   �� 5   
   $��1��6   $��1��6    $��0 2 0 2q�60   6C   �� 5   
   $��2��6   ._�5      � .+�5      �� $��6,0,5,0q�6   $��Center=�6)   $��Stretch=�6D   $��2��6b   $��0��6o   $��Counter Value��6   "   WpfApp3.NumericUpDownControl  5      $��Stretch=�6)   $��2��6N   $��1��6[   $��Center=�6l   $��Stretch=�6�   5       5!      5#      5$      