   M S B A M L   `   `   `  ����K  GA3ManuelMartinez, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:A3ManuelMartinezA3ManuelMartinez  5   	   !    A3ManuelMartinez.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:A3ManuelMartinez     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� .+�5   
   �� -   5         ��Name$ 	lblCities��5      $��Cities��6#   $	��102��64   $��23��6@    �� Left$	 400��6L   
 �� Top$ 48��6^   6p   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	grdCities��5      $	��375��6&   $	��319��62   $	 400��6?   $ 87��6Q   $��Center=�6a   $	��Top=�6~   5      �� 5   
   -   5        $ lblContinents��5      $��
Continents��6'   $	��102��6<   $��23��6H   $ 48��6T   $ 48��6e   $
��Left=�6u   $��Center=�6�   6�   �� 5   
   -   5         ��Name$ cmbBoxContinents��5      $	��220��6b   $��23��6n   $	 135��6z   $ 50��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5   
   -   5        $ lblCountries��5      $��	Countries��6&   $	��102��6:   $��23��6F   $ 48��6R   $	 101��6c    J� RenderTransformOrigin$ 
0.5,-4.085&�6t   $��Center=�6�   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ lstBoxCountries��5      $	��307��6_   $	��128��6k   $ 48��6x   $	 129��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ lblLanguage��5      $��
Languages:��6%   $	��102��6:   $��32��6F   $ 48��6R   $	 273��6c   $��Center=�6t   $	��Top=�6�   6�   �� 5   
   -   5        $ lblLanguages��5      $��Languages list here��6&   $	��205��6D   $��26��6P   $	 150��6\   $	 273��6n   $��Center=�6   $	��Top=�6�   6�   �� 5   
   -	   5        $ lblCurrency��5      $��	Currency:��6%   $	��102��69   $��32��6E   $ 48��6Q   $	 305��6b   $��Center=�6s   $	��Top=�6�   6�   �� 5   
   -
   5        $ lblCurrencies��5      $��Currencies list here��6'   $	��205��6F   $��26��6R   $	 150��6^   $	 305��6p   $��Center=�6�   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ btnAddContinent��5      $��Add Continent��6*   $	��103��6`   $��43��6l   $ 27��6x   $	 363��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ btnAddCountry��5      $��Add Country��6(   $	��105��6Z   $��45��6f   $	 150��6r   $	 363��6�   $
��Left=�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 
btnAddCity��5      $��Add City��6%   $	��102��6R   $��45��6^   $	 276��6j   $	 363��6|   $��Center=�6�   $	��Top=�6�   6�   5       5!      