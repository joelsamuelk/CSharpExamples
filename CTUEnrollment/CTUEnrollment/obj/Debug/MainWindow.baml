   M S B A M L   `   `   `  ����H  DCTUEnrollment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CTUEnrollmentCTUEnrollment  5   	       CTUEnrollment.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CTUEnrollment     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 grid��5      $��10,25,10,10q�6!      
IsReadOnly .    CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  6�   o� 5   
   -   5         o�Name$
 menu��5      $��18��6   $	��Top=�6)   .@�5      m� $��Campuses��6   .@�5      m� -   5        $
��View��5      6)   m� 5      -   5        $	��Add��5      6(   5      m� 5      $��Students��6   .@�5      m� -   5        $
��View��5      6)   m� 5      -   5        $	��Add��5      6(   5      m� 5      $��Parents��6   .@�5      m� -   5        $
��View��5      6)   m� 5      -   5        $	��Add��5      6(   5      m� 5      $��Hardware��6   .@�5      m� $
��View��6   m� 5       $	��Add��6   5!      m� 5#      $��Assigned PCs��6   .@�5$      m� $
��View��6   m� 5%      $	��Add��6   5&      5'      5)      5*      