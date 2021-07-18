# TexElper

[![.NET](https://github.com/Kremator1007/TexElper/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Kremator1007/TexElper/actions/workflows/dotnet.yml)

Hello there.

This repository aims to assist with finding possible dublicates in problems lists. The program reads a user-selected folder and compares .tex files in the folder, printing all possible dublicates to a console. (Please note that is assumes that all files to compare are located in one folder)

Example (based on the files nobly provided by vk.com/math_contest):

	Please enter the directory with files; otherwise the current directory will be used (C:\Users\James\projects\TexElper\program)
	C:\Users\James\Desktop\My documents\tmp
	There are 2 cases of suspected problems repetition:


	In files Summer_1.tex and Summer_2.tex with the text:
	1: 3. Докажите неравенство $a^4 + b^4 + c^4 \geq abc(a + b + c)$ 

	2: 2. Докажите неравенство $a^4 + b^4 + c^4 \geq abc(a + b + c)$



	In files Summer_2.tex and Summer_3.tex with the text:
	1: 6. Дан параллелепипед с вершинами в узлах целочисленной кубической решетки, внутри которого нет других узлов этой решетки (в том числе на сторонах и гранях). Докажите, что его объем равен объему единичного кубика решетки.  


	2: 3. Дан параллелепипед с вершинами в узлах целочисленной кубической решетки, внутри которого нет других узлов этой решетки (в том числе на сторонах и гранях). Докажите, что его объем равен объему единичного кубика решетки.  

	Press any key to quit