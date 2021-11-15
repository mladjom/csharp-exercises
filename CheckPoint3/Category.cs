using System;
using System.Collections.Generic;


namespace CheckPoint3
{
    public class Category
    {
        public Category()
        {
        }
        public Category(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
