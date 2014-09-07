Jenkins96HashBreaker
====================

## What does it do?
This program creates 8 threads which will simultanously calculate hashes and compare them with the ones in `missing.txt`, i.e. tries to brute force file names.

**Please note:** At the moment, it will only generate file names like `SOUND\MUSIC\DRAENOR\MUS_60_###.MP3` where `###` is some random file name with a maximum length of 13 letters (excluding the suffix like `_A` etc).

**Please note:** in order to save time, it will only find file names like `SOUND\MUSIC\DRAENOR\MUS_60_TOME_A.MP3` and *not* `SOUND\MUSIC\DRAENOR\MUS_60_TOME_B.MP3`.
So be smart:
- if you see a file name with `_A`at the end, make sure to add a version with `_B` and maybe`_C` at the end to `filelist.txt` as well
- if you see `_01`, add `_02` and `_03` as well
- etc.


## How to use
1. Make sure missing.txt is in the same directory as the executable file.
2. Run the executable file.
3. Watch your computer's cpu load go to its maximum
4. Wait
5. ??
6. Hit Ctrl+C when you think you have done enough or close the command window
7. Profit: results are stored in found.txt
8. 

## But what about my texture file names?
Feel free to modify the source code to your needs.

## Credits
The implemenatation of the Jenkins96 hash algorithm is from @tomrus88, see
https://github.com/tomrus88/CASCExplorer/blob/master/CASCExplorer/Jenkins96.cs
