# TexElper

[![.NET](https://github.com/Kremator1007/TexElper/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Kremator1007/TexElper/actions/workflows/dotnet.yml)

Hello there.

This repository aims to assist with finding possible duplicates in problems lists. The program reads a user-selected folder and compares .tex files in the folder, printing all possible duplicates to a console. (Please note that is assumes that all files to compare are located in one folder)

Please note that starting from the forth release the console input is no used anymore - the program reads input files from "texelperinput.json", located in the same folder as executable, and outputs results to "out.txt". The logs are written into "%appdata%/TexElper/logs", they can help to find the reason of a crash (if there was one).

Sample "texelperinput.json":
```
{
	"SelectedFiles": [],
	"SelectedDirectories": [
		"C:\\Users\\James\\Desktop\\My documents\\Sample problems"
	]
}
```

Sample "out.txt"
```
There are 2 cases of suspected problems repetition:


In files C:\Users\James\Desktop\My documents\Sample problems\Summer_1.tex and C:\Users\James\Desktop\My documents\Sample problems\Summer_2.tex with the text:
1: 3. Докажите неравенство $a^4 + b^4 + c^4 \geq abc(a + b + c)$
2: 2. Докажите неравенство $a^4 + b^4 + c^4 \geq abc(a + b + c)$


In files C:\Users\James\Desktop\My documents\Sample problems\Summer_2.tex and C:\Users\James\Desktop\My documents\Sample problems\Summer_3.tex with the text:
1: 6. Дан параллелепипед с вершинами в узлах целочисленной кубической решетки, внутри которого нет других узлов этой решетки (в том числе на сторонах и гранях). Докажите, что его объем равен объему единичного кубика решетки.
2: 3. Дан параллелепипед с вершинами в узлах целочисленной кубической решетки, внутри которого нет других узлов этой решетки (в том числе на сторонах и гранях). Докажите, что его объем равен объему единичного кубика решетки.

```


# User guide

- From the "Releases" section download the corresponding binary file
- Create "texelperinput.json" file in the same directory as the binary file
- Fill JSON file with content as in the example above
- Run the binary
- Watch the content of "a.txt" created automatically in the same directory