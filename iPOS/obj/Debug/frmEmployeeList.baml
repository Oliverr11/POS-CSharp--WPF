   M S B A M L   `   `   `  ����?  ;iPOS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:iPOSiPOS  5   	       iPOS.frmEmployeeList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:iPOS     5   	     � Title$  frmEmployeeList��5   	   $	��450��6!   $	��800��6.   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgvEmployeeList��5
   G      AutoGenerateColumns .    
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.1* 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Id+  5      $
 Name��6%   $
 0.2* 63    6A   �� *Name+  5      $ Username��6%   $
 0.2* 67    6E   �� *
Username+  5      $ Password��6%   $
 0.2* 67    6E   �� *
Password+  5      $ Phone��6%   $
 0.2* 64    6B   �� *Phone+  5      $ Salary��6%   $
 0.2* 65    6C   �� *Salary+  5      $ Address��6%   $
 0.2* 66    6D   �� *	Address+5      5      5      