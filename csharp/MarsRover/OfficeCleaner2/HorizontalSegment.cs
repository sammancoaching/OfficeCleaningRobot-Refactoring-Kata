using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OfficeCleaner2
{
    /// <summary>
    /// Represents a horizontal segment along West/East direction.
    /// </summary>
    public struct HorizontalSegment:ISegment
    {
        //the starting coordinates for a segment
        private Coordinate startingCoords;
        //the ending coordinates for a segment
        private Coordinate endingCoords;
        private Hashtable overlappingVerticesTable;

        public int LowerY
        {
            get
            {
                if (startingCoords.Y < endingCoords.Y)
                    return startingCoords.Y;
                else
                    return endingCoords.Y;
            }
        }

        public int UpperY
        {
            get
            {
                if (startingCoords.Y > endingCoords.Y)
                    return startingCoords.Y;
                else
                    return endingCoords.Y;
            }
        }

        public int RightmostX
        {
            get
            {
                if (startingCoords.X > endingCoords.X)
                    return startingCoords.X;
                else
                    return endingCoords.X;
            }
        }

        public int LeftmostX
        {
            get
            {
                if (startingCoords.X < endingCoords.X)
                    return startingCoords.X;
                else
                    return endingCoords.X;
            }
        }

        public void SetCoordinates(Coordinate start, Direction dir, int numOfSteps)
        {
            this.startingCoords = start;
            //instantiate a new hash table that would contain overlapping vertices
            overlappingVerticesTable = new Hashtable();
            //determine ending coordinates for the segment
            switch (dir)
            {
                case Direction.West:
                    endingCoords =
                    new Coordinate(start.X - numOfSteps, start.Y);
                    break;
                case Direction.East:
                    endingCoords =
                    new Coordinate(start.X + numOfSteps, start.Y);
                    break;
            }
        }

        public Coordinate GetEndingCoord()
        {
            return endingCoords;
        }

        public int GetOverlappingVerticesWith(ISegment otherSegment)
        {
            int overlappingVertices = 0;

            if (otherSegment is VerticalSegment)    
                //otherSegment is vertical
            {
                if (otherSegment.RightmostX >= this.LeftmostX &&
                    otherSegment.RightmostX <= this.RightmostX) //otherSegment can take either right or left X, does not matter: the segment is vertical
                    //otherSegment is on the crossing with currentSegment
                {
                    if (this.LowerY >= otherSegment.LowerY &&
                        this.LowerY <= otherSegment.UpperY) 
                        //otherSegment crosses currentSegment
                    {
                        if (!overlappingVerticesTable.ContainsKey(otherSegment.RightmostX))
                        {
                            overlappingVertices++;
                            overlappingVerticesTable.Add
                                (otherSegment.RightmostX,this.LowerY);
                        }
                    }
                }
            }
            else if (otherSegment is HorizontalSegment) 
                //otherSegment is horizontal
            {
                if(this.LowerY==otherSegment.LowerY)    
                    //currentSegment and otherSegment lie on the same horizontal line
                {
                    if (this.LeftmostX > otherSegment.RightmostX)   
                        //otherSegment is to the left of currentSegment
                        //it overlaps none of the vertices for currentSegment
                        return 0;
                    if (this.RightmostX < otherSegment.LeftmostX)
                        //otherSegment is to the right of currentSegment
                        //it overlaps  none of the vertices for currentSegment
                        return 0;
                    if (this.LeftmostX >= otherSegment.LeftmostX &&
                        this.RightmostX <= otherSegment.RightmostX) 
                        //otherSegment completely overlaps currentSegment
                        //indicate that all currentSegment vertices are overlapped by otherSegment
                    {
                        return GetNumberOfAllVertices();
                    }

                    if (this.LeftmostX >= otherSegment.LeftmostX &&
                        this.LeftmostX <= otherSegment.RightmostX)  
                        //otherSegment overlaps partly from the left
                    {
                        for (int i = this.LeftmostX; i <= otherSegment.RightmostX; i++)
                        {
                            if (!overlappingVerticesTable.ContainsKey(i))
                            {
                                overlappingVertices++;
                                overlappingVerticesTable.Add
                                    (i,this.LowerY);
                            }
                        }
                        return overlappingVertices;
                    }

                    if (this.RightmostX >= otherSegment.LeftmostX &&
                        this.RightmostX <= otherSegment.RightmostX)   
                        //otherSegment overlaps from the right
                    {
                        for (int i = this.RightmostX; i >= otherSegment.LeftmostX; i--)
                        {
                            if (!overlappingVerticesTable.ContainsKey(i))
                            {
                                overlappingVertices++;
                                overlappingVerticesTable.Add
                                    (i,this.LowerY);
                            }
                        }
                        return overlappingVertices;
                    }

                    //for all other cases
                    for (int i = otherSegment.LeftmostX; i <= otherSegment.RightmostX; i++)
                    {
                        if (i <= this.RightmostX && i >= this.LeftmostX)    //a vertice lies withing currentSegment
                        {
                            if (!overlappingVerticesTable.ContainsKey(i))
                            {
                                overlappingVertices++;
                                overlappingVerticesTable.Add
                                    (i,this.LowerY);
                            }
                        }
                    }
                }
            }

            return overlappingVertices;
        }

        public void ClearOverlappingVerticesCache()
        {
            overlappingVerticesTable = null;
        }

        public int GetNumberOfAllVertices()
        {
            return this.RightmostX - this.LeftmostX + 1;
        }
    }
}
