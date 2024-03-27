using System.Collections.Generic;

namespace OfficeCleaner10
{
	public class RobotCleaner
    {
		private int uniquePlacesVisited;
		private Point currentPosition;
		private Dictionary<int,LinkedList<LineSegment>>[] lineSegmentDictionary;
		private LinkedList<LineSegment> listOfLineSegments;
		
		// Create robot and put it on its start position
		public RobotCleaner(int startX, int startY)
		{
			currentPosition = new Point(startX, startY);
			uniquePlacesVisited = 1;
			
			// Create an array of two line-segment-dictionarys, segment along x goes in nr 0 and segments along y goes in nr 1
			lineSegmentDictionary = new Dictionary<int,LinkedList<LineSegment>>[2];
			lineSegmentDictionary[0] = new Dictionary<int,LinkedList<LineSegment>>();
			lineSegmentDictionary[1] = new Dictionary<int,LinkedList<LineSegment>>();
			
			// Add the start point to dictionary 0
			listOfLineSegments = new LinkedList<LineSegment>();
			listOfLineSegments.AddLast(new LineSegment(startY, startX, startX, 'x'));
			lineSegmentDictionary[0].Add(startY, listOfLineSegments);
		}
		
		// Return unique places Visited
		public long getUniquePlacesVisited()
		{
			return uniquePlacesVisited;
		}
		
		// visit 'int steps' steps in direction 'char direction'
		public void visit(int steps, char direction)
		{
			LineSegment lineSegment;
			
			if(direction == 'N') 
			{
				lineSegment = new LineSegment(currentPosition.x, currentPosition.y+1, currentPosition.y+steps, 'y');
				currentPosition = new Point(currentPosition.x, currentPosition.y+steps);
			}
			else if(direction == 'S')
			{
				lineSegment = new LineSegment(currentPosition.x, currentPosition.y-steps, currentPosition.y-1, 'y');
				currentPosition = new Point(currentPosition.x, currentPosition.y-steps);
			}
			else if(direction == 'E')
			{
				lineSegment = new LineSegment(currentPosition.y, currentPosition.x+1, currentPosition.x+steps, 'x');
				currentPosition = new Point(currentPosition.x+steps, currentPosition.y);
			}
			else
			{
				lineSegment = new LineSegment(currentPosition.y, currentPosition.x-steps, currentPosition.x-1, 'x');
				currentPosition = new Point(currentPosition.x-steps, currentPosition.y);
			}		
				
			if(!lineSegmentOverlaps(lineSegment))
				uniquePlacesVisited += steps - getNumberOfIntersections(lineSegment);
			else
			{
				VisitUniquePositions(lineSegment);
			}

			// Add line segment to one of two internal dictinarys
            LineSegment ls2 = lineSegment;
			int axis = ls2.alongAxis == 'x' ? 0 : 1;

			if(lineSegmentDictionary[axis].ContainsKey(ls2.value))
			{
				lineSegmentDictionary[axis][ls2.value].AddLast(ls2);
			}
			else
			{
				listOfLineSegments = new LinkedList<LineSegment>();
				listOfLineSegments.AddLast(ls2);
				lineSegmentDictionary[axis].Add(ls2.value, listOfLineSegments);
			}
		}

		private void VisitUniquePositions(LineSegment lineSegment)
		{
			// visit unique positions of the segment
			LineSegment ls = lineSegment;
			int steps1 = ls.max - ls.min + 1;
			Point pointToCheck;
		
			for(int i = 0; i < steps1; i++)
			{
				if(ls.alongAxis == 'x')
					pointToCheck = new Point(ls.min+i, ls.value);
				else
					pointToCheck = new Point(ls.value, ls.min+i);

				var Visited = IsPointAlreadyVisited(pointToCheck);

				if(!Visited)
					uniquePlacesVisited++;					
			}
		}

		private bool IsPointAlreadyVisited(Point pointToCheck)
		{
			// Check if 'Point p' is alredy Visited
			bool Visited = false;
			if (lineSegmentDictionary[0].ContainsKey(pointToCheck.y))
			{
				foreach(LineSegment ls1 in lineSegmentDictionary[0][pointToCheck.y])
				{
					if (pointToCheck.x >= ls1.min && pointToCheck.x <= ls1.max)
					{
						Visited = true;
						break;
					}
				}
			}
			if (lineSegmentDictionary[1].ContainsKey(pointToCheck.x))
			{
				foreach(LineSegment ls1 in lineSegmentDictionary[1][pointToCheck.x])
				{
					if(pointToCheck.y >= ls1.min && pointToCheck.y <= ls1.max)
					{
						Visited = true;
						break;
					}
				}
			}

			return Visited;
		}


		// Check if a line segment overlap any other segments, return true if so.
		private bool lineSegmentOverlaps(LineSegment ls)
		{
			int axis = ls.alongAxis == 'x' ? 0 : 1;

			if(lineSegmentDictionary[axis].ContainsKey(ls.value))
			{
				foreach(LineSegment lss in lineSegmentDictionary[axis][ls.value])
				{
					if(!(ls.min > lss.max || ls.max < lss.min))
						return true;
				}
				return false;
			}
			else
				return false;		
		}
		
		// Return the number of unique intersections with line segment
		private int getNumberOfIntersections(LineSegment ls)
		{
			int axis = ls.alongAxis == 'x' ? 1 : 0;
			int intersections = 0;
			Dictionary<int, LinkedList<LineSegment>>.KeyCollection keyCollection = lineSegmentDictionary[axis].Keys;
			
			foreach (int key in keyCollection)
			{
				if(key >= ls.min && key <= ls.max)
				{
					foreach(LineSegment lss in lineSegmentDictionary[axis][key])
					{
						if(ls.value >= lss.min && ls.value <= lss.max){
							intersections++;
							break;
						}
					}
				}	
			}
						
			return intersections;
		}
    }
}
