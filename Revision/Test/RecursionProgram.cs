using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recursion
{
    public class RecursionProgram
    {
        public class PersonModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Code { get; set; }
            public int ParentId { get; set; }
        }

        public List<PersonModel> personList = new List<PersonModel>
        {
            new PersonModel { Id=1,Name = "Ganesh",Code=100,ParentId=0},
            new PersonModel { Id=2,Name = "Kanchan",Code=101,ParentId=1},
            new PersonModel { Id=3,Name = "Bibek",Code=102,ParentId=1},
            new PersonModel { Id=4,Name = "Suraj",Code=103,ParentId=2},
        };
        public Stack<PersonModel> personStack = new Stack<PersonModel>();
        public void GraphTraversal(int Id)
        {
            foreach (var item in personList)
            {
                //check if it is child
                //if item ko parent id is equal to Id sanga cha ani is unvisited
                if (item.ParentId == Id && (!personStack.Contains(item)))
                {
                    //visit the node
                    Console.WriteLine($"{item.Id}: {item.Name}, {item.Code}, {item.ParentId}");
                    //push into stack
                    personStack.Push(item);
                    //go in search of this item's child
                    GraphTraversal(item.Id);
                    //remove item from stack and go to before node
                    personStack.Pop();
                }
            }
        }
        public void MainFunction()
        {
            GraphTraversal(0);
        }
    }
}