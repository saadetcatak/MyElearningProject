using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class WatchCourse
    {
        public int WatchCourseID { get; set; }
        
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int VideoNumber { get; set; }

        public int VideoUrl { get; set; }
    }
}