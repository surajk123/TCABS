    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Class1
    {
          static string pp, dy,de,te,ass;
          public static string pickup
         {
              get
             {
                  return pp;
             }
              set
             {
                 pp = value;
             }
         }
          public static string address
          {
              get
              {
                  return ass;
              }
              set
              {
                  ass = value;
              }
          }
          public static string dropby
         {
              get
             {
                return dy;
             }
              set
             {
                 dy= value;
             }
         }
          public static string date
          {
              get
              {
                  return de;
              }
              set
              {
                  de = value;
              }
          }
          public static string time
          {
              get
              {
                  return te;
              }
              set
              {
                  te = value;
              }
          }
   
    }
}
