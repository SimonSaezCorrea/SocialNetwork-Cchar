   M S B A M L   `   `   `  ����E  ARed Social, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Red_Social
Red_Social  5   	        Red_Social.AbrirComentario   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Red_Social     5   	     � Title$  TheNewSocial��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� $��
Comentario��6   $
��Left=�6%   $��
362,10,0,0q�6@   $	��Top=�6T   $��Comic Sans MS)�6l   �� 5   
   -   5         ��Name$ 	Contenido��5      $
��Left=�6%   $	��120��6@   $��	30,50,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��730��6�   {�.  6�   �� 5   
   -   5        $ Autor��5      $
��Left=�6!   $��26��6<   $��
75,175,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��133��6�    J� RenderTransformOrigin$ 0.679,0.538&�6�   {�.  6�   �� 5   
   $��Autor��6   $
��Left=�6    $��
30,175,0,0q�6;   $	��Top=�6O   $��26��6g   $��Comic Sans MS)�6s   �� 5   
   -   5        $ FechaPublicacion��5      $
��Left=�6,   $��26��6G   $��331,175,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��133��6�   $ 0.679,0.538&�6�   {�.  6�   �� 5   
   $��Fecha Publicacion��6   $
��Left=�6,   $��222,175,0,0q�6G   $	��Top=�6\   $��26��6t   $��Comic Sans MS)�6�   �� 5   
   -   5        $��Likes��5      $
��Left=�6   $��26��6:   $��555,175,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $��28��6�   $ 0.679,0.538&�6�   {�.  6�   �� 5   
   $��Likes��6   $
��Left=�6    $��511,175,0,0q�6;   $	��Top=�6P   $��26��6h   $��Comic Sans MS)�6t   �� 5   
   -   5        $
��Like��5      $
��Left=�6   $��588,175,0,0q�68   $	��Top=�6M   $��27��6e   $��26��6p   $ 1.634,0.583&�6|   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��../Images/Like.jpg��6   $
��Fill=�64   $��-3,-3,-3,-2q�6C   5      5      �� 5   
   -   5         ��Name$ ListComentarios��5      $
��Left=�6+   $	��130��6F   $��
30,216,0,0q�6S   $	��Top=�6g   $	��730��6   ��5      �� 5      .R�5      � $��2q�6    � ColumnDefinitions 5      �� 5       $��* �6/   .+�5"      �� $��0��6$   ��64   �� *	Content+5#      5$      5&      �� 5'   
   -   5         ��Name$ Comentar��5'      $��Comentar��6#   $
��Left=�66   $��
30,351,0,0q�6Q   $	��Top=�6e   $	��100��6}   $��Comic Sans MS)�6�   6�   �� 5(   
   -   5        $ VerComentario��5(      $��Ver comentario��6(   $
��Left=�6A   $��135,351,0,0q�6\   $	��Top=�6q   $	��100��6�   $��Comic Sans MS)�6�   6�   �� 5)   
   -	   5        $ Cancelar��5)      $��Cancelar��6#   $
��Left=�66   $��707,389,0,0q�6Q   $	��Top=�6f   $��75��6~   $��Comic Sans MS)�6�   6�   5*      5+      