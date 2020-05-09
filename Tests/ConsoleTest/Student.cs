using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    interface IEntity
    {
        int Id { get; set; }
    }

    internal class Student : IComparable<Student>, IEquatable<Student>, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }
        public int GroupID { get; set; }

        public List<int> Ratings { get; set; } = new List<int>();
        
        public double AverageRating
        {
            get
            {
                var result = 0;
                foreach (var rating in Ratings)
                {
                    result += rating;
                }

                if (Ratings.Count != 0)
                    return result / Ratings.Count;

                return 0;
            }
        }

        public int CompareTo(Student other)
        {
            var current_average_rating = AverageRating;
            var other_average_rating = other.AverageRating;

            if(Math.Abs(current_average_rating - other_average_rating) < 0.001)
            {
                return 0;
            }
            if(current_average_rating > other_average_rating)
            {
                return +1;
            }
            else
            {
                return -1;
            }
        }

        public bool Equals(Student other)
        {
            if (other == null) return false;

            return Name == other.Name && Surname == other.Surname && Patronimyc == other.Patronimyc;

            return false;
        }

        public override string ToString() => $"[{Id}]:{Surname} {Name} {Patronimyc}";
    }
}
