﻿List<Point> SetPoints(){
    return new List<Point> {
        new Point{ pointName = "A", x = 0, y = 0 },
        new Point{ pointName = "B", x = 1, y = 1 },
        new Point{ pointName = "C", x = 2, y = 2 },
        new Point{ pointName = "D", x = 8, y = 1 },
        new Point{ pointName = "E", x = 5, y = 3 },
        new Point{ pointName = "F", x = 7, y = 9 }
    };
}



List<Point> pointList = new List<Point>() {
    new Point { pointName = "A", x = 1, y=1},
    new Point { pointName = "B", x = 5, y=8},
    new Point { pointName = "C", x = 7, y=12},
    new Point { pointName = "D", x = 2, y=9},
    new Point { pointName = "E", x = 7, y=2},
    new Point { pointName = "F", x = 1, y=12},
    new Point { pointName = "G", x = 4, y=2}
};

//A(1,1) B(5,8) C(7,12) D(2,9) E(7,2) F(1,12) G(4,2).

TSP problem = new TSP(SetPoints(), "B");

problem.Start();
Console.WriteLine(problem.GetSequenceOfPoints());
Console.WriteLine(problem.GetDistance());
foreach (Point point in problem.GetSequenceOfPointsList()) {
    Console.Write(" -> " + point.ToString());
}







public class TSP {
    private List<Point> pointsList;
    private Point startPoint;
    private string sequenceOfPoints;
    private List<Point> sequenceOfPointsList = new List<Point>();
    private float distance;

    public TSP(List<Point> pointsList, Point startPoint) {
        this.pointsList = pointsList;
        this.startPoint = startPoint;
        sequenceOfPoints += startPoint.pointName;
        sequenceOfPointsList.Add(startPoint);
    }
    public TSP(List<Point> pointsList, string startPointName) {
        this.pointsList = pointsList;
        var tempList = pointsList.Where(x => x.pointName == startPointName).ToArray();
        if (tempList != null)
            startPoint = tempList[0];
        sequenceOfPoints += startPointName;
        sequenceOfPointsList.Add(startPoint);
    }

    public void Start() {
        FindShortestDistance(pointsList, startPoint);
    }


    private float LengthBetweenTwo(Point point_1, Point point_2) {
        return (float)Math.Sqrt(Math.Pow((point_1.x - point_2.x), 2) + Math.Pow((point_1.y - point_2.y), 2));
    }

    private void FindShortestDistance(List<Point> currentListOfPoints, Point currentPoint) {
        float shortestDistance = float.MaxValue;
        Point nextPoint = new Point();
        currentListOfPoints.Remove(currentPoint);
        if (currentListOfPoints.Count() > 1) {
            for (int i = 0; i < currentListOfPoints.Count() - 1; i++) {
                float lengthBetweenTwo = LengthBetweenTwo(currentPoint, currentListOfPoints[i]);
                if (shortestDistance > lengthBetweenTwo) {
                    shortestDistance = lengthBetweenTwo;
                    nextPoint = currentListOfPoints[i];
                }
            }
        }
        else {
            shortestDistance = LengthBetweenTwo(currentPoint, currentListOfPoints[0]);
            TraveledDistance(shortestDistance);
            AddToSequenceOfPoints(currentListOfPoints[0].pointName);
            sequenceOfPointsList.Add(currentListOfPoints[0]);
            shortestDistance = LengthBetweenTwo(currentListOfPoints[0], startPoint);
            TraveledDistance(shortestDistance);
            AddToSequenceOfPoints(startPoint.pointName);
            sequenceOfPointsList.Add(startPoint);
            return;
        }
        TraveledDistance(shortestDistance);
        AddToSequenceOfPoints(nextPoint.pointName);
        sequenceOfPointsList.Add(nextPoint);
        FindShortestDistance(currentListOfPoints, nextPoint);
    }

    private void TraveledDistance(float length) {
        distance += length;
    }

    private void AddToSequenceOfPoints(string pointName) {
        sequenceOfPoints += " -> " + pointName;
    }

    public string GetSequenceOfPoints() {
        return sequenceOfPoints;
    }
    
    public List<Point> GetSequenceOfPointsList() {
        return sequenceOfPointsList;
    }

    public float GetDistance() {
        return distance;
    }
}


public struct Point {
    public string pointName;
    public int x;
    public int y;

    public override string ToString() {
        return $"{pointName}({x}, {y})";
    }
}