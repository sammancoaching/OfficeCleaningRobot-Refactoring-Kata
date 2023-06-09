using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OfficeCleaner2
{
    /// <summary>
    /// Represents a vertical segment along North/South direction.
    /// </summary>
    public struct VerticalSegment:ISegment
    {
        //the starting coordinates for a segment
        private Coordinate startingCoords;
        //the ending coordinates for a segment
        private Coordinate endingCoords;
        private Hashtable overlappingVerticesTable;

        public int LowerY
        {
            get {
                if (startingCoords.Y < endingCoords.Y)
                    return startingCoords.Y;
                else
                    return endingCoords.Y;
            }
        }

        public int UpperY
        {
            get {
                if (startingCoords.Y > endingCoords.Y)
                    return startingCoords.Y;
                else
                    return endingCoords.Y;
            }
        }

        public int RightmostX
        {
            get {
                if (startingCoords.X > endingCoords.X)
                    return startingCoords.X;
                else
                    return endingCoords.X;
            }
        }

        public int LeftmostX
        {
            get {
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
            //set ending coordinates for the segment
            switch (dir)
            {
                case Direction.North:
                    endingCoords =
                    new Coordinate(start.X, start.Y + numOfSteps);
                    break;
                case Direction.South:
                    endingCoords =
                    new Coordinate(start.X, start.Y - numOfSteps);
                    break;
            }
        }

        public Coordinate GetEndingCoord()
        {
            return endingCoords;
        }

        public int GetOverlappingVerticesWith
            (ISegment otherSegment)
        {
            int overlappingVertices = 0;

            if (otherSegment is HorizontalSegment)   //otherSegment is horizontal
            {
                if (otherSegment.LowerY >= this.LowerY &&
                    otherSegment.LowerY <= this.UpperY)   //otherSegment is on the crossing with currentSegment
                {
                    if (this.RightmostX >= otherSegment.LeftmostX &&
                        this.RightmostX <= otherSegment.RightmostX)   //otherSegment crosses currentSegment
                    {
                        if (!overlappingVerticesTable.ContainsKey(otherSegment.LowerY))
                        {
                            overlappingVertices++;
                            overlappingVerticesTable.Add
                               (otherSegment.LowerY, this.RightmostX);
                        }
                    }
                }
            }
            else if (otherSegment is VerticalSegment)    //otherSegment is vertical
            {
                if (this.LeftmostX == otherSegment.LeftmostX)
                //currentSegment and otherSegment lie on the same vertical line
                //find if they overlap and by how many vertices
                {
                    if (this.LowerY > otherSegment.UpperY)    //otherSegment is completely below currentSegment
                        return 0;   //no vertices overlap
                    if (this.UpperY < otherSegment.LowerY)    //otherSegment is completely above currentSegment
                        return 0;   //no vertices overlap

                    if (this.UpperY <= otherSegment.UpperY &&
                        this.LowerY >= otherSegment.LowerY)   //otherSegment completely overlaps currentSegment
                    {
                        return GetNumberOfAllVertices();
                    }

                    if (this.UpperY >= otherSegment.LowerY &&
                        this.UpperY <= otherSegment.UpperY) //otherSegment overlaps from above
                    {
                        for (int j = this.UpperY; j >= otherSegment.LowerY; j--)
                        {
                            if (!overlappingVerticesTable.ContainsKey(j))
                            {
                                overlappingVertices++;
                                overlappingVerticesTable.Add
                                   (j, this.RightmostX);
                            }
                        }
                        return overlappingVertices;
                    }

                    if (this.LowerY >= otherSegment.LowerY &&
                        this.LowerY <= otherSegment.UpperY)   //otherSegment overlaps from below
                    {
                        for (int j = this.LowerY; j <= otherSegment.UpperY; j++)
                        {
                            if (!overlappingVerticesTable.ContainsKey(j))
                            {
                                overlappingVertices++;
                                overlappingVerticesTable.Add
                                   (j, this.RightmostX);
                            }
                        }
                        return overlappingVertices;
                    }

                    //for all other cases
                    for (int vertex = otherSegment.LowerY; vertex <= otherSegment.UpperY; vertex++)
                    {
                        if (vertex <= this.UpperY && vertex >= this.LowerY)
                        {
                            if (!overlappingVerticesTable.ContainsKey(vertex))
                            {
                                overlappingVertices++;
                                overlappingVerticesTable.Add
                                   (vertex, this.RightmostX);
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
            return this.UpperY - this.LowerY + 1;
        }
    }
}
