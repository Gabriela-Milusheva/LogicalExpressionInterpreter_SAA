# 👩‍💻 Logical Expression Interpreter 
<p align="center">
  <img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/logo.png" alt="GitHub Logo" width="100">
</p>

## -Synthesis and Analysis of Algorithms coursework

The Logical Expression Interpreter is an application designed to handle logical functions, allowing users to create, solve, analyze, and visualize logical expressions and truth tables. The program is implemented in C# language with a Windows Forms graphical user interface.

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/all.jpg" alt="All">

**_Note:_** The KeyboardForm is designed to make the application easier to work with for the user, but its functionality is still a work in progress. 🔜


All commands info tooltip:

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/info_toolTip.jpg" alt="Info">


## 🗺️ Content
1. [Adding and removing logical functions // DEFINE & REMOVE Commands](#define)
2. [Saving and reading functions from a file](#file)
3. [Solving a function for given parameters](#solve)
4. [Creating a truth table for a logic function](#all)
5. [Finding a logical function by its truth table](#find)
6. [Function's binary tree visualization](#visualize)


## 📝 1. Adding and removing logical functions <a name="define"></a>

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/define.jpg" alt="Define">

### - DEFINE Command

The DEFINE command creates and stores a logical function with the input expression for future evaluation.

_**Example:**_ DEFINE funcX(a,b): a&b

_**Example:**_ DEFINE funcY(a,b,c): funcX(a,b)|!c

**_Note:_** All input must be in the given format. The letter case doesn't matter. The spaces between parts don't matter.

Parts:

- DEFINE - command name;
  
- funcX - name of the function;
  
- (a,b, ....) - order of the function's arguments;
  
- a&b - logical expression (function body);
  
- &,|,! - logical operators;
  
- a,b,... operands


### - REMOVE Command

The REMOVE command removes the function with the input name.

_**Example:**_ REMOVE funcX


## 💾 2. Saving and reading functions from a file <a name="file"></a>

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/file_menu.jpg" alt="File">

From the File menu we can:

- create a new file (File -> New)

- open an existing text file with functions (File -> Open)

- save the defined functions in a text file (File -> Save Functions)

- store the binary tree image of the function (File -> Save Binary Tree)


## 🧮 3. Solving a function for given parameters <a name="solve"></a>

### - SOLVE Command

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/solve.jpg" alt="Solve">

The SOLVE command allows the user to solve a chosen defined logic function with boolean values (0 or 1). The algorithm first converts the function's expression notation from infix to postfix (Reverse Polish notation) and then solves the postfix expression. 

_**Example:**_ SOLVE funcX(0,1)


## 🏗️ 4. Creating a truth table for a logic function <a name="all"></a>

### - ALL Command

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/truthTable.jpg" alt="TruthTable">

The ALL command creates a Truth Table for a chosen defined logic function's expression

_**Example:**_ ALL funcX


## 🔍 5. Finding a logical function by its truth table <a name="find"></a>

### - FIND Command

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/find_function.jpg" alt="Find">

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/found_function.jpg" alt="Found">

The FIND command takes a given truth table or a path to a text file with a truth table and uses an Evolutionary algorithm to find an expression (defined or undefined) that fits the table. If the given truth table matches with any of the already defined functions, it finds it, otherwise it constructs an expression on the given truth table and defines it.

_**Example:**_ FIND (+ a path to a file with a truth table)

_**Example:**_ 

FIND 

0,0,0:0;

0,0,1:0;

0,1,0:0;

0,1,1:0;

1,0,0:0;

1,0,1:0;

1,1,0:0;

1,1,1:1


## 🖼 6. Function's binary tree visualization <a name="visualize"></a>

### - VISUALIZE Command

<img src="https://github.com/Gabriela-Milusheva/LogicalExpressionInterpreter_SAA/blob/master/SAA/Resources/treeForm.jpg" alt="Visualize">

The VISUALIZE command displays the binary tree of a defined function's expression to the TreeForm.

_**Example:**_ VISUALIZE funcX
