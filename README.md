# C# MineSweeper Project
![Title](https://github.com/Clint-WooliesX/MineSweeper/raw/master/images/MineSweeper.png "Title")

[OSX_Minesweeper_V1.0 release](https://github.com/Clint-WooliesX/MineSweeper/releases/tag/OSX)

See release notes for differences in win64 releases

[Win64_Minesweeper_V1.0 Extended ASCII release](https://github.com/Clint-WooliesX/MineSweeper/releases/tag/Win64extascii)
[Win64_Minesweeper_V1.0 Standard ASCII release](https://github.com/Clint-WooliesX/MineSweeper/releases/tag/Win64)

## Design Brief:
Recreate the Classic game Minesweeper using in a C# Console App, meeting the MVP criteria.

## Features beyond the scope of the MVP:
* Game is rendered to the console using a text based graphical interface
* Grid size  and number of mines can be configured within "appsettings.json"
* discovering  an empty cell will cascade reveal all neighbouring empty cells
* ***Abilty to flag cells as potentially being bombs***
* ***2 Win Scenarios***
  * Uncover all the tiles around the bombs or;
  * Correctly flag all the Mines
* ***Timer to keep score***
* ***App perfoms a startupchecks to ensure console buffersize is large enough to display game***

### if i had more time:
I would have liked to explore the json read and write libraries to implemtent persistent difficulty settings chosen from a game start and high scores table.

### Known issues:
#### Perfomance under Visual studio
Game should be run from the Compiled Binary releases for best performance.
or;
If built and run from Visual Studio use Project > Release mode.

Running the game in debug mode will suffer perfomance issues, and may appear to have freezed for up to 30seconds during some instruction sets.

#### Extended ASCII table support
Text GUI uses extended ASCII characters that may not be suported on in the Windows 10 Console.

Alternate charcters have been provided in the Cell.cs Cell Class.
Lines 27 and 28
and;
Lines 35 and 36

Comment out the escaped extended ASCii characters and uncomment the standadrad charcters.

The game will run a sintended but the grid cells and bomb charcters may appear as "?" instead on thw windows10 OS as the console does not support the extended ASCII character set.

Linux and OSX Zsh terminals supprt these characters by default.




