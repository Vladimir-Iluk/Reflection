using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ClassInfoAttribute : Attribute
    {
        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public string[] Reviewers { get; set; }

        public ClassInfoAttribute(string author, int revision, string description, params string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }
    }

}
