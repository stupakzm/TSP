# ***TSP (Traveling Salesman Problem) Solver***
This project is a C# implementation of a solver for the Traveling Salesman Problem (TSP). The TSP is a well-known computational problem where the objective is to find the shortest possible route that visits a set of points and returns to the starting point.

***Key Features***
**TSP Class Encapsulation:** 
The project includes a dedicated TSP class that encapsulates the logic for solving the TSP.
**Initialization with Points and Starting Point:** The TSP class allows initialization with a list of points, representing the locations to be visited. Points are defined using the Point struct, which includes a name, x-coordinate, and y-coordinate. The class can be initialized with a specific starting point or a starting point name.
**Recursive Algorithm for Shortest Distance:** The TSP class utilizes a recursive algorithm to find the shortest distance among the given points. It iterates through the list of points, comparing distances from the current point to other available points. The algorithm selects the point with the shortest distance and continues recursively until all points are visited.
**Sequence of Points Visited:** The TSP class keeps track of the sequence of points visited during the shortest route calculation. The sequence of points visited can be retrieved, providing the order in which the points are visited.
**Total Distance Traveled:** The TSP class calculates and maintains the total distance traveled during the shortest route. The cumulative distance traveled can be retrieved.

**Usage**
**To use the TSP solver, follow these steps:**
Create a list of points to be visited in the TSP. Each point should be defined with a name, x-coordinate, and y-coordinate.
Initialize an instance of the TSP class, providing the list of points and the starting point or starting point name.
Call the Start method to begin the calculation of the shortest route.
Retrieve the sequence of points visited using the GetSequenceOfPoints method to get the ordered list of visited points.
Retrieve the total distance traveled using the GetDistance method.

Feel free to use this TSP solver in your projects to efficiently solve the Traveling Salesman Problem!
