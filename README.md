# UlystaTest
ParsingFile

12.02.2021 21:40 UPDATE
Algorithm totaly compeleted


12.02.2021 15:09
The algorithm is not fully completed and I did not even start to bring the code back to normal.
I tried to have time to show exactly which parsing algorithm I used.

First, I started parsing the file line by line, using the split method for parsing by the space symbol,
then I wanted to combine 4 separate parts by column numbers, but when I realized that there are numbers like 4,
which will have 2 characters '|' in the line and the order is violated, then I began to redo the algorithm.

The redesigned algorithm parses each digit separately.
1) We reach the whitespace in the first of 4 lines
2) At the same index, we look at the characters in 3 other lines,
    - If there is a space character everywhere,
           then we select substrings by this index
           remove trailing spaces
    - If somewhere it is not a whitespace yet,
	then move the index further so that in each line at this index there is a whitespace symbol
Thus, we get a substring by which we can determine what kind of digit we have


