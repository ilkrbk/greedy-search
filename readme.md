# Greedy search

### Go to

```
./greedy-search/bin/Debug/test1.txt
```

Enter cities list and distance matrix

```
city1 city2 city3 city4 ... cityN
distance matrix
```

### File example

```
Гюмри Ванадзор ... Вайк Джермук
0 63 0 144 97 0 120 0 ... 0
63 0 71 89 138 105 0 0 .. 0
0 71 0 87 0 103 130 0 ... 0 
144 89 87 0 0 49 52 0 ... 0 
97 138 0 0 0 0 45 0 0 ... 0
0 105 103 49 0 0 91 0 ... 0
120 116 130 52 45 91 0 .. 0
0 0 0 0 0 0 0 0 40 0 0 .. 0
. . . . . . . . . . . . . 0
0 0 0 0 0 0 0 0 103 0 ... 0
```

### Run the program
Enter on line 113 the city from which we will calculate the distance and the city to which we will calculate the distance.

```
112 | Algoritm mainAlgo1 = new Algoritm("test1.txt");
113 | (double, List<string>) result = mainAlgo1.GreedySearch("Ереван", "Раздан");
```