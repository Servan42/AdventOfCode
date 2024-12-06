using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day05
{
    public class Updates
    {
        public List<int> PageNumbers { get; set; } = new();

        public static Updates Build(string line)
        {
            var result = new Updates();
            result.PageNumbers = line.Split(',').Select(int.Parse).ToList();
            Assert.That(result.PageNumbers.Count, Is.EqualTo(result.PageNumbers.Distinct().Count()), "page number not distinct");
            return result;
        }

        public bool AreInTheRightOrder(PrecedenceGraph precedenceGraph)
        {
            foreach (var pageNumber in PageNumbers)
            {
                var parents = precedenceGraph.GetDistinctParent(pageNumber);
                foreach (var pageNumberAfter in PageNumbers.SkipWhile(p => p != pageNumber).Skip(1))
                {
                    if (parents.Contains(pageNumberAfter))
                        return false;
                }

                var children = precedenceGraph.GetDistinctChildren(pageNumber);
                foreach (var pageNumberBefore in PageNumbers.TakeWhile(p => p != pageNumber))
                {
                    if (children.Contains(pageNumberBefore))
                        return false;
                }
            }
            return true;
        }

        public int GetMiddleNumber()
        {
            return PageNumbers[PageNumbers.Count / 2];
        }

        public Updates ReOrder(PrecedenceGraph precedenceGraph)
        {
            LinkedList<int> newOrder = new();
            newOrder.AddLast(this.PageNumbers[0]);

            foreach (var pageNumberToSort in PageNumbers.Skip(1))
            {
                LinkedListNode<int>? iterator = newOrder.First;
                var children = precedenceGraph.GetDistinctChildren(pageNumberToSort);
                while (iterator != null)
                {
                    if (children.Contains(iterator.Value))
                        break;

                    iterator = iterator.Next;
                }

                if (iterator == null)
                    newOrder.AddLast(pageNumberToSort);
                else
                    newOrder.AddBefore(iterator, pageNumberToSort);
            }

            this.PageNumbers = new List<int>(newOrder);
            return this;
        }
    }
}
