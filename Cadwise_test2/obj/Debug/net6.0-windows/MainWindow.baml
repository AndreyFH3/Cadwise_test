   M S B A M L   `   `   `  ����H  DCadwise_test2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Cadwise_test2Cadwise_test2  5   	       Cadwise_test2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Cadwise_test2     5   	     � Title$  
MainWindow��5   	   $	��507��6   $	��393��6)   .��5	      � $��0,0,0,-6q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ ATMBalanceText��5      $
��Left=�6,   $��	10,10,0,0q�6G   $
��Wrap=�6Z   $&�� Баланс банкомата:��6n   $	��Top=�6�   �� 5   
   -   5         ��Name$ CashOutButton��5      $!��Снять средства��6(   $
��Left=�6A   $��	10,91,0,0q�6\   $	��Top=�6o   $	��120��6�   6�   �� 5   
   -   5        $ AddToATM��5      $#��Внести средства��6#   $
��Left=�6=   $��
10,116,0,0q�6X   $	��Top=�6l   $	��120��6�   6�   �� 5   
   -   5         ��Name$ GetMoenyText��5      $
��Left=�6(   $��	10,29,0,0q�6C    �� TextWrapping$
 Wrap=�6V   $��0��6j   $	��Top=�6s   $	��120��6�   �� 5   
   -   5         ��Name$ BigMoneyCheckBox��5      $
��Left=�6.   $��	10,52,0,0q�6J   $	��Top=�6]   $��34��6u   $	��136��6�    d� 	IsChecked$ FalseY�6�   .��5      �� $
��Wrap=�6   <:Большие купбры (снятие более 5000)5   &   5      �� 5   
   -   5         ��Name$ LB��5      $��151,31,34,10q�6   �� 5   
   $
��Left=�6   $��
172,10,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   	 J� RenderTransformOrigin$	 0.424,0.427&�6o   �� 6�   
 � Language$
 ru-ru�6�   $�П��6�   �� 6�   $%�олученные купюры��6�   �� 6�   �� 6�   6�   5      5      