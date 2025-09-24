using Microsoft.JavaScript.NodeApi;
using System.Collections.Generic;

namespace ClassLibrary.Entities
{
    [JSExport]
    public struct Test
    {
        public Test(int id, string name, string type, List<Test> children)
        {
            Id = id;
            Name = name;
            Type = type;
            Children = children;
        }
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; }
        public List<Test> Children { get; set; } = new();
    }
}
