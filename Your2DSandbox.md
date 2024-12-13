# Your2DSandbox
### <sp style="color:cyan"> OOP composition, inheritance</sp>

---

## Guide

<details>
<summary><b>Repository</b></summary>

```
Your2DSandbox 
├── Cells
│   ├── ImplementedCells
│   │   ├── Fire.cs
│   │   ├── Glass.cs
│   │   ├── Rock.cs
│   │   ├── Sand.cs
│   │   ├── Steam.cs
│   │   ├── Water.cs
│   │   └── Wood.cs
│   ├── Cell.cs
│   ├── Enum.cs
│   ├── IBurnable.cs
│   ├── IUpdatable.cs
│   └── MovableCell.cs
├── Sim
│   ├── Board.cs
│   └── Simulation.cs
├── Program.cs
├── Your2DSandbox.csproj
├── .gitignore
├── Your2DSandbox.sln
└── README
```

</details>

<details>
<summary><b>.csproj</b></summary>

````
. . .
<ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
. . .
````

</details>

<details>
<summary><b>Authorized Imports</b></summary>

````
using Your2DSandbox.Cells;
using Your2DSandbox.Cells.ImplementedCells;
````

</details>

---

## Easy : Basic Cell & Board

In this first part, we will start with implementing all that is needed for the simulation to take place.
The Simulation will be represented as a Board where each cell will evolve through it.


<details><summary><b>Cells/Enum.cs</b></summary>

First thing first lets create the Enum of every cell type utilized in the simulation

<h4>Code</h4>

```csharp 
public enum CellType
{
    Rock,
    Sand,
    Water,
    Wood, 
    Fire,
    Steam,
    Glass,
}
```

</details>

<details><summary><b>Cells/Cell.cs </b></summary>

We will need a simple abstact <sp style="color:violet">Cell</sp> class for every cell implementation. 

<h4>Prototype</h4>

```csharp 
public abstract class Cell {}
```

<details><summary>Properties</summary>

It has three public Properties with public getter, and protected setter :
 
- <sp style="color:violet">CellType</sp> of type <sp style="color:violet">CellType</sp>
- <sp style="color:violet">Color</sp> of type <sp style="color:violet">ConsoleColor</sp>, used for displaying the cell
- <sp style="color:violet">Representation</sp> of type <sp style="color:violet">char</sp>, also used for displaying the cell

</details>

</details>

<details><summary><b>All the Basic Cell</b></summary>

Let's Implement all the basic cell classes! 

> Warning : All the following classes inherit from <sp style="color:violet">Cell</sp>
 
The constructors take no arguments and must initialize the properties to the following values:

<h4>Cells/ImplementedCells/Rock.cs</h4>

- <sp style="color:violet">CellType</sp> must be set to <sp style="color:violet">CellType.Rock</sp>
- <sp style="color:violet">Color</sp> must be set to <sp style="color:violet">ConsoleColor.DarkGray</sp>
- <sp style="color:violet">Representation</sp> must be set to <sp style="color:violet">R</sp>

<h4>Cells/ImplementedCells/Wood.cs</h4>

- <sp style="color:violet">CellType</sp> must be set to <sp style="color:violet">CellType.Wood</sp>
- <sp style="color:violet">Color</sp> must be set to <sp style="color:violet">ConsoleColor.DarkYellow</sp>
- <sp style="color:violet">Representation</sp> must be set to <sp style="color:violet">B</sp>

<h4>ells/ImplementedCells/Glass.cs</h4>

- <sp style="color:violet">CellType</sp> must be set to <sp style="color:violet">CellType.Glass</sp>
- <sp style="color:violet">Color</sp> must be set to <sp style="color:violet">ConsoleColor.Blue</sp>
- <sp style="color:violet">Representation</sp> must be set to <sp style="color:violet">G</sp>

<h4>Code Example</h4>

```csharp
using Your2DSandbox.Cells.ImplementedCells;

Rock r = new Rock();
Console.WriteLine(r.CellType);
Console.WriteLine(r.Color);
Console.WriteLine(new Glass().Representation);
```

<h4>Output</h4>

```
Rock
DarkGray
G
```

</details>

<details><summary><b>Cells/Cell.cs</b></summary>
Let's return to the Cell class to add a static method that we will be using later.

This function create the correct cell according to the <sp style="color:violet">CellType</sp>.<br>
Currently you should only have <sp style="color:violet">Rock</sp>, <sp style="color:violet">Glass</sp> and <sp style="color:violet">Wood</sp> implemented, 
thus only those aforementioned will be tested at this point, although when you will implement the rest of the cells you will need to add them here.

The function return <sp style="color:violet">null</sp> should the input be <sp style="color:violet">null</sp>.

<h4>Prototype</h4>

```csharp
public static Cell? CellFromCellType(CellType? cellType) { }
```

<h4>Code Example</h4>

```csharp
using Your2DSandbox.Cells;

Console.WriteLine($"new cell:{Cell.CellFromCellType(CellType.Rock)}!");
Console.WriteLine($"new cell:{Cell.CellFromCellType(null)}!");
```
<h4>Output</h4>

```
new cell:Your2DSandbox.Cells.ImplementedCells.Rock!
new cell:!
```

</details>
&nbsp;

<details><summary><b>Sim/Board.cs</b></summary>

Now that we have basic cells lets tackle the <sp style="color:violet">Board</sp> Class

<details><summary>Properties</summary>

It has four public Properties with public getters :

- <sp style="color:violet">Height</sp> and  <sp style="color:violet">Width</sp> of type <sp style="color:violet">int</sp>, the dimensions of our board
- <sp style="color:violet">Cells</sp> of type <sp style="color:violet">Cell?[,]</sp>, used to hold all the cells
- <sp style="color:violet">Random</sp> of type <sp style="color:violet">Random</sp>, used for a bit of randomness in the simulation 
</details>

<details><summary>Constructor</summary>

You now must implement a constructor for the <sp style="color:violet">Board</sp> class.<br>
The constructor needs to initialize all the properties of the class.<br>
- If the <sp style="color:violet">height</sp> or <sp style="color:violet">width</sp> are inferior to 1, an ArgumentException must be thrown.
- The array Cells must be initialised to the size <sp style="color:violet">height</sp> X <sp style="color:violet">width</sp>, filled with null.
- <sp style="color:violet">Random</sp> must be initialized from <sp style="color:violet">seed</sp>.

```csharp
public Board(int height,int width, int seed = 0) { }
```

<h4>Code Example</h4>

```csharp
using Your2DSandbox;
using Your2DSandbox.Cells.ImplementedCells;

Board b = new Board(2,3,42);
b.Cells[1, 2] = new Rock();
Console.WriteLine( b.Cells[1, 0] is null ? "null" : "not null");
Console.WriteLine( b.Cells[1, 2] is null ? "null" : "not null");
```

<h4>Output</h4>

```
not null
null
```

</details>

Lets write some method for later use!

<details><summary>SetCells</summary>
This method is used to create cells in the array. <br>
We trust that the coordinates are correct.

```csharp
public void SetCell(CellType? cellType,int h, int w) { }
```

<h4>Code Example</h4>

```csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Board b = new Board(2,2); 
b.SetCell(CellType.Rock,0,0);
b.SetCell(CellType.Glass,0,1);
b.SetCell(CellType.Wood,1,0);
b.SetCell(CellType.Rock,1,1);
foreach (var c in b.Cells)
{
    Console.WriteLine(c);
}
```

<h4>Output</h4>

```
Your2DSandbox.Cells.ImplementedCells.Rock
Your2DSandbox.Cells.ImplementedCells.Glass
Your2DSandbox.Cells.ImplementedCells.Wood
Your2DSandbox.Cells.ImplementedCells.Rock
```

</details>

<details><summary>SwapCells</summary>
A simple method to switch two cell around the board.<br>
We trust that the coordinates are correct.

<h4>Prototype</h4>

```csharp
public void SwapCells(int h1, int w1, int h2, int w2) { }
```

<h4>Code Example</h4>

```csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Board b = new Board(1,2,42);
b.SetCell(CellType.Rock,0,0);
b.SetCell(CellType.Glass,0,1);
foreach (var c in b.Cells) Console.WriteLine(c);
b.SwapCells(0,1,0,0);
foreach (var c in b.Cells) Console.WriteLine(c);
```

<h4>Output</h4>

```
Your2DSandbox.Cells.ImplementedCells.Rock
Your2DSandbox.Cells.ImplementedCells.Glass
Your2DSandbox.Cells.ImplementedCells.Glass
Your2DSandbox.Cells.ImplementedCells.Rock
```

</details>

<details><summary>FillBoard</summary>
This method set the entirety of the board to a certain cell type. <br>
The parameter can be <sp style="color:violet">null</sp>, and it is the default value.

<h4>Prototype</h4>

```csharp
public void FillBoard(CellType? cellType = null) { }
```

<h4>Code Output</h4>

```csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Board b = new Board(1,2,42);
b.SetCell(CellType.Rock,0,0);
b.SetCell(CellType.Glass,0,1);

int nonNull = 0;
foreach (var c in b.Cells) nonNull += c is not null ? 1 : 0;
Console.WriteLine($"there are {nonNull} non null cells");

b.FillBoard();
nonNull = 0;
foreach (var c in b.Cells) nonNull += c is not null ? 1 : 0;
Console.WriteLine($"there are {nonNull} non null cells");
```

<h4>Output</h4>

```csharp
there are 2 non null cells
there are 0 non null cells
```

</details>
</details>

---

## Intermediate : Simulation & Moving Cells

<details><summary><b>Sim/Simulation.cs</b></summary>

<sp style="color:violet">Simulation</sp> is the wrapper class of the practical.<br>
It has a <sp style="color:violet">Board</sp> and contains method to interact with, run and display the simulation.

<details><summary>Properties</summary>
The <sp style="color:violet">Simulation</sp> class has six public property:

-  <sp style="color:violet">Board</sp> of type <sp style="color:violet">Board</sp> with a only public getter

All of the following property has a public getter and a private setter.

-  <sp style="color:violet">CursorH</sp> and <sp style="color:violet">CursorW</sp> of type <sp style="color:violet">int</sp>
-  <sp style="color:violet">Pause</sp> and <sp style="color:violet">Step</sp> of type <sp style="color:violet">bool</sp>
-  <sp style="color:violet">SelectedCellType</sp> of type <sp style="color:violet">CellType</sp>

</details>

<details><summary>Constructor</summary>
You now must implement a constructor for the <sp style="color:violet">Simulation</sp> class. 

- <sp style="color:violet">Board</sp> must be initialized from the parameters
- <sp style="color:violet">_cursorH</sp> and <sp style="color:violet">_cursorW</sp> must be set to half of the height and half of the width respectively
- <sp style="color:violet">_pause</sp> must be set to <sp style="color:violet">true</sp>
- <sp style="color:violet">_step</sp> must be set to <sp style="color:violet">false</sp>
- <sp style="color:violet">_selectedCellType</sp> must be set at <sp style="color:violet">CellType.Rock</sp>

<h4>Prototype</h4>

```csharp
public Simulation(int h, int w, int seed=0)
```

<h4>Code Example</h4>

````csharp
using Your2DSandbox;

Simulation simulation = new Simulation(7, 20, 32);
Console.WriteLine($"cursorH {simulation.CursorH}, cursorW {simulation.CursorW}");
Console.WriteLine($"Paused : {simulation.Pause}, Step : { simulation.Step}");
Console.WriteLine($"selected celltype : {simulation.SelectedCellType}");
````

<h4>Output</h4>
````
cursorH 3, cursorW 10
Paused : True, Step : False
selected celltype : Rock
````


</details>

<details><summary>Given Code</summary>

The display method being very specific, I give it to you. <br>
You can give a bool as a parameter for it to be prettier in the console. It will not be used in the subject as you can not differentiate the cells.

```csharp
    public void DisplayBoard(bool blockRepresentation = false)
    {
        Console.SetCursorPosition(0, 0);
        
        Console.WriteLine(new String('─',_cursorW+1) +"v" + new String('─',Board.Width-_cursorW) + (_pause ? "  Paused ":  "  Running") + $" | Cell selected {_selectedCellType}  "  );
        for (int i = 0; i < Board.Height; i++)
        {
            Console.Write(i == _cursorH ? ">" : "|");
            for (int j = 0; j < Board.Width; j++)
            {
                if (Board.Cells[i, j] is { } cell)
                {
                    Console.ForegroundColor = cell.Color;
                    Console.Write(blockRepresentation ? "\u2588" :cell.Representation);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine(i == _cursorH ? "<" : "|");
        }
        Console.WriteLine(new String('─',_cursorW+1) +"^" + new String('─',Board.Width-_cursorW));
    }
```

</details>

<h4>Code Example</h4>

```csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Simulation s = new Simulation(6,8 );
s.Board.SetCell(CellType.Glass,1,2);
s.Board.SetCell(CellType.Glass,1,4);
for(int i = 1; i<6; i++) s.Board.SetCell(CellType.Wood,4,i);
s.DisplayBoard();
```

<h4>Output</h4>

```
─────v────  Paused  | Cell selected Rock
|        |
|  G G   |
|        |
>        <
| BBBBB  |
|        |
─────^────
```

</details>

<details><summary><b>Cells/MovableCell.cs</b></summary>

Currently the simulation is not evolving through time so lets implement moving cells to have some motion.

The <sp style="color:violet">MovableCell</sp> class is an abstract class!<br>
It has one public property:

- <sp style="color:violet">GoesUp</sp> of type <sp style="color:violet">bool</sp>, with a public getter and protected setter.

And one abstract method to be implemented by the children:

<h4>Prototype</h4>

```csharp
public abstract void Move(Board b, int h, int w);
```

This method will be directly called in the <sp style="color:violet">Board</sp> class on evey movable cell.

</details>

<details><summary><b>All of the Movable Cell</b></summary>

Let's begin the implementation of MovableCell's child.

> Warning : All the following classes inherit from <sp style="color:violet">Cell</sp>,<br>
While you have not implemented the Move() method just throw a new NotImplementedException() 

The constructors take no arguments and must initialize the properties to the following values:

<h4>Cells/ImplementedCells/Fire.cs</h4>

- <sp style="color:violet">CellType</sp> must be set to <sp style="color:violet">CellType.Fire</sp>
- <sp style="color:violet">Color</sp> must be set to <sp style="color:violet">ConsoleColor.Red</sp>
- <sp style="color:violet">GoesUp</sp> must be set to <sp style="color:violet">true</sp>
- <sp style="color:violet">Representation</sp> must be set to <sp style="color:violet">F</sp>

<h4>Cells/ImplementedCells/Steam.cs</h4>

- <sp style="color:violet">CellType</sp> must be set to <sp style="color:violet">CellType.Steam</sp>
- <sp style="color:violet">Color</sp> must be set to <sp style="color:violet">ConsoleColor.Gray</sp>
- <sp style="color:violet">GoesUp</sp> must be set to <sp style="color:violet">true</sp>
- <sp style="color:violet">Representation</sp> must be set to <sp style="color:violet">V</sp>


<h4>Cells/ImplementedCells/Sand.cs</h4>

- <sp style="color:violet">CellType</sp> must be set to <sp style="color:violet">CellType.Sand</sp>
- <sp style="color:violet">Color</sp> must be set to <sp style="color:violet">ConsoleColor.Yellow</sp>
- <sp style="color:violet">GoesUp</sp> must be set to <sp style="color:violet">false</sp>
- <sp style="color:violet">Representation</sp> must be set to <sp style="color:violet">S</sp>


<h4>Cells/ImplementedCells/Water.cs</h4>

- <sp style="color:violet">CellType</sp> must be set to <sp style="color:violet">CellType.Water</sp>
- <sp style="color:violet">Color</sp> must be set to <sp style="color:violet">ConsoleColor.DarkBlue</sp>
- <sp style="color:violet">GoesUp</sp> must be set to <sp style="color:violet">false</sp>
- <sp style="color:violet">Representation</sp> must be set to <sp style="color:violet">W</sp>


</details>

> Warning! : Now is the time to update **CellFromCellType(CellType? cellType)** in Cells/Cell.cs

<details><summary><b>Cells/MovableCell.cs</b></summary>

Now that we have written the constructor of the child classes, 
let's create some helper methods for the implementation of Move().

<details><summary>GetCellWeight</summary>

A static method that returns the weight of a cell based on its type. <br>
The weight determines if a cell can move into another cell's position. <br>Different cell types have different weights:

- <sp style="color:violet">Steam</sp>: 0
- <sp style="color:violet">Fire</sp>: 1
- <sp style="color:violet">Water</sp>: 2
- <sp style="color:violet">Sand</sp>: 3
- Other: Maximum possible weight

<h4>Prototype</h4>

```csharp
public static int GetCellWeight(CellType cellType) { }
```

<h4>Code Example</h4>

```csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Console.WriteLine($"Weight of Steam: {MovableCell.GetCellWeight(CellType.Steam)}");
Console.WriteLine($"Weight of Rock: {MovableCell.GetCellWeight(CellType.Rock)}");
```

<h4>Output</h4>

```csharp
Weight of Steam: 0
Weight of Rock: 2147483647
```

</details>

<details><summary>TryMoveCell</summary>
A public method that attempts to move a cell from one position to another on the board.<br>
The movement will only succeed if the target position is within bounds and the cell at the target position (if any) is strictly lighter than the cell being moved. <br>
If the conditions are met we switch the two Cell? in the board and the method returns true, otherwise do nothing and return false. <br>
The origin position are considered to be in bound. <br>

<h4>Prototype</h4>

````csharp
public bool TryMoveCell(Board b, int hFrom, int wFrom, int hTo, int wTo)
````

<h4>Code Example</h4>

```csharp

using Your2DSandbox;
using Your2DSandbox.Cells;

Simulation s = new Simulation(1, 3);
s.Board.SetCell(CellType.Sand, 0, 0);
s.Board.SetCell(CellType.Water, 0, 1);
bool move1 = ((MovableCell)s.Board.Cells[0, 1]!).TryMove(s.Board, 0, 1,0,0);
bool move2 = ((MovableCell)s.Board.Cells[0, 0]!).TryMove(s.Board, 0, 0,0,1);
bool move3 = ((MovableCell)s.Board.Cells[0, 1]!).TryMove(s.Board, 0, 1,0,2);
s.DisplayBoard();
Console.WriteLine($"1st : moved successfully : {move1}");
Console.WriteLine($"2nd : moved successfully : {move2}");
Console.WriteLine($"2nd : moved successfully : {move3}");
```

<h4>Output</h4>

```
──v──  Paused  | Cell selected Rock
>W S<
──^──
1st : moved successfully : False
2nd : moved successfully : True
2nd : moved successfully : True
```

</details>

<details><summary>MoveVertically</summary>

A public method that attempts to move  vertically the cell located at height h and width w.<br>
The direction depends on whether the cell goes up or down, and it **tries** to move vertically first. <br>
If the cell could not move then it tries diagonally (beginning by the left).
The method return true if the cell has moved.
<h4>Prototype</h4>

````csharp
public bool MoveVertically(Board b, int h, int w)
````

<h4>Code Example</h4>

````csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Simulation s = new Simulation(2, 3);
s.Board.SetCell(CellType.Sand, 1, 1);
s.Board.SetCell(CellType.Water, 0, 1);
bool move1 = ((MovableCell)s.Board.Cells[1, 1]!).MoveVertically(s.Board, 1, 1);
bool move2 = ((MovableCell)s.Board.Cells[0, 1]!).MoveVertically(s.Board, 0, 1);
s.Board.SetCell(CellType.Water, 0, 1);
bool move3 = ((MovableCell)s.Board.Cells[0, 1]!).MoveVertically(s.Board, 0, 1);
s.DisplayBoard();
Console.WriteLine($"1st : moved successfully : {move1}");
Console.WriteLine($"2nd : moved successfully : {move2}");
Console.WriteLine($"3rd : moved successfully : {move3}");
````

<h4>Output</h4>

````
──v──  Paused  | Cell selected Rock
|   |
>WSW<
──^──
1st : moved successfully : False
2nd : moved successfully : True
3rd : moved successfully : True
````

</details>

<details><summary>MoveHorizontallyErratically</summary>
A public method that attempts to move a cell horizontally in a random direction (left or right). <br>
The method using random here is the explicit details : <br>
We first generate a random number between 0 and 2 both included, and depending the result : 

- 0 => try to move the cell left
- 1 => try to move the cell right
- 2 => nothing

The method returns true if the cell moved.

<h4>Prototype</h4>

````csharp
public bool MoveHorizontallyErratically(Board b, int h, int w)
````

<h4>Code Example</h4>

````csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Simulation s = new Simulation(1, 3, 11);
s.Board.SetCell(CellType.Water, 0, 1);
bool move1 = ((MovableCell)s.Board.Cells[0, 1]!).MoveHorizontallyErratically(s.Board, 0, 1);
s.DisplayBoard();
Console.WriteLine($"moved successfully : {move1}");
````

<h4>Output</h4>

````
──v──  Paused  | Cell selected Rock
>  W<
──^──
moved successfully : True
````

</details>
</details>

<details><summary><b>Implement all the movement</b></summary>

Now that we have some helper function lets write the override the **Move()** method.

<details><summary>Cells/ImplementedCells/Fire.cs</summary>

We want to use some random for the fire, Generate a random between 0 and 1 included :

- If it's a 0 move the cell Vertically
- If it's a 1 move the cell Horizontally

</details>

<details><summary>Cells/ImplementedCells/Sand.cs</summary>

Very simple implementation : move the cell vertically.

</details>

<details><summary>Cells/ImplementedCells/Steam.cs</summary>

Try to move the cell vertically, if it did not move, move the cell horizontally.

</details>

<details><summary>Cells/ImplementedCells/Water.cs</summary>

Try to move the cell vertically, if it did not move, move the cell horizontally.

</details>

</details>

<details><summary><b>Sim/Board.cs</b></summary>

<details><summary>NextBoard</summary>

Let's add a function to Update all the cells inside the Board.

You go through a Copy of the Cells. Make use of the Clone method.

It go through the cloned board, in each cell left to right, top to bottom and if it is a MovableCell
call the method Move on it. 

<h4>Prototype</h4>

````csharp
public void NextBoard()
````

<h4>Code Example</h4>

````csharp
using Your2DSandbox;
using Your2DSandbox.Cells;

Simulation simulation = new Simulation(3 ,2);
simulation.Board.SetCell(CellType.Sand,0,0);
simulation.Board.SetCell(CellType.Water,2,0);
simulation.Board.SetCell(CellType.Water,1,1);
simulation.Board.SetCell(CellType.Water,0,1);
simulation.Board.NextBoard();
simulation.Board.NextBoard();
simulation.DisplayBoard();
````

<h4>Output</h4>

````
──v─  Paused  | Cell selected Rock
|  |
>WW<
|SW|
──^─
````

</details>

<details><summary>FillRandom</summary>

The last method we will implement.
You need to go through the whole Board and fill with a random tile.<br>
To chose the random tile you generate a random number between 0 and 6 included and you take the nth CellType from the enum. This will be the chosen cell.

<h4>Prototype</h4>

```csharp
    public void FillRandom() { }
```

<h4>Code Example</h4>

````csharp
using Your2DSandbox;

Simulation simulation = new Simulation(5, 5, 64);
simulation.Board.FillRandom();
simulation.DisplayBoard();
````

<h4>Output</h4>

````csharp
───v───  Paused  | Cell selected Rock
|SFBSR|
|BFBGG|
>BBFVV<
|GVFWR|
|WBVWG|
───^───
````



</details>

</details>

---

## Hard : Run the Simulation & Interfaces

<details><summary><b>Sim/Simulation.cs</b></summary>

<details><summary>Given Code</summary>
Same as previously, this method for handling input is just tedious so here it is.
It will be used later down the line when running the simulation.

```csharp
    // returns true when stopping the simulation
private bool HandleInput()
    {
        if (!Console.KeyAvailable) return false;
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        
        switch (keyInfo.Key)
        {
            case ConsoleKey.Escape:
                return true;
            case ConsoleKey.LeftArrow:
                if (_cursorW > 0) _cursorW--;
                break;
            case ConsoleKey.RightArrow:
                if (_cursorW < Board.Width - 1) _cursorW++;
                break;
            case ConsoleKey.UpArrow:
                if (_cursorH > 0) _cursorH--;
                break;
            case ConsoleKey.DownArrow:
                if (_cursorH < Board.Height - 1) _cursorH++;
                break;
            case ConsoleKey.Spacebar:
                Board.SetCell(_selectedCellType,_cursorH,_cursorW);
                break;
            case ConsoleKey.Backspace:
                Board.SetCell(null, _cursorH, _cursorW);
                break;
            case ConsoleKey.P:
                _pause = !_pause;
                break;
            case ConsoleKey.Enter:
                _pause = true;
                _step = true;
                break;
            case ConsoleKey.B:
                Board.FillRandom();
                break;
            case ConsoleKey.N:
                Board.FillBoard();
                break;
            case ConsoleKey.E:
                _selectedCellType = CellType.Rock;
                break;
            case ConsoleKey.R:
                _selectedCellType = CellType.Wood;
                break;
            case ConsoleKey.T:
                _selectedCellType = CellType.Sand;
                break;
            case ConsoleKey.Y:
                _selectedCellType = CellType.Water;
                break;
            case ConsoleKey.U:
                _selectedCellType = CellType.Fire;
                break;
            case ConsoleKey.I:
                _selectedCellType = CellType.Steam;
                break;
            case ConsoleKey.O:
                _selectedCellType = CellType.Glass;
                break;
        }
        return false;
    }
```

</details>

<details><summary>RunSimulation</summary>

Now let's implement a method to run the simulation.

In a loop it : 

-  Display the board.
-  Update the board if the simulation is not paused or step is true.
-  Handle the input using HandleInput(). If the method returns true exit the method immediately.
-  Wait *delayPerFrame* millisecond using System.Threading.Thread.Sleep()

<h4>Prototype</h4>

````csharp
public void RunSimulation(int delayPerFrame) { }
````

<h4>Code Example</h4>

````csharp
using Your2DSandbox;

Simulation s = new Simulation(6,15);
````

Although this method will not be tested, it can be used to test thoroughly.

</details>

</details>

Currently (if all is implemented correctly) the cells are only moving through the board.<br>
Let's make them interact with the use of interfaces!

> Warning! : The following two interfaces will be graded at the same time, so they both need to be implemented for the last push.


<details><summary><b>IUpdatable</b></summary>


You need now to create a interface :  IUpdatable.<br>
It will be use to update the cells through time.<br> For example a Fire do not last for ever, we need to extinguish at some time.


<details><summary>Cells/IUpdatable.cs</summary>

The interface will have one method to be implemented :

<h4>Prototype</h4>

````csharp
public void Update(Board b, int h, int w);
````

</details>

You need to add the interface for Steam and Fire Class.

<details><summary>Cells/ImplementedCells/Steam.cs</summary>

<h4> Property </h4>

Steam will need a new public property : 

- CondensationTimer of type int, with a public getter and private setter.

It must be set in the constructor at 50.

<h4> Update </h4>

For the implementation of the Update method, you must decrease CondensationTimer by 1. <br>
When CondensationTimer is below 1, put on the board a new water cell in its place.

</details>

<details><summary>Cells/ImplementedCells/Fire.cs</summary>

<h4> Property </h4>

Fire will need a new public property :

- Lifetime of type int, with a public getter and private setter.

It must be set in the constructor at 7.

<h4> Update </h4>

For the implementation of the Update method, you must decrease Lifetime by a random number between 0 and 1.<br>
When Lifetime is below 1, put on the board nothing in its place.

</details>

</details>

<details><summary><b>IBurnable</b></summary>

You need now to another create a interface :  IUpdatable.<br>
It will be use make the cell react to fire.<br> For example a Water in reaction to Fire will create Steam.

<details><summary>Cells/IBurnable.cs</summary>

The interface will have one method to be implemented :

It returns a bool to extinguish (or not) the fire that burned the cell.
<h4>Prototype</h4>

````csharp
public bool Burn(Board b, int h, int w);
````

</details>

You need to add the interface for Steam, Water, Sand, and Wood Class.

<details><summary>Cells/ImplementedCells/Steam.cs</summary>

<h4> Burn </h4>

For the implementation of the Burn method, reset the CondensationTimer to 50.
It should not extinguish fire ( return false); 

</details>

<details><summary>Cells/ImplementedCells/Water.cs</summary>

<h4> Burn </h4>

For the implementation of the Burn method, you put on the board a new steam cell in its place.
It should extinguish fire (return true);

</details>

<details><summary>Cells/ImplementedCells/Sand.cs</summary>

<h4> Burn </h4>

For the implementation of the Burn method, you put on the board a new glass cell in its place.
It should extinguish fire;

</details>

<details><summary>Cells/ImplementedCells/Wood.cs</summary>

<h4> Burn </h4>

For the implementation of the Burn method, you put on the board a new fire cell in its place.
It should not extinguish fire;

</details>
&nbsp;

<details><summary>Cells/ImplementedCells/Fire.cs</summary>

<h4> Update </h4>

You need to add a small portion of code in the Update method to trigger the fire.

Before what you already wrote in the function, you need to Trigger the Burn method on every adjacent cell that is burnable.
After that you need to extinguish the fire if one Burn returned true.<br>
And by extinguish I mean you put on the board nothing in its place.

</details>

</details>
&nbsp;

<details><summary><b>Sim/Board.cs</b></summary>


Now that we have implemented interfaces let's use them.<br>
You need to tweak a little bit the NextBoard() method.

When you iterate through cells, just before handling the movement of cells, call Update on cells that implements the IUpdatable interface.

</details>

<details><summary><b>Code Example</b></summary>

I will give a simple set up and the first 5 step to show case the implemented interactions.

````csharp
using Your2DSandbox;

Simulation simulation = new Simulation(3, 7, 32);
simulation.Board.FillRandom();
simulation.DisplayBoard();
````

<h4>1</h4>

````csharp
────v────  Paused  | Cell selected Rock
|BSRWFBS|
>BGRGBFR<
|WRWVBFR|
────^────
````

<h4>2</h4>

````csharp
────v────  Paused  | Cell selected Rock  
|BSRVSFF|
>BGRGFFR<
|WRVWF R|
────^────
````

<h4>3</h4>

````csharp
────v────  Paused  | Cell selected Rock  
|BSRSFFF|
>BGRGVFR<
|WRV V R|
────^────
````

<h4>4</h4>

````csharp
────v────  Paused  | Cell selected Rock  
|BSRVFGF|
>BGRGVFR<
|WRV   R|
────^────
````

<h4>5</h4>

````csharp
────v────  Paused  | Cell selected Rock  
|BSRVFGF|
>BGRGVFR<
|WRV   R|
────^────
````

</details>


&nbsp;
