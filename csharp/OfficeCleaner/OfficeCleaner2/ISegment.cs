using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OfficeCleaner2
{
    /// <summary>
    /// Common operations available from any segment.
    /// </summary>
    public interface ISegment
    {
        /// <summary>
        /// Returns a number of vertices on the segment 
        /// which have already been visited by otherSegment.
        /// </summary>
        /// <param name="otherSegment">Earlier segment completed by robot</param>
        /// <returns></returns>
        int GetOverlappingVerticesWith
            (ISegment otherSegment);

        /// <summary>
        /// The bottom Y-coordinate of a segment.
        /// </summary>
        int LowerY {get;}

        /// <summary>
        /// The top Y-coordinate of a segment.
        /// </summary>
        int UpperY {get;}

        /// <summary>
        /// The right side X-coordinate of a segment.
        /// </summary>
        int RightmostX { get; }

        /// <summary>
        /// The left side X-coordinate of a segment.
        /// </summary>
        int LeftmostX {get;}

        /// <summary>
        /// Sets coordinates of a segment newly completed by a robot.
        /// </summary>
        /// <param name="startingCoords">Starting coordinate of a segment.</param>
        /// <param name="dir">Direction of a segment.</param>
        /// <param name="numOfSteps">Number of steps completed by a robot.</param>
        void SetCoordinates(Coordinate startingCoords, Direction dir, int numOfSteps);

        /// <summary>
        /// Returns ending coordinate of a segment.
        /// </summary>
        /// <returns></returns>
        Coordinate GetEndingCoord();

        /// <summary>
        /// Removes all items from cache with overlapping vertices.
        /// Should be performed before a new segment is commenced by a robot.
        /// </summary>
        void ClearOverlappingVerticesCache();

        /// <summary>
        /// Returns a number of all vertices visited by a robot in a segment.
        /// </summary>
        /// <returns></returns>
        int GetNumberOfAllVertices();
    }
}
