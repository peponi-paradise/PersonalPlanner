using System;
using System.Collections.Generic;

namespace PersonalPlanner.Define
{
    public class Task
    {
        public int ID { get; set; }

        public int ParentID { get; set; } = 0;

        public string Name { get; set; } = "New Item";

        public DateTime StartDate { get; set; } = DateTime.Today;

        public DateTime FinishDate { get; set; } = DateTime.Today.AddDays(1);

        public double Progress { get; set; } = 0;

        public string Responsibility { get; set; } = "None";
    }

    public class Dependency
    {
        public int PredecessorID { get; set; }

        public int SuccessorID { get; set; }

        public DevExpress.XtraGantt.DependencyType DependencyType { get; set; }
        public TimeSpan TimeLag { get; set; } = TimeSpan.Zero;
    }

    public class GanttDefine
    {
        public string Name { get; set; }
        public Color Color { get; set; } = new Color() { R = 255, G = 255, B = 255, A = 0 };
        public List<Task> Task { get; set; } = new List<Task>();
        public List<Dependency> Dependency { get; set; } = new List<Dependency>();
    }
}