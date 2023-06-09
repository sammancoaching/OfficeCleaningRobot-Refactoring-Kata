using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner4
{
    public class RobotCleaner
    {
      private int m_xPos;
      private int m_yPos;
      private Hashtable ht_VisitedSpots;

      private void Init(int x, int y)
      {
        m_xPos = x;
        m_yPos = y;
        ht_VisitedSpots = new Hashtable();
        ht_VisitedSpots.Add(m_xPos.ToString() + "," + m_yPos.ToString(), "Visit");
      }

      public RobotCleaner()
      {
        Init(0,0);
      }

      public RobotCleaner(int x, int y)
      {
        Init(x, y);
      }

      public void Move(string direction, int steps)
      {
        int i;
        switch (direction.ToUpper())
        {
          case "N": // Move the robot North.
            for (i = 0; i < steps; i++)
            {
              m_yPos++;
              try
              {
                ht_VisitedSpots.Add(m_xPos.ToString() + "," + m_yPos.ToString(), "Visit");
              }
              catch (ArgumentException ae)
              {
              }
            }
            break;
          case "S": // Move the robot South.
            for (i = 0; i < steps; i++)
            {
              m_yPos--;
              try
              {
                ht_VisitedSpots.Add(m_xPos.ToString() + "," + m_yPos.ToString(), "Visit");
              }
              catch (ArgumentException ae)
              {
              }
            }
            break;
          case "E": //Move the robot East.
            for (i = 0; i < steps; i++)
            {
              m_xPos++;
              try
              {
                ht_VisitedSpots.Add(m_xPos.ToString() + "," + m_yPos.ToString(), "Visit");
              }
              catch (ArgumentException ae)
              {
              }
            }
            break;
          case "W": //Move the robot West.
            for (i = 0; i < steps; i++)
            {
              m_xPos--;
              try
              {
                ht_VisitedSpots.Add(m_xPos.ToString() + "," + m_yPos.ToString(), "Visit");
              }
              catch (ArgumentException ae)
              {
              }
            }
            break;
          default: // Error
            throw new Exception("Invalid direction passed to method Move: " + direction);
        }
      }

      public int VisitedSpots
      {
        get { return ht_VisitedSpots.Count; }
      }

      public void PrintVisitedSpots()
      {
        var result = "";
        foreach (DictionaryEntry spot in ht_VisitedSpots)
        {
          result += spot.ToString();
          result += "\n";
        }
        //Console.Out.Write(result);
      }
    }
}
