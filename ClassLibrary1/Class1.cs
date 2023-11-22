using System;

namespace ClassLibrary1
{
    public class student { }
    public AllUser student = new AllUser(4);
    public class AllUser
    {
        public int CoursProg;
        public int Diplom;
        public int Pz;
        public int Lb;
        public string Result;
        public AllUser(int TeachCourseProg) { CoursProg = TeachCourseProg; }
        public void Print()
        {
            Console.WriteLine(CoursProg);
        }
        public int HardIs()
        {
            var Result = (CoursProg + Diplom);
            return Result;
        }
        
       
  
    }
   
}
