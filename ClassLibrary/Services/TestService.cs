using ClassLibrary.Entities;
using Microsoft.JavaScript.NodeApi;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ClassLibrary.Services
{
    [JSExport]
    public class TestService
    {
        private static readonly Random _rnd = new();

        private readonly List<Test> _items = new()
    {
        new Test { Name = "Example 1", Type ="A", Children = MakeChildren("1") },
        new Test { Name = "Example 2", Type = "B", Children = MakeChildren("2") },
        new Test { Name = "Example 3", Type = "C", Children = MakeChildren("3") },
        new Test { Name = "Example 4", Type = "D", Children = MakeChildren("4") },
    };

        private static List<Test> MakeChildren(string parentMarker)
        {
            var count = _rnd.Next(0, 6);
            var list = new List<Test>(count);
            for (int j = 1; j <= count; j++)
            {
                list.Add(new Test
                {
                    Name = $"Item {parentMarker}.{j}",
                    Type = _rnd.Next(0, 4).ToString(),
                });
            }
            return list;
        }

        public List<Test> GetAll() => _items;

        public Test Create(int id, string name, string type, List<Test> children)
        {
            var t = new Test(id, name, type, children);
            _items.Add(t);
            return t;
        }

        public Test GetTest(string name) =>
            _items.FirstOrDefault(x => x.Name == name);
    }

}
