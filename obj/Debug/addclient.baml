   M S B A M L   `   `   `  ����I  Eиндивид, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:индивидиндивид  5          индивид.addclient   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:индивид     5      -   5          N� Title$  	addclient��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridclient��5      $��0��6+      AutoGenerateColumns .     
IsReadOnly .    	RowHeight$ 30Q�6f      SelectionMode$ Single=�6u      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ код_пациента��6F   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 3* 6\   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *код_пациента+6\     5      $ кличка��6A   $	 3* 6Q   
 6%   �� *кличка+6Q     5      $# фамилия клиента��6J   $	 3* 6c   
 6%   �� * клиент.ф_клиента+6c     5      $# порода_пациента��6]   $	 3* 6v   
 6%   �� *ECпорода_пациента.наименование_породы+6v     5      $ дата_рождения��6G   $	 3* 6^   
 6%   �� *дата_рождения+6^     5      $ вес��6=   $	 3* 6J   
 6%   �� *вес+6J     5      $ пол_пациента��6X   $	 3* 6n   
 6%   �� *;9пол_пациента.наименование_пола+6n     5      $ вид_пациента��6X   $	 3* 6n   
 6%   �� *;9вид_пациента.наименование_вида+6n   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
	 auto 6)   $  Редактировать��66      CellTemplate 5      �� 5      .R�5      ��  ��Name$ 	BtnEditС��6%   -   5        $	��...��5   7   $��0q�6]   5      5       5"      �� 5#   
   -   5        $ BtnAddc��5#      $��1��6"   $	��100��6/   $
��Left=�6;   $��3q�6V   $��Добавить��6a   6t   �� 5$   
   -   5        $ 
BtnDeletec��5$      $��1��6%   $	��100��62   $��Right=�6>   $��3q�6Z   $��Удалить��6e   6w   5%      5&      