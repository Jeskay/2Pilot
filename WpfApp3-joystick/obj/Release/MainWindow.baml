   M S B A M L   `   `   `  ���� K  GWpfApp3-joystick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApp3_joystickWpfApp3_joystick  !    WpfApp3_joystick.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:WpfApp3_joystick     -     �Name$  MainWin�� � Title$ 
MainWindow��$��777.666��$
��1080��$
��1920��$
��1080�� � 	Resources  �� 
TargetType   TBGreyTheme �� Property �� Value  LabelGreyTheme��%�   &	        &	 �     �� " ��.���  � ��$	 235����  � ��$ 80����  � ��
 �������  � ��$ 21(���  �@��TextWrapping$
 Wrap=��� " ��.���  � ��$	 210����  � ��$ 80����  � ��$ 20(�.���� -    ��Name$ Programs_TabControl��$��	2,1,1.6,0q�$��Right=�$��Bottom=�.@��� -    ��Name$ 	Ruler_Tab��$��Ruler��.��� -    �Name$ RulerTab_Grid�����	#FFE5E5E5$
��Left=�$��
0,0,-0.2,0q�$
��1065��$	��720��$	��Top=�.+�� -   $ myGrid��$��-3,45,196.8,0q�	 K� ZIndex$	 2��.+��� -   
 ��Name$
 ImageWebcam1��$
��Left=�$	��847��$	��Top=�$��3��$	 3��r� -    r�Name$ ME_test��$��2��$
��Left=�$	��368��$��
57,337,0,0q�$	��Top=�$	��492�� r� LoadedBehavior$ Manual=� r� Source$ Video/Putin.mp4?� r� Volume$ 2Q�$y�	Collapsed=�$	 4���� -    ��Name$ Images_GroupBox��$��Images��$��	0,10,1,20q�$��Right=�$	��193��$	 3��.��� -	   $ Images_Grid��$
��Left=�$	��516��$��-6,-6,-12,-6q�$	��Top=�$	��199��.+��� -
    ��Name$ 
Images_Box��$
��Left=�$	��691��$��10,10,0,-185q�
����d�$	��Top=�$	��179���� -    ��Name$ RulerCamera_ComboBox��$
��Left=�$��46��$��
0,-1,0,675q�$��Bottom=�$	��252��.@�	� -    	�Name$ RulerStandartCamera_RB��$��Default Camera��$��50��$	��245�� 	� 	GroupName$ RulerCameraSelection�� d� 	IsChecked$
 TrueY�	� -   $ RulerFirstCamera_RB��$��Camera 1��$��50��$	��245��$ RulerCameraSelection��	� -   $ RulerSecondCamera_RB��$��Camera 2��$��50��$	��245��$ RulerCameraSelection���� -   $ MicroRov_Tab��$��MicroRov��.��� -   $ 
Main_Grid1��$
��Left=�$��
0,0,-0.2,0q�$
��1065��$	��720��$	��Top=�.+�� -   $ MicroRov_Grid��$
��Left=�$	��664��$��0,46,0,0q�$	��Top=�$	��861��.+��� -   $
 MicroROV_Image��$
��Left=�$	��Top=��� -   $ MicroROVCamera_ComboBox��$
��Left=�$��46��$��	0,0,0,674q�$��Bottom=�$	��252��.@�	� -   $ MicroROVStandartCamera_RB��$��Default Camera��$��50��$	��245��$ RulerCameraSelection��$
 TrueY�	� -   $ MicroROVFirstCamera_RB��$��Camera 1��$��50��$	��245��$ RulerCameraSelection��	� -   $ MicroROVSecondCamera_RB��$��Camera 2��$��50��$	��245��$ RulerCameraSelection��	� -   $ _9600BaudRate_RB��$��9600 Baud rate��$
��Left=�$��38��$��
899,46,0,0q�$	��Top=�$	��156��$ BaudRate��$
 TrueY�	� -   $ _115200BaudRate_RB��$��115200 BaudRate��$
��Left=�$��38��$��
899,84,0,0q�$	��Top=�$	��156��$ BaudRate���� -    ��Name$ 
COMPort_TB��$
��Left=�$��49��$��899,165,0,0q� �� TextWrapping$
 Wrap=�$��20��$	��Top=�$	��156���� -    ��Name$ COMPort_Label��$��COMPort:��$
��Left=�$��43��$��899,122,0,0q�$	��Top=�$	��156���� -    ��Name$ StartUART_Button��$��Start��$
��Left=�$��59��$��899,219,0,0q�$	��Top=�$	��156���� -   $ Direction_Label��$��	Direction��$
��Left=�$��39��$��871,432,0,0q�$	��Top=�$��70���� -   $ MotorPower_Label��$��
MotorPower��$
��Left=�$��44��$��861,471,0,0q�$	��Top=�$��85���� -   $ LightBrightness_Label��$��LightBrightness��$
��Left=�$��39��$��861,515,0,0q�$	��Top=�$��85���� -   $ DirectionData_label��$
��Left=�$��39��$��946,432,0,0q�$	��Top=�$	��109������  �� Path$ 	Direction� �� UpdateSourceTrigger$ PropertyChanged=��� -    $ MotorPowerData_label��$
��Left=�$��44��$��951,471,0,0q�$	��Top=�$	��104������ $ 
MotorPower�$ PropertyChanged=��� -!   $ LightBrighnessData_label��$
��Left=�$��39��$��946,515,0,0q�$	��Top=�$	��109������ $ LightBrightness�$ PropertyChanged=��� -"   $ SendingData_Label��$
��Left=�$	��149��$��871,283,0,0q�$	��Top=�$	��194������ $ SendingData�$ PropertyChanged=��� -#   $ Recognition_Tab��$��Recognition��.��� -$   $ 	Main_Grid��.+��� -%   $ FindFigures_GroupBox��$��Finded Figures��$
��Left=�$	��700��$��
847,10,0,0q�$	��Top=�$	��217��.��� -&   $ GoupBox_Grid��$
��Left=�$	��668��$	��Top=�$	��197��$��
10,10,-2,0q�.+��� -'    ��Name$ Figures_Canvas��$
��Left=�$	��658��$	��Top=�$	��118��.+��  � Points' �   ��� �w� ����� �w��w�
���  ��$	��130��
 �� Top$	 156��$	��118��A�  �� Left$ 23��
���  ��$��75��$��75��$ 10���� $	��100��$��39��
���  ��$ 10��$	 400���� $��70��$��70��
���  ��$ 23��$	 560���� -(   $ Circles_Label��$
��Left=�$��90��$��	118,0,0,0q�$	��Top=�$��79��$��64(�$��Segoe UI Black)�
���  ������ *	Circles+�� -)   $ Triangles_Label��$
��Left=�$��90��$��118,178,0,0q�$	��Top=�$��79��$��64(�$��Segoe UI Black)�
���  ������ *	Triangles+�� -*   $ Rectangle_Label��$
��Left=�$��90��$��118,372,0,0q�$	��Top=�$��79��$��64(�$��Segoe UI Black)�
���  ������ *Lines+�� -+   $ Square_Label��$
��Left=�$��90��$��118,550,0,0q�$	��Top=�$��79��$��64(�$��Segoe UI Black)�
���  ������ *	Squares+� -,   $ ReacognitioCamera_Grid��$
��Left=�$	��669��$��0,51,0,0q�$	��Top=�$	��847��.+��� --   $
 Image1��$
��Left=�$	��847��$	��Top=��� -.   $  RecognitionCamera_ComboBox��$
��Left=�$��46��$��0,0,0,668.2q�$��Bottom=�$	��252��.@�	� -/   $" RecognitionStandartCamera_RB��$��Default Camera��$��50��$	��245��$  RecognitionCameraSelection��$
 TrueY�	� -0   $ RecognitionFirstCamera_RB��$��Camera 1��$��50��$	��245��$  RecognitionCameraSelection��	� -1   $  RecognitionSecondCamera_RB��$��Camera 2��$��50��$	��245��$  RecognitionCameraSelection���� -2   $ Calculation_Tab��$��Calculation��.��� -3   $ Calculation_Grid��.+��� -4   $ OutputData_Label��$
��Left=�$	��202��$��
511,31,0,0q�$	��Top=�$	��496�����	#FFCBC6C6$��24(����� $ CalculationResult�$ PropertyChanged=��� -5   $ Data_GroupBox��$��Данные��$
��Left=�$	��700��$��	20,10,0,0q�$	��Top=�$	��469��.��� -6   $ Calculation_Grid1��$
��Left=�$	��690��$	��Top=�$	��459��$��
0,0,-2,-12q�.+��� -7   $ 
R2_TextBox��$
��Left=�$��215,163,0,0q�$	��Top=�#��[  ���� $ SmallRadius�$ PropertyChanged=��� -8   $ firstRadius_Label��$!��Меньший радиус��$
��Left=�$��	0,163,0,0q�$	��Top=�#��[ �� -9   $ secondRadius_Label��$!��Больший радиус��$
��Left=�$��	0,309,0,0q�$	��Top=�#��[ �� -:   $ 
R1_TextBox��$
��Left=�$��215,309,0,0q�$	��Top=�#��[  ���� $ 	BigRadius�$ PropertyChanged=��� -;   $ firstRadius_Label_Copy��$!��Радиус полости��$
��Left=�$��	0,447,0,0q�$	��Top=�#��[ �� -<   $ 
R3_TextBox��$
��Left=�$��214,447,0,0q�$	��Top=�#��[  ���� $ CavityRadius�$ PropertyChanged=��� -=   $ firstRadius_Label_Copy1��$��Общая длина��$
��Left=�$��	0,585,0,0q�$	��Top=�#��[ �� ->   $ Height_TextBox��$
��Left=�$��215,585,0,0q�$	��Top=�#��[  ���� $ TotalLength�$ PropertyChanged=��� -?   $ 
Density_CB��$
��Left=�$��55��$��	10,27,0,0q�$	��Top=�$	��200��$��20(�.@��� -@    ��Name$ 	AF_CBItem��$��AF��  �� 
IsSelected  . �� -A   $ BF_IC_CBItem��$��BF IC���� -B   $ 
FPF_CBItem��$	��FPF���� -C   $ TF_JRA_CBItem��$��TF - JRA��